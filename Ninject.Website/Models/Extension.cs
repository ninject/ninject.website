namespace Ninject.Website.Models
{
    using System.Web;

    public class Extension
    {       
        public string Name { get; set; }

        public string Website { get; set; }
       
        public Author Author { get; set; }

        public HtmlString Description { get; set; }
    }
}