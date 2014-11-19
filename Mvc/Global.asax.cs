using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;


using System.Data.Entity;
using ClassLibrary;
using System.Data.Entity.Infrastructure;


namespace Mvc
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            
            Database.SetInitializer<DbContextTestProg>(null);

            //проверка и создание базы
            try
            {
                using (var context = new DbContextTestProg())
                {
                    if (!context.Database.Exists())
                    {
                        
                           ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                    }
                }
                             
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Не удалось инициализировать базу данных.", ex);
            }

        }
    }
}