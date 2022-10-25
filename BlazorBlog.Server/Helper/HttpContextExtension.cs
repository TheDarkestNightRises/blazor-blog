using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace BlazorBlog.Server.Helper;

public static class HttpContextExtension
{
    public static async Task InsertPaginationParamaterInResponse<T>(this HttpContext httpContext,
        IQueryable<T> queryable,int recordsPerPage)
    {
        double count = await queryable.CountAsync();
        double pagesQuantity = Math.Ceiling(count / recordsPerPage);
        httpContext.Response.Headers.Add("pagesQuantity",pagesQuantity.ToString(CultureInfo.CurrentCulture));
    }
}