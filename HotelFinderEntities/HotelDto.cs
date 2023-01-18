using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinderEntities
{
    public class HotelDto
    {
        public string Name { get; set; }
        public string City { get; set; }
    }
}
