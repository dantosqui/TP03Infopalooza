//todo:cambiar colores porque dice el enunciado
Dictionary<int, Cliente> clientes = new Dictionary<int, Cliente>();
bool chau = true;

while (chau)
{

    Console.WriteLine("Menu: \n1. Nueva inscripcion\n2. Obtener estadisticas del evento\n3. Buscar cliente\n4. Cambiar entrada de un cliente\n5. Salir");
    string r = Console.ReadLine();
    switch (r)
    {
        case ("1"):
            NuevaInscripcion(ref clientes);
            break;
        case ("2"):
            ObtenerEstadisticas(clientes);
            break;
        case ("3"):
            Cliente c = BuscarCLiente(clientes);
            if (c != null) { Console.WriteLine($"Apellido:{c.Apellido} Nombre:{c.Nombre} Fecha:{c.FechaInscripcion.ToShortDateString} Tipo de entrada:{c.TipoEntrada} Total abonado: {c.TotalAbonado}"); }
            break;
        case ("4"):
            Cliente c2 = BuscarCLiente(clientes);
            if (c2 != null) { CambiarEntrada(ref c2); }
            break;
        case ("5"):
            chau = false;
            break;

        default:
            break;
    }



}


void NuevaInscripcion(ref Dictionary<int, Cliente> c)
{

    bool v = false; int te = 0; double va, precio = 0; string dni, apellido, nombre; DateTime fecha = DateTime.Now; int id;

    dni = IngresarString("Ingrese su DNI: ");
    apellido = IngresarString("Ingrese Apellido: ");
    nombre = IngresarString("Ingrese Nombre: ");
    while (!v) { v = DateTime.TryParse(IngresarString("Ingrese la fecha de inscripcion(AAAA/MM/DD): "), out fecha); }
    v = true; while (v) { te = IngresarInt("Ingrese el nuevo tipo de Entrada. \nDia 1:$15000 Dia 2:$30000 Dia 3:$10000 Full Pass (4):$40000 :"); v = te < 1 && te > 4; };
    switch (te)
    {
        case 1: precio = 15000; break;
        case 2: precio = 30000; break;
        case 3: precio = 10000; break;
        case 4: precio = 40000; break;
    }
    do { va = IngresarDouble("Total: $" + precio + ". Ingrese total a abonar:"); } while (va < precio);
    if (va > precio) { Console.WriteLine("Su vuelto es: " + (va - precio)); }
    id = Tiquetera.DevolverUltimoId();
    c.Add(id, new Cliente(dni, apellido, nombre, fecha, te, precio));
}

void ObtenerEstadisticas(Dictionary<int, Cliente> clientes)
{

    if (clientes.Any())
    {
        int cantClientes = clientes.Count(); int[] sumaTiposEntrad = new int[4]; Dictionary<DateTime, double> recaudacionPorDia = new Dictionary<DateTime, double>(); double rectotal = 0;

        foreach (var i in clientes)
        {

            sumaTiposEntrad[i.Value.TipoEntrada - 1] += 1;
            if (recaudacionPorDia.Keys.Contains(i.Value.FechaInscripcion)) recaudacionPorDia[i.Value.FechaInscripcion] += i.Value.TotalAbonado;
            else recaudacionPorDia.Add(i.Value.FechaInscripcion, i.Value.TotalAbonado);

            rectotal += i.Value.TotalAbonado;

        }

        sumaTiposEntrad[0] = sumaTiposEntrad[0] * 100 / cantClientes; sumaTiposEntrad[1] = sumaTiposEntrad[1] * 100 / cantClientes; sumaTiposEntrad[2] = sumaTiposEntrad[2] * 100 / cantClientes; sumaTiposEntrad[3] = sumaTiposEntrad[3] * 100 / cantClientes;

        Console.WriteLine($"Cantidad de clientes: {cantClientes}. \nPorcentajes de cada tipo de entrada: Tipo 1: {sumaTiposEntrad[0]}% Tipo 2: {sumaTiposEntrad[2]}% Tipo 3: {sumaTiposEntrad[2]}% Tipo 4: {sumaTiposEntrad[3]}% \nRecaudacion Total: {rectotal}");

        Console.WriteLine("Recaudacion de cada dia:");
        foreach (var i in recaudacionPorDia)
        {
            Console.WriteLine($"Recaudacion del dia {i.Key.ToShortDateString()}: {i.Value}");
        }
    }
    else { Console.WriteLine("Aún no hay clientes."); }

}

Cliente BuscarCLiente(Dictionary<int, Cliente> c)
{

    if (c.Any())
    {
        bool v;
        int id;

        do { id = IngresarInt("Ingrese ID del cliente a buscar: "); v = c.ContainsKey(id); } while (!v);
        return c[id];
    }
    else { Console.WriteLine("Aun no hay clientes"); return null; }

}

void CambiarEntrada(ref Cliente c)
{
    double precio = 0; int te = 0; bool v = true; double va; DateTime fecha=DateTime.Now;
    while (!v) { v = DateTime.TryParse(IngresarString("Ingrese la fecha de inscripcion(AAAA/MM/DD): "), out fecha); }
    v=true;while (v) { te = IngresarInt("Ingrese el Tipo de Entrada. \nDia 1:$15000 Dia 2:$30000 Dia 3:$10000 Full Pass (4):$40000 :"); v = te < 1 && te > 4 && te==c.TipoEntrada; };
    switch (te)
    {
        case 1: precio = 15000; break;
        case 2: precio = 30000; break;
        case 3: precio = 10000; break;
        case 4: precio = 40000; break;
    }
    do { va = IngresarDouble("Total: $" + precio + ". Ingrese total a abonar:"); } while (va < precio);
    c.TipoEntrada=te;c.TotalAbonado=va+c.TotalAbonado;c.FechaInscripcion=fecha;
}

#region funcionesingresar
string IngresarString(string prompt)
{

    Console.Write(prompt);
    return Console.ReadLine();
}

int IngresarInt(string prompt)
{
    Console.Write(prompt);
    int r = 18122022; bool b = false;
    while (!b) { b = int.TryParse(Console.ReadLine(), out r); };
    return r;
}
double IngresarDouble(string prompt)
{
    Console.Write(prompt);
    double r = 18.122022; bool b = false;
    while (!b) { b = double.TryParse(Console.ReadLine(), out r); };
    return r;
}
#endregion