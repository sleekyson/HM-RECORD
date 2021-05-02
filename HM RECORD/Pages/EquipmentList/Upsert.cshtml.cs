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
    public class UpsertModel : PageModel
    {
        private ApplicationDbContext _db;

        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]

        public Equipment Equipment { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            Equipment = new Equipment();
            if (id == null)
            {
                //Create
                return Page();
            }

            //Update
            Equipment = await _db.Equipment.FirstOrDefaultAsync(u => u.Id == id);
            if (Equipment == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Equipment.Id == 0)
                {
                    _db.Equipment.Add(Equipment);
                }
                else
                {
                    _db.Equipment.Update(Equipment);
                }

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}