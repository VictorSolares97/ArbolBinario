using Backend;
using System.Data;

namespace ArbolBinario
{
    public partial class ArbolBinario : Form
    {
        CD_Departamento cd_departamento = new CD_Departamento();
        CD_Municipio cd_municipio = new CD_Municipio();
        public ArbolBinario()
        {
            InitializeComponent();
        }
        // Inicio de Metodos de Capa Presencacion
        private void MtdLimpiarCampos()// Limpia todos los campos de texto.
        {
            txtNombreDepartamento.Clear();
            txtDistanciaDepartamento.Clear();
            txtCantidadMunicipios.Clear();
            cboxCapital.SelectedIndex = -1;
            cboxDepartamentoVecino.SelectedIndex = -1;
        }
        private void MuestraDatosTV()
        {
            DataTable dtDepartamentos = cd_departamento.MtdConsultarDepartamento();
            DataTable dtMunicipios = cd_municipio.MtdConsultarMunicipio();

            tvMostrarArbol.Nodes.Clear();

            Dictionary<int, TreeNode> nodos = new Dictionary<int, TreeNode>();

            // Crear nodos de departamentos
            foreach (DataRow depRow in dtDepartamentos.Rows)
            {
                int depId = Convert.ToInt32(depRow["Id"]);
                string depNombre = depRow["Nombre"].ToString();

                TreeNode nodoDepartamento = new TreeNode(depNombre);
                nodoDepartamento.Tag = depId;

                // Color para departamentos
                nodoDepartamento.ForeColor = Color.Blue;

                nodos[depId] = nodoDepartamento;
            }

            // Relacionar departamentos según DepartamentoVecino
            foreach (DataRow depRow in dtDepartamentos.Rows)
            {
                int depId = Convert.ToInt32(depRow["Id"]);
                object vecinoObj = depRow["DepartamentoVecino"];

                if (vecinoObj == DBNull.Value)
                {
                    tvMostrarArbol.Nodes.Add(nodos[depId]);
                }
                else
                {
                    int idVecino = Convert.ToInt32(vecinoObj);
                    if (nodos.ContainsKey(idVecino))
                    {
                        nodos[idVecino].Nodes.Add(nodos[depId]);
                    }
                    else
                    {
                        tvMostrarArbol.Nodes.Add(nodos[depId]);
                    }
                }
            }

            // Agregar municipios con color distinto
            foreach (DataRow munRow in dtMunicipios.Rows)
            {
                int depId = Convert.ToInt32(munRow["DepartamentoId"]);
                string munNombre = munRow["Nombre"].ToString();

                if (nodos.ContainsKey(depId))
                {
                    TreeNode nodoMunicipio = new TreeNode(munNombre);

                    // Color para municipios
                    nodoMunicipio.ForeColor = Color.Green;

                    nodos[depId].Nodes.Add(nodoMunicipio);
                }
            }
        }


        //Finalizan los metodos

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardarMunicipio_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardarDepartamento_Click(object sender, EventArgs e)// Boton de Guardar Departamento, valida que los campos estén completos, luego llama al método para agregar el departamento a la base de datos y finalmente actualiza el TreeView.
        {
            if (
                string.IsNullOrEmpty(txtNombreDepartamento.Text) ||
                string.IsNullOrEmpty(txtDistanciaDepartamento.Text) ||
                string.IsNullOrEmpty(txtCantidadMunicipios.Text) ||
                string.IsNullOrEmpty(cboxCapital.Text)
                )// Validar que todos los campos estén completos, mensaje de error si no lo están.
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string Nombre = txtNombreDepartamento.Text;
                int DistanciaCapital = Convert.ToInt32(txtDistanciaDepartamento.Text);
                int CantidadMunicipios = Convert.ToInt32(txtCantidadMunicipios.Text);
                bool EsCapital = cboxCapital.SelectedItem.ToString() == "Sí" ? true : false;
                int DepartamentoVecino = Convert.ToInt32(cboxDepartamentoVecino.SelectedValue);

                try
                {
                    cd_departamento.MtdAgregarDepartamento( Nombre, DistanciaCapital, CantidadMunicipios, EsCapital, cboxDepartamentoVecino.SelectedItem.ToString());
                    MessageBox.Show("Departamento agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MuestraDatosTV();
                    MtdLimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar el departamento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ArbolBinario_Load(object sender, EventArgs e)/// Carga los datos al iniciar la aplicación
        {
            MtdLimpiarCampos();
            MuestraDatosTV();
            cboxDepartamentoVecino.Items.Clear();
            cboxDepartamentoVecino.Items.Add("Ninguno");
            cboxDepartamentoVecino.SelectedIndex = 0;

            // Enganchar el evento del TextBox para actualizar el ComboBox
            this.txtDistanciaDepartamento.TextChanged += new System.EventHandler(this.txtDistanciaDepartamento_TextChanged);

        }

        private void txtDistanciaDepartamento_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtDistanciaDepartamento.Text, out int distancia))
            {
                CD_Departamento cd_departamento = new CD_Departamento();
                DataTable dtDepartamentos = cd_departamento.MtdConsultarDepartamento();

                cboxDepartamentoVecino.Items.Clear();
                cboxDepartamentoVecino.Items.Add("Ninguno");

                foreach (DataRow depRow in dtDepartamentos.Rows)
                {
                    int distCapital = Convert.ToInt32(depRow["DistanciaCapital"]);
                    string depNombre = depRow["Nombre"].ToString();

                    // Ahora se agregan solo los departamentos con distancia menor
                    if (distCapital < distancia)
                    {
                        cboxDepartamentoVecino.Items.Add(depNombre);
                    }
                }

                cboxDepartamentoVecino.SelectedIndex = 0;
            }
        }
    }
}