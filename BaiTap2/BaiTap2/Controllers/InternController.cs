using BaiTap2.DATA;
using BaiTap2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BaiTap2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternController : ControllerBase
    {
        private readonly AppDBContext _appDBContext;
        public InternController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetInterns()
        {
            // Lấy UserId từ JWT Token
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userRoleId = _appDBContext.Users.Where(u => u.UserId.ToString() == userId)
                                           .Select(u => u.RoleId)
                                           .FirstOrDefault();

            if (userRoleId == 0)
            {
                return Unauthorized("User role not found");
            }

            // Lấy danh sách quyền truy cập của role
            var allowedColumns = _appDBContext.AllowAccesses
                .Where(a => a.RoleId == userRoleId && a.TableName == "Interns")
                .Select(a => a.AccessProperties)
                .ToList(); 

            // Truy vấn tất cả thực tập sinh từ bảng Intern
            var interns = _appDBContext.Interns.ToList();

            // Duyệt từng Intern và tạo DTO chỉ chứa cột được phép truy cập
            var filteredInterns = interns.Select(i => new InternDto
            {
                InternMail = allowedColumns.Contains("InternMail") ? i.InternMail : null,
                InternName = allowedColumns.Contains("InternName") ? i.InternName : null,
                Major = allowedColumns.Contains("Major") ? i.Major : null
            }).ToList();

            return Ok(filteredInterns);
        }



    }
}
