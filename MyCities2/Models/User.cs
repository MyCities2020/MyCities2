using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace MyCities2.Models
{
    public class User
    {          
        public enum RoleUser
    {
        Abonné,
        Contributeur,
        Auteur,
        Editeur,
        Administrateur,
        
    }
            public int Id { get; set; }      
     
         
            [Required(AllowEmptyStrings = false, ErrorMessage = "entrer une adresse mail valide")]
            [Display(Name = "Courriel", Prompt = "Veuillez saisir votre adresse mail")]
            [EmailAddress(ErrorMessage = " Ce n'est pas une adresse mail valable")]

            //[DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [Display(Name = "Nom")]
            // [DisplayFormat(DataFormatString =)]
            public string LastName { get; set; }

            [Display(Name = "Prénom")]
            public string FirstName { get; set; }

            [Display(Name = "Mot De Passe")]
            public string Password { get; set; }
            public RoleUser Role { get; set; }

    }
    }



