using MyReview.Controle;
using MyReview.Modelo;
using System;
using System.Collections.Generic;

namespace MyReview.Visao
{
    partial class FrmCriaRevisao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCriaRevisao));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtVersao = new System.Windows.Forms.MaskedTextBox();
            this.txtDescricaoRevisao = new System.Windows.Forms.RichTextBox();
            this.lblCampoRevisao = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsavel = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Vincular = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TarefaSia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.txtDescricaoTarefa = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodigoSia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTituloTarefa = new System.Windows.Forms.TextBox();
            this.lblAtividade = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbModelos = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.chkModelo = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Versão:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkModelo);
            this.groupBox1.Controls.Add(this.txtVersao);
            this.groupBox1.Controls.Add(this.txtDescricaoRevisao);
            this.groupBox1.Controls.Add(this.lblCampoRevisao);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(433, 124);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Revisão";
            // 
            // txtVersao
            // 
            this.txtVersao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVersao.Location = new System.Drawing.Point(67, 24);
            this.txtVersao.Mask = "#.##.##.####";
            this.txtVersao.Name = "txtVersao";
            this.txtVersao.Size = new System.Drawing.Size(106, 22);
            this.txtVersao.TabIndex = 4;
            // 
            // txtDescricaoRevisao
            // 
            this.txtDescricaoRevisao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricaoRevisao.Location = new System.Drawing.Point(10, 68);
            this.txtDescricaoRevisao.MaxLength = 500;
            this.txtDescricaoRevisao.Name = "txtDescricaoRevisao";
            this.txtDescricaoRevisao.Size = new System.Drawing.Size(418, 46);
            this.txtDescricaoRevisao.TabIndex = 3;
            this.txtDescricaoRevisao.Text = "";
            // 
            // lblCampoRevisao
            // 
            this.lblCampoRevisao.AutoSize = true;
            this.lblCampoRevisao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCampoRevisao.Location = new System.Drawing.Point(6, 49);
            this.lblCampoRevisao.Name = "lblCampoRevisao";
            this.lblCampoRevisao.Size = new System.Drawing.Size(73, 16);
            this.lblCampoRevisao.TabIndex = 2;
            this.lblCampoRevisao.Text = "Descrição:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExcluir);
            this.groupBox2.Controls.Add(this.btnIncluir);
            this.groupBox2.Controls.Add(this.txtDescricaoTarefa);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtCodigoSia);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtTituloTarefa);
            this.groupBox2.Controls.Add(this.lblAtividade);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(433, 196);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tarefas";
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Titulo,
            this.responsavel,
            this.Vincular,
            this.TarefaSia});
            this.grid.Location = new System.Drawing.Point(21, 394);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(418, 169);
            this.grid.TabIndex = 8;
            // 
            // Id
            // 
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 35;
            // 
            // Titulo
            // 
            this.Titulo.HeaderText = "Título";
            this.Titulo.Name = "Titulo";
            this.Titulo.ReadOnly = true;
            // 
            // responsavel
            // 
            this.responsavel.HeaderText = "Responsável";
            this.responsavel.Name = "responsavel";
            // 
            // Vincular
            // 
            this.Vincular.HeaderText = "Vincular";
            this.Vincular.Name = "Vincular";
            this.Vincular.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Vincular.Width = 50;
            // 
            // TarefaSia
            // 
            this.TarefaSia.HeaderText = "Tarefa Sia";
            this.TarefaSia.Name = "TarefaSia";
            this.TarefaSia.ReadOnly = true;
            this.TarefaSia.Width = 80;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(263, 165);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(79, 23);
            this.btnExcluir.TabIndex = 7;
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // btnIncluir
            // 
            this.btnIncluir.Location = new System.Drawing.Point(349, 165);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(79, 23);
            this.btnIncluir.TabIndex = 6;
            this.btnIncluir.Text = "&Incluir";
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDescricaoTarefa
            // 
            this.txtDescricaoTarefa.Location = new System.Drawing.Point(10, 76);
            this.txtDescricaoTarefa.MaxLength = 500;
            this.txtDescricaoTarefa.Name = "txtDescricaoTarefa";
            this.txtDescricaoTarefa.Size = new System.Drawing.Size(417, 83);
            this.txtDescricaoTarefa.TabIndex = 5;
            this.txtDescricaoTarefa.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Descrição Tarefa:";
            // 
            // txtCodigoSia
            // 
            this.txtCodigoSia.Location = new System.Drawing.Point(347, 32);
            this.txtCodigoSia.Name = "txtCodigoSia";
            this.txtCodigoSia.Size = new System.Drawing.Size(80, 22);
            this.txtCodigoSia.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(346, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Cód. Tarefa:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtTituloTarefa
            // 
            this.txtTituloTarefa.Location = new System.Drawing.Point(10, 32);
            this.txtTituloTarefa.Name = "txtTituloTarefa";
            this.txtTituloTarefa.Size = new System.Drawing.Size(332, 22);
            this.txtTituloTarefa.TabIndex = 1;
            // 
            // lblAtividade
            // 
            this.lblAtividade.AutoSize = true;
            this.lblAtividade.Location = new System.Drawing.Point(6, 16);
            this.lblAtividade.Name = "lblAtividade";
            this.lblAtividade.Size = new System.Drawing.Size(44, 16);
            this.lblAtividade.TabIndex = 0;
            this.lblAtividade.Text = "Título:";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(361, 586);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(79, 32);
            this.btnSalvar.TabIndex = 3;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(276, 586);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 32);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 578);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Revisão Modelo:";
            // 
            // cmbModelos
            // 
            this.cmbModelos.FormattingEnabled = true;
            this.cmbModelos.Location = new System.Drawing.Point(21, 597);
            this.cmbModelos.Name = "cmbModelos";
            this.cmbModelos.Size = new System.Drawing.Size(147, 21);
            this.cmbModelos.TabIndex = 10;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(174, 586);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(79, 32);
            this.button3.TabIndex = 11;
            this.button3.Text = "Clo&nar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisa.Location = new System.Drawing.Point(21, 362);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(385, 22);
            this.txtPesquisa.TabIndex = 12;
            this.txtPesquisa.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 346);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Pesquisa (Descrição)";
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisa.Image")));
            this.btnPesquisa.Location = new System.Drawing.Point(407, 359);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(33, 29);
            this.btnPesquisa.TabIndex = 14;
            this.btnPesquisa.UseVisualStyleBackColor = true;
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // chkModelo
            // 
            this.chkModelo.AutoSize = true;
            this.chkModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkModelo.Location = new System.Drawing.Point(186, 26);
            this.chkModelo.Name = "chkModelo";
            this.chkModelo.Size = new System.Drawing.Size(127, 20);
            this.chkModelo.TabIndex = 5;
            this.chkModelo.Text = "Revisão Modelo";
            this.chkModelo.UseVisualStyleBackColor = true;
            this.chkModelo.CheckedChanged += new System.EventHandler(this.chkModelo_CheckedChanged);
            // 
            // FrmCriaRevisao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 634);
            this.Controls.Add(this.btnPesquisa);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPesquisa);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cmbModelos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCriaRevisao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyReview - Cadastro de Revisões";
            this.Load += new System.EventHandler(this.FrmCriaRevisao_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txtDescricaoRevisao;
        private System.Windows.Forms.Label lblCampoRevisao;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.RichTextBox txtDescricaoTarefa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodigoSia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTituloTarefa;
        private System.Windows.Forms.Label lblAtividade;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Titulo;
        private System.Windows.Forms.DataGridViewComboBoxColumn responsavel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Vincular;
        private System.Windows.Forms.DataGridViewTextBoxColumn TarefaSia;
        private System.Windows.Forms.MaskedTextBox txtVersao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbModelos;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.CheckBox chkModelo;
    }
}