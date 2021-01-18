namespace MyReview.View
{
    partial class FrmCadRevisao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadRevisao));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtRevDescricao = new DevExpress.XtraEditors.MemoEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.txtVersao = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnAdicionar_TarSia = new DevExpress.XtraEditors.SimpleButton();
            this.txtObs_TarSia = new DevExpress.XtraEditors.MemoEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.gridSia = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtDescricao_TarSia = new DevExpress.XtraEditors.MemoEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitulo_TarSia = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.cmbProjeto = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRevDescricao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVersao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtObs_TarSia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescricao_TarSia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitulo_TarSia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProjeto.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.cmbProjeto);
            this.panelControl1.Controls.Add(this.txtRevDescricao);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.checkEdit1);
            this.panelControl1.Controls.Add(this.txtVersao);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Location = new System.Drawing.Point(12, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(743, 100);
            this.panelControl1.TabIndex = 0;
            // 
            // txtRevDescricao
            // 
            this.txtRevDescricao.Location = new System.Drawing.Point(180, 23);
            this.txtRevDescricao.Name = "txtRevDescricao";
            this.txtRevDescricao.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRevDescricao.Properties.Appearance.Options.UseFont = true;
            this.txtRevDescricao.Size = new System.Drawing.Size(558, 75);
            this.txtRevDescricao.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(173, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Descrição:";
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(8, 50);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEdit1.Properties.Appearance.Options.UseFont = true;
            this.checkEdit1.Properties.Caption = "Revisão Modelo";
            this.checkEdit1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkEdit1.Size = new System.Drawing.Size(164, 20);
            this.checkEdit1.TabIndex = 7;
            // 
            // txtVersao
            // 
            this.txtVersao.Location = new System.Drawing.Point(8, 22);
            this.txtVersao.Name = "txtVersao";
            this.txtVersao.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVersao.Properties.Appearance.Options.UseFont = true;
            this.txtVersao.Properties.BeepOnError = false;
            this.txtVersao.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.SimpleMaskManager));
            this.txtVersao.Properties.MaskSettings.Set("mask", "#.##.##.####");
            this.txtVersao.Size = new System.Drawing.Size(164, 22);
            this.txtVersao.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Versão:";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnAdicionar_TarSia);
            this.groupControl1.Controls.Add(this.txtObs_TarSia);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.gridSia);
            this.groupControl1.Controls.Add(this.txtDescricao_TarSia);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.txtTitulo_TarSia);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Location = new System.Drawing.Point(12, 109);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(743, 214);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Tarefas do SIA (Todas as tarefas serão lançadas em uma única Suíte)";
            // 
            // btnAdicionar_TarSia
            // 
            this.btnAdicionar_TarSia.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionar_TarSia.Appearance.Options.UseFont = true;
            this.btnAdicionar_TarSia.Location = new System.Drawing.Point(325, 185);
            this.btnAdicionar_TarSia.Name = "btnAdicionar_TarSia";
            this.btnAdicionar_TarSia.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionar_TarSia.TabIndex = 17;
            this.btnAdicionar_TarSia.Text = "Adicionar";
            this.btnAdicionar_TarSia.Click += new System.EventHandler(this.btnAdicionar_TarSia_Click);
            // 
            // txtObs_TarSia
            // 
            this.txtObs_TarSia.Location = new System.Drawing.Point(77, 123);
            this.txtObs_TarSia.Name = "txtObs_TarSia";
            this.txtObs_TarSia.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObs_TarSia.Properties.Appearance.Options.UseFont = true;
            this.txtObs_TarSia.Size = new System.Drawing.Size(323, 58);
            this.txtObs_TarSia.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Obs:";
            // 
            // gridSia
            // 
            this.gridSia.Location = new System.Drawing.Point(406, 32);
            this.gridSia.MainView = this.gridView1;
            this.gridSia.Name = "gridSia";
            this.gridSia.Size = new System.Drawing.Size(332, 173);
            this.gridSia.TabIndex = 14;
            this.gridSia.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridSia;
            this.gridView1.Name = "gridView1";
            // 
            // txtDescricao_TarSia
            // 
            this.txtDescricao_TarSia.Location = new System.Drawing.Point(77, 59);
            this.txtDescricao_TarSia.Name = "txtDescricao_TarSia";
            this.txtDescricao_TarSia.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao_TarSia.Properties.Appearance.Options.UseFont = true;
            this.txtDescricao_TarSia.Size = new System.Drawing.Size(323, 58);
            this.txtDescricao_TarSia.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Descrição:";
            // 
            // txtTitulo_TarSia
            // 
            this.txtTitulo_TarSia.Location = new System.Drawing.Point(77, 31);
            this.txtTitulo_TarSia.Name = "txtTitulo_TarSia";
            this.txtTitulo_TarSia.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitulo_TarSia.Properties.Appearance.Options.UseFont = true;
            this.txtTitulo_TarSia.Size = new System.Drawing.Size(323, 22);
            this.txtTitulo_TarSia.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Título:";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gridControl2);
            this.groupControl2.Location = new System.Drawing.Point(12, 329);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(743, 259);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "Suites de Testes";
            // 
            // gridControl2
            // 
            this.gridControl2.Location = new System.Drawing.Point(5, 26);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(733, 228);
            this.gridControl2.TabIndex = 18;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new System.Drawing.Point(680, 594);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 18;
            this.simpleButton2.Text = "Salvar";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.Location = new System.Drawing.Point(599, 594);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(75, 23);
            this.simpleButton3.TabIndex = 19;
            this.simpleButton3.Text = "Cancelar";
            // 
            // cmbProjeto
            // 
            this.cmbProjeto.EditValue = "";
            this.cmbProjeto.Location = new System.Drawing.Point(8, 76);
            this.cmbProjeto.Name = "cmbProjeto";
            this.cmbProjeto.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProjeto.Properties.Appearance.Options.UseFont = true;
            this.cmbProjeto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbProjeto.Properties.NullText = "Selecione o Projeto";
            this.cmbProjeto.Size = new System.Drawing.Size(164, 22);
            this.cmbProjeto.TabIndex = 11;
            // 
            // FrmCadRevisao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 629);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("FrmCadRevisao.IconOptions.Image")));
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "FrmCadRevisao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyReview - Cadastro de Revisão";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRevDescricao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVersao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtObs_TarSia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescricao_TarSia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitulo_TarSia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProjeto.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.MemoEdit txtRevDescricao;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.TextEdit txtVersao;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnAdicionar_TarSia;
        private DevExpress.XtraEditors.MemoEdit txtObs_TarSia;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraGrid.GridControl gridSia;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.MemoEdit txtDescricao_TarSia;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtTitulo_TarSia;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.LookUpEdit cmbProjeto;
    }
}