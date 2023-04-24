class Cliente
{



    public string Dni { get; private set; }
    public string Apellido { get; private set; }
    public string Nombre { get; private set; }
    public DateTime FechaInscripcion { get; private set; }
    public int TipoEntrada { get; private set; }
    public double TotalAbonado { get; private set; }

    static public int[] valoresEntradas = { 15000, 30000, 10000, 40000 };

    public Cliente(string _dni, string _apellido, string _nombre, DateTime _fechainscripcion, int _TipoEntrada, double _totalabonado)
    {
        Dni = _dni;
        Apellido = _apellido;
        Nombre = _nombre;
        FechaInscripcion = _fechainscripcion;
        TipoEntrada = _TipoEntrada;
        TotalAbonado = _totalabonado;
    }

    public bool CambiarEntrada(int tipo, double plata)
    {

        double valorEntrada;
        bool ret = valoresEntradas[tipo - 1] > valoresEntradas[this.TipoEntrada];
        if (ret)
        { this.TipoEntrada = tipo; this.TotalAbonado += valoresEntradas[tipo - 1]; }

        return ret;
    }
}