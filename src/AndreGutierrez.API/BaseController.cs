using AndreGutierrez.API.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AndreGutierrez.API
{
    public abstract class BaseController : ControllerBase
    {
        public BaseController()
        {
        }

        [NonAction]
        public ActionResult ArgumentExceptionHandling(Exception ex)
        {
            var response = new ResponseBase(ex);
            return BadRequest(response);
        }

        [NonAction]
        public ActionResult ExceptionHandling(Exception ex)
        {
            var response = new ResponseBase(ex);
            return StatusCode((int)HttpStatusCode.InternalServerError, response);
        }

        [NonAction]
        public ActionResult AuthenticationExceptionHandling(Exception ex)
        {
            var response = new ResponseBase(ex);
            return StatusCode((int)HttpStatusCode.Unauthorized, response);
        }
    }
}
