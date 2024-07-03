using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using GestionTareaWeb.Models;
using GestionTareaWeb.Servicios;

namespace GestionTareaWeb.Helpers
{
    public class EnviarCorreoPedidos
    {

        //public string EnvioCorreoPedido(TipoSolicitudCorreo objSolicitudCorreo
        //                                ,List<CabeceradCorreo> ListaCabecera
        //                                , List<ItemGuardarPedidosCorreo> ListaPedidos 
        //                                ,List<ObtenerInformacionConfiguracionParametroCorreosDe>  ListaDe 
        //                                ,List<ObtenerInformacionConfiguracionParametroCorreoPara> ListaPara
        //                                ,List<ObtenerInformacionConfiguracionParametroCorreoCopia> ListaCopia )
        //{
        //    var email = new MailMessage();


        //    var TiempoDia ="";

        //    DateTime ahora = DateTime.Now;
        //    var horaActual = ahora.TimeOfDay;
        //    // Definir intervalos para día, tarde y noche
        //    TimeSpan inicioDia = new TimeSpan(1, 0, 0);     // 1:00 AM
        //    TimeSpan finDia = new TimeSpan(17, 59, 59);    // 5:59 PM
        //    TimeSpan inicioTarde = new TimeSpan(18, 0, 0); // 6:00 PM
        //    TimeSpan finTarde = new TimeSpan(20, 59, 59);  // 8:59 PM

        //    if (horaActual >= inicioDia && horaActual <= finDia)
        //    {
        //        TiempoDia= "día";
        //    }
        //    else if (horaActual >= inicioTarde && horaActual <= finTarde)
        //    {
        //        TiempoDia= "tarde";
        //    }
        //    else
        //    {
        //        TiempoDia= "noche";
        //    }


        //    var tablaHTML = "<style>" +
        //        "#customers { font-family: Arial, Helvetica, sans-serif; border-collapse: collapse; width: 100%; margin-bottom: 2rem; } #customers td, #customers th { border: 1px solid #ddd; padding: 8px; } #customers tr:nth-child(even) { background-color: #f2f2f2; } #customers tr:hover { background-color: #ddd; } #customers th { padding-top: 12px; padding-bottom: 12px; text-align: left; background-color: #04AA6D; color: white; } #ppp{margin-top: 2rem;}" +
        //           "</style>" +
        //           "<p id=\"ppp\">Estimados buenas"+ TiempoDia +".  </p>" +
        //           "<p id=\"data\" style=\"font-size:15px;\">Por medio del presente solicito " + objSolicitudCorreo .textoTipoPedido.ToLower()+ "para los equipos nuevos que se detallan en el siguiente cuadro.  " + "</p>" +
        //            "<p id=\"dataSol\" style=\"font-size:15px;\">" + objSolicitudCorreo.textoTipoSolicitud.ToUpper() + "-  Tipo: "   + objSolicitudCorreo.textoTipoSolicitud.ToLower() + "</p>" +
        //           "<table id=\"customers\">" +
        //               "<thead>" +
        //                   "<tr>";



        //    var totalCantidad = 0;



        //    if (objSolicitudCorreo.textoTipoPedido =="LLANTAS" && objSolicitudCorreo.textoTipoSolicitud == "PROGRAMADA"  )
        //    {

        //        foreach (var item in ListaCabecera)
        //        {
        //            tablaHTML +=
        //                  "<th>" + item.nombreCampo + "</th>";

        //        }

        //        tablaHTML += "</tr>" +
        //                    "</thead>" +
        //                    "<tbody>";


        //        foreach (var item in ListaPedidos)
        //        {
        //            tablaHTML += "<tr>" +
        //                        "<td>" + item.eje + "</td>" +
        //                        "<td>" + item.medida + "</td>" +
        //                        "<td>" + item.cantidad + "</td>" +
        //                        "</tr>";
        //            totalCantidad = totalCantidad + (int)item.cantidad;


        //        }
        //        tablaHTML += "<tr>" +
        //                        "<td> </td>"+
        //                        "<td>TOTAL</td>"+
        //                        "<td>"+totalCantidad+"</td>"+
        //                       "</tr>";


        //        tablaHTML += "</tbody>" +
        //           "</table> ";




        //    }


        //    if (objSolicitudCorreo.textoTipoPedido == "LLANTAS" && objSolicitudCorreo.textoTipoSolicitud == "ESPECIAL")
        //    {

        //        foreach (var item in ListaCabecera)
        //        {
        //            tablaHTML +=
        //                  "<th>" + item.nombreCampo + "</th>";

        //        }

        //        tablaHTML += "</tr>" +
        //                    "</thead>" +
        //                    "<tbody>";


        //        foreach (var item in ListaPedidos)
        //        {
        //            tablaHTML += "<tr>" +
        //                        "<td>" + item.medida + "</td>" +
        //                        "<td>" + item.eje + "</td>" +
        //                        "<td>" + item.cantidad + "</td>" +
        //                        "</tr>";
        //            totalCantidad = totalCantidad + (int)item.cantidad;


        //        }
        //        tablaHTML += "<tr>" +
        //                           "<td> </td>" +
        //                           "<td>TOTAL</td>" +
        //                           "<td>" + totalCantidad + "</td>" +
        //                          "</tr>";

        //        tablaHTML += "</tbody>" +
        //    "</table> ";
        //    }



        //    if (objSolicitudCorreo.textoTipoPedido == "VEHICULOS" && objSolicitudCorreo.textoTipoSolicitud == "PROGRAMADA")
        //    {
        //        foreach (var item in ListaCabecera)
        //        {


        //            if (item.nombreCampo != "TIPOVEHICULO" || item.nombreCampo != "PLACA-CHASIS")
        //            {
        //                if (item.nombreCampo == "PLACA-CABEZAL")
        //                {

        //                    tablaHTML +=
        //                     "<th>" + "PLACA" + "</th>";

        //                }
        //                else
        //                {
        //                    tablaHTML +=
        //                   "<th>" + item.nombreCampo + "</th>";

        //                }

        //            }

        //        }

        //        foreach (var item in ListaPedidos)
        //        {
        //            tablaHTML += "<tr>" +
        //                        "<td>" + item.placa + "</td>" +
        //                        "<td>" + item.eje + "</td>" +
        //                        "<td>" + item.medida + "</td>" +
        //                         "<td>" + item.posicion + "</td>" +
        //                          "<td>" + item.cantidad + "</td>" +
        //                        "</tr>";
        //            totalCantidad = totalCantidad + (int)item.cantidad;


        //        }
        //        tablaHTML += "<tr>" +
        //                           "<td> </td>" +
        //                           "<td> </td>" +
        //                           "<td> </td>" +
        //                           "<td>TOTAL</td>" +
        //                           "<td>" + totalCantidad + "</td>" +
        //                          "</tr>";

        //        tablaHTML += "</tbody>" +
        //    "</table> ";




        //    }

        //    if (objSolicitudCorreo.textoTipoPedido == "VEHICULOS" && objSolicitudCorreo.textoTipoSolicitud == "ESPECIAL")
        //    {
        //        foreach (var item in ListaCabecera)
        //        {


        //            if (item.nombreCampo != "TIPOVEHICULO" || item.nombreCampo != "PLACA-CHASIS")
        //            {
        //                if (item.nombreCampo == "PLACA-CABEZAL")
        //                {

        //                    tablaHTML +=
        //                     "<th>" + "PLACA" + "</th>";

        //                }
        //                else
        //                {
        //                    tablaHTML +=
        //                   "<th>" + item.nombreCampo + "</th>";

        //                }

        //            }

        //        }

        //        foreach (var item in ListaPedidos)
        //        {
        //            tablaHTML += "<tr>" +
        //                        "<td>" + item.placa + "</td>" +
        //                        "<td>" + item.marca + "</td>" +
        //                        "<td>" + item.modelo + "</td>" +
        //                         "<td>" + item.fechaMontaje + "</td>" +
        //                          "<td>" + item.kilometroAcumulado + "</td>" +
        //                          "<td>" + item.posicion + "</td>" +
        //                          "<td>" + item.cantidad + "</td>" +
        //                          "<td>" + item.kilometroActual + "</td>" +
        //                          "<td>" + item.kilometroRecorrido + "</td>" +
        //                          "<td>" + item.medida + "</td>" +
        //                        "</tr>";
        //            totalCantidad = totalCantidad + (int)item.cantidad;


        //        }
        //        tablaHTML += "<tr>" +
        //                           "<td> </td>" +
        //                           "<td> </td>" +
        //                           "<td> </td>" +
        //                             "<td> </td>" +
        //                           "<td> </td>" +
        //                           "<td>TOTAL</td>" +
        //                           "<td>" + totalCantidad + "</td>" +
        //                            "<td> </td>" +
        //                             "<td> </td>" +
        //                           "<td> </td>" +
        //                          "</tr>";

        //        tablaHTML += "</tbody>" +
        //    "</table> ";




        //    }
        //    tablaHTML += "</tbody>" +
        //   "</table> ";













        //    email.Subject = "[TMS] Mantenimiento " + "" + " " + DateTime.Now.ToString("dd/MM/yyyy");
        //    email.Body = tablaHTML;
        //    email.IsBodyHtml = true;
        //    email.From = new MailAddress("rcadena@aptelink.com", "TMS Mantenimiento");




        //        foreach (var em in ListaPara)
        //        {
        //            if (!string.IsNullOrEmpty(em.dataPara) && !string.IsNullOrWhiteSpace(em.dataPara))
        //                if (em.dataPara.Contains("@") && em.dataPara.Contains("."))
        //                    email.To.Add(em.dataPara.Trim());
        //        }









        //    var mailCopy = "";

        //    foreach(var item in ListaCopia)
        //    {
        //        mailCopy = item.dataCopia+"; ";
        //        email.Bcc.Add(mailCopy);
        //    }



        //        var proceso =  mailService.SendEmailAsync(email);
        //        if (proceso.IsCompletedSuccessfully)
        //        {
        //            return 200;
        //        }

        //        email.Dispose();

        //        return 500;
        //    }


        public string EnvioCorreoPedido(TipoSolicitudCorreo objSolicitudCorreo
                                            , List<CabeceradCorreo> ListaCabecera
                                            , List<ItemGuardarPedidosCorreo> ListaPedidos
                                            , List<ObtenerInformacionConfiguracionParametroCorreosDe> ListaDe
                                            , List<ObtenerInformacionConfiguracionParametroCorreoPara> ListaPara
                                            , List<ObtenerInformacionConfiguracionParametroCorreoCopia> ListaCopia

            )
        {
            MailMessage email = new MailMessage();
            SmtpClient smtp = new SmtpClient();



            return "hola";
        }











    }
}
