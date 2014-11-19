using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary;
using System.Data.Entity;


namespace Mvc.Controllers
{
    public class PerformerController : Controller
    {
        //
        // GET: /Performer/
        //Вывод полного списка исполнителей
        public ActionResult Index()
        {

            PerformerService perfserv = new PerformerService();
            
            List<Performer> list=perfserv.SelectAllPerformers();
            
            ViewBag.Result = list;
            
            return View();
        }

        //Добавление информации об исполнителе в справочник
        [HttpPost]
        public ActionResult AddView(Performer performer)
        {
            if (!string.IsNullOrEmpty(performer.Surname) && !string.IsNullOrEmpty(performer.Name)
                   && !string.IsNullOrEmpty(performer.Patronymic))
            {
                PerformerService perfserv = new PerformerService();

                if (perfserv.SearchPerformer(performer).Count != 0)
                {
                    ViewBag.Message = "Такой пользователь уже существует";

                }
                else
                {
                    perfserv.AddPerformer(performer);
                }
            }
           // return RedirectToAction("AddView");
            return View(performer);
        }
        

        //отображение формы ввода информации об исполнителе
        
            public ActionResult Add()
        {

                    
           return View();
          
            
        }

        //удаление информации об исполнителе из справочника
        public ActionResult Delete(int id)
        {

            PerformerService perfserv = new PerformerService();

            perfserv.DeletePerformer(id);
            
            return RedirectToAction("Index");

        }

        //Вывод формы для редактирования информации об исполнителе
        public ActionResult Edit(int id)
        {

            PerformerService perfserv = new PerformerService();

            ViewBag.Result = perfserv.SelectByIdPerformer(id);

            return View();

        }



        //Изменение информации об исполнителе
        public ActionResult SaveChanges(Performer performer)
        {
            if (!string.IsNullOrEmpty(performer.Surname) && !string.IsNullOrEmpty(performer.Name)
                              && !string.IsNullOrEmpty(performer.Patronymic))
            {

                PerformerService perfserv = new PerformerService();

                perfserv.EditPerformer(performer);
            }

            return RedirectToAction("Index");

        }



    }
}
