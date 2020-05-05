using Microsoft.AspNetCore.Mvc.Rendering;
using MyCities2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyCities2.ViewModels
{
    public class BatimentViewModel
    {
        
        public enum TypeBatiment
        {
            culturel, Religieux
        }
        public Batiment Model { get; set; }

        public BatimentViewModel(Batiment model)
        {
            this.Model = model;

            ListDeStyle = new List<SelectListItem>();

            foreach(var v in Enum.GetValues(typeof(Models.StyleBatiment)))
            {

                var itm = new SelectListItem(v.ToString(), ((int)v).ToString());
                ListDeStyle.Add(itm);

            }
            //IEnumerable<Models.StyleBatiment> values = (IEnumerable <Models.StyleBatiment>) Enum.GetValues(typeof(Models.StyleBatiment));
            //ListDeStyle = values.Select(v => new SelectListItem(v.ToString(),((int)v).ToString()));
        }

        private TypeBatiment typebat;

        public TypeBatiment Typebat
        { 
            get{ return typebat; } 
            set{ typebat = value; } 
        }
        /*
        public StyleBatiment typebat
        {
            get { return typebat; }
            set { typebat = value; }
        }

        */
        //public IEnumerable<SelectListItem> ListDeStyle { get; set; }

        public List<SelectListItem> ListDeStyle { get; set; }

        public string Nom
        {
            get { return Model.Nom; }
            set { Model.Nom = value; }
        }
        
        public string Description
        {
            get { return Model.Description; }
            set { Model.Description = value; }
        }
        

    }
}
