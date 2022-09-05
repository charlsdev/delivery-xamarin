using System;

namespace delivery_employes.Models
{
    public class Delivery
    {
        public string Id { get; set; }
        public string Cedula { get; set; }
        public string NameCompleto { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }
        public string Producto { get; set; }
        public string Precio { get; set; }
        public string Cantidad { get; set; }
        public string Subtotal { get; set; }
        public string Iva { get; set; }
        public string Total { get; set; }
    }
}