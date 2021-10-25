using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;


namespace practice8_2
{Не треба методи іменувати завданнями. Треба по суті. Ми один клас видозмінюємо для кількох задач.
    class Storage
    {
        private Dictionary<string, Product> arrayOfProduct;
        public Product ArrayOfProduct
        {
            set { arrayOfProduct.Add(value.Name, value); }
        }
        

        public Storage(string path)
        {
            try
            {
                using (var sr = new StreamReader(path))
                {
                    string[] buf = sr.ReadToEnd().Split(' ', '\n');
                    for (int i = 0; i < buf.Length; i++)
                    {
                        arrayOfProduct.Add(buf[i].Split(' ')[0], new Product(buf[i]));
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public ArrayList zavd1(Storage storage)
        {
            ArrayList buf = new ArrayList();
            
            
            foreach(var t in arrayOfProduct)
            {
                if(storage.arrayOfProduct.ContainsKey(t.Key))
                {
                    if(storage.arrayOfProduct[t.Key]==t.Value)
                        buf.Add(t.Value);
                }
            }
            return buf;
        }
        public ArrayList zavd2(Storage storage)
        {
            ArrayList buf = new ArrayList();
            foreach (var t in arrayOfProduct)
            {
                if (storage.arrayOfProduct.ContainsKey(t.Key))
                {
                    if (storage.arrayOfProduct[t.Key] != t.Value)
                        buf.Add(t.Value);
                }
                else
                {

                    buf.Add(t.Value);

                }
            }
            return buf;
        }
        public ArrayList zavd3(Storage storage)
        {
            ArrayList buf=new ArrayList();
            
            foreach (var t in storage.arrayOfProduct)
            {
                if (arrayOfProduct.ContainsKey(t.Key))
                {
                    if (arrayOfProduct[t.Key] != t.Value)
                        buf.Add(t.Value);
                }
                else
                {

                    buf.Add(t.Value);

                }
            }
            foreach (var t in arrayOfProduct)
            {
                if (storage.arrayOfProduct.ContainsKey(t.Key))
                {
                    if (storage.arrayOfProduct[t.Key] != t.Value)
                        buf.Add(t.Value);
                }
                else
                {
                    buf.Add(t.Value);
                }
            }
            
            return buf;
        }
    }
    

    class Product
    {
        private string name;
        private double price;
        private double weight;
        

        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        public double Price
        {
            set { price = value; }
            get { return price; }
        }
        public double Weight
        {
            set { weight = value; }
            get { return weight; }
        }
        

        public Product(string name, double price, double weight, DateTime dateOfCreation)
        {
            this.name = name;
            this.price = price;
            this.weight = weight;
            
        }
        public Product(string str)
        {
            string[] buf = str.Split(' ');
            this.name = buf[0];
            this.price =Convert.ToDouble(buf[1]);
            this.weight = Convert.ToDouble(buf[2]);
            
        }
        public static bool operator ==(Product a, Product b)
        {
            bool Ind = false;
            if ((a.name == b.name) && (a.price == b.price) && (a.weight == b.weight))
            {
                Ind = true;
            }
            
            return Ind;
        }
        public static bool operator !=(Product a, Product b)
        {
            bool Ind = false;
            if (!((a.name == b.name) && (a.price == b.price) && (a.weight == b.weight)))
            {
                Ind = true;
            }

            return Ind;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter path to file:");
            string path = Console.ReadLine();
            Storage storage1 = new Storage(path);
            Console.WriteLine("Enter path to file:");
            path = Console.ReadLine();
            Storage storage2 = new Storage(path);
            storage1.zavd1(storage2);
            storage1.zavd2(storage2);
            storage1.zavd3(storage2);
        }
    }
}
