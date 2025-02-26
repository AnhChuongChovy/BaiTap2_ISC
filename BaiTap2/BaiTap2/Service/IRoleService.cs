using BaiTap2.Models;

namespace BaiTap2.Service
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllRoles();
        Task<Role?> GetRoleById(int roleId);
        Task<Role> CreateRole(Role role);
        Task<Role?> UpdateRole(int roleId, Role role);
        Task<bool> DeleteRole(int roleId);
    }
}
