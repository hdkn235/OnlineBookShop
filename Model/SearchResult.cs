using System;
using System.Collections.Generic;
using System.Web;

namespace BookShop.Model
{
    public class SearchResult
    {
        public string Title { get; set; }
        public string ContentDescription { get; set; }
        public DateTime PublishDate { get; set; }
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public decimal UnitPrice { get; set; }
        public JobType JobType { get; set; }
    }

    public enum JobType
    {
        Add, Update, Delete
    }
}