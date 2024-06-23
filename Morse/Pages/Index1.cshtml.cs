using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Morse.MorseTranslator;

namespace Morse.Pages
{
    public class Index1Model : PageModel
    {
        [BindProperty]
        public string InputText { get; set; }
        [BindProperty]
        public string OutputText { get; set; }
        private readonly ILogger<IndexModel> _logger;

        public Index1Model(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            MorseCodeTranslator morseCodeTranslator = new MorseCodeTranslator();
            OutputText = morseCodeTranslator.TranslateMorseToEng(InputText);
            return Page();
        }
    }
}
