using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caso_semana07
{
    internal class Program
    {
        static int max = 100;
        static string[] nombres=new string[max];
        static double[] notas=new double[max];
        static int contador = 0;
        static public void Titulo()
        {
            Console.WriteLine("**************************");
            Console.WriteLine("Sistema de notas");
            Console.WriteLine("**************************");
        }
        static public void Registrar_estudiante()
        {
            Console.WriteLine("Registro de estudiante nuevo: ");
            if (contador >= max)
            {
                Console.WriteLine("Legamos a la capacidad máxima");
                return;
            }
            Console.Write("Ingresar nombres: ");
            string nombre=Console.ReadLine();
            double nota;
            while (true)
            {
                Console.Write("Ingresar nota: ");
                nota=double.Parse(Console.ReadLine());
                if(nota>=0 & nota <= 20)
                {
                    break;
                }
                Console.WriteLine("Error: La nota debe ser[0-20]");
            }
            nombres[contador] = nombre;
            notas[contador] = nota;
            contador++;
        }
        static public void mostrar()
        {
            Console.WriteLine("******Listado de Estudiantes******");
            if (contador == 0)
            {
                Console.WriteLine("No hya datos por mostrar");
                return;
            }
            for(int i = 0; i < contador; i++)
            {
                Console.WriteLine((i + 1) + ".-" + nombres[i] + "-Nota:" + notas[i]);
            }
        }
        static void Main(string[] args)
        {
            Titulo();
            int opc = 0;
            while (opc != 6)
            {
                Console.WriteLine("******MENU PRINCIPAL******");
                Console.WriteLine("[1]Registrar estudiante");
                Console.WriteLine("[2]Registrar estudiante");
                Console.WriteLine("[3]Modificar nota");
                Console.WriteLine("[4]Mostrar lista sin ordenar");
                Console.WriteLine("[5]Mostrar reporte ordenado por burbuja");
                Console.WriteLine("[6]Salir");
                Console.Write("Ingresar opción: ");
                if (opc < 1 || opc > 6)
                {
                    Console.WriteLine("Error fuera de rango[1-6]");
                    continue;
                }
                switch (opc)
                {
                    case 1:
                        Registrar_estudiante();break;
                    case 2:
                        //buscar_estudiante();
                        break;
                    case 3:
                        //modificar_nota();
                        break;
                    case 4:
                        mostrar();
                        break;
                    case 5:
                        //burbuja();
                        break;
                    case 6:
                        Console.WriteLine("Gracias por usar el sistema");
                        break;
                    default:
                        Console.WriteLine("Opción incorrecta..");
                        break;
                }
            }
        }
    }
}
