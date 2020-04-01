using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Mall.Models
{
    public class ViewBook
    {

        //public IPagedList<T> Books { get; set; }
        public string Search { get; set; }

        public string Category { get; set; }
        public string SortBy { get; set; }
    }
}