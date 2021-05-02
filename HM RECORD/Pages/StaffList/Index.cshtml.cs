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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Staff> Staffs { get; set; }


        public async Task OnGet()
        {
            Staffs = await _db.Staff.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var staff = await _db.Staff.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            _db.Staff.Remove(staff);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}