namespace Asp.NetCoreMvc.CookieAuth.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; } = null;
        public string Username { get; set; }
        public bool Locked { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? ProfileImageFileName { get; set; } = "no-image.jpg";
        public string Role { get; set; } = "user";
    }
}
