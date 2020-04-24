using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MyCities.Models
{
    public enum TypeCulte
    {
        Catholique,
        Protestant,
        Musulman,
        Juif,
        Bouddhiste
    }
    public class BatimentReligieux : Batiment
    {
        public string TypeReligieux { get; set; }
        public TypeCulte Culte { get; set; }
    }
}
