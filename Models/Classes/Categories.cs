using System.ComponentModel.DataAnnotations;

namespace Glosy_TestCase.Models.Classes
{
    public class Categories
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}