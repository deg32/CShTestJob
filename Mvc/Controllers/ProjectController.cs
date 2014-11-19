using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary;

namespace Mvc.Controllers
{
    public class ProjectController : Controller
    {
        //
        // GET: /Project/

        //Вывод списка проектов
        public ActionResult Index()
        {

            ProjectService projserv = new ProjectService();

            PerformerService perfserv = new PerformerService();

            List<ProjectModel> list = projserv.SelectAllProjects();

            ViewBag.Result = list;

            return View();
        }

        //Форма добавления нового проекта в справочник
        [HttpGet]
        public ActionResult AddView()
        {

            PerformerService perfserv = new PerformerService();

            CompanyService compserv = new CompanyService();

            ViewBag.Leaders = perfserv.SelectAllPerformers();

            ViewBag.CompaniesCustomers = compserv.SelectAllCompanys();

            ViewBag.Performers = perfserv.SelectAllPerformers();

            return View();
        }

        // Сохранение информации о новом проекте
        [HttpPost]
        public ActionResult AddView(Project project, int leaderid, int custid, int devid, int[] perfids)
        {
            if (!string.IsNullOrEmpty(project.Name) && project.StartDate < project.FinishDate)
            {
                ProjectService projserv = new ProjectService();



                projserv.AddProject(project, leaderid, custid, devid, perfids);

            }
            else
            {
                ModelState.AddModelError("err", "Ошибка");

            }

            //return RedirectToAction("AddView");
            PerformerService perfserv = new PerformerService();

            CompanyService compserv = new CompanyService();

            ViewBag.Leaders = perfserv.SelectAllPerformers();

            ViewBag.CompaniesCustomers = compserv.SelectAllCompanys();

            ViewBag.Performers = perfserv.SelectAllPerformers();
            return View(project);


        }



        //Удаление информации о проекте
        public ActionResult Delete(int id)
        {

            ProjectService projserv = new ProjectService();

            projserv.DeleteProject(id);

            return RedirectToAction("Index");
        }


        // Вывод сортированного по имени списка проектов
        public ActionResult SortByProjectName()
        {

            ProjectService projserv = new ProjectService();

        

            List<ProjectModel> list = projserv.SortProjectBy("Name");

            ViewBag.Result = list;
            //return RedirectToAction("Index");
            return View();
        }


        //Удаление исполнителя из проекта
         public ActionResult RemovePervormersFromProject(int project_id, int performer_id)
        {

            ProjectService projserv = new ProjectService();
            projserv.DeleteProjectPerformers(project_id, performer_id);

            return RedirectToAction("Index");

        }

        //Вывод списка исполнителей проекта для удаления
         public ActionResult RemoveUserList(int project_id)
         {

             ProjectService projserv = new ProjectService();

             PerformerService perfserv = new PerformerService();
                       

             List<Performer> list = perfserv.SelectProjectPerformers(project_id);

             ViewBag.Result = list;
             ViewBag.ProjectId = project_id;

             return View();
         }




         public ActionResult EditProject(int project_id)
         {

                        
            ProjectService projserv = new ProjectService();

            PerformerService perfserv = new PerformerService();

            List<ProjectModel> list = projserv.SelectAllProjects();

            CompanyService compserv = new CompanyService();

            ViewBag.Leaders = perfserv.SelectAllPerformers();

            ViewBag.CompaniesCustomers = compserv.SelectAllCompanys();

            ViewBag.Performers = perfserv.SelectAllPerformers();


             ViewBag.Result=(from l in list where l.Project.Id==project_id select l).ToList();
                         
             ViewBag.ProjectId = project_id;

             ViewBag.ProjectName = projserv.SelectByIdProject(project_id).Name;

             return View();
         }



        //сохранение изменений в проекте
         public ActionResult SaveEditProject(Project project,  int leaderid, int custid, int devid, int[] perfids)
         {                                                        

             return RedirectToAction("Index");
         }

    }
}
