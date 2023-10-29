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
            return CantidadDias * 20000.0;
        }
    }
}
