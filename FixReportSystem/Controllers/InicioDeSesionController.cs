﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixReportSystem.Controllers
{
    public class InicioDeSesionController : Controller
    {
        // GET: InicioDeSesionController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: InicioDeSesionController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InicioDeSesionController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InicioDeSesionController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InicioDeSesionController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InicioDeSesionController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InicioDeSesionController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InicioDeSesionController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
