using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;


namespace LibraryCatalog
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the name of a file: ");
            string fileName = Console.ReadLine();
           
            
            Console.Clear();
            //Console.WriteLine("File Name: {0}", fileName);
            CardCatalog fN = new CardCatalog(fileName);
            CardCatalogMenu(fN, fileName);
        }
        
        public static void CardCatalogMenu(CardCatalog fN, string fileName)
        {
            Console.WriteLine("File Name: {0}", fileName);
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. List All books");
            Console.WriteLine("2. Add A Book");
            Console.WriteLine("3. Save and Exit");
            string optionChoice = Console.ReadLine();
            
            if (optionChoice == "1")
            {
                fN.ListBooks();
                Console.ReadLine();
                Console.Clear();
                CardCatalogMenu(fN,fileName);
            }
            else if (optionChoice == "2")
            {
                Console.Write("What is the title of the book: ");
                string titleToBook = Console.ReadLine();
                Console.Write("What is the name of the author: ");
                string authorToBook = Console.ReadLine();

                fN.AddBook(titleToBook,authorToBook);
                Console.ReadLine();
                Console.Clear();
                CardCatalogMenu(fN, fileName);
            }
            else if (optionChoice == "3")
            {
                fN.Save(fileName);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Make sure you pressed a valid option. {0} was entered.", optionChoice);
                Console.ReadLine();
                Console.Clear();
                CardCatalogMenu(fN, fileName);
            }
        }
    }
}
