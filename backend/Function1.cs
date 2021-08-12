using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace backend
{
    public class Function1
    {
        protected ThDbContext context;

        public Function1(ThDbContext context)
        {
            this.context = context;
        }

        [FunctionName("Function1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string firstname = req.Query["firstname"];
            string lastname = req.Query["lastname"];

            var person = new Person();
            person.FirstName = firstname;
            person.LastName = lastname;

            context.Persons.Add(person);
            context.SaveChanges();

            return new OkResult();
        }
    }
}
