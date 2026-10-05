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
                Console.WriteLine("No hay datos por mostrar");
                return;
            }
            for(int i = 0; i < contador; i++)
            {
                Console.WriteLine((i + 1) + ".-" + nombres[i] + "-Nota:" + notas[i]);
            }
        }
        static public void buscar_estudiante()
        {
            Console.WriteLine("**********BUSCAR ESTUDIANTE**********");

            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados");
                return;
            }
            Console.Write("Ingresar nombre a buscar: ");
            string nom_buscar=Console.ReadLine().ToLower();
            bool encontrado= false;
            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == nom_buscar)
                {
                    Console.WriteLine(nombres[i]+" tiene " + notas[i]);
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("Estudiante no encontrado");
            }
        }
        static public void modificar_estudiante()
        {
            Console.WriteLine("**********MODIFICAR ESTUDIANTE**********");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados");
                return;
            }
            Console.Write("Ingresar nombre de estudiante: ");
            string nom_buscar= Console.ReadLine().ToLower();
            for (int i = 0;i<contador; i++)
            {
                if (nombres[i].ToLower() == nom_buscar)
                {
                    Console.WriteLine(nombres[i] + " tiene " + notas[i]);
                    double nueva_nota;
                    while (true)
                    {
                        Console.Write("Ingresar la nueva nota: ");
                        nueva_nota=double.Parse(Console.ReadLine());
                        if (nueva_nota >= 0 && nueva_nota <= 20)
                        {
                            notas[i]=nueva_nota;
                            Console.WriteLine("Nota modificada...");
                            break;
                        }
                        Console.WriteLine("Error, nota no válida[0-20]:");

                    }
                    break;
                }
            }
            Console.WriteLine("Estudiante no encontrado");
        }
        static public void burbuja()
        {
            double temp_notas;
            string temp_nombres;
            for (int i = 0; i < contador-1; i++)
            {
                for (int j = 0; j < contador-i-1; j++)
                {
                    if (notas[j] > notas[j + 1])
                    {
                        temp_notas = notas[j];
                        notas[j] = notas[j+1];
                        notas[j + 1] = temp_notas;

                        temp_nombres = nombres[j];
                        nombres[j] = nombres[j + 1];
                        nombres[j+1]= temp_nombres;
                    }
                }
            }
        }
        static public void seleccion()
        {
            Console.WriteLine("******REPORTE POR SELECCIÓN DESCENDENTE******");
            if (contador == 0)
            {
                Console.WriteLine("No hay datos por mostrar");
                return;
            }

            for (int i = 0; i < contador - 1; i++)
            {
                int max_idx = i;
                for (int j = i + 1; j < contador; j++)
                {
                    if (notas[j] > notas[max_idx])
                    {
                        max_idx = j;
                    }
                }

                double temp_nota = notas[max_idx];
                notas[max_idx] = notas[i];
                notas[i] = temp_nota;

                string temp_nombre = nombres[max_idx];
                nombres[max_idx] = nombres[i];
                nombres[i] = temp_nombre;
            }

            mostrar();
        }

        static public void promynot()
        {
            Console.WriteLine("******PROMEDIO Y NOTA MÁXIMA******");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados");
                return;
            }

            double suma = 0;
            double max_nota = notas[0];
            string mejor_alumno = nombres[0];

            for (int i = 0; i < contador; i++)
            {
                suma += notas[i];

                if (notas[i] > max_nota)
                {
                    max_nota = notas[i];
                    mejor_alumno = nombres[i];
                }
            }

            double promedio = suma / contador;

            Console.WriteLine("Promedio general del aula: " + promedio.ToString("F2"));
            Console.WriteLine("Nota máxima: " + max_nota + " (Estudiante: " + mejor_alumno + ")");
        }
        static void Main(string[] args)
        {
            Titulo();
            int opc = 0;
            while (opc != 8)
            {
                Console.Clear();
                Console.WriteLine("******MENU PRINCIPAL******");
                Console.WriteLine("[1]Registrar estudiante");
                Console.WriteLine("[2]Buscar estudiante");
                Console.WriteLine("[3]Modificar nota");
                Console.WriteLine("[4]Mostrar lista sin ordenar");
                Console.WriteLine("[5]Mostrar reporte ordenado por burbuja"); //Ascendente
                Console.WriteLine("[6]Mostrar por seleccion DESC"); //Por selection sort descendente
                Console.WriteLine("[7]Promedio y nota maxima");
                Console.WriteLine("[8]Salir");
                Console.Write("Ingresar opción: ");
                if (!int.TryParse(Console.ReadLine(), out opc))
                {
                    Console.WriteLine("Ingresar un valor numérico");
                    continue;
                }
                switch (opc)
                {
                    case 1:
                        Registrar_estudiante();break;
                    case 2:
                        buscar_estudiante();
                        break;
                    case 3:
                        modificar_estudiante();
                        break;
                    case 4:
                        mostrar();
                        break;
                    case 5:
                        burbuja();
                        break;
                    case 6:
                        seleccion();
                        break;
                    case 7:
                        promynot();
                        break;
                    case 8:
                        Console.WriteLine("Gracias por usar el sistema");
                        break;
                    default:
                        Console.WriteLine("Opción incorrecta..");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
