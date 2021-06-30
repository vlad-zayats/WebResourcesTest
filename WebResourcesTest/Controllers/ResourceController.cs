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
        public object GetResources()
        {
            List<string> cacheResources = new();
            bool existResources = memoryCache.TryGetValue("resources", out object listResources);
            if(!existResources)
            {
                listResources = (object)cacheResources;
                return listResources; 
            }
            else
            {
                return listResources;
            }                       
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

        // GET: Удалить ресурс по id
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
