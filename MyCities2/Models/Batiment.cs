using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MyCities2.Models
{
    public enum StyleBatiment
    {
        Moderne,
        Ghotique,
        Classique,
        Académique,
        Composite,
        Abâtardi,
        Bizintin,
        Renaissance,
        Roman,
    }

    public enum TypeBatiment
    {
        Moderne,
        Ghotique,
        Classique,
    }
    public class Batiment
    {
       
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string Categorie{ get; set; }
        public double Longitude{ get; set; }
        public double Latitude { get; set; }
        public string Adresse1 { get; set; }
        public string Adresse2 { get; set; }
        public string Ville { get; set; }
        public string CP { get; set; }
        public string Architecte { get; set; }
        public string ImageURL { get; set; }
        public DateTime? Periode_construction_debut { get; set; }
        public DateTime? Periode_construction_fin { get; set; }
        public StyleBatiment Style { get; set; }
        public TypeBatiment Type { get; set; }
        public string Siteweb { get; set; }
        public ICollection<DetailsArchitecture> Details { get; set; }
    }
}
