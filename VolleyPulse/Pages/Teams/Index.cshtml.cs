using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic.DTO_s;

namespace UI.Pages.Teams
{
    public class IndexModel : PageModel
    {
        private readonly ITeamLogic _teamLogic;

        public IndexModel(ITeamLogic teamLogic)
        {
            _teamLogic = teamLogic;
        }

        public List<Team> Teams { get; private set; } = new();

        public IActionResult OnGet()
        {
            Teams = _teamLogic.GetAllTeams();

            return Page();
        }
    }
}
