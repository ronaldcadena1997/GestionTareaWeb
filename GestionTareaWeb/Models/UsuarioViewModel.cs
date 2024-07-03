using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace GestionTareaWeb.Models
{
    public class UsuarioViewModel
    {
        public string id { get; set; }

        public string idRol { get; set; }

        public string tipoRol { get; set; }

        public string nombre { get; set; }
        public string apellido { get; set; }

        public string telefono { get; set; }

        public string descripcionRoles { get; set; }

        public string correo { get; set; }

        public string contrasenia { get; set; }

        public List<ItemsUsuarios> itemUsuario { get; set; }

        public List<ItemRoles> ListaItemRoles { get; set; }
        
    }

    public class ItemsUsuarios
    {
        public string nombre { get; set; }
        public string apellido { get; set; }

        public string correo { get; set; }

        public string telefono { get; set; }

        public string tipoRol { get; set; }

        public string  id { get; set; }


    }

    public class ItemRoles
    {
        public string id { get; set; }

        public string descripcion { get; set; }

    }



}
