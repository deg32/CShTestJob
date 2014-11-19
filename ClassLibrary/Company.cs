using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary
{  
    
    //Описание компании
    public class Company : BaseEntity
    {

        [Required]
        [DisplayName("Название")]
        public virtual string Name { set; get; }
        
        [Required]
        [DisplayName("Адрес")]
        public virtual string Address { set; get; }
         [DisplayName("E-mail")]
        public virtual string Email { set; get; }

        public Company() { }
        public Company(string name, string adress, string email)
        {
            Name = name;
            Address = adress;
            Email = email;
        }

    }
}
