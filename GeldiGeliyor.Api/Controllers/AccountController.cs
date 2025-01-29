using GeldiGeliyor.Business.Abstract;
using GeldiGeliyor.Business.Concrete.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace GeldiGeliyor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController(IAuthService authService) : ControllerBase
    {
        //jwt.io
        [HttpGet]
        public async Task<IActionResult> CreateToken([FromQuery] LoginDto loginDto)
        {
            string token = await authService.CreateTokenAsync(loginDto);
            return Ok(token);
        }
    }
}
