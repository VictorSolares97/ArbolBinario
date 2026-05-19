using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class CD_Municipio
    {
        Conexion conn = new Conexion();

        //Metodo para agregar un Nuevo Municipio (Boton Guardar)
        public void MtdAgregarMunicipio(string Nombre, int Poblacion, int DistanciaCabecera,int DepartamentoId)
        {
            String QueryAgregar = "Insert into Municipio (Nombre, Poblacion, DistanciaCabecera,DepartamentoId )values (@Nombre, @Poblacion, @DistanciaCabecera, @DepartamentoId );";

            SqlCommand sqlcm = new SqlCommand(QueryAgregar, conn.MtdAbrirConexion());
            sqlcm.Parameters.AddWithValue("@Nombre", Nombre);
            sqlcm.Parameters.AddWithValue("@Poblacion", Poblacion);
            sqlcm.Parameters.AddWithValue("@DistanciaCabecera", DistanciaCabecera);
            sqlcm.Parameters.AddWithValue("@DepartamentoId", DepartamentoId);
            sqlcm.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

        //Metodo para Consultar Municipio (Seleccionar Municipio)
        public DataTable MtdConsultarMunicipio()
        {
            string Query = "Select * from Municipio";//Cambiar Query
            SqlDataAdapter Adapter = new SqlDataAdapter(Query, conn.MtdAbrirConexion());
            DataTable dt = new DataTable();
            Adapter.Fill(dt);

            conn.MtdCerrarConexion();

            return dt;
        }
    }
}
