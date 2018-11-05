using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;

namespace LibraryCatalog
{
    [Serializable]
    class Book 
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string DatePublished { get; set; }
        public string YearWritten { get; set; }
        public string Genre { get; set; }

        /*
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Author", Author);
            info.AddValue("Title", Title);
        }
        public Book(SerializationInfo info, StreamingContext context)
        {
            Author = (string)info.GetValue("Author", typeof(string));
            Title = (string)info.GetValue("Title", typeof(string));
        }
        */
    }
}
