using System;
using System.Collections.Generic;
using System.Text;

namespace ArticuosCRUD
{
    internal class Producto
    {
        public Producto(int id, string nombre, int cantidad, decimal precio)
        {
            this.Id = id;
            Nombre = nombre;
            Cantidad = cantidad;
            Precio = precio;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Nombre}, Precio: {Precio}, Cantidad: {Cantidad}";
        }
    }
}