using FixReportSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

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
    }
}
