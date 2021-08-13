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
    public class AllUsers
    {
        protected ThDbContext context;

        public AllUsers(ThDbContext context)
        {
            this.context = context;
        }

        [FunctionName("AllUsers")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "user")] HttpRequest req,
            ILogger log)
        {
            var person = context.Persons.Where(p => p.Deleted == false).ToList();

            return new OkObjectResult(person);
        }
    }
}
