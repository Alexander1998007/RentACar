using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using RentACar.BLL.DTO;
using RentACar.BLL.Interfaces;
using RentACar.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.BLL.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public ApplicationUserService(
            UserManager<ApplicationUser> userManger,
            IMapper mapper)
        {
            _userManager = userManger;
            _mapper = mapper;
        }

        public async Task<ApplicationUserDTO> GetCurrentUserAsync(HttpContext httpContext)
        {
            var user = await _userManager.GetUserAsync(httpContext.User);
            return _mapper.Map<ApplicationUserDTO>(user);
        }

        public async Task<string> GetCurrentUserIdAsync(HttpContext httpContext)
        {
            var user = await GetCurrentUserAsync(httpContext);
            return user.Id;
        }
    }
}
