namespace GestionTareaWeb.Models
{

    public class PermisosViewModel
    {
        public List<DataPermisosPantallaUsuarios> ListaDataPermisosPantallaUsuario { get; set; }
    }

    public class DataPermisosPantallaUsuarios
    {
        public string nombrePantalla { get; set; }

        public string nombreSeccion { get; set; }

        public string urlSeccion { get; set; }

        public string iconoPantalla { get; set; }

    }




}
