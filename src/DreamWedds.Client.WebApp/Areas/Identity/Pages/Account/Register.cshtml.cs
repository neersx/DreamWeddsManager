using DreamWeddsManager.Application.Requests.Identity;
using DreamWeddsManager.Infrastructure.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DreamWedds.Client.WebApp.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly UserManager<BlazorHeroUser> _userManager;
        private readonly SignInManager<BlazorHeroUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public RegisterModel(
            UserManager<BlazorHeroUser> userManager,
            SignInManager<BlazorHeroUser> signInManager,
            ILogger<LoginModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        private readonly RegisterRequest Input = new();

        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl = null) => ReturnUrl = returnUrl;
    }
}
