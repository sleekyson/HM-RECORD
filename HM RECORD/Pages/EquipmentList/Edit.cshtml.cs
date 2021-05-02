using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HM_RECORD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HM_RECORD.Pages.EquipmentList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]

        public Equipment Equipment { get; set; }

        public async Task OnGet(int id)
        {
            Equipment = await _db.Equipment.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var EquipmentFromDb = await _db.Equipment.FindAsync(Equipment.Id);
                EquipmentFromDb.Name = Equipment.Name;
                EquipmentFromDb.WardLocation = Equipment.WardLocation;
                EquipmentFromDb.Number = Equipment.Number;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}