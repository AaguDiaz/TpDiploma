using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controladora
{
    public class CnReportes
    {
        MoReportes reportes = new MoReportes();

        public bool LoadDataPed(DateTime startDate, DateTime endDate)
        {
            endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day,
                endDate.Hour, endDate.Minute, 59);
            if (startDate != reportes.startDate || endDate != reportes.endDate)
            {
                reportes.startDate = startDate;
                reportes.endDate = endDate;
                reportes.numberDays = (endDate - startDate).Days;

                reportes.CargarTotales();
                reportes.CargarPedidos();
                reportes.CargarTopListas();
                reportes.CargarTopPedidos();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
