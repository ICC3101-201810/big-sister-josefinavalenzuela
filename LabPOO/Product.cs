using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabPOO
{
    public delegate void Hermana(List<Product> carrito, Receta prod, List<Receta> receta);
    public class Product
    {
        private string name;
        private int stock;
        private int price; //Price for one unit of the product
        private string unit;
        private int Cant;

        public Product(string name, int price, int stock,int cant, string unit)
        {
            this.name = name;
            this.stock = stock;
            this.price = price;
            this.unit = unit;
            Cant = cant;
        }

        public event Hermana Equivocado;
        public void Suscribir()
        {
            Equivocado += new Hermana(OnEquivocado);
        }
        protected void OnEquivocado(List<Product> carrito, Receta prod, List<Receta> rec)
        {
            Console.WriteLine("Se ingreso " + prod.Nombre + "este producto no estaba en la lista!!");
            this.QuitarElemento(carrito, prod, rec);
            
        }

       

        public void Revisar(List<Product> carrito, List<Receta> rec)
        {
            Receta Adm = new Receta("", 1, 1, "");

            foreach (Receta receta in rec)
            {
                int contarelementos = 0;
                foreach(Product producto in carrito)
                {
                    if (receta.Nombre == producto.Name)
                    {
                        contarelementos += 1;
                    }
                       
                }
                //Elemento que no esta en la lista en el carro
                if(contarelementos == 0)
                {
                    
                    Equivocado(carrito, receta, rec); 
                }
                

            }
        }

        public List<Product> QuitarElemento(List<Product> carrito, Receta prod, List<Receta> receta)
        {
            foreach (Product p in carrito)
            {
                if (p.Name == prod.Name)
                {
                    carrito.Remove(p);
                }
            }

            return carrito;
        }

        public bool Agregar(List<Product> carrito)
        {
            if (stock > 0)
            {
                carrito.Add(this);
                stock--;
                return true;
            }
            return false;
        }



        public string Name { get => name; }
        public int Stock { get => stock; }
        public int Price { get => price; }
        public string Unit { get => unit; }
    }

    public class Receta
    {
        public string Nombre;
        public int Cantidad;
        public int Cantidadunit;
        public string Unit;
        public List<Receta> Lista = new List<Receta>();
        public Receta(string nombre, int cantidad, int cantidadunit, string unit)
        {
            Nombre = nombre;
            Cantidad = cantidad;
            Unit = unit;
            Cantidadunit = cantidadunit;
        }

        public void AgregarElemento()
        {
            Lista.Add(this);
        }

        public Receta GetReceta(string nombre)
        {
            foreach (Receta i in Lista)
            {
                if(i.Nombre == nombre)
                {
                    return i;
                }
            }
            return null;
        }
        
            

         

    }
}
