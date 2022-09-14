using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace chas_medicinais.Pages
{
    public class TermosModel : PageModel
    {
        private readonly ILogger<TermosModel> _logger;

        public TermosModel(ILogger<TermosModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
