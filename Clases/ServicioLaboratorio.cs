
namespace saludAr.Clases
{
    internal class ServicioLaboratorio : ServicioMedico
    {
        public string Nombre { get; set; }
        public int NivelComplejidad { get; set; }

        //cambie el orden de los parametros porque no funcionaba bien el calculo de los servicios de laboratorio de complejidad
        public ServicioLaboratorio(string nombre, int cantidadDias, int nivelComplejidad)
           : base(cantidadDias)

        {
            Nombre = nombre;
            NivelComplejidad = nivelComplejidad;
        }

        public override double CalcularPrecio()
        {
            double precioBase = CantidadDias * 10000;
            if (NivelComplejidad > 3)
            {
                precioBase += 0.25 * precioBase;
            }
            double iva = precioBase * 0.21;
            return precioBase + (iva/2);
        }
    }
}
