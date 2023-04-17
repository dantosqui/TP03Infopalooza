
class Tiquetera {


    public static int UltimoID=1;

    public static int DevolverUltimoId() {

        int id=UltimoID;
        UltimoID+=1;
        return id;
    } 
}