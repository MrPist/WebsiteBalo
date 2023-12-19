using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebsiteBalo.Data;
using WebsiteBalo.Models;

namespace WebsiteBalo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        void GetInfo()
        {
            ViewBag.danhmuc = _context.Danhmucs.ToList();
            //ViewData["solg"] = GetCartItems().Count();
        }
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
            GetInfo();
            var applicationDbContext = _context.Mathangs.Include(m => m.MaDmNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            GetInfo();
            if (id == null || _context.Mathangs == null)
            {
                return NotFound();
            }

            var mathang = await _context.Mathangs
                .Include(m => m.MaDmNavigation)
                .FirstOrDefaultAsync(m => m.MaMh == id);
            if (mathang == null)
            {
                return NotFound();
            }

            return View(mathang);
        }

        private bool MathangExists(int id)
        {
          return (_context.Mathangs?.Any(e => e.MaMh == id)).GetValueOrDefault();
        }
        public IActionResult Login(string email, string matkhau) 
        {
            GetInfo();
            return View();
        }
        public async Task<IActionResult> ProductsByName(string keyword)
        {
            GetInfo();
            var mathang = _context.Mathangs.Where(p => p.Ten.Contains(keyword));
            return View(await mathang.ToListAsync());
        }
    }
}
