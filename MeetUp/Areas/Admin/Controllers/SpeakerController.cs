using MeetUp.DAL;
using MeetUp.Models;
using MeetUp.ViewModels.Speakers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeetUp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpeakerController : Controller
    {
        private readonly AppDbContext _context;

        public SpeakerController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Speaker> speakers=await _context.speakers.ToListAsync();
            return View(speakers);
        }
        public async Task<IActionResult> Create()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSpeakerVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            await _context.speakers.AddAsync(new Speaker
            {
                Name = vm.Name,
                Subtitle = vm.Subtitle,
                ImageUrl = vm.ImageUrl,
            });
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
           
        }
        public async Task<IActionResult> Update(int? id) 
        {
            if (id == null) return BadRequest();
           var res=await _context.speakers.FirstOrDefaultAsync(x => x.Id == id);
            if (res == null) return NotFound();
            return View(res);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id,CreateSpeakerVM vm)
        {
            if (id == null) return BadRequest();
            var res = await _context.speakers.FirstOrDefaultAsync(x => x.Id == id);
            if (res == null) return NotFound();

            res.Name = vm.Name;
            res.Subtitle = vm.Subtitle;
            res.ImageUrl = vm.ImageUrl;

           
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null) return BadRequest();
            var res = await _context.speakers.FirstOrDefaultAsync(x => x.Id == id);
            if (res == null) return NotFound();
            _context.Remove(res);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
