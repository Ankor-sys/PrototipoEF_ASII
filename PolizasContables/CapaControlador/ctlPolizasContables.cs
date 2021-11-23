using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControlador
{
    public class ctlPolizasContables
    {
        Sentencias sn = new Sentencias();
        public string incrementarId()
        {
            string id = sn.incrementarId();

            return id;
        }

        public DataTable llenarDataGrid(string tabla, string id)
        {
            DataTable table = new DataTable();
            table = sn.llenarTabla(tabla, id);
            return table;
        }

        public void insertarEncabezado(string id, string fecha, string tipoPoliza)
        {
            sn.insertarEncabezado(id, fecha, tipoPoliza);

        }

        public void insertarDetalle(string Id, string fecha, string idCuenta, string saldo, string idtipoOp, string concepto)
        {
            sn.insertarDetalle(Id, fecha, idCuenta, saldo, idtipoOp, concepto);
        }
    }

    
}
