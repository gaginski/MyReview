namespace MyReview.View
{
    partial class FrmListaUsuarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListaUsuarios));
            this.dtgListaUsuarios = new System.Windows.Forms.DataGridView();
            this.btnCadastrar = new DevExpress.XtraEditors.SimpleButton();
            this.scsBusca = new DevExpress.XtraEditors.SearchControl();
            this.btnEditar = new DevExpress.XtraEditors.SimpleButton();
            this.btnExcluir = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBusca = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scsBusca.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgListaUsuarios
            // 
            this.dtgListaUsuarios.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dtgListaUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaUsuarios.GridColor = System.Drawing.SystemColors.Control;
            this.dtgListaUsuarios.Location = new System.Drawing.Point(12, 37);
            this.dtgListaUsuarios.Name = "dtgListaUsuarios";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgListaUsuarios.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgListaUsuarios.Size = new System.Drawing.Size(578, 343);
            this.dtgListaUsuarios.TabIndex = 0;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrar.Appearance.Options.UseFont = true;
            this.btnCadastrar.Location = new System.Drawing.Point(593, 65);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(119, 23);
            this.btnCadastrar.TabIndex = 1;
            this.btnCadastrar.Text = "&Cadastrar";
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // scsBusca
            // 
            this.scsBusca.Location = new System.Drawing.Point(12, 6);
            this.scsBusca.Name = "scsBusca";
            this.scsBusca.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scsBusca.Properties.Appearance.Options.UseFont = true;
            this.scsBusca.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.scsBusca.Size = new System.Drawing.Size(448, 22);
            this.scsBusca.TabIndex = 2;
            this.scsBusca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            this.scsBusca.Leave += new System.EventHandler(this.enter_srcBusca);
            // 
            // btnEditar
            // 
            this.btnEditar.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Appearance.Options.UseFont = true;
            this.btnEditar.Location = new System.Drawing.Point(593, 94);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(119, 23);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            // 
            // btnExcluir
            // 
            this.btnExcluir.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Appearance.Options.UseFont = true;
            this.btnExcluir.Location = new System.Drawing.Point(593, 123);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(119, 23);
            this.btnExcluir.TabIndex = 4;
            this.btnExcluir.Text = "E&xcluir";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(593, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Status";
            // 
            // cmbBusca
            // 
            this.cmbBusca.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBusca.FormattingEnabled = true;
            this.cmbBusca.Location = new System.Drawing.Point(466, 6);
            this.cmbBusca.Name = "cmbBusca";
            this.cmbBusca.Size = new System.Drawing.Size(121, 24);
            this.cmbBusca.TabIndex = 8;
            this.cmbBusca.Leave += new System.EventHandler(this.enter_srcBusca);
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(593, 35);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(119, 24);
            this.comboBox2.TabIndex = 9;
            // 
            // FrmListaUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 392);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.cmbBusca);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.scsBusca);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.dtgListaUsuarios);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("FrmListaUsuarios.IconOptions.Image")));
            this.KeyPreview = true;
            this.Name = "FrmListaUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listagem Usuários";
            this.Load += new System.EventHandler(this.FrmListaUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scsBusca.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgListaUsuarios;
        private DevExpress.XtraEditors.SimpleButton btnCadastrar;
        private DevExpress.XtraEditors.SearchControl scsBusca;
        private DevExpress.XtraEditors.SimpleButton btnEditar;
        private DevExpress.XtraEditors.SimpleButton btnExcluir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBusca;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}