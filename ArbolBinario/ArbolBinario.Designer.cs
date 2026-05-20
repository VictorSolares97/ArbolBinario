namespace ArbolBinario
{
    partial class ArbolBinario
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArbolBinario));
            panel1 = new Panel();
            btnEliminarNodo = new Button();
            btnListadoNodos = new Button();
            btnCalcularDistancia = new Button();
            btnBuscarNodo = new Button();
            btnRecorrerArbol = new Button();
            tvMostrarArbol = new TreeView();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            label9 = new Label();
            cboxDepartamentoVecino = new ComboBox();
            btnGuardarDepartamento = new Button();
            cboxCapital = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            txtCantidadMunicipios = new TextBox();
            txtDistanciaDepartamento = new TextBox();
            label2 = new Label();
            txtNombreDepartamento = new TextBox();
            label1 = new Label();
            groupBox3 = new GroupBox();
            btnGuardarMunicipio = new Button();
            txtPoblacion = new TextBox();
            label8 = new Label();
            label7 = new Label();
            txtDistanciaCabecera = new TextBox();
            label6 = new Label();
            cboxDepartamento = new ComboBox();
            txtNombreMunicipio = new TextBox();
            label5 = new Label();
            groupBox5 = new GroupBox();
            txtResultado = new TextBox();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.ActiveBorder;
            panel1.Controls.Add(btnEliminarNodo);
            panel1.Controls.Add(btnListadoNodos);
            panel1.Controls.Add(btnCalcularDistancia);
            panel1.Controls.Add(btnBuscarNodo);
            panel1.Controls.Add(btnRecorrerArbol);
            panel1.Location = new Point(1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1230, 74);
            panel1.TabIndex = 1;
            // 
            // btnEliminarNodo
            // 
            btnEliminarNodo.Anchor = AnchorStyles.Top;
            btnEliminarNodo.BackColor = SystemColors.ScrollBar;
            btnEliminarNodo.FlatStyle = FlatStyle.Flat;
            btnEliminarNodo.Image = (Image)resources.GetObject("btnEliminarNodo.Image");
            btnEliminarNodo.ImageAlign = ContentAlignment.MiddleLeft;
            btnEliminarNodo.Location = new Point(865, 11);
            btnEliminarNodo.Name = "btnEliminarNodo";
            btnEliminarNodo.Size = new Size(206, 44);
            btnEliminarNodo.TabIndex = 7;
            btnEliminarNodo.Text = "Eliminar Ubicación";
            btnEliminarNodo.UseVisualStyleBackColor = false;
            // 
            // btnListadoNodos
            // 
            btnListadoNodos.Anchor = AnchorStyles.Top;
            btnListadoNodos.BackColor = SystemColors.ScrollBar;
            btnListadoNodos.FlatStyle = FlatStyle.Flat;
            btnListadoNodos.Image = (Image)resources.GetObject("btnListadoNodos.Image");
            btnListadoNodos.ImageAlign = ContentAlignment.MiddleLeft;
            btnListadoNodos.Location = new Point(653, 11);
            btnListadoNodos.Name = "btnListadoNodos";
            btnListadoNodos.Size = new Size(206, 44);
            btnListadoNodos.TabIndex = 6;
            btnListadoNodos.Text = "Listado de Nodos";
            btnListadoNodos.UseVisualStyleBackColor = false;
            // 
            // btnCalcularDistancia
            // 
            btnCalcularDistancia.Anchor = AnchorStyles.Top;
            btnCalcularDistancia.BackColor = SystemColors.ScrollBar;
            btnCalcularDistancia.FlatStyle = FlatStyle.Flat;
            btnCalcularDistancia.Image = (Image)resources.GetObject("btnCalcularDistancia.Image");
            btnCalcularDistancia.ImageAlign = ContentAlignment.MiddleLeft;
            btnCalcularDistancia.Location = new Point(441, 11);
            btnCalcularDistancia.Name = "btnCalcularDistancia";
            btnCalcularDistancia.Size = new Size(206, 44);
            btnCalcularDistancia.TabIndex = 5;
            btnCalcularDistancia.Text = "Calcular Distancia";
            btnCalcularDistancia.UseVisualStyleBackColor = false;
            // 
            // btnBuscarNodo
            // 
            btnBuscarNodo.Anchor = AnchorStyles.Top;
            btnBuscarNodo.BackColor = SystemColors.ScrollBar;
            btnBuscarNodo.FlatStyle = FlatStyle.Flat;
            btnBuscarNodo.Image = (Image)resources.GetObject("btnBuscarNodo.Image");
            btnBuscarNodo.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscarNodo.Location = new Point(229, 11);
            btnBuscarNodo.Name = "btnBuscarNodo";
            btnBuscarNodo.Size = new Size(206, 44);
            btnBuscarNodo.TabIndex = 4;
            btnBuscarNodo.Text = "Buscar";
            btnBuscarNodo.UseVisualStyleBackColor = false;
            // 
            // btnRecorrerArbol
            // 
            btnRecorrerArbol.Anchor = AnchorStyles.Top;
            btnRecorrerArbol.BackColor = SystemColors.ScrollBar;
            btnRecorrerArbol.FlatStyle = FlatStyle.Flat;
            btnRecorrerArbol.Image = (Image)resources.GetObject("btnRecorrerArbol.Image");
            btnRecorrerArbol.ImageAlign = ContentAlignment.MiddleLeft;
            btnRecorrerArbol.Location = new Point(17, 11);
            btnRecorrerArbol.Name = "btnRecorrerArbol";
            btnRecorrerArbol.Size = new Size(206, 44);
            btnRecorrerArbol.TabIndex = 3;
            btnRecorrerArbol.Text = "Recorrido";
            btnRecorrerArbol.UseVisualStyleBackColor = false;
            // 
            // tvMostrarArbol
            // 
            tvMostrarArbol.Dock = DockStyle.Fill;
            tvMostrarArbol.Location = new Point(3, 25);
            tvMostrarArbol.Name = "tvMostrarArbol";
            tvMostrarArbol.Size = new Size(653, 459);
            tvMostrarArbol.TabIndex = 2;
            tvMostrarArbol.AfterSelect += tvMostrarArbol_AfterSelect;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(tvMostrarArbol);
            groupBox1.Font = new Font("Segoe UI", 12F);
            groupBox1.Location = new Point(12, 100);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(659, 487);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Arbol de Regiones";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(cboxDepartamentoVecino);
            groupBox2.Controls.Add(btnGuardarDepartamento);
            groupBox2.Controls.Add(cboxCapital);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(txtCantidadMunicipios);
            groupBox2.Controls.Add(txtDistanciaDepartamento);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txtNombreDepartamento);
            groupBox2.Controls.Add(label1);
            groupBox2.Font = new Font("Segoe UI", 12F);
            groupBox2.Location = new Point(677, 100);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(541, 259);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Departamento";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 176);
            label9.Name = "label9";
            label9.Size = new Size(163, 21);
            label9.TabIndex = 18;
            label9.Text = "Departamento Vecino:";
            // 
            // cboxDepartamentoVecino
            // 
            cboxDepartamentoVecino.FormattingEnabled = true;
            cboxDepartamentoVecino.Items.AddRange(new object[] { "-------------" });
            cboxDepartamentoVecino.Location = new Point(213, 168);
            cboxDepartamentoVecino.Name = "cboxDepartamentoVecino";
            cboxDepartamentoVecino.Size = new Size(319, 29);
            cboxDepartamentoVecino.TabIndex = 17;
            // 
            // btnGuardarDepartamento
            // 
            btnGuardarDepartamento.BackColor = SystemColors.ScrollBar;
            btnGuardarDepartamento.FlatStyle = FlatStyle.Flat;
            btnGuardarDepartamento.Font = new Font("Segoe UI", 18F);
            btnGuardarDepartamento.Image = (Image)resources.GetObject("btnGuardarDepartamento.Image");
            btnGuardarDepartamento.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardarDepartamento.Location = new Point(326, 203);
            btnGuardarDepartamento.Name = "btnGuardarDepartamento";
            btnGuardarDepartamento.Size = new Size(206, 44);
            btnGuardarDepartamento.TabIndex = 16;
            btnGuardarDepartamento.Text = "Guardar";
            btnGuardarDepartamento.UseVisualStyleBackColor = false;
            btnGuardarDepartamento.Click += btnGuardarDepartamento_Click;
            // 
            // cboxCapital
            // 
            cboxCapital.FormattingEnabled = true;
            cboxCapital.Items.AddRange(new object[] { "Sí", "No" });
            cboxCapital.Location = new Point(213, 133);
            cboxCapital.Name = "cboxCapital";
            cboxCapital.Size = new Size(319, 29);
            cboxCapital.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 141);
            label4.Name = "label4";
            label4.Size = new Size(107, 21);
            label4.TabIndex = 11;
            label4.Text = "¿Es la Capital?";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 106);
            label3.Name = "label3";
            label3.Size = new Size(176, 21);
            label3.TabIndex = 10;
            label3.Text = "Cantidad de Municipios:";
            // 
            // txtCantidadMunicipios
            // 
            txtCantidadMunicipios.Location = new Point(213, 98);
            txtCantidadMunicipios.Name = "txtCantidadMunicipios";
            txtCantidadMunicipios.Size = new Size(319, 29);
            txtCantidadMunicipios.TabIndex = 9;
            txtCantidadMunicipios.TextChanged += textBox3_TextChanged;
            // 
            // txtDistanciaDepartamento
            // 
            txtDistanciaDepartamento.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtDistanciaDepartamento.Location = new Point(213, 63);
            txtDistanciaDepartamento.Name = "txtDistanciaDepartamento";
            txtDistanciaDepartamento.Size = new Size(319, 29);
            txtDistanciaDepartamento.TabIndex = 8;
            txtDistanciaDepartamento.TextChanged += txtDistanciaDepartamento_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 71);
            label2.Name = "label2";
            label2.Size = new Size(201, 21);
            label2.TabIndex = 7;
            label2.Text = "Distancia de la Capital (km):";
            label2.Click += label2_Click;
            // 
            // txtNombreDepartamento
            // 
            txtNombreDepartamento.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNombreDepartamento.Location = new Point(213, 28);
            txtNombreDepartamento.Name = "txtNombreDepartamento";
            txtNombreDepartamento.Size = new Size(319, 29);
            txtNombreDepartamento.TabIndex = 6;
            txtNombreDepartamento.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 36);
            label1.Name = "label1";
            label1.Size = new Size(71, 21);
            label1.TabIndex = 5;
            label1.Text = "Nombre:";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox3.Controls.Add(btnGuardarMunicipio);
            groupBox3.Controls.Add(txtPoblacion);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(txtDistanciaCabecera);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(cboxDepartamento);
            groupBox3.Controls.Add(txtNombreMunicipio);
            groupBox3.Controls.Add(label5);
            groupBox3.Font = new Font("Segoe UI", 12F);
            groupBox3.Location = new Point(677, 365);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(541, 222);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Municipio";
            // 
            // btnGuardarMunicipio
            // 
            btnGuardarMunicipio.BackColor = SystemColors.ScrollBar;
            btnGuardarMunicipio.FlatStyle = FlatStyle.Flat;
            btnGuardarMunicipio.Font = new Font("Segoe UI", 18F);
            btnGuardarMunicipio.Image = (Image)resources.GetObject("btnGuardarMunicipio.Image");
            btnGuardarMunicipio.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardarMunicipio.Location = new Point(326, 168);
            btnGuardarMunicipio.Name = "btnGuardarMunicipio";
            btnGuardarMunicipio.Size = new Size(206, 44);
            btnGuardarMunicipio.TabIndex = 5;
            btnGuardarMunicipio.Text = "Guardar";
            btnGuardarMunicipio.UseVisualStyleBackColor = false;
            btnGuardarMunicipio.Click += btnGuardarMunicipio_Click;
            // 
            // txtPoblacion
            // 
            txtPoblacion.Location = new Point(213, 133);
            txtPoblacion.Name = "txtPoblacion";
            txtPoblacion.Size = new Size(319, 29);
            txtPoblacion.TabIndex = 17;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 141);
            label8.Name = "label8";
            label8.Size = new Size(77, 21);
            label8.TabIndex = 16;
            label8.Text = "Población";
            label8.Click += label8_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 106);
            label7.Name = "label7";
            label7.Size = new Size(201, 21);
            label7.TabIndex = 15;
            label7.Text = "Distancia de Cabecera (km):";
            // 
            // txtDistanciaCabecera
            // 
            txtDistanciaCabecera.Location = new Point(213, 98);
            txtDistanciaCabecera.Name = "txtDistanciaCabecera";
            txtDistanciaCabecera.Size = new Size(319, 29);
            txtDistanciaCabecera.TabIndex = 14;
            txtDistanciaCabecera.TextChanged += textBox5_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 71);
            label6.Name = "label6";
            label6.Size = new Size(113, 21);
            label6.TabIndex = 13;
            label6.Text = "Departamento:";
            // 
            // cboxDepartamento
            // 
            cboxDepartamento.FormattingEnabled = true;
            cboxDepartamento.Location = new Point(213, 63);
            cboxDepartamento.Name = "cboxDepartamento";
            cboxDepartamento.Size = new Size(319, 29);
            cboxDepartamento.TabIndex = 13;
            cboxDepartamento.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // txtNombreMunicipio
            // 
            txtNombreMunicipio.Location = new Point(213, 28);
            txtNombreMunicipio.Name = "txtNombreMunicipio";
            txtNombreMunicipio.Size = new Size(319, 29);
            txtNombreMunicipio.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 36);
            label5.Name = "label5";
            label5.Size = new Size(71, 21);
            label5.TabIndex = 13;
            label5.Text = "Nombre:";
            // 
            // groupBox5
            // 
            groupBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox5.Controls.Add(txtResultado);
            groupBox5.Font = new Font("Segoe UI", 12F);
            groupBox5.Location = new Point(15, 593);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(1203, 251);
            groupBox5.TabIndex = 0;
            groupBox5.TabStop = false;
            groupBox5.Text = "Resultados";
            // 
            // txtResultado
            // 
            txtResultado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtResultado.Location = new Point(6, 28);
            txtResultado.Multiline = true;
            txtResultado.Name = "txtResultado";
            txtResultado.ReadOnly = true;
            txtResultado.Size = new Size(1188, 217);
            txtResultado.TabIndex = 0;
            // 
            // ArbolBinario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(1230, 856);
            Controls.Add(groupBox5);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Name = "ArbolBinario";
            Text = "Form1";
            Load += ArbolBinario_Load;
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Button btnRecorrerArbol;
        private Button btnBuscarNodo;
        private TreeView tvMostrarArbol;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Label label2;
        private TextBox txtNombreDepartamento;
        private TextBox txtDistanciaDepartamento;
        private Label label3;
        private TextBox txtCantidadMunicipios;
        private ComboBox cboxCapital;
        private Label label4;
        private GroupBox groupBox3;
        private Label label6;
        private ComboBox cboxDepartamento;
        private TextBox txtNombreMunicipio;
        private Label label5;
        private TextBox txtDistanciaCabecera;
        private Label label7;
        private Button btnGuardarDepartamento;
        private Button btnGuardarMunicipio;
        private TextBox txtPoblacion;
        private Label label8;
        private ComboBox cboxDepartamentoVecino;
        private Label label9;
        private GroupBox groupBox5;
        private Button btnListadoNodos;
        private Button btnCalcularDistancia;
        private Button btnEliminarNodo;
        private TextBox txtResultado;
    }
}
