using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            addTarea();
        }
        static void addTarea()
        {
            var tarea=new Tareas();
            tarea.Descripcion = "Ejecutar algo";
            tarea.Estado = "Activa";
            using (var repository = RepositoryFactory.CreateRepository())
            {
                repository.Create(tarea);
            }
            Console.WriteLine($"Tarea: {tarea.TareaID},Estado:{tarea.Estado}");
            Console.ReadLine();

        }
        static void addCategoryandProduct()
        {
            var categories = new Categories();
            categories.CategoryName = "Beverages";
            categories.Description = "Soft drinks, coffees, teas, beers, and ales";

            var product = new Products();
            product.ProductName = "Chai";

            product.UnitPrice = 18.00M;
            product.UnitsInStock = 39;

            categories.Products.Add(product);

            using (var repository= RepositoryFactory.CreateRepository())
            {
                repository.Create(categories);
            }
            Console.WriteLine($"Categoria: {categories.CategoryID},Producto:{product.ProductID}");
            Console.ReadLine();


        }
    }
}
