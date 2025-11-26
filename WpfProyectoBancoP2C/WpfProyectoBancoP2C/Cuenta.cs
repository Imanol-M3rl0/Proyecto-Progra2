using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProyectoBancoP2C
{
    public class Cuenta
    {
        //propidades 
        public string Nombre { get; set; }
        public double Saldo { get; set; }
        //contructores
        public Cuenta()
        {
            Nombre = "no definido";
            Saldo = 0;
        }
        public Cuenta(string nom, double sal)
        {
            Nombre = nom;
            Saldo = sal;
        }
        //funcionalidad
        public string VerDatos()
        {
            return Nombre + " " + Saldo.ToString();
        }
    }
}
