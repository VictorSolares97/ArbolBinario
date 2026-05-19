using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class CD_Departamento
    {
        Conexion conn = new Conexion();

        //Metodo para agregar un Nuevo Municipio (Boton Guardar)
        public void MtdAgregarDepartamento(int DepartamentoVecino,string  Nombre, int DistanciaCapital, int CantidadMunicipios, bool EsCapital)
        {
            String QueryAgregar = "Insert into Departamento (DepartamentoVecino, Nombre, DistanciaCapital, CantidadMunicipios, EsCapital)values (@DepartamentoVecino, @Nombre, @DistanciaCapital, @CantidadMunicipios, @EsCapital);";

            SqlCommand sqlcm = new SqlCommand(QueryAgregar, conn.MtdAbrirConexion());
            sqlcm.Parameters.AddWithValue("@DepartamentoVecino", DepartamentoVecino);
            sqlcm.Parameters.AddWithValue("@Nombre", Nombre);
            sqlcm.Parameters.AddWithValue("@DistanciaCapital", DistanciaCapital);
            sqlcm.Parameters.AddWithValue("@CantidadMunicipios", CantidadMunicipios);
            sqlcm.Parameters.AddWithValue("@EsCapital", EsCapital);
            sqlcm.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

        //Metodo para Consultar Departamento (Seleccionar Departamento)
        public DataTable MtdAgregarMunicipio()
        {
            string Query = "Select * from Departamento";//Cambiar Query
            SqlDataAdapter Adapter = new SqlDataAdapter(Query, conn.MtdAbrirConexion());
            DataTable dt = new DataTable();
            Adapter.Fill(dt);

            conn.MtdCerrarConexion();

            return dt;
        }
    }
}
