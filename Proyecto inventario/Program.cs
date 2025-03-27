using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyecto_inventario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion;

            Console.Title = "Inventario";

            Console.WriteLine("Inventario");
            Console.WriteLine("\n");
            Console.WriteLine("Agregar un nuevo producto..............................1");
            Console.WriteLine("Modificar datos de un producto.........................2");
            Console.WriteLine("Buscar un producto por nombre o código.................3");
            Console.WriteLine("Guardar y cargar inventario desde un archivo...........4");
            Console.WriteLine("Salir del sistema......................................5");
            Console.WriteLine("\n");
            Console.Write("eliga una opcion...");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    agregar_producto();
                break;
                case 2:
                    modificar();
                break;
                case 3:
                    //buscar_un_producto();
                break;
                case 4:

                break;
                case 5:
                    salir();
                break;
                default:
                    Console.WriteLine("introduzca una opcion valida!!!");
                break;
            }
        }
        static void agregar_producto()
        {
            string codigo, nombre;
            int stock;
            double precio;
            string desicion;
            
            Console.Clear();
            Console.WriteLine("agregar producto");
            Console.WriteLine("\n");
            Console.Write("introduzca el codigo del producto ");
            codigo = Console.ReadLine();
            Console.Write("introduzca el nombre del producto ");
            nombre = Console.ReadLine();
            Console.Write("introduzca el precio del producto $");
            precio = Double.Parse(Console.ReadLine());
            Console.Write("introduzca el numero de stock disponible ");
            stock = int.Parse(Console.ReadLine());

            if (precio >= 0 && stock > 0)
            {
                Console.WriteLine("\n");
                Console.Write("desea guardar los datos? S/N ");
                desicion = Console.ReadLine();

                if (desicion == "s" || desicion == "S")
                {
                    StreamWriter archivo = File.AppendText("datos_de_clientes.txt");

                    archivo.WriteLine(codigo + "\t" + nombre + "\t" + "$" + precio + "\t" + stock);
                    archivo.Close();
                    Console.WriteLine("\n");
                    Console.WriteLine("se ha guardado el producto!");
                    Console.ReadKey();
                }
                else if(desicion == "n" || desicion == "N")
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("se ha cancelado la operacion...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("solo puede elegir entre S o N");
                    Console.ReadKey();
                }

            }
            else
            {
                Console.WriteLine("\n");
                Console.WriteLine("ingrese un valor valido");
                Console.ReadKey();
            }
        }

        static void modificar()
        {
            Console.Clear();
            Console.WriteLine("Modificar datos de un producto");
            Console.WriteLine("\n");

            TextReader leerarchivo = new StreamReader("datos_de_clientes.txt");
            Console.WriteLine(leerarchivo.ReadToEnd());

            //int opcion_modificar;
            
            

            Console.WriteLine("Que desea modificar?");
            Console.WriteLine("\n");
            Console.WriteLine("codigo............................1");
            Console.WriteLine("producto..........................2");
            Console.WriteLine("precio............................3");
            Console.WriteLine("stock.............................4");
            Console.WriteLine("\n");
            Console.Write("eliga una opcion ");

            string filePath = "datos_de_clientes.txt";

            Console.WriteLine("Ingrese la palabra que desea reemplazar:");
            string palabraOriginal = Console.ReadLine();
            Console.WriteLine("Ingrese la nueva palabra para reemplazar:");
            string nuevaPalabra = Console.ReadLine();


            string contenido = File.ReadAllText(filePath);
            string contenidoModificado = contenido.Replace(palabraOriginal, nuevaPalabra);

            File.WriteAllText(filePath, contenidoModificado);

            Console.WriteLine("El archivo ha sido modificado.");
        }

        /*static void buscar_un_producto()
        {
            Console.Clear();
            Console.WriteLine("Buscar un producto por nombre o código");
            Console.WriteLine("\n");

        }*/
        
        static void salir() 
        { 
            Environment.Exit(0);
        }
    }
}