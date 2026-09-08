using System;
using System.Collections.Generic;
using System.Text;

namespace ArticuosCRUD
{
    internal class Menu
    {
        private readonly string Titulo;
        private readonly string[] Opciones;
        private List<Producto> ListaProductos;
        public ManejadorArticulos Manejador { get; set; }
        public Menu(string titulo, string[] opciones)
        {
            Titulo = titulo;
            Opciones = opciones;
            Manejador = new ManejadorArticulos();
        }
        public void MostrarMenu()
        {
            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine(Titulo);
                Console.WriteLine(new string('#', Titulo.Length));
                for (int i = 0; i < Opciones.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {Opciones[i]}");
                }
                Console.WriteLine("0. Salir");
                //Console.WriteLine("Gestor de Articulos");
                //Console.WriteLine("====================");
                //Console.WriteLine("1. Agregar");
                //Console.WriteLine("2. Listar");
                //Console.WriteLine("3. Buscar");
                //Console.WriteLine("4. Modificar");
                //Console.WriteLine("5. Eliminar");
                //Console.WriteLine("0. Salir");
                string opcion = Console.ReadLine() ?? "";
                switch(opcion)
                {
                    case "0":
                        continuar = false;
                        break;
                    case "1":
                        MostrarAgregar();
                        break;
                    case "2":
                        MostrarListar();
                        break;
                    case "3":
                        MostrarBuscar();
                        break;
                    case "4":
                        MostrarBuscarNombre();
                        break;
                    case "5":
                        MostrarModificar();
                        break;
                    case "6":
                        MostrarEliminar();
                        break;
                    default:
                        Console.WriteLine("Opcion Invalida");
                        Console.ReadLine();
                        break;
                }
            }
        }
        public void MostrarAgregar()
        {
            Console.Clear();
            Console.WriteLine("Agregar Producto");
            Console.WriteLine("================");
            Console.WriteLine();
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Precio: ");
            decimal precio = (decimal.TryParse(Console.ReadLine(), out decimal valor))? valor:0;
            Console.Write("Cantidad: ");
            int cantidad = (int.TryParse(Console.ReadLine(), out int valor1)) ? valor1 : 0;
            Manejador.AgregarProducto(nombre, cantidad, precio);
            Console.WriteLine("Producto creado correctamente");
            Console.ReadLine();
        }
        public void MostrarListar()
        {
            Console.Clear();
            Console.WriteLine("Listar Productos");
            Console.WriteLine("================");
            Manejador.ListarProductos();
            Console.ReadLine();
        }
        public void MostrarBuscar()
        {
            int id;
            Console.Clear();
            Console.WriteLine("Buscar Producto por ID");
            Console.WriteLine("======================");
            id = PedirValorentero("ID");
            Producto resultado = Manejador.BuscarptoductoPorId(id);
            if (resultado != null)
            {
                Console.WriteLine(resultado.ToString());
            }
            else
            {
                Console.WriteLine("Producto no encontrado");
            }
            Console.ReadLine();
        }
        public int PedirValorentero(string titulo)
        {
            while (true)
            {
                Console.WriteLine($"{titulo}: ");
                if(int.TryParse(Console.ReadLine(), out int valor))
                {
                    return valor;
                }
                else
                {
                    Console.WriteLine("valor no valido. Ingresa nuevamente");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            
        }
        public void MostrarBuscarNombre()
        {
            Console.Clear();
            Console.WriteLine("buscar por Nombre");
            Console.WriteLine("================");
            Console.WriteLine();
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            foreach (Producto item in Manejador.BuscarProductosPorNombre(nombre))
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }
        public void MostrarModificar()
        {
            Console.Clear();
            Console.WriteLine("Modificar Producto");
            Console.WriteLine("=============================");
            Console.WriteLine();
            int id = PedirValorentero("ID de producto");
            Producto? producto = Manejador.BuscarptoductoPorId(id);
            if (producto is null)
            {
                Console.WriteLine("Producto no encontrado");
                return;
            }
            Console.WriteLine(producto.ToString());
            Console.WriteLine("Ingrese los datos nuevos");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Precio: ");
            decimal precio = (decimal.TryParse(Console.ReadLine(), out decimal valor)) ? valor : 0;
            Console.Write("Cantidad: ");
            int cantidad = (int.TryParse(Console.ReadLine(), out int valor1)) ? valor1 : 0;
            Manejador.ModificarProducto(id, nombre, precio, cantidad);
            Console.WriteLine("Producto modificado correctamente");
            Console.ReadLine();
        }
        public void MostrarEliminar()
        {
            Console.Clear();
            Console.WriteLine("Eliminar Producto");
            Console.WriteLine("=================");
            int id = PedirValorentero("ID del producto");
            Producto? producto = Manejador.BuscarptoductoPorId(id);
            if (producto is null)
            {
                Console.WriteLine("Producto no encontrado");
                return;
            }
            Console.WriteLine(producto.ToString());
            Console.WriteLine("Deseas eliminar el producto?");
            string respuesta = Console.ReadLine()?.Trim()?? "n";
            if (respuesta.Equals("s", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Operacion Cancelada. Presione cualquier tecla para continuar...");
                return;
            }
            Manejador.EliminarProducto(id);
            Console.WriteLine("Producto eliminado correctamente");
            Console.ReadLine();
        }
    }
}
