using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Caching;
using System.Web.Http;

namespace AppDemo.Controllers
{
    public class ValuesController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return GetValues();
        }

        public string Get(int id)
        {
            var values = GetValues();
            if (values == null)
            {
                return null;
            }

            return id > values.Count ? "out-of-range" : values[id];
        }

        private static IList<string> GetValues()
        {
            var context = HttpContext.Current;
            if (context == null)
            {
                return null;
            }

            var list = context.Cache.Get("__values__") as IList<string>;
            if (list != null)
            {
                return list;
            }

            var temp = ConfigurationManager.AppSettings["Values"];
            var tempArray = temp.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
            context.Cache.Insert("__values__", tempArray, null,
                DateTime.Now.AddDays(12),
                Cache.NoSlidingExpiration);

            return new List<string>(tempArray);            
        } 
    }
}
