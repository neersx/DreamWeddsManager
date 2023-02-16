using DreamWedds.Client.WebApp.Models;
using DreamWeddsManager.Application.Interfaces.Services;
using DreamWeddsManager.Application.Interfaces.Services.Identity;
using DreamWeddsManager.Infrastructure.Models.Identity;
using DreamWeddsManager.Infrastructure.Services.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DreamWedds.Client.WebApp.ViewComponents
{
    public class NavigationViewComponent : ViewComponent
    {
        private readonly UserManager<BlazorHeroUser> _userManager;
        private readonly ICurrentUserService _currentUserService;
        private readonly ITokenService _identityService;
        private readonly string[] _roles;
        public NavigationViewComponent(
            UserManager<BlazorHeroUser> userManager,
            ICurrentUserService currentUserService,
            ITokenService  identityService
            )
        {
            _userManager = userManager;
            _currentUserService = currentUserService;
            _identityService = identityService;
            var userId = _currentUserService.UserId;
            _roles = _userManager.Users.Where(x => x.Id == userId).Include(x => x.UserRoles).SelectMany(x => x.UserRoles).Select(x => x.Name).ToArray();
        }
        public IViewComponentResult Invoke()
        {
            
            var items = NavigationModel.GetNavigation(x=>!x.Roles.Any()  || (x.Roles.Any() && _roles.Any() && x.Roles.Where(x=>_roles.Contains(x)).Any()) );

            return View(items);
        }
    }
}
