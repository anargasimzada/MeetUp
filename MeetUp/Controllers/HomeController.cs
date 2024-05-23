using MeetUp.DAL;
using MeetUp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeetUp.Controllers
{
    public class HomeController(AppDbContext _con) : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Speaker> speakers = await _con.speakers.ToListAsync();
            return View(speakers);
        }
    }
}
