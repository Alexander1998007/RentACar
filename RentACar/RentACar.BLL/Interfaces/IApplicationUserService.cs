using Microsoft.AspNetCore.Http;
using RentACar.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.BLL.Interfaces
{
    public interface IApplicationUserService
    {
        Task<ApplicationUserDTO> GetCurrentUserAsync(HttpContext httpContext);
        Task<string> GetCurrentUserIdAsync(HttpContext httpContext);
    }
}
