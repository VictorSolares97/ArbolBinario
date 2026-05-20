using Backend;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

            txtNombreMunicipio.Clear();
            cboxDepartamento.SelectedIndex = -1;
            txtDistanciaCabecera.Clear();
            txtPoblacion.Clear();
        }
        private void MuestraDatosTV()// Metodo para mostrar datos en el TreeView
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
                int munId = Convert.ToInt32(munRow["Id"]); // Id del municipio
                string munNombre = munRow["Nombre"].ToString();

                if (nodos.ContainsKey(depId))
                {
                    TreeNode nodoMunicipio = new TreeNode(munNombre);
                    nodoMunicipio.Tag = munId; // Guardar Id del municipio

                    // Color para municipios
                    nodoMunicipio.ForeColor = Color.Green;

                    nodos[depId].Nodes.Add(nodoMunicipio);
                }
            }
        }

        private void MtdBuscarDepartamento()
        {
            DataTable dtDepartamentos = cd_departamento.MtdConsultarDepartamento();

            cboxDepartamento.DataSource = dtDepartamentos;
            cboxDepartamento.DisplayMember = "Nombre";       // Lo que se muestra en la lista
            cboxDepartamento.ValueMember = "Id";             // El valor real que se usa (DepartamentoId)
            cboxDepartamento.SelectedIndex = -1;             // Para que aparezca vacío al inicio
        }


        //Finalizan los metodos

        // Inicio de las tablas y botones
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
            if (string.IsNullOrEmpty(txtNombreMunicipio.Text) ||
                    string.IsNullOrEmpty(cboxDepartamento.Text) ||
                    string.IsNullOrEmpty(txtDistanciaCabecera.Text) ||
                    string.IsNullOrEmpty(txtPoblacion.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int departamentoId = Convert.ToInt32(cboxDepartamento.SelectedValue);
            string nombre = txtNombreMunicipio.Text;
            int distanciaCabecera = Convert.ToInt32(txtDistanciaCabecera.Text);
            int poblacion = Convert.ToInt32(txtPoblacion.Text);

            try
            {
                // Validar límite de municipios
                int cantidadActual = cd_departamento.MtdObtenerCantidadMunicipios(departamentoId);
                int limite = cd_departamento.MtdObtenerLimiteMunicipios(departamentoId);

                if (cantidadActual >= limite)
                {
                    MessageBox.Show("Este departamento ya alcanzó el máximo de municipios permitidos (" + limite + ").",
                                    "Límite alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Si no ha alcanzado el límite, procede a guardar
                cd_municipio.MtdAgregarMunicipio(departamentoId, nombre, poblacion, distanciaCabecera);
                MessageBox.Show("Municipio agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MuestraDatosTV();   // Actualiza el TreeView
                MtdLimpiarCampos(); // Limpia los campos
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el municipio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                bool EsCapital = cboxCapital.SelectedItem.ToString() == "Sí" ? true : false;// Convierte los datos en booleano
                int DepartamentoVecino = Convert.ToInt32(cboxDepartamentoVecino.SelectedValue);

                try
                {
                    cd_departamento.MtdAgregarDepartamento(Nombre, DistanciaCapital, CantidadMunicipios, EsCapital, cboxDepartamentoVecino.SelectedItem.ToString());
                    MessageBox.Show("Departamento agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MuestraDatosTV();
                    MtdBuscarDepartamento();
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
            MtdBuscarDepartamento();
            cboxDepartamentoVecino.Items.Clear();
            cboxDepartamentoVecino.Items.Add("Ninguno");
            cboxDepartamentoVecino.SelectedIndex = 0;

            // Enganchar el evento del TextBox para actualizar el ComboBox
            this.txtDistanciaDepartamento.TextChanged += new System.EventHandler(this.txtDistanciaDepartamento_TextChanged);

        }

        private void txtDistanciaDepartamento_TextChanged(object sender, EventArgs e)// Actualiza el ComboBox de Departamentos Vecinos según la distancia ingresada en el TextBox "Distancia de la Capital (km)".
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

        private void tvMostrarArbol_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode nodo = e.Node;

            if (nodo.Tag == null) return;

            if (cd_departamento.MtdConsultarDepartamentoPorId((int)nodo.Tag).Rows.Count > 0)
            // Departamento
            {
                int departamentoId = Convert.ToInt32(nodo.Tag);

                DataTable dtDep = cd_departamento.MtdConsultarDepartamentoPorId(departamentoId);
                // Municipios del departamento
                DataTable dtMun = cd_municipio.MtdConsultarMunicipioPorDepartamentoId(departamentoId);

                if (dtDep.Rows.Count > 0)

                {
                    DataRow dep = dtDep.Rows[0];

                    // Construir lista de municipios
                    List<string> municipios = new List<string>();
                    foreach (DataRow row in dtMun.Rows)
                    {
                        municipios.Add(row["Nombre"].ToString());
                    }

                    string listaMunicipios = municipios.Count > 0 ? string.Join(", ", municipios) : "Ninguno";

                    txtResultado.Text =
                     "=== Departamento ===" + Environment.NewLine +
                     "Nombre: " + dep["Nombre"].ToString() + Environment.NewLine +
                      "Distancia a Capital: " + dep["DistanciaCapital"].ToString() + Environment.NewLine +
                      "Cantidad de Municipios: " + dep["CantidadMunicipios"].ToString() + Environment.NewLine +
                     "Departamento( Vecino: " + (dep["NombreVecino"] == DBNull.Value ? "Ninguno" : dep["NombreVecino"].ToString()) +     Environment.NewLine +
                      "Municipios: " + listaMunicipios;
                }
                else
                {
                    txtResultado.Text = "No se encontraron datos para este departamento.";
                }
            } else
            {
                int municipioId = Convert.ToInt32(nodo.Tag);
                DataTable dtMun = cd_municipio.MtdConsultarMunicipioPorId(municipioId);

                if (dtMun.Rows.Count > 0)
                {
                    DataRow mun = dtMun.Rows[0];

                    txtResultado.Text =
                        "=== Municipio ===" + Environment.NewLine +
                        "Nombre: " + mun["Nombre"].ToString() + Environment.NewLine +
                        "Población: " + mun["Poblacion"].ToString() + Environment.NewLine +
                        "Distancia a Cabecera: " + mun["DistanciaCabecera"].ToString() + Environment.NewLine +
                        "Pertenece al Departamento: " + mun["NombreDepartamento"].ToString();
                }
                else
                {
                    txtResultado.Text = "No se encontraron datos para este municipio.";
                }
            }

        }
    }
}