using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace ClassLibrary
{
    public class DbContextTestProg : DbContext
    {
        public DbContextTestProg()
            : base("ProjectDb15")
        {
        }
                public DbSet<Performer> Performers { set; get;}
                public DbSet<Company> Companys { set; get; }
                public DbSet<Project> Projects { set; get; }
                public DbSet<ProjectPerformer> ProjectPerformer { set; get; }
        
    }
}
