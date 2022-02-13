using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Ateliex.Api
{
    public static class AteliexApiConventions
    {
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        public static void Delete(
            //[ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
            int id)
        { }
    }
}
