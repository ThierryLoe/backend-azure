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
   
    public class update
    {
        protected ThDbContext context;
        public update(ThDbContext context)
        {
            this.context = context;
        }

        [FunctionName("put")]
        public async Task<IActionResult> Run(
                 [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "user/{id}")] HttpRequest req, int id,
                 ILogger log)
        {
            string firstname = (req.Query["FirstName"]);
            string lastName = (req.Query["LastName"]);

            var person = context.Persons.Where(p => p.PersonId == id).FirstOrDefault();
            try
            {
                person.FirstName = firstname;
                person.LastName = lastName;
                context.SaveChanges();
            }catch (Exception ex)
            {
                return new NotFoundObjectResult(ex.Message);
            }
            return new OkResult();
        }
    }
}
