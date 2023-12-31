using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ICloudNetworkApp.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        [NonAction]
        public IActionResult Problem(List<Error> errors)
        {

            if (errors.Count is 0)
            {
                return Problem();
            }

            foreach (Error error in errors)
            {

                if (error.Type == ErrorType.Unexpected)
                {
                    string errorMessage = $"{error.Code}: {error.Description}";
                    return BadRequest(errorMessage);
                }

                if (error.Type == ErrorType.Unauthorized && error.Code == "401")
                {
                    return Unauthorized();
                }

                if (error.Type == ErrorType.Validation)
                {
                    return ValidationProblem(errors);
                }

                return Unauthorized();
            }

            return Problem();
        }

        [NonAction]
        internal IActionResult ValidationProblem(List<Error> errors)
        {
            var modelStateDictionary = new ModelStateDictionary();
            foreach (var error in errors)
            {
                modelStateDictionary.AddModelError(
                    error.Code,
                    error.Description
                );
            }
            return ValidationProblem(modelStateDictionary);
        }
    }
}
