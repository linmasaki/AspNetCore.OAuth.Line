using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using AspNetCore.OAuth.Line;
using Microsoft.AspNetCore.Authentication.Cookies;
using static AspNetCore.OAuth.Line.LineAuthenticationConstants;


namespace DemoApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty(SupportsGet = true)] public string OpenId { get; set; }

        [BindProperty(SupportsGet = true)] public string Name { get; set; }

        [BindProperty(SupportsGet = true)] public string PictureUrl { get; set; }

        [BindProperty(SupportsGet = true)] public string Email { get; set; }


        public void OnGet()
        {
            var calimIdentity = (ClaimsIdentity)HttpContext.User.Identity;
            OpenId = calimIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!string.IsNullOrEmpty(OpenId))
            {
                Name = calimIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
                PictureUrl = calimIdentity.Claims.FirstOrDefault(c => c.Type == Claims.PictureUrl)?.Value;
                Email = calimIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            }
        }

        public async Task<IActionResult> OnPostLoginAsync()
        {
            var properties = new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddMinutes(30),
                IsPersistent = true,
                RedirectUri = Url.PageLink("Index")
            };
            return Challenge(properties, LineAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task<IActionResult> OnGetLogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage();
        }
    }
}
