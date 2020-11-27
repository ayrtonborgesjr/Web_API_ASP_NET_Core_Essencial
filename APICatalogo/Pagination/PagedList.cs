using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogo.Pagination
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }

        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;

        public PagedList(List<T> items, int totalSourceItems, int pageNumber, int pageSize)
        {
            TotalCount = totalSourceItems;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int) Math.Ceiling(totalSourceItems / (double) pageSize);

            AddRange(items);
        }

        public async static Task<PagedList<T>> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            int totalSourceItems = source.Count();
            var items = await source.Skip((pageNumber -1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedList<T>(items, totalSourceItems, pageNumber, pageSize);
        }
    }
}
