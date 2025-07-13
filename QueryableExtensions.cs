namespace AspnetCoreMvcFull2
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int page, int pageSize)
        {
            page = Math.Max(1, page);
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
