using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Seguridad
{
    public class CnAuditoria
    {
        Modelo.Seguridad.MoAuditoria auditoria = new Modelo.Seguridad.MoAuditoria();


        public void InsertarAuditoria(string registro)
        {
            auditoria.InsertarAuditoria(registro);
        }

        public DataTable CargarInicio(int currentPage, DateTime desde, DateTime hasta)
        {
            return auditoria.CargarInicio(currentPage, desde, hasta);
        }

        public bool LoadInicio(DateTime startDate, DateTime endDate)
        {
            endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day,
                endDate.Hour, endDate.Minute, 59);
            if (startDate != auditoria.startDate || endDate != auditoria.endDate)
            {
                auditoria.startDate = startDate;
                auditoria.endDate = endDate;
                auditoria.CargarTablaInico(startDate, endDate);
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable CargarTrazabilidad(int currentPage, DateTime desde, DateTime hasta)
        {
            return auditoria.CargarTrazabilidad(currentPage, desde,hasta);
        }

        public bool LoadTrazabilidad(DateTime startDate, DateTime endDate)
        {
            endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day,
                               endDate.Hour, endDate.Minute, 59);
            if (startDate != auditoria.startDate || endDate != auditoria.endDate)
            {
                auditoria.startDate = startDate;
                auditoria.endDate = endDate;
                auditoria.CargarTablaTrazabilidad(startDate, endDate);
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable BuscarTrazabilidad(int currentPage, DateTime desde, DateTime hasta, int busqueda)
        {
            return auditoria.BuscarTrazabilidad(currentPage, desde, hasta, busqueda);
        }

    }
}
