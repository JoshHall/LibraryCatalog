using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace LibraryCatalog
{
    [Serializable]
    public class CardCatalog
    {
        private string _filename;
        
        private List<Book> _books = new List<Book>(); //This is the private member variable that contains all of the books 
        
        public CardCatalog(string fileName)
        {
            _filename = fileName;
            
            IFormatter formatter = new BinaryFormatter();
            
            Stream streamFileNameData = new FileStream(fileName, FileMode.OpenOrCreate);
            if (streamFileNameData.Length != 0)
            {
                _books = (List<Book>)formatter.Deserialize(streamFileNameData);
            }
            streamFileNameData.Close();
            /*
            streamFileNameData.Close();
            Stream streamBookList = new FileStream("BookList.dat", FileMode.Open);
            _books = (List<Book>)formatter.Deserialize(streamBookList);
            streamBookList.Close();
             */

        }

        public void ListBooks()
        {
            foreach (var book in _books)
            {
                Console.WriteLine("Title: {0}, Author: {1}", book.Title, book.Author);
            } 
        }

        public void AddBook(string title, string author) 
        {
            Book s = new Book();
            s.Title = title;
            s.Author = author;
            //Genre = "";
            //DatePublished = "";
            //YearWritten = "";
            _books.Add(s);
        }

        /*
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FileName", _filename);
            info.AddValue("BookList", _books);
        }
        public void FileName(SerializationInfo info, StreamingContext context)
        {
            _filename = (string)info.GetValue("FileName", typeof(string));
        }
        public void BookList(SerializationInfo info, StreamingContext context)
        {
            _books = (List<Book>)info.GetValue("BookList", typeof(List<Book>));
        }
        */

        public void Save(string fileName)
        {
            
            IFormatter bf = new BinaryFormatter();
            Stream streamFileNameData = new FileStream(fileName, FileMode.Create);
            //Stream streamBookList = new FileStream("BookList.dat", FileMode.Create);
            
            bf.Serialize(streamFileNameData, _books);
            //bf.Serialize(streamBookList, _books);
            
        }
    }
}

