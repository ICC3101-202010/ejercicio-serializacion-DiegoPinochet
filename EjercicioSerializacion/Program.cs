using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioSerializacion
{
    class Program
    {
        static void Main(string[] args)
        {
            bool x = true;
            List<Persona> personlist = new List<Persona>();
            IFormatter formatter = new BinaryFormatter();
            

            while (x == true)
            {
                Console.WriteLine("--------Menú--------\n Porfavor escriba el número.\n");
                Console.WriteLine(" 1) Crear Persona.\n 2) Mostrar Listas Persona.\n 3) Cargar Personas.\n 4) Guardar Personas.\n 5)Cerrar programa");
                int num = int.Parse(Console.ReadLine());
                

                switch (num)
                {
                    case 1:
                        Console.WriteLine("Escriba el nombre, apellido y edad");
                        string name = Console.ReadLine();
                        string lastname = Console.ReadLine();
                        int id = int.Parse(Console.ReadLine());
                        Persona persona = new Persona(name, lastname, id);
                        personlist.Add(persona);
                        Console.WriteLine("--------------------------------------------");
                        break;
                    case 2:
                        Console.WriteLine("\n");
                        for(int i = 0; i < personlist.Count(); i++)
                        {
                            Console.WriteLine(personlist[i].InfoPersona(), ".");
                        }
                        Console.WriteLine("--------------------------------------------");
                        break;
                    case 4:
                        Console.WriteLine("\n");
                        for (int i = 0; i < personlist.Count(); i++)
                        {
                            Stream stream = new FileStream("Personas.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                            formatter.Serialize(stream, personlist[i]);
                            stream.Close();
                        }
                        Console.WriteLine("--------------------------------------------");
                        break;
                    case 3:
                        Console.WriteLine("\n");

                        for (int i = 0; i < personlist.Count(); i++)
                        {
                            Stream stream = new FileStream("Personas.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                            Persona person = (Persona)formatter.Deserialize(stream);
                            Console.WriteLine("Person", i, ": ", person.InfoPersona());
                            stream.Close();
                        }
                        
                        Console.WriteLine("--------------------------------------------");
                        break;
                    case 5:
                        Console.WriteLine("\n");
                        x = false;
                        break;


                }


                    


                    
                
            }
        }
    }
}
