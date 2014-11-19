using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ClassLibrary
{
    public class ProjectService
    {
        //Добавление нового проекта
        public void AddProject(Project project, int leaderid, int custid, int devid, int[] perfids)
        {

            using (var dbcont = new DbContextTestProg())
            {
                
                project.ProjectLeader = dbcont.Performers.Find(leaderid);

                project.ProjectCustomer = dbcont.Companys.Find(custid);

                project.ProjectExecutor = dbcont.Companys.Find(devid);

                foreach (int id in perfids)
                {

                    ProjectPerformer projperf = new ProjectPerformer();

                    projperf.Project = project;

                    projperf.Performer = dbcont.Performers.Find(id);

                    project.Performers.Add(projperf);

                }

                dbcont.Projects.Add(project);
                dbcont.SaveChanges();

            }

        }

        //Выбор проекта по Id
        public Project SelectByIdProject(int id)
        {
            using (var dbcont = new DbContextTestProg())
            {
                var project = dbcont.Projects.FirstOrDefault(x => x.Id == id);

                return project;
            }
        }

    

        //создание списка всех исполнителей проекта
        public string SelectAllProjectPerformers(int id)
        {
            using (var dbcont = new DbContextTestProg())
            {

                string listofperformers = "";

                var project = dbcont.Projects.FirstOrDefault(x => x.Id == id);

                foreach (var p in project.Performers)
                {

                    listofperformers += p.Performer.Surname + " " + p.Performer.Name + " " + p.Performer.Patronymic;

                }

                return listofperformers;
            }
        }


        //Cортировка проектов
        public List<ProjectModel> SortProjectBy(string sorttype) 
        {
            ProjectService projserv = new ProjectService();


            using (var dbcont = new DbContextTestProg())
            {
                var projects = (from p in dbcont.Projects orderby p.Name
                                select new
                                {
                                    Project = p,
                                    ProjectLeader = p.ProjectLeader.Surname + " " + p.ProjectLeader.Name,
                                    CompanyCustomer = p.ProjectCustomer.Name,
                                    ProjectExecutor = p.ProjectExecutor.Name,
                                    ProjectPerformers = p.Performers
                                }).ToList().Select(xx => new ProjectModel
                                {
                                    Project = xx.Project,
                                    ProjectLeader = xx.ProjectLeader,
                                    CompanyCustomer = xx.CompanyCustomer,
                                    ProjectExecutor = xx.ProjectExecutor,
                                    ProjectPerformers = xx.ProjectPerformers.Select(x => x.Performer).Select(x => x.Name + " " + x.Patronymic + " " + x.Surname).Aggregate((curr, next) => string.Format("{0}; {1}", curr, next))
                                });


                return projects.ToList();

            }

        }

        // Выбор всех существующих проектов
        public List<ProjectModel> SelectAllProjects()
        {
            ProjectService projserv = new ProjectService();


            using (var dbcont = new DbContextTestProg())
            {
                var projects = (from p in dbcont.Projects
                                select new 
                                {
                                    Project = p,
                                    ProjectLeader = p.ProjectLeader.Surname + " " + p.ProjectLeader.Name,
                                    CompanyCustomer = p.ProjectCustomer.Name,
                                    ProjectExecutor = p.ProjectExecutor.Name,
                                    ProjectPerformers = p.Performers
                                }).ToList().Select(xx=>new ProjectModel
                                {
                                    Project = xx.Project,
                                    ProjectLeader = xx.ProjectLeader,
                                    CompanyCustomer = xx.CompanyCustomer,
                                    ProjectExecutor = xx.ProjectExecutor,
                                  
                                    ProjectPerformers = (xx.ProjectPerformers != null && xx.ProjectPerformers.Any())
                                                            ? xx.ProjectPerformers.Select(x => x.Performer).Select(x => x.Name + " " + x.Patronymic + " " + x.Surname).Aggregate((curr, next) => string.Format("{0}; {1}", curr, next))
                                                            : string.Empty

                                });


                return projects.ToList();

            }

        }


        //Удаление проекта
        public void DeleteProject(int id)
        {

            using (var dbcont = new DbContextTestProg())
            
            {
                foreach (var removeItem in dbcont.ProjectPerformer.Where(x => x.Project.Id == id).ToList())
                {
                    dbcont.ProjectPerformer.Remove(removeItem);
                }

                var project = dbcont.Projects.FirstOrDefault(x => x.Id == id);

                if (project != null)
                {
                    dbcont.Projects.Remove(project);

                    dbcont.SaveChanges();
                }


            }

        }


        //Удаление исполнителя проекта
        public void DeleteProjectPerformers(int project_id, int performer_id)
        {

            using (var dbcont = new DbContextTestProg())
            {

                var projectperformer = dbcont.ProjectPerformer.FirstOrDefault(x => x.Project.Id == project_id && x.Performer.Id == performer_id);


                if (projectperformer != null)
                {
                    dbcont.ProjectPerformer.Remove(projectperformer);

                    dbcont.SaveChanges();
                }


            }

        }

       
    }
       
 }
