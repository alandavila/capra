using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitacoraCAPRA
{
    public class Chofer
    {
        private string choferID;
        private string nombre;

        public string ChoferID
        {
            set { choferID = value; }
            get { return choferID; }
        }
        public string Nombre
        {
            set { nombre = value; }
            get { return nombre; }
        }
    }
}
