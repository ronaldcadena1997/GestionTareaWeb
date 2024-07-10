namespace GestionTareaWeb.Models
{
    public class HomeIndexViewModel
    {
        public string id { get; set; }
        public string user { get; set; }
        public IEnumerable<Proyecto> Proyectos { get; set; }
        public EjemploGUIDViewModel EjemploGUID_1 { get; set; }
        public EjemploGUIDViewModel EjemploGUID_2 { get; set; }

        public long nota { get; set; }
        public long idTask { get; set; }
        public string tarea { get; set; }
        public string usuario { get; set; }


        public string usuarioId { get; set; }

        public DataDashboard ObjDataDashboard { get; set; }

        public List<DataPermisosPantallaUsuarioss> ListaDataPermisosPantallaUsuario { get; set; }

        public UsuariosInformacion ObjUsuarios { get; set; }

        public List<UsuariosInformacion> ListaUsuarios { get; set; }

        public List<TaskViewModels> ListaTaskViewModel { get; set; }
        public List<TaskViewModels> ListaTaskViewModelEstudiante { get; set; }


        public FechasDashBoard ObjFechasDashBoard { get; set; }
    }


    public class DataDashboard
    {
        public int montajesRealizados { get; set; }

        public int vehiculosDisponibles { get; set; }

        public int llantasTotales { get; set; }

        public int pedidosRealizados { get; set; }
    }




    public class DataDiasDelaSemana
    {
        public List<DiasDeSemanaData> ListadataPorDia { get; set; }
        public List<DataChartPorDiaDashboard> ListaDataChartPorDiaDashboard { get; set; }

        public List<DataPedidoDashboard> ListaDetallePedidoDashboard { get; set; }

        public List<DataLlantaDashboard> ListaDetalleLlantaDashboard { get; set; }


    }


    public class DataLlantaDashboard
    {
        public string  termico { get; set; }
        public string placaAsignacion { get; set; }

        public string estadoLlanta { get; set; }

        public List<ListaDetalleLlantaInfo> listaDetalleLlantaDashboard { get; set; }
    }

    public class DetalleLlantaDashboard
    {
        public List<ListaDetalleLlantaInfo> listaListaDetalleLLantaInfo { get; set; }

    }

    public class ListaDetalleLlantaInfo
    {

        public string descripcion { get; set; }
        public string dataDescripcion { get; set; }
    }


    public class UsuariosInformacion
    {
        public string id { get; set; }

        public string nombre { get; set; }
        public string apellido { get; set; }

        public string correo { get; set; }

        public string telefono { get; set; }

        public string contrasenia { get; set; }

        public string tipoRol { get; set; }
    }
    public class ItemUsuarioTarea
    {
        public long idTask { get; set; }
        public string tarea { get; set; }
        public string usuario { get; set; }

        public long nota { get; set; }

        public string usuarioId { get; set; }
      
    }


    public class TaskViewModels
    {
        public string idEstuduante { get; set; }
        public string nombre { get; set; }

        public string descripcion { get; set; }

        public bool estadoNota { get; set; }
        public long nota { get; set; }

        public long idTask { get; set; }


    }


    public class TaskViewModelRegister
    {
        public string idEstuduante { get; set; }
        public string Nombre { get; set; }

        public long nota { get; set; }
        public string descripcion { get; set; }

        public long idTask { get; set; }


    }

    public class DataPedidoDashboard
    {
        public string codigoPedido { get; set; }
        public string enviadoPedido { get; set; }
        public string tipoSolicitud { get; set; }
        public string tipoPedido { get; set; }
        public string motivoPedido { get; set; }

        public List<DetallePedidoDashboard> listaDetallePedidoDashboard { get; set; }
    }




    public class DetallePedidoDashboard
    {
        public List<ListaDetallePedidoInfo> listaListaDetallePedidoInfo { get; set; }

    }

    public class ListaDetallePedidoInfo
    {

        public string descripcion { get; set; }
        public string dataDescripcion { get; set; }
    }





    public class DataChartPorDiaDashboard
    {

        public string codigo { get; set; }
        public string placa { get; set; }
        public string tipoVehiculo { get; set; }

        public string fechaMontaje { get; set; }
        public long? kmMontaje { get; set; }

        public List<NumerosTotalesDetalleMontaje>  listaNumerosTotalesDetalleMontaje { get; set; }

    }
    public class NumerosTotalesDetalleMontaje
    {

        public string descripcion { get; set; }
        public int numeroGeneral { get; set; }


    }




    public class DiasDeSemanaData
    {
        public int numeroDia { get; set; }
        public int dataPorDia { get; set; }
    }

    public class FechasDashBoard
    {
        public string fechaInicio { get; set; }

        public string fechaFin { get; set; }
    }

    public class DataChartDashboar
    {
        public string tipo { get; set; }
        public string fechaInicio { get; set; }

        public string fechaFin { get; set; }
    }


    public class DataPermisosPantallaUsuarioss
    {
        public string nombrePantalla { get; set; }

        public string nombreSeccion { get; set; }

        public string urlSeccion { get; set; }


    }
}