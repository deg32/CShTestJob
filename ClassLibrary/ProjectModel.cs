using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{

    //Модель проекта для представления проекта с указанием  ФИО руководителя и списка исполнителей
    public class ProjectModel
    {
            public Project Project { get; set; }
            public string ProjectLeader { get; set; }
            public string CompanyCustomer { get; set; }
            public string ProjectExecutor { get; set; }
            public string ProjectPerformers { get; set; }

       
    }
}
