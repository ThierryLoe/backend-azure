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
    public class GetUser
    {
        protected ThDbContext context;

        public GetUser(ThDbContext context)
        {
            this.context = context;
        }

        [FunctionName("GetUser")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "user/{id}")] HttpRequest req, int id,
            ILogger log)
        {
            
            //int id = Convert.ToInt32(req.Query["id"]);

            var person = context.Persons.FirstOrDefault(p => p.PersonId == id && p.Deleted == false);

            if (person != null)
            {
                return new OkObjectResult(person);
            }
            return new NotFoundResult();
        }
    }
}
