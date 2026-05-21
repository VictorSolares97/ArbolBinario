using Backend;
using System.Data;
using System.Runtime.Intrinsics.X86;
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
        // Inicio de Metodos de Capa Presentacion
        //-------------------------------------------------------------------------------------------------//
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

                // Guardar tipo y Id en el Tag
                nodoDepartamento.Tag = "Departamento:" + depId;

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

            // Agregar municipios con referencia al departamento
            foreach (DataRow munRow in dtMunicipios.Rows)
            {
                int depId = Convert.ToInt32(munRow["DepartamentoId"]);
                string munNombre = munRow["Nombre"].ToString();

                if (nodos.ContainsKey(depId))
                {
                    TreeNode nodoMunicipio = new TreeNode(munNombre);

                    // Guardar tipo, Id y DepartamentoId en el Tag
                    nodoMunicipio.Tag = "Municipio:" + munRow["Id"] + ":" + depId;

                    nodoMunicipio.ForeColor = Color.Green;
                    nodos[depId].Nodes.Add(nodoMunicipio);
                }
            }

            // Expandir todo para que quede abierto
            tvMostrarArbol.ExpandAll();
        }

        private void MtdBuscarDepartamento()
        {
            DataTable dtDepartamentos = cd_departamento.MtdConsultarDepartamento();

            cboxDepartamento.DataSource = dtDepartamentos;
            cboxDepartamento.DisplayMember = "Nombre";       // Lo que se muestra en la lista
            cboxDepartamento.ValueMember = "Id";             // El valor real que se usa (DepartamentoId)
            cboxDepartamento.SelectedIndex = -1;             // Para que aparezca vacío al inicio
        }

        // Método auxiliar para buscar un nodo por nombre en todo el árbol
        private TreeNode BuscarNodoPorNombre(TreeNodeCollection nodos, string nombre)
        {
            foreach (TreeNode nodo in nodos)
            {
                if (nodo.Text.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                    return nodo;

                TreeNode encontrado = BuscarNodoPorNombre(nodo.Nodes, nombre);
                if (encontrado != null) return encontrado;
            }
            return null;
        }

        // Método auxiliar para obtener el camino desde un nodo hasta la raíz
        private List<TreeNode> ObtenerCaminoHastaRaiz(TreeNode nodo)
        {
            List<TreeNode> camino = new List<TreeNode>();
            while (nodo != null)
            {
                camino.Insert(0, nodo); // Insertar al inicio para mantener orden raíz nodo
                nodo = nodo.Parent;
            }
            return camino;
        }

        // Método auxiliar para obtener el recorrido entre dos nodos (misma rama o distintas)
        private List<string> ObtenerRecorridoEntreNodos(TreeNode origen, TreeNode destino)
        {
            var caminoOrigen = ObtenerCaminoHastaRaiz(origen);
            var caminoDestino = ObtenerCaminoHastaRaiz(destino);

            // Encontrar ancestro común
            int i = 0;
            while (i < caminoOrigen.Count && i < caminoDestino.Count && caminoOrigen[i] == caminoDestino[i])
            {
                i++;
            }

            List<string> recorrido = new List<string>();

            // 1. Desde el origen hacia arriba hasta el ancestro común (incluyendo Capital si aplica)
            for (int j = caminoOrigen.Count - 1; j >= i; j--)
            {
                if (!string.IsNullOrWhiteSpace(caminoOrigen[j].Text))
                    recorrido.Add(caminoOrigen[j].Text);
            }

            // 2. Incluir el ancestro común (ej. Capital)
            if (i > 0 && !string.IsNullOrWhiteSpace(caminoOrigen[i - 1].Text))
                recorrido.Add(caminoOrigen[i - 1].Text);

            // 3. Desde el ancestro común hacia abajo hasta el destino
            for (int j = i; j < caminoDestino.Count; j++)
            {
                if (!string.IsNullOrWhiteSpace(caminoDestino[j].Text))
                    recorrido.Add(caminoDestino[j].Text);
            }

            return recorrido;
        }


        // Método auxiliar para distinguir si es Departamento o Municipio
        private bool EsDepartamento(string nombre)
        {
            // Aquí puedes validar con la BD directamente
            DataTable dtDep = cd_departamento.MtdConsultarDepartamentoPorNombre(nombre);
            return dtDep.Rows.Count > 0;
        }




        //Finalizan los metodos
        //-------------------------------------------------------------------------------------------------------------------//

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
            tvMostrarArbol.ExpandAll();
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

            // Parsear el Tag
            string tagInfo = nodo.Tag.ToString();
            string[] partes = tagInfo.Split(':');

            if (partes[0] == "Departamento")
            {
                int departamentoId = Convert.ToInt32(partes[1]);

                DataTable dtDep = cd_departamento.MtdConsultarDepartamentoPorId(departamentoId);
                DataTable dtMun = cd_municipio.MtdConsultarMunicipioPorDepartamentoId(departamentoId);

                if (dtDep.Rows.Count > 0)
                {
                    DataRow dep = dtDep.Rows[0];

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
                        "Departamento Vecino: " + (dep["NombreVecino"] == DBNull.Value ? "Ninguno" : dep["NombreVecino"].ToString()) + Environment.NewLine +
                        "Municipios: " + listaMunicipios;
                }
                else
                {
                    txtResultado.Text = "No se encontraron datos para este departamento.";
                }
            }
            else if (partes[0] == "Municipio")
            {
                int municipioId = Convert.ToInt32(partes[1]);
                int departamentoId = Convert.ToInt32(partes[2]);

                DataTable dtMun = cd_municipio.MtdConsultarMunicipioPorId(municipioId);

                if (dtMun.Rows.Count > 0)
                {
                    DataRow mun = dtMun.Rows[0];

                    txtResultado.Text =
                        "=== Municipio ===" + Environment.NewLine +
                        "Nombre: " + mun["Nombre"].ToString() + Environment.NewLine +
                        "Población: " + mun["Poblacion"].ToString() + Environment.NewLine +
                        "Distancia a Cabecera: " + mun["DistanciaCabecera"].ToString() + Environment.NewLine +
                        "Pertenece al Departamento: " + nodo.Parent.Text;
                }
                else
                {
                    txtResultado.Text = "No se encontraron datos para este municipio.";
                }
            }

        }

        private void btnRecorrerArbol_Click(object sender, EventArgs e)
        {
            // Solicitar al usuario los departamentos origen y destino
            string depOrigen = Microsoft.VisualBasic.Interaction.InputBox(
                "Ingrese el nombre del departamento de origen:",
                "Recorrido");

            if (string.IsNullOrWhiteSpace(depOrigen)) return;

            string depDestino = Microsoft.VisualBasic.Interaction.InputBox(
                "Ingrese el nombre del departamento destino:",
                "Recorrido");

            if (string.IsNullOrWhiteSpace(depDestino)) return;

            // Buscar nodos en el TreeView
            TreeNode nodoOrigen = BuscarNodoPorNombre(tvMostrarArbol.Nodes, depOrigen);
            TreeNode nodoDestino = BuscarNodoPorNombre(tvMostrarArbol.Nodes, depDestino);

            if (nodoOrigen == null || nodoDestino == null)
            {
                MessageBox.Show("No se encontraron los departamentos especificados.");
                return;
            }

            // Obtener recorrido entre origen y destino
            List<string> recorrido = ObtenerRecorridoEntreNodos(nodoOrigen, nodoDestino);

            // Mostrar resultado en el TextBox
            if (recorrido.Count > 0)
            {
                txtResultado.Text = string.Join(" -> ", recorrido);
            }
            else
            {
                txtResultado.Text = "No existe un recorrido entre esos departamentos.";
            }
        }

        private void tvMostrarArbol_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = true;

        }

        private void btnBuscarNodo_Click(object sender, EventArgs e)
        {
            string criterio = Microsoft.VisualBasic.Interaction.InputBox(
               "Ingrese el nombre del departamento o municipio a buscar:",
               "Buscar");

            if (string.IsNullOrWhiteSpace(criterio)) return;

            TreeNode nodoEncontrado = BuscarNodoPorNombre(tvMostrarArbol.Nodes, criterio);

            if (nodoEncontrado != null && nodoEncontrado.Tag != null)
            {
                tvMostrarArbol.SelectedNode = nodoEncontrado;
                tvMostrarArbol.SelectedNode.Expand();

                // Aquí parseamos el Tag en lugar de castear a int
                string tagInfo = nodoEncontrado.Tag.ToString();
                string[] partes = tagInfo.Split(':');

                if (partes[0] == "Departamento")
                {
                    int depId = Convert.ToInt32(partes[1]);
                    DataTable dtDep = cd_departamento.MtdConsultarDepartamentoPorId(depId);
                    if (dtDep.Rows.Count > 0)
                    {
                        DataRow row = dtDep.Rows[0];
                        txtResultado.Text =
                            "=== Departamento ===" + Environment.NewLine +
                            "Nombre: " + row["Nombre"].ToString() + Environment.NewLine +
                            "Distancia a Capital: " + row["DistanciaCapital"].ToString() + " km" + Environment.NewLine +
                            "Cantidad de Municipios: " + row["CantidadMunicipios"].ToString() + Environment.NewLine +
                            "Departamento Vecino: " + (row["NombreVecino"] == DBNull.Value ? "Ninguno" : row["NombreVecino"].ToString());
                    }
                }
                else if (partes[0] == "Municipio")
                {
                    int munId = Convert.ToInt32(partes[1]);
                    int depId = Convert.ToInt32(partes[2]);

                    DataTable dtMun = cd_municipio.MtdConsultarMunicipioPorNombre(nodoEncontrado.Text, depId);
                    if (dtMun.Rows.Count > 0)
                    {
                        DataRow row = dtMun.Rows[0];
                        txtResultado.Text =
                            "=== Municipio ===" + Environment.NewLine +
                            "Nombre: " + row["Nombre"].ToString() + Environment.NewLine +
                            "Departamento: " + nodoEncontrado.Parent.Text + Environment.NewLine +
                            "Distancia a Cabecera: " + row["DistanciaCabecera"].ToString() + " km" + Environment.NewLine +
                            "Población: " + row["Poblacion"].ToString();
                    }
                }
            }
            else
            {
                txtResultado.Text = "No se encontró el nodo especificado.";
            }
        }

        private void btnCalcularDistancia_Click(object sender, EventArgs e)
        {
            string origen = Microsoft.VisualBasic.Interaction.InputBox(
                  "Ingrese el nombre del departamento o municipio de origen:",
                  "Origen");
            if (string.IsNullOrWhiteSpace(origen)) return;

            string destino = Microsoft.VisualBasic.Interaction.InputBox(
                "Ingrese el nombre del departamento o municipio de destino:",
                "Destino");
            if (string.IsNullOrWhiteSpace(destino)) return;

            string resultado = "";

            // Buscar origen
            DataTable dtOrigenDep = cd_departamento.MtdConsultarDepartamentoPorNombre(origen);
            DataTable dtOrigenMun = null;
            if (dtOrigenDep.Rows.Count == 0 && origen.ToLower() != "capital")
            {
                DataTable dtDepOrigen = cd_departamento.MtdObtenerDepartamentoPorMunicipio(origen);
                if (dtDepOrigen.Rows.Count > 0)
                {
                    int depIdOrigen = Convert.ToInt32(dtDepOrigen.Rows[0]["DepartamentoId"]);
                    dtOrigenMun = cd_municipio.MtdConsultarMunicipioPorNombre(origen, depIdOrigen);
                }
            }

            // Buscar destino
            DataTable dtDestinoDep = cd_departamento.MtdConsultarDepartamentoPorNombre(destino);
            DataTable dtDestinoMun = null;
            if (dtDestinoDep.Rows.Count == 0 && destino.ToLower() != "capital")
            {
                DataTable dtDepDestino = cd_departamento.MtdObtenerDepartamentoPorMunicipio(destino);
                if (dtDepDestino.Rows.Count > 0)
                {
                    int depIdDestino = Convert.ToInt32(dtDepDestino.Rows[0]["DepartamentoId"]);
                    dtDestinoMun = cd_municipio.MtdConsultarMunicipioPorNombre(destino, depIdDestino);
                }
            }

            // Capital a Departamento
            if (dtOrigenDep.Rows.Count > 0 && destino.ToLower() == "capital")
            {
                DataRow dep = dtOrigenDep.Rows[0];
                resultado = $" La distancia entre la Capital y {dep["Nombre"]} es {dep["DistanciaCapital"]} km.";
            }
            else if (origen.ToLower() == "capital" && dtDestinoDep.Rows.Count > 0)
            {
                DataRow dep = dtDestinoDep.Rows[0];
                resultado = $" La distancia entre la Capital y {dep["Nombre"]} es {dep["DistanciaCapital"]} km.";
            }

            // Capital a Municipio
            else if (dtOrigenMun != null && dtOrigenMun.Rows.Count > 0 && destino.ToLower() == "capital")
            {
                DataRow mun = dtOrigenMun.Rows[0];
                DataTable dtDep = cd_departamento.MtdObtenerDepartamentoPorMunicipio(mun["Nombre"].ToString());
                int distCapitalDep = Convert.ToInt32(dtDep.Rows[0]["DistanciaCapital"]);
                int distCabeceraMun = Convert.ToInt32(mun["DistanciaCabecera"]);
                int distanciaTotal = distCapitalDep + distCabeceraMun;

                resultado = $" La distancia entre la Capital y {mun["Nombre"]} es {distanciaTotal} km.";
            }
            else if (origen.ToLower() == "capital" && dtDestinoMun != null && dtDestinoMun.Rows.Count > 0)
            {
                DataRow mun = dtDestinoMun.Rows[0];
                DataTable dtDep = cd_departamento.MtdObtenerDepartamentoPorMunicipio(mun["Nombre"].ToString());
                int distCapitalDep = Convert.ToInt32(dtDep.Rows[0]["DistanciaCapital"]);
                int distCabeceraMun = Convert.ToInt32(mun["DistanciaCabecera"]);
                int distanciaTotal = distCapitalDep + distCabeceraMun;

                resultado = $" La distancia entre la Capital y {mun["Nombre"]} es {distanciaTotal} km.";
            }

            // Departamento a Municipio
            else if (dtOrigenDep.Rows.Count > 0 && dtDestinoMun != null && dtDestinoMun.Rows.Count > 0)
            {
                DataRow dep = dtOrigenDep.Rows[0];
                DataRow mun = dtDestinoMun.Rows[0];
                int distCabecera = Convert.ToInt32(mun["DistanciaCabecera"]);
                resultado = $" La distancia entre {dep["Nombre"]} y {mun["Nombre"]} es {distCabecera} km.";
            }
            else if (dtOrigenMun != null && dtOrigenMun.Rows.Count > 0 && dtDestinoDep.Rows.Count > 0)
            {
                DataRow dep = dtDestinoDep.Rows[0];
                DataRow mun = dtOrigenMun.Rows[0];
                int distCabecera = Convert.ToInt32(mun["DistanciaCabecera"]);
                resultado = $" La distancia entre {dep["Nombre"]} y {mun["Nombre"]} es {distCabecera} km.";
            }

            // Departamento a Departamento
            else if (dtOrigenDep.Rows.Count > 0 && dtDestinoDep.Rows.Count > 0)
            {
                DataRow dep1 = dtOrigenDep.Rows[0];
                DataRow dep2 = dtDestinoDep.Rows[0];

                int dist1 = Convert.ToInt32(dep1["DistanciaCapital"]);
                int dist2 = Convert.ToInt32(dep2["DistanciaCapital"]);

                string vecino1 = dep1["DepartamentoVecino"].ToString();
                string vecino2 = dep2["DepartamentoVecino"].ToString();
                resultado = $"Depuración: vecino1='{vecino1}', vecino2='{vecino2}'";//// Linea de prueba

                int distancia;

                // Caso 1: ambos vecinos son Capital ? suma directa
                if (vecino1.ToLower() == "capital" && vecino2.ToLower() == "capital")
                {
                    distancia = dist1 + dist2;
                }
                // Caso 2: mismo vecino distinto de Capital ? calcular hijo?padre y luego sumar
                if (vecino1.Trim().Equals(vecino2.Trim(), StringComparison.OrdinalIgnoreCase) && !vecino1.Trim().Equals("Capital", StringComparison.OrdinalIgnoreCase))
                {
                    DataTable dtPadre = cd_departamento.MtdConsultarDepartamentoPorNombre(vecino1.Trim());
                    if (dtPadre.Rows.Count > 0)
                    {
                        int distPadre = Convert.ToInt32(dtPadre.Rows[0]["DistanciaCapital"]);
                        int distHijo1 = Math.Abs(dist1 - distPadre);
                        int distHijo2 = Math.Abs(dist2 - distPadre);
                        distancia = distHijo1 + distHijo2;
                    }
                    else
                    {
                        resultado = $"? No se encontró el nodo padre '{vecino1}' en la tabla Departamento.";
                        distancia = -1;
                    }
                }


                // Caso 3: vecinos distintos ? suma
                else
                {
                    distancia = dist1 + dist2;
                }

                resultado = $"Departamento a Departamento: La distancia entre {dep1["Nombre"]} y {dep2["Nombre"]} es {distancia} km.";
            }


            if (string.IsNullOrEmpty(resultado))
                resultado = "No se encontró información para calcular la distancia.";

            txtResultado.Text = resultado;
        }

        private void btnListadoNodos_Click(object sender, EventArgs e)
        {
            if (tvMostrarArbol.SelectedNode != null)
            {
                TreeNode nodoSeleccionado = tvMostrarArbol.SelectedNode;

                // Limpiar resultados previos
                txtResultado.Clear();

                // Si el nodo tiene hijos, listarlos
                if (nodoSeleccionado.Nodes.Count > 0)
                {
                    txtResultado.AppendText($"Listado de nodos hijos de {nodoSeleccionado.Text}:\r\n");

                    foreach (TreeNode hijo in nodoSeleccionado.Nodes)
                    {
                        txtResultado.AppendText($"- {hijo.Text}\r\n");
                    }
                }
                else
                {
                    txtResultado.AppendText($"{nodoSeleccionado.Text} no tiene nodos hijos.\r\n");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un nodo en el árbol para listar sus hijos.");
            }
        }
    }
}