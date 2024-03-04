using System.Net;
using Asp.Versioning;
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
    [Route("api/{version:apiVersion}")]
    public class CategoryController : Controller
    {
        private readonly IBaseUseCase<IEnumerable<CategoryResponse>> _getAllCategory;

        public CategoryController(IBaseUseCase<IEnumerable<CategoryResponse>> getAllCategory)
        {
            this._getAllCategory = getAllCategory;
        }

        /// <summary>
        /// This Endpoint returns a list of all categories.
        /// </summary>
        ///<response code="401">Unauthorized</response>
        ///<response code="403">Forbidden</response>
        ///<response code="204">There is no content</response>
        ///<response code="500">Internal server error</response>
        ///<response code="200">Returns list of all categories</response>
        [HttpGet]
        [Route("category")]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<CategoryResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCategory()
        {

            var categories = await this._getAllCategory.ExecuteAsync(default).ConfigureAwait(false);

            if (categories == null || !categories.Any())
            {
                return NoContent();
            }

            return Ok(categories);
        }
    }
}
