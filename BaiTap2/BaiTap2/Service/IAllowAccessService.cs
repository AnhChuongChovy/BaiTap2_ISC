using BaiTap2.Models;

namespace BaiTap2.Service
{
    public interface IAllowAccessService
    {
        Task<IEnumerable<AllowAccess>> GetAllPermissions();
        Task<AllowAccess?> GetPermissionById(int id);
        Task<AllowAccess> CreatePermission(AllowAccess allowAccess);
        Task<AllowAccess?> UpdatePermission(int id, AllowAccess allowAccess);
        Task<bool> DeletePermission(int id);
    }
}
