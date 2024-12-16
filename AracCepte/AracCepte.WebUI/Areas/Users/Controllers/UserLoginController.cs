using AracCepte.WebUI.Areas.Users.Models;
using Microsoft.AspNetCore.Mvc;
using AracCepte.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using AracCepte.DataAccess.Context;
using AracCepte.DTO.DTOs.LoginDto;
using Microsoft.IdentityModel.Tokens.Configuration;

namespace AracCepte.WebUI.Areas.Users.Controllers
{

    [Area("Users")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class UserLoginController : Controller
    {
        private readonly AracCepteContext _context;

        public UserLoginController(AracCepteContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            var model = new LoginFromModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginFromModel model)
        {
            if (ModelState.IsValid)
            {
                //emaili bul
                var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);

                //sifresini kontrol et
                if (user != null && user.Password == model.Password)
                {
                    return RedirectToAction("HomePage", "UserHome");
                }
                else
                {
                    ModelState.AddModelError("", "Gecersiz kullanici adi veya sifre");
                }
            }
            return View();
        }
        private User GetUserByEmailAndPassword(string email, string password)
        {
            // Burada veritabanı sorgusu yapılabilir
            // Örnek kullanıcı verisi
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user.Email == email && user.Password == password)
            {
                return (user);
            }
            return null;
        }
    }
}