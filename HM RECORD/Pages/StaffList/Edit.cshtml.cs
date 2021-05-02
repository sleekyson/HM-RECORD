using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HM_RECORD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HM_RECORD.Pages.StaffList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]

        public Staff Staff { get; set; }

        public async Task OnGet(int id)
        {
            Staff = await _db.Staff.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var StaffFromDb = await _db.Staff.FindAsync(Staff.Id);
                StaffFromDb.Surname = Staff.Surname;
                StaffFromDb.Name = Staff.Name;
                StaffFromDb.Gender = Staff.Gender;
                StaffFromDb.PhoneNo = Staff.PhoneNo;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}