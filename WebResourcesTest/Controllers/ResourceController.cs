using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebResourcesTest.Controllers
{
    [Route("Resource/GetResources")]
    public class ResourceController : Controller
    {
        private IMemoryCache memoryCache;

        public ResourceController(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        // GET: Получить список всех ресурсов
        [HttpGet]
        public List<string> GetResources()
        {
            List<string> cacheResources = new();
            bool existResources = memoryCache.TryGetValue("resources", out List<string> listResources);
            if(!existResources)
            {
                listResources = (List<string>)cacheResources;
                return listResources; 
            }
            else
            {
                return listResources;
            }                       
        }

        // POST: Создать ресурс (с возможностью предоставить начальное значение)
        [HttpPost]
        public bool Create(string valueResources)
        {
            try
            {                
                memoryCache.TryGetValue("resources", out List<string> listResources);
                if(listResources == null)
                {
                    listResources = new();
                }
                listResources.Add(valueResources);
                memoryCache.Set("resources", listResources);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //// post: перезаписать ресурс
        //[httppost]
        //public actionresult edit(int id, iformcollection collection)
        //{
        //    try
        //    {
        //        return redirecttoaction(nameof(getresources));
        //    }
        //    catch
        //    {
        //        return view();
        //    }
        //}

        // GET: Удалить ресурс по id
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}
    }
}
