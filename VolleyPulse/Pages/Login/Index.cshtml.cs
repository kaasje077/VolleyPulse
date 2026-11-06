using Domain.DTO_s;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Pages.Login
{
    public class IndexModel : PageModel
    {
        private readonly IMemberLogic _memberLogic;
        public IndexModel(IMemberLogic memberLogic)
        {
            _memberLogic = memberLogic;
        }
        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }
        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                ModelState.AddModelError(string.Empty, "Email and Password are required.");
                return Page();
            }
            var member = _memberLogic.AuthenticateMember(Email, Password);
            if (member == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return Page();
            }
            // Store member information in session or cookie as needed
            // For example:
            HttpContext.Session.SetString("MemberId", member.id.ToString());
            HttpContext.Session.SetString("MemberRole", member.Role.ToString());
            return RedirectToPage("/Schedule/Index");
        }
        
    }
}
