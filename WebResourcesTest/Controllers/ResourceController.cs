using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebResourcesTest.Controllers
{
    public class ResourceController : Controller
    {
        // GET: Получить список всех ресурсов
        public ActionResult Index()
        {
            return View();
        }

        // POST: Создать ресурс (с возможностью предоставить начальное значение)
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

        // POST: Перезаписать ресурс
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

        // GET: ResourceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
