using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiEjemplo.Models
{
    public class Actividad
    {
        private int idActiv;

        public int GetIdActiv()
        {
            return idActiv;
        }

        public void SetIdActiv(int value)
        {
            idActiv = value;
        }

        private String nombre;

        public String GetNombre()
        {
            return nombre;
        }

        public void SetNombre(String value)
        {
            nombre = value;
        }

        private String descripcion;

        public String GetDescripcion()
        {
            return descripcion;
        }

        public void SetDescripcion(String value)
        {
            descripcion = value;
        }

        private int edadMin;

        public int GetEdadMin()
        {
            return edadMin;
        }

        public void SetEdadMin(int value)
        {
            edadMin = value;
        }

        private int edadMax;

        public int GetEdadMax()
        {
            return edadMax;
        }

        public void SetEdadMax(int value)
        {
            edadMax = value;
        }

        private int limPer;

        public int GetLimPer()
        {
            return limPer;
        }

        public void SetLimPer(int value)
        {
            limPer = value;
        }

        private string calle;

        public string GetCalle()
        {
            return calle;
        }

        public void SetCalle(string value)
        {
            calle = value;
        }

        private int direccion;

        public int GetDireccion()
        {
            return direccion;
        }

        public void SetDireccion(int value)
        {
            direccion = value;
        }

        private DateTime fecha;

        public DateTime GetFecha()
        {
            return fecha;
        }

        public void SetFecha(DateTime value)
        {
            fecha = value;
        }

        public Actividad(int idActiv, string nombre, string descripcion, int edadMin, int edadMax, int limPer, string calle, int direccion, DateTime fecha)
        {
            this.idActiv = idActiv;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.edadMin = edadMin;
            this.edadMax = edadMax;
            this.limPer = limPer;
            this.calle = calle;
            this.direccion = direccion;
            this.fecha = fecha;
        }
        public Actividad()
        {
            this.idActiv = 0;
            this.nombre = "";
            this.descripcion = "";
            this.edadMin = 0;
            this.edadMax = 0;
            this.limPer = 0;
            this.calle = "";
            this.direccion = 0;
            this.fecha = DateTime.Now;
        }
    }
}