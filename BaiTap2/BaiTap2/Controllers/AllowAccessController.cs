using BaiTap2.Models;
using BaiTap2.Response;
using BaiTap2.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllowAccessController : ControllerBase
    {
        private readonly IAllowAccessService _allowAccessService;

        public AllowAccessController(IAllowAccessService allowAccessService)
        {
            _allowAccessService = allowAccessService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var permissions = await _allowAccessService.GetAllPermissions();
            return Ok(new ApiResponse<IEnumerable<AllowAccess>>(true, "Danh sách quyền truy cập được lấy thành công.", permissions));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var permission = await _allowAccessService.GetPermissionById(id);
            if (permission == null) return NotFound(new ApiResponse<AllowAccess>(false, "Quyền truy cập không tồn tại."));
            return Ok(new ApiResponse<AllowAccess>(true, "Quyền truy cập được tìm thấy.", permission));
        }

        [HttpPost]
        public async Task<IActionResult> Create(AllowAccessDTO allowAccessDto)
        {
            var allowAccess = new AllowAccess
            {
                AccessProperties = allowAccessDto.AccessProperties,
                TableName = allowAccessDto.TableName,
                RoleId = allowAccessDto.RoleId,
            };
            var createdPermission = await _allowAccessService.CreatePermission(allowAccess);
            return CreatedAtAction(nameof(GetById), new { id = createdPermission.Id },
                new ApiResponse<AllowAccess>(true, "Quyền truy cập đã được tạo thành công.", createdPermission));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AllowAccessDTO allowAccessDto)
        {
            var allowAccess = new AllowAccess
            {
                AccessProperties = allowAccessDto.AccessProperties,
                TableName = allowAccessDto.TableName,
                RoleId = allowAccessDto.RoleId,
            };
            var updatedPermission = await _allowAccessService.UpdatePermission(id, allowAccess);
            if (updatedPermission == null) return NotFound(new ApiResponse<AllowAccess>(false, "Không tìm thấy quyền truy cập để cập nhật."));
            return Ok(new ApiResponse<AllowAccess>(true, "Quyền truy cập đã được cập nhật thành công.", updatedPermission));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _allowAccessService.DeletePermission(id);
            if (!success) return NotFound(new ApiResponse<bool>(false, "Không tìm thấy quyền truy cập để xóa."));
            return Ok(new ApiResponse<bool>(true, "Quyền truy cập đã được xóa thành công."));
        }
    }
}
