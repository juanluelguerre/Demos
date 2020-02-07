using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyBudget.Pages
{
	public class IndexModel : PageModel
	{
		[BindProperty]
		public int Total { get; set; } = 0;

		public void OnGet()
		{
		}
		
		public void OnPostAddAsync()
		{
			Total++;
		}

		public void OnPostRemoveAsync()
		{
			if (Total > 0)
				Total--;
		}
	}
}
