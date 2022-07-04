using System.ComponentModel.DataAnnotations;
using System;
namespace Mbaku.Models
{
    public class Contacts
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        public string Department { get; set; }
    }
}