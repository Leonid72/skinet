using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Extenstions
{
    public static class UserManagerExtenstions
    {
        public static async Task<AppUser> FindUserByClaimsPrincipalWithAddress(this UserManager<AppUser> userManager,
                                ClaimsPrincipal user)
        {
            var email = user.FindFirstValue(ClaimTypes.Email);
            return await userManager.Users.Include(x=>x.Address).FirstOrDefaultAsync(x=>x.Email == email);
        }

        public static async Task<AppUser> FindByEmailFromClaimPrincipal(this UserManager<AppUser> userManager,
                                ClaimsPrincipal user)
        {
            return await userManager.Users.SingleOrDefaultAsync(x=>x.Email == user.FindFirstValue(ClaimTypes.Email));
        }
    }
}