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
        public void MtdAgregarMunicipio( int DepartamentoId,string Nombre, int Poblacion, int DistanciaCabecera)
        {
            String QueryAgregar = "Insert into Municipio (DepartamentoId,Nombre, Poblacion, DistanciaCabecera )values (@DepartamentoId,@Nombre, @Poblacion, @DistanciaCabecera);";

            SqlCommand sqlcm = new SqlCommand(QueryAgregar, conn.MtdAbrirConexion());
            sqlcm.Parameters.AddWithValue("@DepartamentoId", DepartamentoId);
            sqlcm.Parameters.AddWithValue("@Nombre", Nombre);
            sqlcm.Parameters.AddWithValue("@Poblacion", Poblacion);
            sqlcm.Parameters.AddWithValue("@DistanciaCabecera", DistanciaCabecera);
            sqlcm.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

        //Metodo para Consultar Municipios guardados (Seleccionar Municipio)
        public DataTable MtdConsultarMunicipio()
        {
            string Query = "Select * from Municipio";//Cambiar Query
            SqlDataAdapter Adapter = new SqlDataAdapter(Query, conn.MtdAbrirConexion());
            DataTable dt = new DataTable();
            Adapter.Fill(dt);

            conn.MtdCerrarConexion();

            return dt;
        }

        public DataTable MtdConsultarMunicipiosPorDepartamento(int departamentoId)// Metodo para el DataGridview
        {
            string Query = "SELECT Id, Nombre, Poblacion, DistanciaCabecera " +
                           "FROM Municipio WHERE DepartamentoId = @DepartamentoId";

            SqlDataAdapter adapter = new SqlDataAdapter(Query, conn.MtdAbrirConexion());
            adapter.SelectCommand.Parameters.AddWithValue("@DepartamentoId", departamentoId);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.MtdCerrarConexion();
            return dt;
        }

        public DataTable MtdConsultarMunicipioPorNombre(string nombre, int departamentoId)
        {
            string Query = "SELECT Id, Nombre, Poblacion, DistanciaCabecera " +
                           "FROM Municipio WHERE Nombre = @Nombre AND DepartamentoId = @DepartamentoId";

            SqlDataAdapter adapter = new SqlDataAdapter(Query, conn.MtdAbrirConexion());
            adapter.SelectCommand.Parameters.AddWithValue("@Nombre", nombre);
            adapter.SelectCommand.Parameters.AddWithValue("@DepartamentoId", departamentoId);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.MtdCerrarConexion();
            return dt;
        }

        public DataTable MtdConsultarMunicipioPorId(int municipioId)
        {
            string query = @"
        SELECT m.Id, m.Nombre, m.Poblacion, m.DistanciaCabecera,
               m.DepartamentoId, d.Nombre AS NombreDepartamento
        FROM Municipio m
        INNER JOIN Departamento d ON m.DepartamentoId = d.Id
        WHERE m.Id = @MunicipioId";

            SqlCommand sqlcm = new SqlCommand(query, conn.MtdAbrirConexion());
            sqlcm.Parameters.AddWithValue("@MunicipioId", municipioId);

            SqlDataAdapter adapter = new SqlDataAdapter(sqlcm);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            conn.MtdCerrarConexion();

            return dt;
        }

        public DataTable MtdConsultarMunicipioPorDepartamentoId(int departamentoId)
        {
            string query = @"
        SELECT m.Id, m.Nombre, m.Poblacion, m.DistanciaCabecera, 
               d.Nombre AS NombreDepartamento
        FROM Municipio m
        INNER JOIN Departamento d ON m.DepartamentoId = d.Id
        WHERE m.DepartamentoId = @DepartamentoId";

            SqlCommand sqlcm = new SqlCommand(query, conn.MtdAbrirConexion());
            sqlcm.Parameters.AddWithValue("@DepartamentoId", departamentoId);

            SqlDataAdapter adapter = new SqlDataAdapter(sqlcm);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            conn.MtdCerrarConexion();

            return dt;
        }



    }
}
