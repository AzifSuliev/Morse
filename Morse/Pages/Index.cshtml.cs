using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Morse.MorseTranslator;
namespace Morse.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string InputText { get; set; }
        [BindProperty]
        public string OutputText { get; set; }
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            MorseCodeTranslator morseCodeTranslator = new MorseCodeTranslator();
            OutputText = morseCodeTranslator.TranslateEngToMorse(InputText);
            return Page();
        }
    }
}
