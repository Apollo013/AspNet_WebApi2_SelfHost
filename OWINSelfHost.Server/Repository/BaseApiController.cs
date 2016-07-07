using OWINSelfHost.Server.ActionResults;
using System.Net.Http;
using System.Web.Http;

namespace OWINSelfHost.Server.Repository
{
    public class BaseApiController : ApiController
    {

        protected CompanyRepository repo;

        public BaseApiController()
        {
            repo = new CompanyRepository();
        }

        #region Custom Error Action Results
        protected static NotFoundActionResult NotFound(HttpRequestMessage request, string message)
        {
            return new NotFoundActionResult(request, message);
        }
        #endregion
    }
}
