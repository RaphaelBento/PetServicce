using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetServicce.Model
{
    public class CartaoDeVacinacao
    {
        [Key()]
        public string NomeDoPet { get; set; }

        

        public string Sexo { get; set; }

     

        public string Especie { get; set; }

        public string Raca { get; set; }

     
        public int Peso { get; set; }

        public string DataNascimento { get; set; }


        public string Telefone { get; set; }

        public string Vacina { get; set; }

        public string DataVacina { get; set; }

        public string MedicoVeterinario { get; set; }
    }
}
