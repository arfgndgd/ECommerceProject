using Bogus.DataSets;
using Project.COMMON.Tools;
using Project.DAL.ContextClasses;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.StrategyPatterns
{

    //Bogus kütüphanesi bize hazır Data sunar. Test için yazılımcı dostu bir kütüphanedir. candır.

    //MyInit kullanırken Migrate yapmak sağolıklı değildir. Tek yolda bu değildir.
    //Eğer zaten düzgün bir CodeFirst yazdı isek ilgili veritabanına gelecek tek bir istek Databasein oluşması için yeterlidir.
    public class MyInit:CreateDatabaseIfNotExists<MyContext> //Eğer Database yok işe çalışacak olan yapı

    //DataBase'e tam olusurken veri ekleyebilmek adına Seed metodunu override etmeliyiz...
    {
        protected override void Seed(MyContext context)
        {
            #region Admin
            AppUser au = new AppUser();
            au.UserName = "arif123";
            au.Password = DantexCrypt.Crypt("123");
            au.Email = "gundogduarif4@gmail.com";
            au.Role = ENTITIES.Enums.UserRole.Admin;
            context.AppUsers.Add(au);
            context.SaveChanges();
            #endregion


            for (int i = 0; i < 10; i++)
            {
                AppUser ap = new AppUser();
                ap.UserName = new Internet("tr").UserName();
                ap.Password = new Internet("tr").Password();
                ap.Email = new Internet("tr").Email();
                context.AppUsers.Add(ap);

            }
            context.SaveChanges();

            for (int i =2; i < 12; i++)
            {
                UserProfile up = new UserProfile();
                up.ID = i; //Birebir ilişkiden dolayı üst tarafta olullturulan AppUserların Idleri ile bunlar eşleşmeli. Bu yüzden döngü iterasyonunu 2den başlattık
                up.FirstName = new Name("tr").FirstName();
                up.LastName = new Name("tr").LastName();
                up.Address = new Address("tr").Locale;
                context.UserProfiles.Add(up);
            }
            context.SaveChanges();

            for (int i = 0; i < 10; i++)
            {
                Category c = new Category();
                c.CategoryName = new Commerce("tr").Categories(1)[0];
                c.Description = new Lorem("tr").Sentence(10);

                for (int j = 0; j < 30; j++)
                {
                    Product p = new Product();
                    p.ProductName = new Commerce("tr").ProductName();
                    p.UnitPrice = Convert.ToDecimal(new Commerce("tr").Price());
                    p.UnitsInStock = 100;
                    p.ImagePath = new Images().Nightlife();
                    c.Products.Add(p);
                }

                context.Categories.Add(c);
                context.SaveChanges();



            }
        }
    }
}
