using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HM_RECORD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HM_RECORD.Pages.EquipmentList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Equipment> Equipments { get; set; }


        public async Task OnGet()
        {
            Equipments = await _db.Equipment.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var equipment = await _db.Equipment.FindAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }
            _db.Equipment.Remove(equipment);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
