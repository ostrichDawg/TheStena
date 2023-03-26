using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Cryptography;
using TheStena.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.OpenApi.Models;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

var securityScheme = new OpenApiSecurityScheme()
{
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey,
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = "JWT auth",
};

var securityReq = new OpenApiSecurityRequirement()
                {
                    {
                     new OpenApiSecurityScheme
                     {
                     Reference = new OpenApiReference
                     {
                     Type = ReferenceType.SecurityScheme,
                     Id = "Bearer"
                     }
                     },
                     new string[] {}
                    }
                };

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("Bearer", securityScheme);
    opt.AddSecurityRequirement(securityReq);

});
builder.Services.AddDbContext<StenaDBContext>(options =>
                            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateIssuerSigningKey = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/register", [AllowAnonymous] async (UserLoginData userLD, StenaDBContext db) =>
{
    User user = new User()
    {
        Name = userLD.Name,
        PasswordHash = MD5.HashData(Encoding.UTF8.GetBytes(userLD.Password)),
        CreatedDate = DateTime.Now,
        Role = "OP"
    };

    await db.Users.AddAsync(user);
    await db.SaveChangesAsync();

    return Results.Ok();
});

app.MapPost("/login", [AllowAnonymous] async (UserLoginData userLD, StenaDBContext db) =>
{
    var user = await db.Users.FirstOrDefaultAsync(u => u.Name == userLD.Name);
    if (user == null)
        return Results.Unauthorized();

    if (!user.PasswordHash.SequenceEqual(MD5.HashData(Encoding.UTF8.GetBytes(userLD.Password))))
        return Results.Unauthorized();

    List<Claim> claims = new List<Claim>()
    {
        new Claim(ClaimTypes.Name, user.Name),
        new Claim(ClaimTypes.Role, user.Role)
    };

    var issuer = builder.Configuration["Jwt:Issuer"];
    var audience = builder.Configuration["Jwt:Audience"];
    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]));
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    var token = new JwtSecurityToken(issuer: issuer,
                                     audience: audience,
                                     claims: claims,
                                     expires: DateTime.Now.AddDays(1),
                                     signingCredentials: credentials);

    var stringToken = new JwtSecurityTokenHandler().WriteToken(token);

    return Results.Ok(stringToken);
});

app.MapGet("/users", [Authorize] async (StenaDBContext db) =>
{
    var usersList = await db.Users.ToListAsync();

    if (usersList == null)
        return Results.NotFound();

    var usersDTO = from user in usersList
                   select new UserDTO()
                   {
                       Name = user.Name,
                       CreationDate = user.CreatedDate
                   };

    return Results.Ok(usersDTO);
});

app.MapGet("/users/{name}", [Authorize] async (string name, StenaDBContext db) =>
{
    //await db.Users.FindAsync(userId)
    //    is User user ? Results.Ok(user) : Results.NotFound()
    var user = await db.Users.FirstOrDefaultAsync(u => u.Name == name);

    if (user == null)
        return Results.NotFound();

    UserDTO userDTO = new UserDTO()
    {
        Name = user.Name,
        CreationDate = user.CreatedDate
    };

    return Results.Ok(userDTO);
});

app.MapPut("/profile/configure", [Authorize] async (StenaDBContext db, UserLoginData inputUser, HttpContext httpContext) =>
{
    var userName = httpContext.User.FindFirstValue(ClaimTypes.Name);
    if (userName == null)
        return Results.Unauthorized();

    var user = await db.Users.FirstOrDefaultAsync(u => u.Name == userName);
    if (user == null)
        return Results.Unauthorized();

    user.Name = inputUser.Name;
    user.PasswordHash = MD5.HashData(Encoding.UTF8.GetBytes(inputUser.Password));

    await db.SaveChangesAsync();

    return Results.Ok();
});

app.MapDelete("/profile/delete", [Authorize] async (StenaDBContext db, HttpContext httpContext) =>
{
    string? userName = httpContext.User.FindFirstValue(ClaimTypes.Name);
    if (userName == null)
        return Results.Unauthorized();

    var user = await db.Users.FirstOrDefaultAsync(u => u.Name == userName);
    if (user == null)
        return Results.Unauthorized();

    db.Users.Remove(user);
    await db.SaveChangesAsync();

    return Results.Ok();
});

app.MapDelete("/profile/delete/{id}", [Authorize(Roles = "admin")] async (StenaDBContext db,
    HttpContext httpContext, int id) =>
{
    var user = await db.Users.FindAsync(id);
    if (user == null)
        return Results.NotFound();

    db.Users.Remove(user);
    await db.SaveChangesAsync();

    return Results.Ok();
});

app.MapGet("/stena", [AllowAnonymous] async (StenaDBContext db) =>
{
    var posts = await db.Posts.Include(p => p.Author).Include(p => p.Comments).ToListAsync();

    return Results.Ok(posts);
});

app.MapGet("/users/{name}/posts", [AllowAnonymous] async (StenaDBContext db, string name) =>
{
    var user = await db.Users.Where(u => u.Name == name).FirstOrDefaultAsync();
    if (user == null)
        return Results.NotFound();

    var posts = await db.Posts.Where(p => p.AuthorId == user.Id).ToListAsync();

    return Results.Ok(posts);
});

app.MapPut("/posts/{id}", [Authorize] async (int id, CommentDTO comment, StenaDBContext db, HttpContext httpContext) =>
{
    var post = await db.Posts.FindAsync(id);
    if (post == null)
        return Results.NotFound();

    var username = httpContext.User.FindFirstValue(ClaimTypes.Name);
    if (username == null)
        return Results.Unauthorized();

    var user = await db.Users.FirstOrDefaultAsync(u => u.Name == username);
    if (user == null)
        return Results.Unauthorized();

    Comment newComment = new Comment()
    {
        Text = comment.Text,
        AurhtorId = user.Id,
        PostId = id
    };

    await db.Comments.AddAsync(newComment);
    await db.SaveChangesAsync();

    return Results.Ok(comment);
});

app.UseAuthentication();
app.UseAuthorization();
app.Run();