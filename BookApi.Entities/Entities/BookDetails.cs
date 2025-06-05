//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BookApi.Entities.Entities
//{
//    internal class BookDetails
//    {

//        [Key]

//        public int Id { get; set; }

//        public String Title { get; set; }

//        public string Description { get; set; }

//        public string Author { get; set; }


//    }
//}


using System;
using System.ComponentModel.DataAnnotations;

namespace BookApi.Entities.Entities
{
    public class BookDetails
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;
    }
}
