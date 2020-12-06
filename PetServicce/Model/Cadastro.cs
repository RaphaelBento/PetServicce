using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetServicce.Model
{
    public class Cadastro
    {

        public string NomeDoDono { get; set; }

        [Required(ErrorMessage ="Campo cpf é de preenchimento obrigatório")]
        [Key()]
        public string Cpf { get; set; }

        [Required(ErrorMessage ="Campo numero é de preenchimento obrigatório")]
        public string NumeroContato { get; set; }

        public string Endereco { get; set; }

        [Required(ErrorMessage ="Campo nome do pet é obrigatório")]
        public string NomeDoPet { get; set; }

        public string Especie { get; set; }

        public string Raca { get; set; }

        [Required(ErrorMessage ="Campo peso do pet é obrigatório")]
        public int Peso { get; set; }

        public string ApelidoDoPet { get; set; }

        [Required(ErrorMessage ="Campo senha é obrigatório")]
        public string Senha { get; set; }

        

    }
}
