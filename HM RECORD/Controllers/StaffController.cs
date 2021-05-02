using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HM_RECORD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HM_RECORD.Controllers
{
    [Route("api/Staff")]
    [ApiController]
    public class StaffController : Controller
    {

        private readonly ApplicationDbContext _db;

        public StaffController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
            return Json(data: new { data=await _db.Staff.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var staffFromDb =await _db.Staff.FirstOrDefaultAsync(u => u.Id == id);
            if (staffFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Staff.Remove(staffFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
