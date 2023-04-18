using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_PT_WinForms_2_2
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public User(string firstName, string lastName, string email, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }

        public override string ToString()
        {
            return $"{"Имя: " + FirstName} { "Фамилия: "+LastName}, {"Email: "+Email}, {"Телефон: "+Phone}";
        }
    }
}
