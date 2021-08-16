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
    public class CreateUser
    {
        protected ThDbContext context;

        public CreateUser(ThDbContext context)
        {
            this.context = context;
        }

        [FunctionName("create")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "user")] HttpRequest req,
            ILogger log)
        {
            string firstname = req.Query["firstname"];
            string lastname = req.Query["lastname"];

            if (firstname != "" && lastname != "")
            {
                var person = new Person();
                person.FirstName = firstname;
                person.LastName = lastname;
                context.Persons.Add(person);
                await context.SaveChangesAsync();
            }
            else
            {
                return new BadRequestResult();
            }

            return new OkResult();
        }
    }
}
