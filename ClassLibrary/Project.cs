using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ClassLibrary
{

    public enum Priority
    {
        Hight,
        Normal,
        Low
    }


    //класс Проект
    public class Project: BaseEntity
    {
        [Required]
        [DisplayName("Имя проекта")]
        public virtual string Name { set; get; }
        
        [Required]
        [DisplayName("Дата начала")]
        public virtual DateTime StartDate { set; get; }
        
        [Required]
        [DisplayName("Дата завершения")]
        public virtual DateTime FinishDate { set; get; }
        
        [Required]
        [DisplayName("Руководитель проекта")]
         public virtual Performer ProjectLeader { set; get; }
        
        [DisplayName("Компания заказчик")]
        public virtual Company ProjectCustomer { set; get; }
         
        [DisplayName("Компания исполнитель")]
        public virtual Company ProjectExecutor { set; get; }
         
        [DisplayName("Приоритет")]
        public virtual Priority ProjectPriority { set; get; }
        
        [DisplayName("Комментарий")]
        public virtual string Comment { set; get; }

         [Required]
        [DisplayName("Список исполнителей")]
        public virtual List<ProjectPerformer> Performers { set; get; }


        public Project() 
        {
            Performers = new List<ProjectPerformer>();
            StartDate= new DateTime(2014,1,1);
            StartDate = new DateTime(2014, 1, 1);
        }

    }
}
