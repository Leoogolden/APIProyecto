using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiEjemplo.Models
{
    public class Actividad
    {
        public int IdActiv
        {
            get;
            set;
        }
        public string Nombre { get; set; }
        
        public string Descripcion { get; set; }
        
        public int EdadMin { get; set; }
        
        public int EdadMax { get; set; }
        
        public int LimPer { get; set; }
        
        public string Calle { get; set; }
        
        public int Direccion { get; set; }
        
        public DateTime Fecha { get; set; }
        
        public Actividad(int idActiv, string nombre, string descripcion, int edadMin, int edadMax, int limPer, string calle, int direccion, DateTime fecha)
        {
            this.IdActiv = idActiv;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.EdadMin = edadMin;
            this.EdadMax = edadMax;
            this.LimPer = limPer;
            this.Calle = calle;
            this.Direccion = direccion;
            this.Fecha = fecha;
        }
        public Actividad()
        {
            this.IdActiv = 0;
            this.Nombre = "";
            this.Descripcion = "";
            this.EdadMin = 0;
            this.EdadMax = 0;
            this.LimPer = 0;
            this.Calle = "";
            this.Direccion = 0;
            this.Fecha = DateTime.Now;
        }
    }
}