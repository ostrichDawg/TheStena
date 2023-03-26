namespace TheStena.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public byte[] PasswordHash { get; set; }
        public DateTime CreatedDate { get; set; }        
    }

    public class UserDTO
    {
        public string? Name { get; set; }
        public DateTime CreationDate { get; set; }
    }

    public class UserLoginData
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
