using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.VIEWMODEL.ViewModels
{
    public class PaymentVM
    {
        //Sanal Post Entegrasyonu

        //Normal şartlarda bu gibi sınıflar çalıştığımız bankadan aldığımız dökümantasyonun kılavuzluğu sayesinde oluşturulur. Ancak bu bir similasyon olduğu için propertyleri kendimiz belirledik

        public int ID { get; set; }
        public string CardUserName { get; set; }
        public string SecurityNumber { get; set; }

        public string CardNumber { get; set; }
        public int CardExpiryMonth { get; set; }
        public int CardExpiryYear { get; set; }
        public decimal ShoppingPrice { get; set; }
    }
}
