using AracCepte.DTO.DTOs.VehicleDtos;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using AracCepte.Entity;

namespace AracCepte.WebUI.Areas.Users.Controllers
{
    [Area("Users")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class AddVehicleController : Controller
    {
        public IActionResult AddVehicle()
        {
            return View("AddVehicle");
        }
        [HttpPost("api/vehicles")]
        public IActionResult AddVehicle([FromBody] CreateVehicleDto vehicle)
        {
            if (vehicle == null)
            {
                return BadRequest("Araç bilgileri boş olamaz.");
            }

            // İşlemler burada yapılır (veritabanına ekleme vb.)
            return Ok(new { message = "Araç başarıyla eklendi.", vehicle });
        }

    }
}
