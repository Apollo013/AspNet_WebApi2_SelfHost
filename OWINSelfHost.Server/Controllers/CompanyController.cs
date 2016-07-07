using OWINSelfHost.Models.Models;
using OWINSelfHost.Server.Exceptions;
using OWINSelfHost.Server.Repository;
using System;
using System.Web.Http;

namespace OWINSelfHost.Server.Controllers
{
    public class CompanyController : BaseApiController
    {

        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(repo.Get(id));
            }
            catch (ObjectNotFoundException ex)
            {
                return NotFound(Request, ex.Message);
            }

        }

        public IHttpActionResult Get()
        {
            return Ok(repo.Get());
        }

        public IHttpActionResult Post(Company model)
        {
            try
            {
                return Ok(repo.Create(model));
            }
            catch (ObjectExistsException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Put(Company model)
        {
            try
            {
                return Ok(repo.Update(model).ToString());
            }
            catch (ObjectNotFoundException ex)
            {
                return NotFound(Request, ex.Message);
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                return Ok(repo.Delete(id));
            }
            catch (ObjectNotFoundException ex)
            {
                return NotFound(Request, ex.Message);
            }
        }
    }
}
