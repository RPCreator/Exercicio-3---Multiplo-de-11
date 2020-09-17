using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exercicio_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberController : Controller
    {
        [HttpGet]
        public List<NumberObject> Get()
        {
            var JsonNumbers = Path.Combine(Directory.GetCurrentDirectory(), $".\\JsonFiles\\Numbers.json");

            var Numbers = System.IO.File.ReadAllText(JsonNumbers);     

            JObject NumbersArray = JObject.Parse(Numbers);

            List<NumberObject> result = new List<NumberObject>();

            ListNumberObject ListNumber = JsonConvert.DeserializeObject<ListNumberObject>(Numbers);
                 
            for (int i = 0; i < ListNumber.numbers.Count(); i++)
            {
                NumberObject n = new NumberObject();
                n.number = Convert.ToInt32(ListNumber.numbers[i]);
                n.isMultiple = true;
                if (n.number % 11 == 0)
                {
                     n.isMultiple = false;
                }
         
                result.Add(n);
            }

            return result;
        }
    }
}
