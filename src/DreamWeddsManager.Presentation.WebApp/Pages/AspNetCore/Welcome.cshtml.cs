using DreamWeddsManager.Application.Extensions;
using Serilog;

namespace SmartAdmin.WebUI.Pages.AspNetCore
{
    [Authorize()]
    public class WelcomeModel : PageModel
    {
        static int _callCount;
        private readonly ILogger<WelcomeModel> _logger;
        private readonly IDiagnosticContext _diagnosticContext;

        public WelcomeModel(ILogger<WelcomeModel> logger,
            IDiagnosticContext diagnosticContext)
        {
            _logger = logger;
            _diagnosticContext = diagnosticContext;
            
        }

        public void OnGet()
        {
            _logger.LogInformation("new163@163.com".ToMD5());
            _logger.LogInformation("Welcome.");
            _diagnosticContext.Set("IndexCallCount", Interlocked.Increment(ref _callCount));
        }
    public  Task<JsonResult> OnGetFilter(string input)
    {
      return  Task.FromResult(new JsonResult(input));
    }
    public  Task<JsonResult> OnPost(string input)
    {
      return Task.FromResult(new JsonResult(string.Empty));
        }
  }
}
