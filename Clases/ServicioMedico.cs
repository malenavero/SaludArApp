
namespace saludAr.Clases
{
    internal class ServicioMedico:Servicio
    {
        public int CantidadDias { get; set; }

        public ServicioMedico(int cantidadDias)
        {
            CantidadDias = cantidadDias;
        }
    }
}
