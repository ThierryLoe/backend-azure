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
    public class DeleteUser
    {
        protected ThDbContext context;
        public DeleteUser(ThDbContext context)
        {
            this.context = context;
        }

        [FunctionName("delete")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "user")] HttpRequest req,
            ILogger log)
        {
            int id = Convert.ToInt32(req.Query["id"]);

            var person = new Person() { PersonId = id };

            context.Persons.Attach(person);
            person.Deleted = true;
            context.SaveChanges();
            
            return new OkResult();

        }
    }
}
