using Microsoft.AspNetCore.Mvc;
using IT_Lab.Models;
using IT_Lab.Services;
using System.Linq;

namespace IT_Lab.Controllers
{
    public class TablesController : Controller
    {
        private readonly DatabaseService _dbService;

        public TablesController(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        // GET: Tables
        public IActionResult Index()
        {
            var tables = _dbService.LoadDatabase();
            return View(tables);
        }

        // GET: Tables/Create
        public IActionResult CreateTable()
        {
            return View();
        }

        // POST: Tables/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTable(TableModel model)
        {
            if (ModelState.IsValid)
            {
                var tables = _dbService.LoadDatabase();

                // Перевірка на унікальність імені таблиці
                if (tables.Any(t => t.Name.Equals(model.Name, System.StringComparison.OrdinalIgnoreCase)))
                {
                    ModelState.AddModelError("Name", "Така таблиця вже існує.");
                    return View(model);
                }

                tables.Add(model);
                _dbService.SaveDatabase(tables);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Tables/Edit/Name
        public IActionResult EditTable(string name)
        {
            var tables = _dbService.LoadDatabase();
            var table = tables.FirstOrDefault(t => t.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
            if (table == null)
            {
                return NotFound();
            }
            return View(table);
        }

        // POST: Tables/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTable(TableModel model)
        {
            if (ModelState.IsValid)
            {
                var tables = _dbService.LoadDatabase();
                var table = tables.FirstOrDefault(t => t.Name.Equals(model.Name, System.StringComparison.OrdinalIgnoreCase));

                if (table != null)
                {
                    table.Columns = model.Columns;
                    table.Rows = model.Rows;
                    _dbService.SaveDatabase(tables);
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }
            return View(model);
        }

        // GET: Tables/Delete/Name
        public IActionResult DeleteTable(string name)
        {
            var tables = _dbService.LoadDatabase();
            var table = tables.FirstOrDefault(t => t.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
            if (table == null)
            {
                return NotFound();
            }
            return View(table);
        }

        // POST: Tables/Delete/Name
        [HttpPost, ActionName("DeleteTable")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string name)
        {
            var tables = _dbService.LoadDatabase();
            var table = tables.FirstOrDefault(t => t.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
            if (table != null)
            {
                tables.Remove(table);
                _dbService.SaveDatabase(tables);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
