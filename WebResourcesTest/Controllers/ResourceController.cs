using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebResourcesTest.Controllers
{
    public class ResourceController : Controller
    {
        private IMemoryCache memoryCache;

        public ResourceController(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        // GET: Получить список всех ресурсов
        [Route("Resource/GetResources")]
        [HttpGet]
        public List<string> GetResources()
        {
            try
            {
                List<string> cacheResources = new();
                bool existResources = memoryCache.TryGetValue("resources", out List<string> listResources);
                if (!existResources)
                {
                    listResources = (List<string>)cacheResources;
                    return listResources;
                }
                else
                {
                    return listResources;
                }
            }
            catch(Exception ex)
            {
                List<string> message = new() {ex.Message};
                return message;
            }
        }

        // POST: Создать ресурс (с возможностью предоставить начальное значение)
        [HttpPost]
        [Route("Resource/Create")]
        public string Create(string valueResources)
        {
            try
            {                
                memoryCache.TryGetValue("resources", out List<string> listResources);
                if(listResources == null)
                    listResources = new();
                if (valueResources == null)
                    return "Ресурс не добавлен! Не было указано значение.";
                listResources.Add(valueResources);
                memoryCache.Set("resources", listResources);
                return "Ресурс добавлен";
            }
            catch
            {
                return "Ошибка! Ресурс не добавлен.";
            }
        }

        //post: перезаписать ресурс
        [HttpPost]
        [Route("Resource/Edit")]
        public string Edit(int id, string valueResources)
        {
            try
            {
                memoryCache.TryGetValue("resources", out List<string> listResources);
                if (listResources == null)
                    return "Нет ресурсов для изменения";
                int counter = 0;
                for (int i = 0; i < listResources.Count; i++)
                {
                    if (i == id)
                    {
                        listResources[id] = valueResources;
                        counter += 1;
                    }
                }
                memoryCache.Set("resources", listResources);
                if (counter == 1)
                    return $"Ресурс под номером {id} изменен на {valueResources}.";
                else
                    return $"Ресурс под номером {id} не существует.";
            }
            catch
            {
                return "Ошибка! Ресурс не найден или значение не верно";
            }
        }

        //GET: Удалить ресурс по id
        [HttpPost]
        [Route("Resource/Delete")]
        public string Delete(int id)
        {
            try
            {
                memoryCache.TryGetValue("resources", out List<string> listResources);
                if (listResources == null)
                    return "Нет ресурсов для удаления";
                listResources.RemoveAt(id);
                return $"Ресурс под номером {id} удален.";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
