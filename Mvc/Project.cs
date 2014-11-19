using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public enum Priority
    {
        Hight,
        Normal,
        Low
    }
    public class Project : BaseEntity
    {
        public virtual string ProjectName { set; get; }
        public virtual DateTime StartDate { set; get; }
        public virtual DateTime FinishDate { set; get; }
        public virtual Performer ProjectLeader { set; get; }
        public virtual Company ProjectCustomer { set; get; }
        public virtual Company ProjectExecutor { set; get; }
        public virtual Priority ProjectPriority { set; get; }
        public virtual string Comment { set; get; }
        public virtual List<Performer> Performers { set; get; }



        public Project()
        {
            Performers = new List<Performer>();
        }
        public Project(string projectname, DateTime startdate, DateTime finishdate, Performer projectleader, Company projectcustomer,
                            Company projectexecutor, Priority projectpriorit, string comment, List<Performer> performers)
            : this()
        {
            ProjectName = projectname;
            StartDate = startdate;
            FinishDate = finishdate;
            ProjectLeader = projectleader;
            ProjectCustomer = projectcustomer;
            ProjectExecutor = projectexecutor;
            ProjectPriority = projectpriorit;
            Comment = comment;
            Performers = performers;

        }

    }
}
