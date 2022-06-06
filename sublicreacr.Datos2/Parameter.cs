using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sublicreacr.Datos
{
    public class Parameter
    {
        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private Object valor;

        public Object Value
        {
            get { return valor; }
            set { valor = value; }
        }

        public Parameter(String name, Object value)
        {
            this.name = name;
            this.valor = value;
        }
    }
}
