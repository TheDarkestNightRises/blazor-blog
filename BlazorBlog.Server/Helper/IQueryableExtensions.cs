using BlazorBlog.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorBlog.Server.Helper;

public static class IQueryableExtensions
{
    public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginationDto pagination)
    {
        return queryable.Skip((pagination.PageNumber - 1) * pagination.MaxPerPage).Take(pagination.MaxPerPage);
    }

}