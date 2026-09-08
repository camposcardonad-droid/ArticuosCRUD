using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ArticuosCRUD
{
    internal class ManejadorArticulos
    {
        private List<Producto> listaProductos;
        public ManejadorArticulos()
        {
            listaProductos = new List<Producto>();
        }
        public void AgregarProducto(string nombre, int cantidad, decimal precio)
        {
            Producto producto = new Producto(listaProductos.Count + 1, nombre, cantidad, precio);
            listaProductos.Add(producto);
            
        }
        public void ListarProductos()
        {
            foreach (Producto item in listaProductos)
            {
                Console.WriteLine(item.ToString());
            }
        }
        public Producto BuscarptoductoPorId(int id)
        {
            foreach (Producto producto in listaProductos)
            {
                if (producto.Id == id)
                {
                    return producto;
                }
            }
            return null;
        }
        public List<Producto> BuscarProductosPorNombre(string nombre)
        {
            return listaProductos.Where(p => p.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public void ModificarProducto(int id, string nombre, decimal precio, int cantidad)
        {
            Producto? producto = BuscarptoductoPorId(id);
            if (producto is not null)
            {
                producto.Nombre = nombre;
                producto.Precio = precio;
                producto.Cantidad = cantidad;
            }
            
        }
        public void EliminarProducto(int id)
        {
            Producto producto = BuscarptoductoPorId(id);
            if (producto is not null)
            {
                listaProductos.Remove(producto);
            }
        }
    }
}
