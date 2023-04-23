class Cliente {



    public string Dni {get; private set;}
    public string Apellido {get; private set;}
    public string Nombre {get; private set;}
    public DateTime FechaInscripcion {get;  set;}
    public int TipoEntrada {get;  set;}
    public double TotalAbonado {get;  set;}

public Cliente (string _dni, string _apellido, string _nombre, DateTime _fechainscripcion, int _TipoEntrada, double _totalabonado) {
    Dni=_dni;
    Apellido=_apellido;
    Nombre=_nombre;
    FechaInscripcion=_fechainscripcion;
    TipoEntrada=_TipoEntrada;
    TotalAbonado=_totalabonado;
}
}
//añadir metodo cambiarentrada
