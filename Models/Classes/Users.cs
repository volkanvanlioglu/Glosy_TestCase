using System.ComponentModel.DataAnnotations;

namespace Glosy_TestCase.Models.Classes
{
    public class Users
    {
        [Key]
        public int ID { get; set; }
        public int RoleID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}