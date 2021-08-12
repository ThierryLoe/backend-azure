using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;

namespace backend
{
    public class Function2
    {
        protected ThDbContext context;

        public Function2(ThDbContext context)
        {
            this.context = context;
        }

        [FunctionName("Function2")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            
            int id = Convert.ToInt32(req.Query["id"]);

            var person = context.Persons.FirstOrDefault(p => p.PersonId == id);

            return new OkObjectResult(person);
        }
    }
}
