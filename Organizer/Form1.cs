using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TestDB db = new TestDB();

        private void Form1_Load(object sender, EventArgs e)
        {
            /*   // Create and save a new Blog 
               Console.Write("Enter a name for a new Blog: ");
               var name = Console.ReadLine();

               var blog = new Blog { Name = name };
               db.Blogs.Add(blog);
               db.SaveChanges();

               // Display all Blogs from the database 
               var query = from b in db.Blogs
                           orderby b.Name
                           select b;

               Console.WriteLine("All blogs in the database:");
               foreach (var item in query)
               {
                   Console.WriteLine(item.Name);
               }

               Console.WriteLine("Press any key to exit...");
               Console.ReadKey();*/
              
            
            /* 
                Customer customer = new Customer();

                // Получить данные из формы с помощью средств
                // привязки моделей ASP.NET
                IValueProvider provider =
                    new FormValueProvider(ModelBindingExecutionContext);
                if (TryUpdateModel<Customer>(customer, provider))
                {
                    // Загрузить фото профиля с помощью средств .NET
                    HttpPostedFile photo = Request.Files["photo"];
                    if (photo != null)
                    {
                        BinaryReader b = new BinaryReader(photo.InputStream);
                        customer.Photo = b.ReadBytes((int)photo.InputStream.Length);
                    }

                    // В этой точке непосредственно начинается работа с Entity Framework

                    // Создать объект контекста
                    SampleContext context = new SampleContext();

                    // Вставить данные в таблицу Customers с помощью LINQ
                    context.Customers.Add(customer);

                    // Сохранить изменения в БД
                    context.SaveChanges();*/
            }
        }
    }
    
}
