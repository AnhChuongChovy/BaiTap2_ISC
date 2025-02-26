using BaiTap2.DATA;
using BaiTap2.Models;
using Microsoft.EntityFrameworkCore;

namespace BaiTap2.Service
{
    public class AllowAccessService : IAllowAccessService
    {
        private readonly AppDBContext _context;

        public AllowAccessService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AllowAccess>> GetAllPermissions()
        {
            return await _context.AllowAccesses.ToListAsync();
        }

        public async Task<AllowAccess?> GetPermissionById(int id)
        {
            return await _context.AllowAccesses.FindAsync(id);
        }

        public async Task<AllowAccess> CreatePermission(AllowAccess allowAccess)
        {
            _context.AllowAccesses.Add(allowAccess);
            await _context.SaveChangesAsync();
            return allowAccess;
        }

        public async Task<AllowAccess?> UpdatePermission(int id, AllowAccess allowAccess)
        {
            var existingPermission = await _context.AllowAccesses.FindAsync(id);
            if (existingPermission == null) return null;

            existingPermission.TableName = allowAccess.TableName;
            existingPermission.AccessProperties = allowAccess.AccessProperties;

            await _context.SaveChangesAsync();
            return existingPermission;
        }

        public async Task<bool> DeletePermission(int id)
        {
            var permission = await _context.AllowAccesses.FindAsync(id);
            if (permission == null) return false;

            _context.AllowAccesses.Remove(permission);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
