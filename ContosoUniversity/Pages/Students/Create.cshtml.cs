﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly ContosoUniversity.Models.ContosoUniversityContext _context;

        public CreateModel(ContosoUniversity.Models.ContosoUniversityContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StudentVM StudentVM { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //var emptyStudent = new Student();
            //if (await TryUpdateModelAsync<Student>(
            //    emptyStudent,
            //    "student",
            //    s=>s.FirstMidName, s=>s.LastName, s=>s.EnrollmentDate))
            //{
            //    _context.Student.Add(Student);
            //    await _context.SaveChangesAsync();
            //    return RedirectToPage("./Index");
            //}

            var entry = _context.Add(new Student());
            entry.CurrentValues.SetValues(StudentVM);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}