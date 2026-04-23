using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sa3dny.Api.DTOs.Requests;
using Sa3dny.Data;
using Sa3dny.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Sa3dny.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public RequestsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost("Create")]
        public async Task<ActionResult> CreateRequest(CreateRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var request = new Requests
            {
                Customer_Id = dto.Customer_Id,
                Service_Id = dto.Service_Id,
                Description_Req = dto.Description_Req,
                Status = "Pending"
            };
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                message = "Request created successfully",
                requestId = request.Request_Id
            });
        }
        [HttpPut("respond")]
        public async Task<IActionResult> RespondToRequest(RequestResponseDto dto)
        {
            var providerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var request = await _context.Requests.FindAsync(dto.Request_Id);

            if (request == null)
                return NotFound("Request not found");

            if (request.Status != "Pending")
                return BadRequest("Request already handled");

            if (dto.Status != "Accept" && dto.Status != "Decline")
                return BadRequest("Invalid status");

            request.Status = dto.Status;
            request.Provider_Id = providerId;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = $"Request {dto.Status} successfully",
                requestId = request.Request_Id,
                providerId = providerId
            });
        }
        [HttpGet("provider-request")]
        public async Task<IActionResult> GetRequest()
        {
            var providerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var provider = await _context.Providers
            .FirstOrDefaultAsync(p => p.provider_id == providerId);

            if (provider == null)
                return Unauthorized();

            var requests = await _context.Requests
          .Where(r => r.Service_Id == provider.ServiceId
          && r.Status == "Pending").ToListAsync();

            return Ok(requests);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("admin/update")]
        public async Task<IActionResult> updateRequest(AdminUpdateRequestDto dto)
        {
            var request = await _context.Requests.FindAsync(dto.Request_Id);

            if (request == null)
                return NotFound("Request not found");

            var validStatuses = new[] { "Pending", "Accept", "Decline", "Cancelled" };

            if (!validStatuses.Contains(dto.Status))
                return BadRequest("Invalid status");

            request.Description_Req = dto.Description_Req;
            request.location = dto.Address;
            request.phone = dto.Phone;
            request.Service_Id = dto.Service_Id;
            request.Status = dto.Status;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Request updated successfully by admin",
                requestId = request.Request_Id,
                newStatus = request.Status
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("admin/delete/{id}")]
        public async Task<IActionResult> deleteRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);

            if (request == null)
                return NotFound("Request not found");

            _context.Requests.Remove(request);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Request deleted permanently",
                requestId = id
            });
        }
    }
}
