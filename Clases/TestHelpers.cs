class TestHelpers
{
    public static string GetStringPorConsola(string mensaje)
    {
        // validamos que ingrese algo
        string valor;

        do
        {
            Console.Write(mensaje);
            valor = Console.ReadLine();
        } while (string.IsNullOrEmpty(valor));

        return valor;
    }

    public static int GetIntPorConsola(string mensaje)
    {
        // validamos que no ingrese negativos
        int valor;

        do
        {
            Console.Write(mensaje);
        } while (!int.TryParse(Console.ReadLine(), out valor) || valor < 0);

        return valor;
    }

    public static double GetDoublePorConsola(string mensaje)
    {
        // validamos que no ingrese negativos
        double valor;

        do
        {
            Console.Write(mensaje);
        } while (!double.TryParse(Console.ReadLine(), out valor) || valor < 0);

        return valor;
    }

}
