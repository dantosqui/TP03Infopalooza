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

            break;
        case ("4"):

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
    while (v) { v = DateTime.TryParse(IngresarString("Ingrese la fecha de inscripcion: "), out fecha); }
    v = true; while (v) { te = IngresarInt("Ingrese el Tipo de Entrada. \nDia 1:$15000 Dia 2:$30000 Dia 3:$10000 Full Pass (4):$40000 :"); v = te < 1 && te > 4; };
    switch (te)
    {
        case 1: precio = 15000; break;
        case 2: precio = 30000; break;
        case 3: precio = 10000; break;
        case 4: precio = 40000; break;
    }
    do {va=IngresarDouble("Total: $"+ precio + ". Ingrese total a abonar:");} while(va<precio);
    if (va>precio) {Console.WriteLine("Su vuelto es: " + (va-precio));}
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