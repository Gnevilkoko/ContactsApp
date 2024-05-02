using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s4_lab5.Models
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }
        public string Number {  get; set; }

        public int ContactId { get; set; }
        public Contact Contact { get; set; }

        public override string? ToString()
        {
            return Number;
        }
    }
}
