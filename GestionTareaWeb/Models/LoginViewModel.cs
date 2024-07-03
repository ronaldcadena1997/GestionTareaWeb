namespace GestionTareaWeb.Models
{
    public class Login
    {
        public string User { get; set; }
        public string Password { get; set; }
        public List<DataPermisosPantallaUsuario> ListaDataPermisosPantallaUsuario { get; set; }
    }





    public class DataPermisosPantallaUsuario
    {
        public string nombrePantalla { get; set; }

        public string nombreSeccion { get; set; }

        public string urlSeccion { get; set; }


    }










}