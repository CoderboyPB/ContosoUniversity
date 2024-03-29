﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly ContosoUniversity.Models.ContosoUniversityContext _context;

        public DetailsModel(ContosoUniversity.Models.ContosoUniversityContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Student.Include(s => s.Enrollments)
               .ThenInclude(e => e.Course).AsNoTracking().FirstOrDefaultAsync(s => s.ID == id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
