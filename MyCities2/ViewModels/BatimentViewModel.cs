using Microsoft.AspNetCore.Mvc.Rendering;
using MyCities2.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MyCities2.ViewModels
{

    
    public class BatimentViewModel
    {
        public BatimentViewModel() 
        {
            model = new Batiment();
            modelBatCulturel = new BatimentCulturel();
            
        }
        //public enum TypeBatiment
        //{
        //    culturel, Religieux
        //}

        //public enum StyleBatiment
        //{
        //    Gothique, Roman, Moderne
        //}

        //public enum TypeCulturel
        //{
        //    Gothique, Roman, Moderne
        //}
        public Batiment model { get; set; }
        public BatimentCulturel modelBatCulturel { get; set; }
        public BatimentViewModel(Batiment model, BatimentCulturel modelBatCulturel)
        {
            this.model = model;
            this.modelBatCulturel = modelBatCulturel;

            ListDeStyle = new List<SelectListItem>();
            ListeTypeBatiment = new List<SelectListItem>();
            ListeTypeCulture = new List<SelectListItem>();

            foreach (var v in Enum.GetValues(typeof(Models.StyleBatiment)))
            {

                var itm = new SelectListItem(v.ToString(), ((int)v).ToString());
                ListDeStyle.Add(itm);

            }
            //IEnumerable<Models.StyleBatiment> values = (IEnumerable <Models.StyleBatiment>) Enum.GetValues(typeof(Models.StyleBatiment));
            //ListDeStyle = values.Select(v => new SelectListItem(v.ToString(),((int)v).ToString()));

            foreach (var v in Enum.GetValues(typeof(Models.TypeBatiment)))
            {

                var itm = new SelectListItem(v.ToString(), ((int)v).ToString());
                ListeTypeBatiment.Add(itm);

            }

            foreach (var v in Enum.GetValues(typeof(Models.TypeCulturel)))
            {

                var itm = new SelectListItem(v.ToString(), ((int)v).ToString());
                ListeTypeCulture.Add(itm);

            }
        }

        //public IEnumerable<SelectListItem> ListDeStyle { get; set; }

        public List<SelectListItem> ListDeStyle { get; set; }
        public List<SelectListItem> ListeTypeBatiment { get; set; }

        public List<SelectListItem> ListeTypeCulture { get; set; }
        public int Id
        {
            get { return model.Id; }
            set { model.Id = value; }
        }
        public string Nom
        {
            get { return model.Nom; }
            set { model.Nom = value; }
        }

        public string Description
        {
            get { return model.Description; }
            set { model.Description = value; }
        }

        public string Categorie
        {
            get { return model.Categorie; }
            set { model.Categorie = value; }
        }

        public double Longitude
        {
            get { return model.Longitude; }
            set { model.Longitude = value; }
        }

        public string CP
        {
            get { return model.CP; }
            set { model.CP = value; }
        }
        public string Architecte
        {
            get { return model.Architecte; }
            set { model.Architecte = value; }
        }
        public string ImageURL { get; set; }
        public DateTime? Periode_construction_debut
        {
            get { return model.Periode_construction_debut; }
            set { model.Periode_construction_debut = value; }
        }
        public DateTime? Periode_construction_fin
        {
            get { return model.Periode_construction_fin; }
            set { model.Periode_construction_fin = value; }
        }
        public double Latitude
        {
            get { return model.Latitude; }
            set { model.Latitude = value; }
        }

        public string Adresse1
        {
            get { return model.Adresse1; }
            set { model.Adresse1 = value; }
        }

        public string Adresse2
        {
            get { return model.Adresse2; }
            set { model.Adresse2 = value; }
        }

        public string Ville
        {
            get { return model.Ville; }
            set { model.Ville = value; }

        }

        private TypeBatiment typebat;

        public TypeBatiment Typebat
        {
            get { return typebat; }
            set { typebat = value; }
        }

        private StyleBatiment styleBat;
        public StyleBatiment Stylebat
        {
            get { return styleBat; }
            set { styleBat = value; }
        }
        public string Siteweb
        {
            get { return model.Siteweb; }
            set { model.Siteweb = value; }
        }
        //public TypeCulturel typeCulturel
        //{
        //    get { return model.typeCulturel; }
        //    set { model.typeCulturel = value; }
        //}
    }
}
