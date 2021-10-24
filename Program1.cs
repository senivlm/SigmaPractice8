using System;
using System.IO;

namespace HW8_1
{
    class Utilita
    {
        private readonly string path = @"C:\Users\chummi\source\repos\Practice8_1\Input.txt";
        Product[] products;
        private int size = 0;
        public int Size => size;
        public Utilita()
        {
            string[] readText = File.ReadAllLines(path);
            products = new Product[readText.Length];
            string[] sub;
            for (int i = 0; i < 10; i++)
            {
                sub = readText[i].Split(' ');
                products[i] = new Product(sub[0], Convert.ToDouble(sub[1]));
            }
            size = this.products.Length;
        }

        public Product[] BackM(Product[] product)
        {
            for (int i = 0; i < this.products.Length; i++)
            {
                product[i] = new Product(products[i]);
            }
            return product;
        }


        public string Write(Product[] product)
        {
            string res = null;
            for (int i = 0; i < product.Length; i++)
            {
                res += product[i].ToString() + "\n";
            }
            return res;
        }

    }

    class Product
    {
        private readonly string name = null;
        private readonly double price = 0;
        public string Name => name;
        public double Price => price;

        public Product(string name, double price)
        {
            this.name = name;
            this.price = price;
        }
        public Product(Product product)
        {
            this.name = product.name;
            this.price = product.price;
        }


        public override string ToString()
        {
            return "Name\t" + name + "\tPrice\t" + price;
        }


    }

    class BubleSort
    {
        private Utilita utilita = new Utilita();
        public void Sort(Product[] product, Program.Comparison compar)
        {

            for (int write = 0; write < product.Length; write++)
            {
                for (int sort = 0; sort < product.Length - 1; sort++)
                {
                    if (compar(product[sort], product[sort + 1]) == 1)
                    {
                        Swap( product, sort);
                    }
                }
            }
            string result = utilita.Write(product);
            Console.WriteLine(result);
        }



        public void Swap( Product[] product, int sort)
        {
            Product temp = product[sort + 1];
            product[sort + 1] = product[sort];
            product[sort] = temp;
        }


    }


    class Program
    {
        public delegate int Comparison(Product a, Product b);


        static void Main(string[] args)
        {
            Utilita utilita = new Utilita();
            Product[] product=new Product[utilita.Size];
            utilita.BackM(product);
            BubleSort buble = new BubleSort();
            Console.WriteLine("Compared by name: ");
            Comparison n = CompareName;
            buble.Sort(product, n);
            Console.WriteLine("Compared by price\n");
            n = ComparePrice;
            buble.Sort(product, n);
        }


        public static int ComparePrice(Product a, Product b)
        {
            if (a.Price < b.Price)
            {
                return 1;
            }
            else return 0;
        }


        public static int CompareName(Product a, Product b)
        {
            return string.Compare(a.Name, b.Name, StringComparison.Ordinal);
        }
    }
}
