using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetServicce.Model
{
    public class Login
    {
        [Required(ErrorMessage ="Campo Usuario não pode ficar em branco")]
        public string Usuario { get; set; }


        [Required(ErrorMessage ="Campo senha não pode ficar em branco")]
        public string Senha { get; set; }



    }
}
