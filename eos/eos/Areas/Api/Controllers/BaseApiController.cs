using System;
using System.Linq;
using System.Web.Http;
using eos.Models.Users;

namespace eos.Areas.Api.Controllers
{
    public class BaseApiController : ApiController
    {
        public String ApiKey
        {
            get { return GetHeader("ApiKey"); }
        }

        public String UserId
        {
            get { return UserManager.FindByApiKey(ApiKey).Id; }
        }

        public String GetHeader(String name)
        {
            return (Request.Headers.All(t => t.Key != name))
                ? null
                : Request.Headers.GetValues(name).First();
        }
    }
}