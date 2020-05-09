using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MyCities2.Models
{
   //enum TypeCulturel 
   // {
   //   ArtDéco, Cinema, Théatre
   // }
    public class BatimentCulturel : Batiment
    {
        public string TypeCulturel { get; set; }
    }

}
