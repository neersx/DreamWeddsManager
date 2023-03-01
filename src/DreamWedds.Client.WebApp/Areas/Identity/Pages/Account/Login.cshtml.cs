using DreamWeddsManager.Application.Interfaces.Services;
using DreamWeddsManager.Application.Interfaces.Services.Identity;
using DreamWeddsManager.Application.Requests.Identity;
using DreamWeddsManager.Client.Infrastructure.Managers.Identity.Authentication;
using DreamWeddsManager.Infrastructure.Models.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace DreamWedds.Client.WebApp.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserManager<BlazorHeroUser> _userManager;
        private readonly SignInManager<BlazorHeroUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly ITokenService _identityService;

        public LoginModel(
              UserManager<BlazorHeroUser> userManager,
              SignInManager<BlazorHeroUser> signInManager,
              ITokenService identityService,
              ICurrentUserService currentUserService,
              ILogger<LoginModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _identityService = identityService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            public string UserName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                var model = new TokenRequest() { Email = Input.UserName, Password = Input.Password };
                var result = await _identityService.LoginAsync(model);

                //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, result1.Principal);
                if (result.Succeeded)
                {
                    ClaimsPrincipal currentUser = User;
                    var users = _userManager.GetUserAsync(User).Result;
                    var user = await _userManager.FindByEmailAsync(Input.UserName);
                    await _userManager.AddLoginAsync(user, new UserLoginInfo("UserNamePassword", user.Id, "Account/Login"));
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }

                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

    }
}
