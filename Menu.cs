using System;
using System.Collections.Generic;
using System.Text;

namespace ArticuosCRUD
{
    internal class Menu
    {
        public Menu()
        {

        }
        public void MostrarMenu()
        {
            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("Gestor de Articulos");
                Console.WriteLine("====================");
                Console.WriteLine("1. Agregar");
                Console.WriteLine("2. Listar");
                Console.WriteLine("3. Buscar");
                Console.WriteLine("4. Modificar");
                Console.WriteLine("5. Eliminar");
                Console.WriteLine("6. Salir");
                string opcion = Console.ReadLine() ?? "";
                switch(opcion)
                {
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opcion Invalida");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
