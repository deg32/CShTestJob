using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ProjectServices
    {
        public void AddProject(DevProject project)
        {

            using (var dbcont = new DbContextTestProg())
            {

                dbcont.Projects.Add(project);
                dbcont.SaveChanges();
            }

        }

        public List<DevProject> SelectAllProjects()
        {

            using (var dbcont = new DbContextTestProg())
            {
                var projects = (from p in dbcont.Projects select p).ToList();
                return projects;

            }

        }

    }
}
