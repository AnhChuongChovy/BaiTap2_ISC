using BaiTap2.DATA;
using BaiTap2.Models;
using Microsoft.EntityFrameworkCore;

namespace BaiTap2.Service
{
    public class RoleService: IRoleService
    {
        private readonly AppDBContext _context;

        public RoleService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role?> GetRoleById(int roleId)
        {
            return await _context.Roles.Include(u=>u.User).FirstOrDefaultAsync(r=>r.RoleId == roleId);
        }

        public async Task<Role> CreateRole(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<Role?> UpdateRole(int roleId, Role role)
        {
            var existingRole = await _context.Roles.FindAsync(roleId);
            if (existingRole == null) return null;

            existingRole.RoleName = role.RoleName;
            await _context.SaveChangesAsync();
            return existingRole;
        }

        public async Task<bool> DeleteRole(int roleId)
        {
            var role = await _context.Roles.FindAsync(roleId);
            if (role == null) return false;

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
