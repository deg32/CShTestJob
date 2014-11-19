using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    //класс для работы с исполнителями
    public class PerformerService
    {
        public void AddPerformer(Performer performer)
        {

            using (var dbcont = new DbContextTestProg())
            {
           
                dbcont.Performers.Add(performer);
                dbcont.SaveChanges();
            } 

        }


        public List<Performer> SelectAllPerformers()
        {

            using (var dbcont = new DbContextTestProg())
            {
                var performers = (from p in dbcont.Performers orderby p.Name select p).ToList();
                return performers;

            }

        }

        public List<Performer> SelectProjectPerformers(int project_id)
        {

            using (var dbcont = new DbContextTestProg())
            {
                var performers=(from pp in dbcont.ProjectPerformer where pp.Project.Id==project_id select pp.Performer).ToList();
                             
                
                
                return performers;

            }

        }





        public List<Performer> SearchPerformer(Performer performer)
        {

         using (var dbcont = new DbContextTestProg())
            {
              var PerformerList = (from p in dbcont.Performers orderby p.Id where p.Surname == performer.Surname where p.Name==performer.Name where p.Patronymic==performer.Patronymic select p).ToList();
                return PerformerList;

            }

        }
        public void DeletePerformer(int id)
        {

            using (var dbcont = new DbContextTestProg())
            {
                var performer = dbcont.Performers.FirstOrDefault(x => x.Id == id);

                if (performer != null) 
                { 
                    dbcont.Performers.Remove(performer);
                    dbcont.SaveChanges();
                }


            }

        }

      public Performer SelectByIdPerformer(int id)
      {
          using (var dbcont = new DbContextTestProg())
          {
              var performer = dbcont.Performers.FirstOrDefault(x => x.Id == id);
             
              return performer;
          }
      }


        public void EditPerformer(Performer newperformer)
        {

            using (var dbcont = new DbContextTestProg())
            {
                var performer = dbcont.Performers.FirstOrDefault(x => x.Id == newperformer.Id);
                if (performer != null)
                {
                    performer.Name = newperformer.Name;
                    performer.Surname = newperformer.Surname;
                    performer.Patronymic = newperformer.Patronymic;
                    performer.Email = newperformer.Email;
                    dbcont.SaveChanges();
                }
            }

        }

    }
}
