using System.Collections.Generic;
using System.Linq;

namespace GenericsExample
{
    // <T> means a type parameter
    public class Pager<T>
    {
        private List<T> _allRecords { get; set; }
        // current page is 0/ on the first page.
        public int CurrentPage { get; set; }
        public int RecordsPerPage { get; set; } = 5;

        public Pager(List<T> allRecords)
        {
            _allRecords = allRecords;
        }
        public List<T> GetCurrentPage()
        {
            var skipAmount = CurrentPage * RecordsPerPage;
            return _allRecords
                .Skip(skipAmount)
                .Take(RecordsPerPage)
                .ToList();
        }
        public List<T> GetPreviousPage()
        {
            CurrentPage--;
            return GetCurrentPage();
        }

        public List<T> GetNextPage()
        {
            CurrentPage++;
            return GetCurrentPage();
        }
    }
}