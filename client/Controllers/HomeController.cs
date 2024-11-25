using Application.Common.Interface;
using client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace client.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModel homePage = new() {
                Hotels = await _unitOfWork.Hotel.GetAll(includeProperties: "HotelAmenities,Amenity"),
                Nights = 1,
                CheckIn = DateOnly.FromDateTime(DateTime.Now),
                CheckOut = DateOnly.FromDateTime(DateTime.Now.AddDays(1))

            };
            
            return View(homePage);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
