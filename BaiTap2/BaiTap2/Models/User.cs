using System.Data;
using System.Text.Json.Serialization;

namespace BaiTap2.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public int RoleId { get; set; }

        // Liên kết với Role 1-1
        [JsonIgnore]
        public Role? Role { get; set; }
    }

    public class UserDTO
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public int RoleId { get; set; }
    }
}
