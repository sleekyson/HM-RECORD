using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HM_RECORD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HM_RECORD.Controllers
{

    [Route("api/Equipment")]
    [ApiController]
    public class EquipmentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EquipmentController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(data: new { data = await _db.Equipment.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var equipmentFromDb = await _db.Equipment.FirstOrDefaultAsync(u => u.Id == id);
            if (equipmentFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Equipment.Remove(equipmentFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
