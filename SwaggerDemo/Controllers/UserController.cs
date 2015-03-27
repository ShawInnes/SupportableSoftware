using System.Collections.Generic;
using System.Web.Http;
using SwaggerDemo.Models;

namespace SwaggerDemo.Controllers
{
    public class UserController : ApiController
    {
        public void Put(User user)
        {
        }

        public IEnumerable<User> Get()
        {
            return new List<User>();
        }

        public bool Login(User user)
        {
            return true;
        }
    }
}