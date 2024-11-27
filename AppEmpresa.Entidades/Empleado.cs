using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEmpresa.Entidades
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set;}
        public string? Direcrion { get; set;}
        public DateTime? FechaNacimiento { get; set;}
        public double Salario { get; set;}
        public double? Comision { get; set; }

        public int CargoId {  get; set;}  //FK
        public Cargo? Cargo { get; set;}

        public int DepartamentoId { get; set; }  // FK
        public Departamento? Departamento { get; set; }


    }
}
