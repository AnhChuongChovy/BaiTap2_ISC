namespace BaiTap2.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        // Thiết lập quan hệ 1-1 với User
        public User? User { get; set; }
    }
    public class RoleDTO
    {
        public string RoleName { get; set; } = string.Empty;
    }
}
