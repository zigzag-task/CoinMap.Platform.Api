using Asp.Versioning;
using CoinMap.Platform.Api.Boundary.Request.Class;
using CoinMap.Platform.Api.Boundary.Response;
using CoinMap.Platform.Api.UseCase.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoinMap.Platform.Api.Controllers.V1
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/venue")]
    public class VenueController : Controller
    {
        private readonly IBaseUseCase<IEnumerable<VenueResponse>> _getAllByCategory;

        public VenueController(IBaseUseCase<IEnumerable<VenueResponse>> getAllByCategory)
        {
            this._getAllByCategory = getAllByCategory;
        }

        /// <summary>
        /// This Endpoint returns a list of all venues by category name.
        /// </summary>
        ///<response code="401">Unauthorized</response>
        ///<response code="403">Forbidden</response>
        ///<response code="404">Resourse can't be found</response>
        ///<response code="400">The request is not valid according to requirements</response>
        ///<response code="500">Internal server error</response>
        ///<response code="200">Returns list of all categories</response>
        [HttpGet]
        [Route("category/{category}")]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<VenueResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllByCategory([FromRoute] string category)
        {

            if (string.IsNullOrEmpty(category)) 
            {
                return BadRequest("The request is not valid according to requirements");
            }

            VenueQuery query = new VenueQuery() { Category = category };

            var venues = await this._getAllByCategory.ExecuteAsync(query).ConfigureAwait(false);

            if (venues == null || !venues.Any()) 
            {
                return NotFound("Resourse can't be found");
            }

            return Ok(venues);
        }
    }
}
