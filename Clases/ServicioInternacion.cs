namespace saludAr.Clases
{
    internal class ServicioInternacion : ServicioMedico
    {
        public string Especialidad { get; set; }

        public ServicioInternacion(string especialidad, int cantidadDias)
            : base(cantidadDias)
        {
            Especialidad = especialidad;
        }

        public override double CalcularPrecio()
        {
            double precioBase = CantidadDias * 20000.0;
            double iva = precioBase * 0.21;
            return precioBase + (iva/2);
        }
    }
}
