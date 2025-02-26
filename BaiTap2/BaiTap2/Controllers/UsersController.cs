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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUsers();
            return Ok(new ApiResponse<IEnumerable<User>>(true, "Lấy thành công danh sách người dùng", users));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null) return NotFound(new ApiResponse<User>(false, "Người dùng không tồn tại"));
            return Ok(new ApiResponse<User>(true, "Tìm thấy người dùng", user));
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDTO userDto)
        {
            var user = new User
            {
                Email = userDto.Email,
                FullName = userDto.FullName,
                DateOfBirth = userDto.DateOfBirth,
                PasswordHash = userDto.PasswordHash,
                RoleId = userDto.RoleId,
            };
            var createdUser = await _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetById), new { id = createdUser.UserId },
                new ApiResponse<User>(true, "Tạo mới người dùng thành công", createdUser));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserDTO userDto)
        {
            var user = new User
            {
                Email = userDto.Email,
                FullName = userDto.FullName,
                DateOfBirth = userDto.DateOfBirth,
                PasswordHash = userDto.PasswordHash,
                RoleId = userDto.RoleId,
            };
            var updatedUser = await _userService.UpdateUser(id, user);
            if (updatedUser == null) return NotFound(new ApiResponse<User>(false, "Không tìm thấy người dùng để cập nhật"));
            return Ok(new ApiResponse<User>(true, "Cập nhật người dùng thành công", updatedUser));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _userService.DeleteUser(id);
            if (!success) return NotFound(new ApiResponse<bool>(false, "Không tìm thấy người dùng để xóa"));
            return Ok(new ApiResponse<bool>(true, "Xóa người dùng thành công"));
        }
    }
}
