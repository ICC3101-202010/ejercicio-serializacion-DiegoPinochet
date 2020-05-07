using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace EjercicioSerializacion
{
    [Serializable]
    class Persona
    {
        private string name;
        private string lastname;
        private int age;
       
        public Persona(string Name, string Lastname, int Age)
        {
            this.name = Name;
            this.lastname = Lastname;
            this.age = Age;
        }
        public string InfoPersona()
        {
            string info = name + " " + lastname + " " + age + ".";
            return info;
        }
    }
}
