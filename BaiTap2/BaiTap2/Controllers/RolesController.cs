using BaiTap2.Models;
using BaiTap2.Response;
using BaiTap2.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleService.GetAllRoles();
            return Ok(new ApiResponse<IEnumerable<Role>>(true, "Danh sách vai trò được lấy thành công.", roles));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var role = await _roleService.GetRoleById(id);
            var roleDto = new Role
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
            };
            if (role == null) return NotFound(new ApiResponse<Role>(false, "Vai trò không tồn tại."));
            return Ok(new ApiResponse<Role>(true, "Vai trò được tìm thấy.", roleDto));
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleDTO roleDto)
        {
            var role = new Role
            {
                RoleName = roleDto.RoleName
            };

            var createdRole = await _roleService.CreateRole(role);
            return CreatedAtAction(nameof(GetById), new { id = createdRole.RoleId },
                new ApiResponse<Role>(true, "Vai trò đã được tạo thành công.", createdRole));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RoleDTO roleDto)
        {
            var role = new Role
            {
                RoleName = roleDto.RoleName
            };

            var updatedRole = await _roleService.UpdateRole(id, role);
            if (updatedRole == null) return NotFound(new ApiResponse<Role>(false, "Không tìm thấy vai trò để cập nhật."));
            return Ok(new ApiResponse<Role>(true, "Vai trò đã được cập nhật thành công.", updatedRole));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _roleService.DeleteRole(id);
            if (!success) return NotFound(new ApiResponse<bool>(false, "Không tìm thấy vai trò để xóa."));
            return Ok(new ApiResponse<bool>(true, "Vai trò đã được xóa thành công."));
        }
    }
}
