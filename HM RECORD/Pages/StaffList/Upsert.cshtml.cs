using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HM_RECORD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HM_RECORD.Pages.StaffList
{
    public class UpsertModel : PageModel
    {
        private ApplicationDbContext _db;

        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]

        public Staff Staff { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            Staff = new Staff();
            if (id ==  null)
            {
                //Create
                return Page();
            }

            //Update
            Staff = await _db.Staff.FirstOrDefaultAsync(u => u.Id == id);
            if (Staff == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Staff.Id == 0)
                {
                    _db.Staff.Add(Staff);
                }
                else
                {
                    _db.Staff.Update(Staff);
                }
                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }


    }
}