using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCities2.Models
{
    public class BatimentDetailsDTO
    {
        public int Id { get; set; }
        public string TypeReligieux { get; set; }
        public TypeCulte Culte { get; set; }
        public string TypeCulturel { get; set; }

        public string NomDetail { get; set; }
        public string Description { get; set; }
    }
}
