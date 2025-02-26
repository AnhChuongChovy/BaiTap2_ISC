namespace BaiTap2.Models
{
    public class AllowAccess
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string TableName { get; set; } = string.Empty;
        public string AccessProperties { get; set; } = string.Empty; 

        // Liên kết với Role
        public Role? Role { get; set; }
    }

    public class AllowAccessDTO
    {
        public int RoleId { get; set; }
        public string TableName { get; set; } = string.Empty;
        public string AccessProperties { get; set; } = string.Empty;
    }
}
