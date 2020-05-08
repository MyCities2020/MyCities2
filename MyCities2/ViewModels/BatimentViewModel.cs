using Microsoft.AspNetCore.Mvc.Rendering;
using MyCities2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyCities2.ViewModels
{
    public class BatimentViewModel : Batiment
    {
        
        public enum TypeBatiment
        {
            culturel, Religieux
        }

        public enum StyleBatiment
        {
            Gothique, Roman, Moderne
        }

        public Batiment model { get; set; }

        public BatimentViewModel(Batiment model)
        {
            this.model = model;

            ListDeStyle = new List<SelectListItem>();
            ListeTypeBatiment = new List<SelectListItem>();

            foreach(var v in Enum.GetValues(typeof(Models.StyleBatiment)))
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
            
        }

        

        
        //public IEnumerable<SelectListItem> ListDeStyle { get; set; }

        public List<SelectListItem> ListDeStyle { get; set; }
        public List<SelectListItem> ListeTypeBatiment { get; set; }
        public string Nom
        {
            get { return model.Nom; }
            set { model.Nom = value; }
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
        public string Ville
        {
            get { return model.Ville; }
            set { model.Ville = value; }
            
        }

    }
}
