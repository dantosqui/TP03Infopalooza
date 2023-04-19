
Dictionary<int, Cliente> clientes = new Dictionary<int, Cliente>();
bool chau = true;

while (chau) {

    Console.WriteLine("Menu: \n1. Nueva inscripcion\n2. Obtener estadisticas del evento\n3. Buscar cliente\n4. Cambiar entrada de un cliente\n5. Salir");
    string r=Console.ReadLine();
    switch(r){
        case ("1"):
        
        NuevaInscripcion(ref clientes);
        break;
        case ("2"):
            
        break;
        case ("3"):
            
        break;
        case ("4"):
            
        break;
        case ("5"):
        chau=false;    
        break;
        
        default:
        break;
    }
    


}


void NuevaInscripcion(ref Dictionary<int,Cliente> c){

    bool v=false;int te=0; double va=0; string dni, apellido, nombre; DateTime fecha=DateTime.Now; int id;

    dni=IngresarString("Ingrese su DNI: ");
    apellido=IngresarString("Ingrese Apellido: ");
    nombre=IngresarString("Ingrese Nombre: ");
    while (v){v= DateTime.TryParse(IngresarString("Ingrese la fecha de inscripcion: "), out fecha);}
    v=true;while (v) {te=IngresarInt("Ingrese el Tipo de Entrada: "); v=te<1&&te>4;};
    switch(te) {
        case 1: va=15000; break;case 2: va=30000; break;case 3: va=10000; break;case 4: va=40000; break;
        }
    id=Tiquetera.DevolverUltimoId();
    c.Add(id,new Cliente(dni,apellido,nombre, fecha, te,va));
}

string IngresarString(string prompt) {

    Console.Write(prompt);
    return Console.ReadLine();
}

int IngresarInt(string prompt) {
    Console.Write(prompt);
    int r=18122022; bool b=false;
    while (!b) {b=int.TryParse(Console.ReadLine(), out r);};
    return r;
}
double IngresarDouble(string prompt) {
    Console.Write(prompt);
    double r=18.122022; bool b=false;
    while (!b) {b=double.TryParse(Console.ReadLine(), out r);};
    return r;
}