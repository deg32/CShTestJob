using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ClassLibrary
{
    //класс Исполнители
    public class Performer : BaseEntity
    {
        [Required]
        [DisplayName("Имя")]
        public virtual string Name { set; get; }

        [Required]
        [DisplayName("Фамилия")]
        public virtual string Surname { set; get; }

        [Required]
        [DisplayName("Отчество")]
        public virtual string Patronymic { set; get; }

        [DisplayName("E-mail")]
        public virtual string Email { set; get; }
        
        [DisplayName("Руководитель")]
        public virtual bool isProjectLeader { set; get; }

       // public virtual List<Project> Projects { set; get; }
        public Performer() 
        {
           
        }
        public Performer(string name, string surname, string patromic, string email, bool isprojectleader)
        {
            Name = name;
            Surname = surname;
            Patronymic = patromic;
            Email = email;
            isProjectLeader = isprojectleader;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", Surname, Name, Patronymic);
        }


    }
}
