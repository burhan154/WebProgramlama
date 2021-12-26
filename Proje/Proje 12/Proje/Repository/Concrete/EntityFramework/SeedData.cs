using Proje.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Repository.Concrete.EntityFramework
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices
                 .GetRequiredService<ElectronicContext>();

            context.Database.Migrate();

            if (!context.Products.Any())
            {
                var products = new[]
                {
                    new Product(){ ProductName="Dell Laptop", Stock=100,Price=10060, Image="photo7.jpg",IsHome=true,IsApproved=false,IsFeatured=true, Description="Laptops are folded shut for transportation, and thus are suitable for mobile use. Its name comes from lap, as it was deemed practical to be placed on a person's lap when being used.", HtmlContent="Laptops are folded shut for transportation, and thus are suitable for mobile use. Its name comes from lap, as it was deemed practical to be placed on a person's lap when being used.", DateAdded=DateTime.Now.AddDays(-30)},
                    new Product(){ ProductName="Asus Laptop", Stock=150,Price=16260, Image="photo4.jpg",IsHome=true,IsApproved=false,IsFeatured=true, Description="Laptops are folded shut for transportation, and thus are suitable for mobile use. Its name comes from lap, as it was deemed practical to be placed on a person's lap when being used.", HtmlContent="Laptops are folded shut for transportation, and thus are suitable for mobile use. Its name comes from lap, as it was deemed practical to be placed on a person's lap when being used.", DateAdded=DateTime.Now.AddDays(-30)},
                    new Product(){ ProductName="Lenovo Laptop", Stock=200,Price=18260, Image="photo2.jpg",IsHome=true,IsApproved=false,IsFeatured=true, Description="Laptops are folded shut for transportation, and thus are suitable for mobile use. Its name comes from lap, as it was deemed practical to be placed on a person's lap when being used.", HtmlContent="Laptops are folded shut for transportation, and thus are suitable for mobile use. Its name comes from lap, as it was deemed practical to be placed on a person's lap when being used.", DateAdded=DateTime.Now.AddDays(-30)},
                    new Product(){ ProductName="Huawei Laptop", Stock=100,Price=15260, Image="photo3.jpg",IsHome=true,IsApproved=false,IsFeatured=true, Description="Laptops are folded shut for transportation, and thus are suitable for mobile use. Its name comes from lap, as it was deemed practical to be placed on a person's lap when being used.", HtmlContent="Laptops are folded shut for transportation, and thus are suitable for mobile use. Its name comes from lap, as it was deemed practical to be placed on a person's lap when being used.", DateAdded=DateTime.Now.AddDays(-30)},
                    new Product(){ ProductName="Oppo Earphone",Stock=70, Price=125, Image="earphone15.jpg",IsHome=true,IsApproved=true,IsFeatured=true, Description="Earphone is used for listening music on phones or another electronic devices.", HtmlContent="Earphone is used for listening music on phones or another electronic devices.", DateAdded=DateTime.Now.AddDays(-5)},
                    new Product(){ ProductName="Samsung Earphone",Stock=70, Price=125, Image="earphone11.jpg",IsHome=true,IsApproved=true,IsFeatured=true, Description="Earphone is used for listening music on phones or another electronic devices.", HtmlContent="Earphone is used for listening music on phones or another electronic devices.", DateAdded=DateTime.Now.AddDays(-5)},
                    new Product(){ ProductName="Huawei Earphone",Stock=85, Price=280, Image="earphone10.jpg",IsHome=true,IsApproved=true,IsFeatured=true, Description="Earphone is used for listening music on phones or another electronic devices.", HtmlContent="Earphone is used for listening music on phones or another electronic devices.", DateAdded=DateTime.Now.AddDays(-5)},
                    new Product(){ ProductName="JBL Earphone",Stock=100, Price=1250, Image="earphone13.jpg",IsHome=true,IsApproved=true,IsFeatured=true, Description="Earphone is used for listening music on phones or another electronic devices.", HtmlContent="Earphone is used for listening music on phones or another electronic devices.", DateAdded=DateTime.Now.AddDays(-5)},
                    new Product(){ ProductName="Asus Monitor",Stock=90, Price=2500, Image="monitor5.jpg",IsHome=true,IsApproved=true,IsFeatured=true, Description="A monitor is an electronic visual computer display that includes a screen, circuitry and the case in which that circuitry is enclosed.", HtmlContent="A monitor is an electronic visual computer display that includes a screen, circuitry and the case in which that circuitry is enclosed.", DateAdded=DateTime.Now.AddDays(-2)},
                    new Product(){ ProductName="Acer Monitor",Stock=90, Price=4500, Image="monitor2.jpg",IsHome=true,IsApproved=true,IsFeatured=true, Description="A monitor is an electronic visual computer display that includes a screen, circuitry and the case in which that circuitry is enclosed.", HtmlContent="A monitor is an electronic visual computer display that includes a screen, circuitry and the case in which that circuitry is enclosed.", DateAdded=DateTime.Now.AddDays(-2)},
                    new Product(){ ProductName="Hp Monitor",Stock=90, Price=1500, Image="monitor3.jpg",IsHome=true,IsApproved=true,IsFeatured=true, Description="A monitor is an electronic visual computer display that includes a screen, circuitry and the case in which that circuitry is enclosed.", HtmlContent="A monitor is an electronic visual computer display that includes a screen, circuitry and the case in which that circuitry is enclosed.", DateAdded=DateTime.Now.AddDays(-2)},
                    new Product(){ ProductName="MSI Monitor",Stock=90, Price=6500, Image="monitor4.jpg",IsHome=true,IsApproved=true,IsFeatured=true, Description="A monitor is an electronic visual computer display that includes a screen, circuitry and the case in which that circuitry is enclosed.", HtmlContent="A monitor is an electronic visual computer display that includes a screen, circuitry and the case in which that circuitry is enclosed.", DateAdded=DateTime.Now.AddDays(-2)},

                    new Product(){ ProductName="Nikon Camera",Stock=90, Price=2500, Image="camera10.jpg",IsHome=true,IsApproved=true,IsFeatured=true, Description="Camera is used for taking pictures with people.", HtmlContent="Camera is used for taking pictures with people.", DateAdded=DateTime.Now.AddDays(-2)},
                    new Product(){ ProductName="Canon Camera",Stock=90, Price=3500, Image="camera2.jpg",IsHome=true,IsApproved=true,IsFeatured=true, Description="Camera is used for taking pictures with people.", HtmlContent="Camera is used for taking pictures with people.", DateAdded=DateTime.Now.AddDays(-2)},
                    new Product(){ ProductName="Sony Camera",Stock=90, Price=4500, Image="camera3.jpg",IsHome=true,IsApproved=true,IsFeatured=true, Description="Camera is used for taking pictures with people.", HtmlContent="Camera is used for taking pictures with people.", DateAdded=DateTime.Now.AddDays(-2)},
                    new Product(){ ProductName="Samsung Camera",Stock=90, Price=5500, Image="camera4.jpg",IsHome=true,IsApproved=true,IsFeatured=true, Description="Camera is used for taking pictures with people.", HtmlContent="Camera is used for taking pictures with people.", DateAdded=DateTime.Now.AddDays(-2)},



                };

                context.Products.AddRange(products);

                var categories = new[]
                {
                    new Category(){ CategoryName="Laptop"},
                    new Category(){ CategoryName="Earphone"},
                    new Category(){ CategoryName="Monitor"},
                    new Category(){ CategoryName="Camera"},

                };

                context.Categories.AddRange(categories);

                var productcategories = new[]
                {
                    new ProductCategory(){ Product=products[0],Category=categories[0]},
                    new ProductCategory(){ Product=products[1],Category=categories[0]},
                    new ProductCategory(){ Product=products[2],Category=categories[0]},
                    new ProductCategory(){ Product=products[3],Category=categories[0]},


                    new ProductCategory(){ Product=products[4],Category=categories[1]},
                    new ProductCategory(){ Product=products[5],Category=categories[1]},
                    new ProductCategory(){ Product=products[6],Category=categories[1]},
                    new ProductCategory(){ Product=products[7],Category=categories[1]},

                    new ProductCategory(){ Product=products[8],Category=categories[2]},
                    new ProductCategory(){ Product=products[9],Category=categories[2]},
                    new ProductCategory(){ Product=products[10],Category=categories[2]},
                    new ProductCategory(){ Product=products[11],Category=categories[2]},

                    new ProductCategory(){ Product=products[12],Category=categories[3]},
                    new ProductCategory(){ Product=products[13],Category=categories[3]},
                    new ProductCategory(){ Product=products[14],Category=categories[3]},
                    new ProductCategory(){ Product=products[15],Category=categories[3]},

                };

                context.AddRange(productcategories);


                var images = new[]
                {
                    new Image(){ ImageName="photo7.jpg", Product=products[0]},
                    new Image(){ ImageName="photo4.jpg", Product=products[0]},
                    new Image(){ ImageName="photo2.jpg", Product=products[0]},
                    new Image(){ ImageName="photo3.jpg", Product=products[0]},

                    new Image(){ ImageName="photo7.jpg", Product=products[1]},
                    new Image(){ ImageName="photo4.jpg", Product=products[1]},
                    new Image(){ ImageName="photo2.jpg", Product=products[1]},
                    new Image(){ ImageName="photo3.jpg", Product=products[1]},

                    new Image(){ ImageName="photo7.jpg", Product=products[2]},
                    new Image(){ ImageName="photo4.jpg", Product=products[2]},
                    new Image(){ ImageName="photo2.jpg", Product=products[2]},
                    new Image(){ ImageName="photo3.jpg", Product=products[2]},

                    new Image(){ ImageName="photo7.jpg", Product=products[3]},
                    new Image(){ ImageName="photo4.jpg", Product=products[3]},
                    new Image(){ ImageName="photo2.jpg", Product=products[3]},
                    new Image(){ ImageName="photo3.jpg", Product=products[3]},

                    new Image(){ ImageName="earphone15.jpg", Product=products[4]},

                    new Image(){ ImageName="earphone11.jpg", Product=products[5]},

                    new Image(){ ImageName="earphone10.jpg", Product=products[6]},
                  
                    new Image(){ ImageName="earphone13.jpg", Product=products[7]},

                    new Image(){ ImageName="monitor5.jpg", Product=products[8]},
                    new Image(){ ImageName="monitor2.jpg", Product=products[8]},
                    new Image(){ ImageName="monitor3.jpg", Product=products[8]},
                    new Image(){ ImageName="monitor4.jpg", Product=products[8]},

                    new Image(){ ImageName="monitor5.jpg", Product=products[9]},
                    new Image(){ ImageName="monitor2.jpg", Product=products[9]},
                    new Image(){ ImageName="monitor3.jpg", Product=products[9]},
                    new Image(){ ImageName="monitor4.jpg", Product=products[9]},

                    new Image(){ ImageName="monitor5.jpg", Product=products[10]},
                    new Image(){ ImageName="monitor2.jpg", Product=products[10]},
                    new Image(){ ImageName="monitor3.jpg", Product=products[10]},
                    new Image(){ ImageName="monitor4.jpg", Product=products[10]},

                    new Image(){ ImageName="monitor5.jpg", Product=products[11]},
                    new Image(){ ImageName="monitor2.jpg", Product=products[11]},
                    new Image(){ ImageName="monitor3.jpg", Product=products[11]},
                    new Image(){ ImageName="monitor4.jpg", Product=products[11]},

                    new Image(){ ImageName="camera10.jpg", Product=products[12]},
                    new Image(){ ImageName="camera2.jpg", Product=products[13]},
                    new Image(){ ImageName="camera3.jpg", Product=products[14]},
                    new Image(){ ImageName="camera4.jpg", Product=products[15]},

                   


                };

                context.Images.AddRange(images);

                var attributes = new[]
                {
                    new ProductAttribute(){ Attribute="Display",Value="15.6", Product=products[0]},
                    new ProductAttribute(){ Attribute="Processor",Value="Intel i7", Product=products[0]},
                    new ProductAttribute(){ Attribute="RAM Memory",Value="8 GB", Product=products[0]},
                    new ProductAttribute(){ Attribute="Hard Disk",Value="1 TB", Product=products[0]},
                    new ProductAttribute(){ Attribute="Color",Value="Black", Product=products[0]},

                    new ProductAttribute(){ Attribute="Display",Value="15.6", Product=products[1]},
                    new ProductAttribute(){ Attribute="Processor",Value="Intel i7", Product=products[1]},
                    new ProductAttribute(){ Attribute="RAM Memory",Value="8 GB", Product=products[1]},
                    new ProductAttribute(){ Attribute="Hard Disk",Value="1 TB", Product=products[1]},
                    new ProductAttribute(){ Attribute="Color",Value="Black", Product=products[1]},

                    new ProductAttribute(){ Attribute="Display",Value="15.6", Product=products[2]},
                    new ProductAttribute(){ Attribute="Processor",Value="Intel i7", Product=products[2]},
                    new ProductAttribute(){ Attribute="RAM Memory",Value="8 GB", Product=products[2]},
                    new ProductAttribute(){ Attribute="Hard Disk",Value="1 TB", Product=products[2]},
                    new ProductAttribute(){ Attribute="Color",Value="Black", Product=products[2]},

                    new ProductAttribute(){ Attribute="Display",Value="15.6", Product=products[3]},
                    new ProductAttribute(){ Attribute="Processor",Value="Intel i7", Product=products[3]},
                    new ProductAttribute(){ Attribute="RAM Memory",Value="8 GB", Product=products[3]},
                    new ProductAttribute(){ Attribute="Hard Disk",Value="1 TB", Product=products[3]},
                    new ProductAttribute(){ Attribute="Color",Value="Black", Product=products[3]},




                    new ProductAttribute(){ Attribute="Aktif Gürültü Engelleme(ANC)",Value="Var", Product=products[4]},
                    new ProductAttribute(){ Attribute="Bluetooth Version",Value="5.0", Product=products[4]},
                    new ProductAttribute(){ Attribute="Kulaklık Tipi",Value="Stereo", Product=products[4]},
                    new ProductAttribute(){ Attribute="Suya& Tere Dayanıklılık",Value="Var", Product=products[4]},

                    new ProductAttribute(){ Attribute="Aktif Gürültü Engelleme(ANC)",Value="Var", Product=products[5]},
                    new ProductAttribute(){ Attribute="Bluetooth Version",Value="5.0", Product=products[5]},
                    new ProductAttribute(){ Attribute="Kulaklık Tipi",Value="Stereo", Product=products[5]},
                    new ProductAttribute(){ Attribute="Suya& Tere Dayanıklılık",Value="Var", Product=products[5]},

                    new ProductAttribute(){ Attribute="Aktif Gürültü Engelleme(ANC)",Value="Var", Product=products[6]},
                    new ProductAttribute(){ Attribute="Bluetooth Version",Value="5.0", Product=products[6]},
                    new ProductAttribute(){ Attribute="Kulaklık Tipi",Value="Stereo", Product=products[6]},
                    new ProductAttribute(){ Attribute="Suya& Tere Dayanıklılık",Value="Var", Product=products[6]},

                    new ProductAttribute(){ Attribute="Aktif Gürültü Engelleme(ANC)",Value="Var", Product=products[7]},
                    new ProductAttribute(){ Attribute="Bluetooth Version",Value="5.0", Product=products[7]},
                    new ProductAttribute(){ Attribute="Kulaklık Tipi",Value="Stereo", Product=products[7]},
                    new ProductAttribute(){ Attribute="Suya& Tere Dayanıklılık",Value="Var", Product=products[7]},


                    new ProductAttribute(){ Attribute="Çözünürlük(max)",Value="1920x1080", Product=products[8]},
                    new ProductAttribute(){ Attribute="Ekran Büyüklüğü",Value="23.8 inç", Product=products[8]},
                    new ProductAttribute(){ Attribute="Yenileme Hızı(hz)",Value="165 Hz", Product=products[8]},
                    new ProductAttribute(){ Attribute="Dahili Hoparlör",Value="Var", Product=products[8]},

                    new ProductAttribute(){ Attribute="Çözünürlük(max)",Value="1920x1080", Product=products[9]},
                    new ProductAttribute(){ Attribute="Ekran Büyüklüğü",Value="23.8 inç", Product=products[9]},
                    new ProductAttribute(){ Attribute="Yenileme Hızı(hz)",Value="165 Hz", Product=products[9]},
                    new ProductAttribute(){ Attribute="Dahili Hoparlör",Value="Var", Product=products[9]},

                    new ProductAttribute(){ Attribute="Çözünürlük(max)",Value="1920x1080", Product=products[10]},
                    new ProductAttribute(){ Attribute="Ekran Büyüklüğü",Value="23.8 inç", Product=products[10]},
                    new ProductAttribute(){ Attribute="Yenileme Hızı(hz)",Value="165 Hz", Product=products[10]},
                    new ProductAttribute(){ Attribute="Dahili Hoparlör",Value="Var", Product=products[10]},

                    new ProductAttribute(){ Attribute="Çözünürlük(max)",Value="1920x1080", Product=products[11]},
                    new ProductAttribute(){ Attribute="Ekran Büyüklüğü",Value="23.8 inç", Product=products[11]},
                    new ProductAttribute(){ Attribute="Yenileme Hızı(hz)",Value="165 Hz", Product=products[11]},
                    new ProductAttribute(){ Attribute="Dahili Hoparlör",Value="Var", Product=products[11]},


                    new ProductAttribute(){ Attribute="Kamera Formatı",Value="JPG", Product=products[12]},
                    new ProductAttribute(){ Attribute="Video Çözünürlüğü",Value="1080P", Product=products[12]},
                    new ProductAttribute(){ Attribute="Görüntü Çözünürlüğü",Value="244X3624", Product=products[12]},
                    new ProductAttribute(){ Attribute="SD Kart",Value="Maksimum 32 GB", Product=products[12]},

                    new ProductAttribute(){ Attribute="Kamera Formatı",Value="JPG", Product=products[13]},
                    new ProductAttribute(){ Attribute="Video Çözünürlüğü",Value="1080P", Product=products[13]},
                    new ProductAttribute(){ Attribute="Görüntü Çözünürlüğü",Value="244X3624", Product=products[13]},
                    new ProductAttribute(){ Attribute="SD Kart",Value="Maksimum 32 GB", Product=products[13]},

                    new ProductAttribute(){ Attribute="Kamera Formatı",Value="JPG", Product=products[14]},
                    new ProductAttribute(){ Attribute="Video Çözünürlüğü",Value="1080P", Product=products[14]},
                    new ProductAttribute(){ Attribute="Görüntü Çözünürlüğü",Value="244X3624", Product=products[14]},
                    new ProductAttribute(){ Attribute="SD Kart",Value="Maksimum 32 GB", Product=products[14]},

                    new ProductAttribute(){ Attribute="Kamera Formatı",Value="JPG", Product=products[15]},
                    new ProductAttribute(){ Attribute="Video Çözünürlüğü",Value="1080P", Product=products[15]},
                    new ProductAttribute(){ Attribute="Görüntü Çözünürlüğü",Value="244X3624", Product=products[15]},
                    new ProductAttribute(){ Attribute="SD Kart",Value="Maksimum 32 GB", Product=products[15]},

                };

                context.Attributes.AddRange(attributes);


                context.SaveChanges();
            }
        }
    }
}
