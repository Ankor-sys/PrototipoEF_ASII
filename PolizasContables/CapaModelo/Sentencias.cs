using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaModelo
{
    public class Sentencias
    {
        Conexion cn = new Conexion();

        public string incrementarId()
        {
            string id = "";
            // string Query = "select * from polizaEncabezado order by length (idPolizaEncabezado) DESC limit 1;";
            string Query = " SELECT(idPolizaEncabezado * 1) as `idPolizaEncabezado` from polizaEncabezado order by(idPolizaEncabezado) DESC limit 1;";
            //  string Query = "select * from polizaDetalle ORDER BY length(idPolizaEncabezado ) ASC;";

            OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            if (busqueda.Read())
            {

                id = busqueda["idPolizaEncabezado"].ToString();

            }
            else
            {
                Console.WriteLine("Error acá");
            }
            return id;
        }

        public DataTable llenarTabla(string tabla, string id)// metodo  que obtinene el contenido de una tabla
        {
            DataTable table = new DataTable();
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT * FROM '" + tabla + " ; ";
            try
            {
                OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, cn.conexion());

                dataTable.Fill(table);

            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Error al leer los datos " + ex.Message);
            }
            return table;
        }

        public void insertarEncabezado(string Id, string fecha, string tipoPoliza)
        {
            string cadena = "INSERT INTO" +
            " polizaEncabezado VALUES (" + "'" + Id + "', '" + fecha + "' ,'" + tipoPoliza + "');";

            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();
        }

        public void insertarDetalle(string Id, string fecha, string idCuenta, string saldo, string idtipoOp, string concepto)
        {


            string cadena = "INSERT INTO" +
            " polizaDetalle VALUES (" + "'" + Id + "', '" + fecha + "' ,'" + idCuenta + "','" + saldo + "','" + idtipoOp + "','" + concepto + "' );";

            Console.WriteLine(cadena);
            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();
        }
    }
}
