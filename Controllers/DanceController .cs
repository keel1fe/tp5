using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using tp5.Models;

namespace tp5.Controllers
{
    public class DanceController : Controller
    {
        // Хранилище данных в памяти (для примера)
        private static List<Dance> _dances = new List<Dance>();
        private static int _nextId = 1;

        // GET: /Dance/
        public IActionResult Index()
        {
            // Для теста: начальные данные если список пуст
            if (!_dances.Any())
            {
                _dances.Add(new Dance
                {
                    CourseId = _nextId++,
                    FIO = "Иванова Анна",
                    Age = 8,
                    StyleDance = "Балет",
                    StartDate = DateTime.Now.AddDays(-30),
                    ParentPhone = "+79161234567"
                });
            }

            return View(_dances.OrderBy(d => d.CourseId).ToList());
        }

        // GET: /Dance/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Dance/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Dance dance)
        {
            if (ModelState.IsValid)
            {
                dance.CourseId = _nextId++;
                _dances.Add(dance);

                Debug.WriteLine($"Добавлена запись: {dance.FIO}, ID: {dance.CourseId}");

                return RedirectToAction(nameof(Index));
            }

            return View(dance);
        }

        // GET: /Dance/Edit/5
        public IActionResult Edit(int id)
        {
            var dance = _dances.FirstOrDefault(d => d.CourseId == id);
            if (dance == null)
            {
                return NotFound();
            }
            return View(dance);
        }

        // POST: /Dance/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Dance dance)
        {
            if (id != dance.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingDance = _dances.FirstOrDefault(d => d.CourseId == id);
                if (existingDance == null)
                {
                    return NotFound();
                }

                // Обновляем все поля
                existingDance.FIO = dance.FIO;
                existingDance.Age = dance.Age;
                existingDance.StyleDance = dance.StyleDance;
                existingDance.StartDate = dance.StartDate;
                existingDance.ParentPhone = dance.ParentPhone;

                Debug.WriteLine($"Обновлена запись ID: {id}");

                return RedirectToAction(nameof(Index));
            }
            return View(dance);
        }

        // GET: /Dance/Delete/5
        public IActionResult Delete(int id)
        {
            var dance = _dances.FirstOrDefault(d => d.CourseId == id);
            if (dance == null)
            {
                return NotFound();
            }
            return View(dance);
        }

        // POST: /Dance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var dance = _dances.FirstOrDefault(d => d.CourseId == id);
            if (dance != null)
            {
                _dances.Remove(dance);
                Debug.WriteLine($"Удалена запись ID: {id}");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}