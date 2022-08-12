using Pear.Africa.Assessment.Common.Features.Pagination;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pear.Africa.Assessment.Components.Pagination
{
    public class PagingResponse<T> where T : class
    {
        public List<T> Items { get; set; }
        public Paging Paging { get; set; }
    }
}
