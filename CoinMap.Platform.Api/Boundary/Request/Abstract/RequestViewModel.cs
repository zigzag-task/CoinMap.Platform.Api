using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CoinMap.Platform.Api.Boundary.Request.Abstract
{
    public abstract class RequestViewModel
    {
        [BindNever]
        public virtual string RequestId => new HttpContextAccessor().HttpContext!.TraceIdentifier;
    }
}
