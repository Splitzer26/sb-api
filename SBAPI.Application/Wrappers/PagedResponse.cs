using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAPI.Application.Wrappers
{
    public class PagedResponse<T>:Response<T>
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalItems { get; set; }

        public PagedResponse(T data, int pageNumber, int pageSize, int totalItems)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Data = data;
           // this.Message = null;
            this.Succeeded = true;
           // this.Errors = null;
            this.TotalItems = totalItems;
        }
    }
}
