using System.ComponentModel.DataAnnotations;

namespace s4_lab5.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Phone Phone { get; set; }

        public Contact()
        {
        }

        public Contact(int id, string name, string surname, Phone phone)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Phone = phone;
        }

        public Contact(string name, string surname, Phone phone)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
        }
    }
}
