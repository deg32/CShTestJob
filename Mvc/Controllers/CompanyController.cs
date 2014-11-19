using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary;
using System.Data.Entity;

namespace Mvc.Controllers
{
    public class CompanyController : Controller
    {
        //
        // GET: /Company/

        //Вывод полного списка компаний
        public ActionResult Index()
        {

            CompanyService compserv = new CompanyService();

            List<Company> list = compserv.SelectAllCompanys();

            ViewBag.Result = list;

            return View();
        }

        //Вывод формы для добавления информации о компании
        
   
        public ActionResult Add()
        {

            return View();

        }


        //Добавление информации о компании в справочник компаний


        [HttpPost]
        public ActionResult AddView(Company company)


        {

            if (!string.IsNullOrEmpty(company.Name) && !string.IsNullOrEmpty(company.Address))
            {
                CompanyService compserv = new CompanyService();

                if (compserv.SearchCompany(company).Count != 0)
                {
                    ViewBag.Message = "Фирма с таким названием уже существует";

                }
                else
                {
                    compserv.AddCompany(company);
                }

            }
            else
            {
                ModelState.AddModelError("err", "Ошибка");

            }
            

            return View("AddView");

        }

     

        //Удаление информации о компании
        public ActionResult Delete(int id)
        {

            CompanyService compserv = new CompanyService();

            compserv.DeleteCompany(id);

            return RedirectToAction("Index");

        }


        //Вывод формы для редактирования информации о компании
        public ActionResult Edit(int id)
        {

            CompanyService compserv = new CompanyService();

            ViewBag.Result = compserv.SelectByIdCompany(id);

            return View();

        }


        //Сохранение отредактированной информации о компании
        public ActionResult SaveChanges(Company newcompany)
        {
            if (!string.IsNullOrEmpty(newcompany.Name) && !string.IsNullOrEmpty(newcompany.Address))
            {
                CompanyService compserv = new CompanyService();

                compserv.EditCompany(newcompany);
               
            }
            return RedirectToAction("Index");
        }


    }
}
