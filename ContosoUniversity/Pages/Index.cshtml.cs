using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoUniversity.Models.SchoolViewModels;

namespace ContosoUniversity.Pages
{
    public class IndexModel : PageModel
    {
        public List<EnrollmentDateGroup> MyProp { get; set; }
        public void OnGet()
        {

        }
    }
}
