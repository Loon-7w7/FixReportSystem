using FixReportSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FixReportSystem.Controllers
{
    public class ReportController : Controller
    {
        private readonly ModelContext _context;
        public ReportController(ModelContext context)
        {
            _context = context;
        }

        public IActionResult ViewList(string id)
        {
            //ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserName");
            //if (!string.IsNullOrWhiteSpace(id))
            //{
            //    var report = from rpt in _context.Reports
            //                 where rpt.UserId == id
            //                 select rpt;
            //    return View(report.SingleOrDefault());
            //}

            return View("ViewList", _context.Reports);
        }

        public IActionResult Index(string id)
        {
            ViewData["ReportId"] = new SelectList(_context.Reports, "Id", "Name");
            if (!string.IsNullOrWhiteSpace(id))
            {
                var report = from rpt in _context.Reports
                              where rpt.ReportId == id
                              select rpt;
                return View(report.SingleOrDefault());
            }
            else
            {
                return View("ViewList", _context.Reports);
            }
        }
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserName");

            return View();
        }
        [HttpPost]
        public IActionResult Create(Report report)
        {
            report.ReportId = Guid.NewGuid().ToString();
            _context.Reports.Add(report);
            _context.SaveChanges();
            return View("Index", report);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = await _context.Reports.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            ViewData["ReportId"] = new SelectList(_context.Reports, "RepordId", "ReportId", report.ReportId);
            return View(report);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ReportId, Name, LastName, Building, Classroom, Furniture, Email, HeadCngineeringCourse, FurnitureOrClaim, ReportDescription, UserId, User")] Report report)
        {
            if (id != report.ReportId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(report);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportExists(report.ReportId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReportId"] = new SelectList(_context.Reports, "ReportId", "ReportId", report.ReportId);
            return View(report);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reports = await _context.Reports
                .Include(c =>c.User)
                .FirstOrDefaultAsync(m => m.ReportId == id);
            if (reports == null)
            {
                return NotFound();
            }

            return View(reports);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var report = await _context.Reports.FindAsync(id);
            _context.Reports.Remove(report);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool ReportExists(string id)
        {
            return _context.Reports.Any(e => e.ReportId == id);
        }
    }
}
