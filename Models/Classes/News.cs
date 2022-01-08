using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Glosy_TestCase.Models.Classes
{
    public class News
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [AllowHtml]
        public string Detail { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
    }
}