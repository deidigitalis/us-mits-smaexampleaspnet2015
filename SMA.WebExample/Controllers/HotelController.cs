using SMA.WebExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMA.WebExample.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        public ActionResult Index()
        {
            return View(GetHotels());
        }

        public ActionResult Edit(int id)
        {
            Hotel hotel = GetHotels().FirstOrDefault(x => x.HotelId == id);
            return View(hotel);
        }

        [HttpPost]
        public ActionResult Edit(Hotel model)
        {
            if (ModelState.IsValid)
            {
                //Modifica en la base de datos
                return RedirectToAction("Details", "Hotel", new { id = model.HotelId });
            }

            ModelState.AddModelError(string.Empty, "This hotel has invalid values.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            Hotel hotel = GetHotels().FirstOrDefault(x => x.HotelId == id);
            return View(hotel);
        }

        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }

        private static List<Hotel> GetHotels()
        {
            Hotel hotel1 = new Hotel
            {
                Name = "Gran Melia Colon",
                Address = "Canalejas, 1, 41001 Sevilla, España",
                Category = 5,
                Email = "granmeliacolon@melia.com",
                Description = "Hotel de Gran Lujo situado en el centro de Sevilla.",
                Phone = "954505599",
                HotelType = "HOTEL"
            };

            Hotel hotel2 = new Hotel
            {
                Name = "Barceló Sevilla Renacimiento",
                Address = "Avda. Alvaro Alonso Barba, s/n | Isla de la Cartuja, 41092 Sevilla, España",
                Category = 5,
                Email = "renacimiento.res@barcelo.com",
                Description = "Hotel de diseño original y moderno.",
                Phone = "954462222",
                HotelType = "HOTEL"
            };

            return new List<Hotel> { hotel1, hotel2 };
        }
    }
}