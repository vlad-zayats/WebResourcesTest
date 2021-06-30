using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebResourcesTest.Controllers
{
    [Route("Resource/Resources")]
    public class ResourceController : Controller
    {
        private IMemoryCache memoryCache;

        public ResourceController(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        // GET: Получить список всех ресурсов
        [HttpGet]
        public string GetResources()
        {
            return "OK";
        }

        // POST: Создать ресурс (с возможностью предоставить начальное значение)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(GetResources));
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
                return RedirectToAction(nameof(GetResources));
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
