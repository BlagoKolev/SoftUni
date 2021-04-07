using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.DataProcessor.ExportDto
{
   public  class ExportCraziestAuthorsDto
    {
        public string AuthorName { get; set; }
        public CraziestBooksDto[] Books { get; set; }
    }
}
