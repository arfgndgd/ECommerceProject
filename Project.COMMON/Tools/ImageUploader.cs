using System;
using System.Collections.Generic;
using System.IO;//input output kütüphanesidir. Bilgisayarımız içerisinde dosya işlemleri(modifikasyon okuma) için kullanılır
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Project.COMMON.Tools
{
    public static class ImageUploader
    {
        //Metod geriye string döndürecek

        //HttpPostedFileBase => MVC'de bir dosya post edilmek isteniyorsa bu tipteki bir nesne tarafından karşılanır.

        //Aşağıdaki HttpPostedFileBase tipi çağırabilmek için System.Web kütüphanesini eklemeyi unutmayın(artık DLL uzantısı gözükmemektedir)

        public static string UploadImage(string serverPath, HttpPostedFileBase file)
        {
            if (file != null)
            {
                Guid uniqueName = Guid.NewGuid();
                //~/Picture/Addadaf/uniqueGuid.jpg
                //~ Bulundupu prjeni kök dizini anlamına gelir
                //MVCde ~ karakteri normal bir şekilde kök dizine çık olarak @Url.Action kullanmadığımız sürece algılanmaz. Dolayısıyla bu string karakteri kaldırarak path düzenlememiz gerekir.
                serverPath = serverPath.Replace("~", string.Empty);

                string[] fileArray = file.FileName.Split('.');
                //Split, bize gelen string ifadeyi belirlediğimiz bir karakterden itibaren elemanlara böler(spor.futbol.galatasaray.png) ifadesini . ile böldüğümüzde karsımıza 3 elemanlı bir dizi çıkar.

                string extension = fileArray[fileArray.Length - 1].ToLower();

                string fileName = $"{uniqueName}.{extension}";

                if (extension == "jpg" || extension == "gif" || extension == "png" || extension == "jpeg")
                {
                    //System.IO kütüphanesi
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath + fileName)))
                    {
                        return "1";//Guid kullandığımız için aynı ismin tekrarlanmaması konusunda güvendeğiz. Yine de 1'i yani doya zaten var kodunu burada Algoritmik olarak çıkarmak zorundayız.
                    }
                    else
                    {
                        string filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);
                        file.SaveAs(filePath);
                        return serverPath + fileName;
                    }
                }
                else
                {
                    return "2"; //seçilen dosya uzantısı uygun değil     
                }
            }
            else
            {
                return "3";//dosya bos
            }
        }
        
    }
}
