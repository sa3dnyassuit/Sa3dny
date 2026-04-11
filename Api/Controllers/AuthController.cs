using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sa3dny.Api.DTOs.Auth;
using Sa3dny.Api.Services;
using Sa3dny.Data;
using Sa3dny.Data.Models;

namespace Sa3dny.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppDbContext _context;
        private readonly JwtService _jwtService;

        public AuthController(
            UserManager<IdentityUser> userManager,
            AppDbContext context,
            JwtService jwtService)
        {
            _userManager = userManager;
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPost("register/customer")]
        public async Task<IActionResult> RegisterCustomer([FromBody] RegisterCustomerDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUser = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUser != null)
                return BadRequest(new { message = "Email already exists" });

            // ✅ تأكد إن الـ Location موجود
            var location = _context.Locations.FirstOrDefault(l => l.Name_Location == dto.LocationName);
            if (location == null)
                return BadRequest(new { message = "Location not found" });

            var identityUser = new IdentityUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                PhoneNumber = dto.Phone
            };

            var result = await _userManager.CreateAsync(identityUser, dto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _userManager.AddToRoleAsync(identityUser, "Customer");

            var customer = new Customer
            {
                Name = dto.Name,
                Phone = dto.Phone,
                Email = dto.Email,
                PasswordHash = identityUser.PasswordHash,
                LocationName = dto.LocationName, // ✅ بيخزن الاسم مباشرة
                created_at = DateTime.UtcNow
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            var token = _jwtService.GenerateToken(
                identityUser.Id, dto.Email, dto.Name, "Customer");

            return Ok(new AuthResponseDto
            {
                Token = token,
                Email = dto.Email,
                Name = dto.Name,
                Role = "Customer",
                ExpiresAt = DateTime.UtcNow.AddDays(7)
            });
        }

        [HttpPost("register/provider")]
        public async Task<IActionResult> RegisterProvider([FromBody] RegisterProviderDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUser = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUser != null)
                return BadRequest(new { message = "Email already exists" });

            var governorate = _context.Governorates.FirstOrDefault(g => g.Name_Governorate == dto.GovernorateName);
            if (governorate == null)
                return BadRequest(new { message = "Governorate not found" });

            var location = _context.Locations.FirstOrDefault(l => l.Name_Location == dto.LocationName);
            if (location == null)
                return BadRequest(new { message = "Location not found" });

            var serviceCategory = _context.ServiceCategories.FirstOrDefault(sc => sc.Name_Category == dto.ServiceCategoryName);
            if (serviceCategory == null)
                return BadRequest(new { message = "Service category not found" });

            var service = _context.Services.FirstOrDefault(s => s.service_name == dto.ServiceName);
            if (service == null)
                return BadRequest(new { message = "Service not found" });

            var nationalIdPath = SaveBase64File(dto.NationalIdImageBase64, "national_ids");
            var licensePath = SaveBase64File(dto.ProfessionalLicenseBase64, "licenses");

            var identityUser = new IdentityUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                PhoneNumber = dto.Phone
            };

            var result = await _userManager.CreateAsync(identityUser, dto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _userManager.AddToRoleAsync(identityUser, "Provider");

            var provider = new Provider
            {
                Name = dto.Name,
                Phone = dto.Phone,
                Email = dto.Email,
                PasswordHash = identityUser.PasswordHash,
                GovernorateId = governorate.Id_Governorate,
                LocationName = dto.LocationName, // ✅ بيخزن الاسم مباشرة
                national_id_Provider = dto.NationalId,
                ServiceCategoryId = serviceCategory.Id_Category,
                ServiceId = service.service_id,
                NationalIdImagePath = nationalIdPath,
                ProfessionalLicensePath = licensePath,
                created_at = DateTime.UtcNow
            };

            _context.Providers.Add(provider);
            await _context.SaveChangesAsync();

            var token = _jwtService.GenerateToken(
                identityUser.Id, dto.Email, dto.Name, "Provider");

            return Ok(new AuthResponseDto
            {
                Token = token,
                Email = dto.Email,
                Name = dto.Name,
                Role = "Provider",
                ExpiresAt = DateTime.UtcNow.AddDays(7)
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                return Unauthorized(new { message = "Invalid email or password" });

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!isPasswordValid)
                return Unauthorized(new { message = "Invalid email or password" });

            var roles = await _userManager.GetRolesAsync(user);
            string role = "";
            string name = "";

            if (roles.Contains("Customer"))
            {
                role = "Customer";
                var customer = _context.Customers.FirstOrDefault(c => c.Email == dto.Email);
                name = customer?.Name ?? "";
            }
            else if (roles.Contains("Provider"))
            {
                role = "Provider";
                var provider = _context.Providers.FirstOrDefault(p => p.Email == dto.Email);
                name = provider?.Name ?? "";
            }
            else
            {
                return Unauthorized(new { message = "User role not found" });
            }

            var token = _jwtService.GenerateToken(user.Id, dto.Email, name, role);

            return Ok(new AuthResponseDto
            {
                Token = token,
                Email = dto.Email,
                Name = name,
                Role = role,
                ExpiresAt = DateTime.UtcNow.AddDays(7)
            });
        }

        private string SaveBase64File(string base64, string folder)
        {
            var bytes = Convert.FromBase64String(base64);
            var fileName = $"{Guid.NewGuid()}.jpg";
            var folderPath = Path.Combine("wwwroot", "uploads", folder);
            Directory.CreateDirectory(folderPath);
            var filePath = Path.Combine(folderPath, fileName);
            System.IO.File.WriteAllBytes(filePath, bytes);
            return $"/uploads/{folder}/{fileName}";
        }
    }
}