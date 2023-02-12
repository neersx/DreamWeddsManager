using DreamWeddsManager.Application.Interfaces.Services;
using DreamWeddsManager.Application.Interfaces.Services.Identity;
using DreamWeddsManager.Infrastructure.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartAdmin.WebUI.Models;

namespace SmartAdmin.WebUI.ViewComponents
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
        }
        public IViewComponentResult Invoke()
        {
            
            var items = NavigationModel.GetNavigation(x=>!x.Roles.Any()  || (x.Roles.Any() && _roles.Any() && x.Roles.Where(x=>_roles.Contains(x)).Any()) );

            return View(items);
        }
    }
}
