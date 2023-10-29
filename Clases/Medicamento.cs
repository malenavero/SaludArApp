
namespace saludAr.Clases
{
    internal class Medicamento:Servicio
    {
        public string Nombre { get; set; }
        public double PorcentajeGanancia { get; set; }
        public double PrecioLista { get; set; }
        public Medicamento(string nombre, double porcentajeGanancia, double precioLista)
        {
            Nombre = nombre;
            PorcentajeGanancia = porcentajeGanancia;
            PrecioLista = precioLista;
        }

        public override double CalcularPrecio()
        {
            double precioConGanancia = PrecioLista + (PrecioLista * PorcentajeGanancia / 100);
            double iva = 0.21 * precioConGanancia;
            double precioFinal = precioConGanancia + iva;
            return precioFinal;
        }

    }
}
