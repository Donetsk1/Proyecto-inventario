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
        static List<string> inventario = new List<string>(); // Lista para manejar el inventario en memoria
        static string filePath = "datos_de_clientes.txt";

        static void Main(string[] args)
        {
            int opcion;

            Console.Title = "Inventario";

            do
            {
                Console.Clear();
                Console.WriteLine("Inventario");
                Console.WriteLine("\n");
                Console.WriteLine("Agregar un nuevo producto..............................(1)");
                Console.WriteLine("Modificar datos de un producto.........................(2)");
                Console.WriteLine("Buscar un producto por nombre o código.................(3)");
                Console.WriteLine("Cargar inventario desde un archivo.....................(4)");
                Console.WriteLine("Salir del sistema......................................(5)");
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
                        buscar_un_producto();
                        break;
                    case 4:
                        GuardarCargarInvent();
                        break;
                    case 5:
                        salir();
                        break;
                    default:
                        Console.WriteLine("\n");
                        Console.Write("introduzca una opcion valida!!!");
                        break;
                }
                Console.ReadKey();
            }
            while (opcion != 5);
        }

        //agregar un producto a un archivo

        static string codigo, nombre;
        static int stock;
        static double precio;
        static void agregar_producto()
        {
            
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
                    Console.WriteLine("\n");
                    Console.Write("presione una tecla para continuar...");
                    return;
                }
                else if(desicion == "n" || desicion == "N")
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("se ha cancelado la operacion...");
                    Console.WriteLine("\n");
                    Console.Write("presione una tecla para continuar...");
                    return;
                }
                else
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("solo puede elegir entre S o N");
                    Console.WriteLine("\n");
                    Console.Write("presione una tecla para continuar...");
                    return;
                }

            }
            else
            {
                Console.WriteLine("\n");
                Console.WriteLine("ingrese un valor valido");
                Console.WriteLine("\n");
                Console.Write("presione una tecla para continuar...");
                return;
            }
        }

        //modificacion de un producto

        static void modificar()
        {
            /*Console.Clear();
            Console.WriteLine("Modificar Producto");

            if (inventario.Count == 0)
            {
                Console.WriteLine("No hay productos en el inventario.");
                Console.WriteLine("\n");
                Console.Write("presione una tecla para continuar...");
                return;
            }

            Console.Write("Ingrese el código o nombre del producto a modificar: ");
            string criterio = Console.ReadLine().Trim();
            int index = inventario.FindIndex(p => p.IndexOf(criterio, StringComparison.OrdinalIgnoreCase) >= 0);

            if (index == -1)
            {
                Console.WriteLine("Producto no encontrado.");
                Console.WriteLine("\n");
                Console.Write("presione una tecla para continuar...");
                return;
            }

            Console.WriteLine($"Producto encontrado: {inventario[index]}");

            Console.Write("Nuevo nombre: ");
            string nuevoNombre = Console.ReadLine().Trim();
            Console.Write("Nuevo precio: ");
            if (!double.TryParse(Console.ReadLine(), out double nuevoPrecio))
            {
                Console.WriteLine("Precio inválido.");
                Console.WriteLine("\n");
                Console.Write("presione una tecla para continuar...");
                return;
            }
            Console.Write("Nuevo stock: ");
            if (!int.TryParse(Console.ReadLine(), out int nuevoStock))
            {
                Console.WriteLine("Stock inválido.");
                Console.WriteLine("\n");
                Console.Write("presione una tecla para continuar...");
                return;
            }

            string[] datos = inventario[index].Split('\t');
            inventario[index] = $"{datos[0]}\t{nuevoNombre}\t${nuevoPrecio}\t{nuevoStock}";

            Console.WriteLine("\nProducto modificado correctamente.");
            Console.WriteLine("\n");
            Console.Write("presione una tecla para continuar...");
            */
        }

        //busqueda de un articulo

        static void buscar_un_producto()
        {
            Console.Clear();
            Console.WriteLine("Buscar un producto por nombre o código");
            Console.WriteLine("\n");

            Console.Write("Ingrese el código o nombre del producto a buscar: ");
            string criterio = Console.ReadLine();

            string filePath = "datos_de_clientes.txt";

            if (File.Exists(filePath))
            {
                string[] lineas = File.ReadAllLines(filePath);
                bool encontrado = false;

                Console.WriteLine("Resultados de la búsqueda:");
                foreach (string linea in lineas)
                {
                    if (linea.Contains(criterio))
                    {
                        Console.WriteLine(linea);
                        encontrado = true;
                    }
                }

                if (!encontrado)
                {
                    Console.WriteLine("No se encontró ningún producto con ese nombre.");
                    Console.WriteLine("\n");
                    Console.Write("presione una tecla para continuar...");
                }
            }
            else
            {
                Console.WriteLine("El archivo de inventario no existe.");
                Console.WriteLine("\n");
                Console.Write("presione una tecla para continuar...");
            }
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        //cargar inventario de un archivo

        static void GuardarCargarInvent()
        {
            int opcion;
            string filePath = "datos_de_clientes.txt";

            Console.Clear();

            if (File.Exists(filePath))
            {
                string contenido = File.ReadAllText(filePath);
                Console.WriteLine("Datos cargados: ");
                Console.WriteLine("Codigo / Nombre  / Precio  / Stock ");
                Console.WriteLine("\n");
                Console.WriteLine(contenido);
                Console.WriteLine("\n");
                Console.Write("presione una tecla para continuar...");
                return;
            }
            else
            {
                Console.WriteLine("El archivo no existe.");
                Console.Write("presione una tecla para continuar...");
                Console.ReadKey();
                return;
            }
        }

        //Esta funcion GuardarDatos esta implementada en agregar producto con steamwriter por lo que es inservible
        /*static void GuardarDatos(string filePath)
        {

            string datos = codigo;

            File.WriteAllText(filePath, datos);
            Console.WriteLine("Datos guardados correctamente.");
        }*/
        /////////////////////////////////////////////////////////////////////////
        
        /*static void CargarDatos(string filePath)
        {
            
        }*/

        //salida del programa

        static void salir() 
        { 
            Environment.Exit(0);
        }
    }
}