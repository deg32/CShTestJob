using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    //класс для работы с компаниями
    public class CompanyService
    {

        //добавление компании
      public void AddCompany(Company company)
        {

            using (var dbcont = new DbContextTestProg())
            {
           
                dbcont.Companys.Add(company);
                dbcont.SaveChanges();
            } 

        }

        //вывод списка компаний
        public List<Company> SelectAllCompanys()
        {

            using (var dbcont = new DbContextTestProg())
            {
                var companys = (from c in dbcont.Companys select c).ToList();
                return companys;

            }

        }

        //Поиск компании

        public List<Company> SearchCompany(Company company)
        {

            using (var dbcont = new DbContextTestProg())
            {
                var PerformerList = (from c in dbcont.Companys orderby c.Id where c.Name == company.Name select c).ToList();
                return PerformerList;

            }

        }

        //удаление компании
        public void DeleteCompany(int id)
        {

            using (var dbcont = new DbContextTestProg())
            {
                var company = dbcont.Companys.FirstOrDefault(x => x.Id == id);

                if (company != null) 
                {
                    dbcont.Companys.Remove(company);
                    dbcont.SaveChanges();
                }


            }

        }

        //Выбор компании по заданному Id
      public Company SelectByIdCompany(int id)
      {
          using (var dbcont = new DbContextTestProg())
          {
              var company = dbcont.Companys.FirstOrDefault(x => x.Id == id);

              return company;
          }
      }

        //Редактирование данных о компании
      public void EditCompany(Company newcompany)
        {

            using (var dbcont = new DbContextTestProg())
            {
                var company = dbcont.Companys.FirstOrDefault(x => x.Id == newcompany.Id);
                if (company != null)
                {
                    company.Name = newcompany.Name;
                    company.Address = newcompany.Address;
                    company.Email = newcompany.Email;
                    dbcont.SaveChanges();
                }
            }

        }

    }
}
