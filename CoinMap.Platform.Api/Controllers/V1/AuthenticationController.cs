using Asp.Versioning;
using CoinMap.Platform.Api.Boundary.Request.Class;
using CoinMap.Platform.Api.Boundary.Response;
using CoinMap.Platform.Api.UseCase.Interface;
using CoinMap.Platform.Middleware.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CoinMap.Platform.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class AuthenticationController : Controller
    {
        private readonly IBaseUseCase<RegisterResponse> _registration;
        private readonly IBaseUseCase<LoginResponse> _login;

        public AuthenticationController(IBaseUseCase<RegisterResponse> registration, IBaseUseCase<LoginResponse> login)
        {
            this._registration = registration;
            this._login = login;
        }

        /// <summary>
        /// Endpoint for new user registration.
        /// </summary>
        ///<response code="400">The request is not valid according to requirements</response>
        ///<response code="500">Internal server error</response>
        ///<response code="200">The request is successful</response>
        [HttpPost]
        [Route("token")]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RegisterResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] LoginQuery user)
        {

            if (user == null)
            {
                return BadRequest();
            }

            var response = await this._login.ExecuteAsync(user).ConfigureAwait(false);

            return Ok(response);
        }

        /// <summary>
        /// Endpoint for new user registration.
        /// </summary>
        ///<response code="400">The request is not valid according to requirements</response>
        ///<response code="500">Internal server error</response>
        ///<response code="200">The request is successful</response>
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(RegisterResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Register([FromBody] RegisterQuery user)
        {

            if (user == null) 
            {
                return BadRequest();
            }

            var response = await this._registration.ExecuteAsync(user).ConfigureAwait(false);

            return Ok(response);
        }
    }
}
