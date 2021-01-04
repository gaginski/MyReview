namespace MyReview.Visao
{
    partial class FrmBarraTarefas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBarraTarefas));
            this.btnUsuario = new System.Windows.Forms.Button();
            this.btnRevisao = new System.Windows.Forms.Button();
            this.btnMinhasTarefas = new System.Windows.Forms.Button();
            this.btnRelatorio = new System.Windows.Forms.Button();
            this.btnCasoTeste = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsuarioLogado = new System.Windows.Forms.Label();
            this.btnConfig = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUsuario
            // 
            this.btnUsuario.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnUsuario.Image")));
            this.btnUsuario.Location = new System.Drawing.Point(12, 12);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(96, 90);
            this.btnUsuario.TabIndex = 0;
            this.btnUsuario.Text = "Usuários";
            this.btnUsuario.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUsuario.UseVisualStyleBackColor = false;
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // btnRevisao
            // 
            this.btnRevisao.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRevisao.Image = ((System.Drawing.Image)(resources.GetObject("btnRevisao.Image")));
            this.btnRevisao.Location = new System.Drawing.Point(12, 108);
            this.btnRevisao.Name = "btnRevisao";
            this.btnRevisao.Size = new System.Drawing.Size(96, 90);
            this.btnRevisao.TabIndex = 1;
            this.btnRevisao.Text = "Revisões";
            this.btnRevisao.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRevisao.UseVisualStyleBackColor = false;
            this.btnRevisao.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMinhasTarefas
            // 
            this.btnMinhasTarefas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMinhasTarefas.Image = ((System.Drawing.Image)(resources.GetObject("btnMinhasTarefas.Image")));
            this.btnMinhasTarefas.Location = new System.Drawing.Point(12, 204);
            this.btnMinhasTarefas.Name = "btnMinhasTarefas";
            this.btnMinhasTarefas.Size = new System.Drawing.Size(96, 90);
            this.btnMinhasTarefas.TabIndex = 2;
            this.btnMinhasTarefas.Text = "Minhas Tarefas";
            this.btnMinhasTarefas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMinhasTarefas.UseVisualStyleBackColor = false;
            this.btnMinhasTarefas.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnRelatorio
            // 
            this.btnRelatorio.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRelatorio.Image = ((System.Drawing.Image)(resources.GetObject("btnRelatorio.Image")));
            this.btnRelatorio.Location = new System.Drawing.Point(12, 300);
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.Size = new System.Drawing.Size(96, 90);
            this.btnRelatorio.TabIndex = 3;
            this.btnRelatorio.Text = "Relatórios";
            this.btnRelatorio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRelatorio.UseVisualStyleBackColor = false;
            this.btnRelatorio.Click += new System.EventHandler(this.btnRelatorio_click);
            // 
            // btnCasoTeste
            // 
            this.btnCasoTeste.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCasoTeste.Image = ((System.Drawing.Image)(resources.GetObject("btnCasoTeste.Image")));
            this.btnCasoTeste.Location = new System.Drawing.Point(12, 396);
            this.btnCasoTeste.Name = "btnCasoTeste";
            this.btnCasoTeste.Size = new System.Drawing.Size(96, 90);
            this.btnCasoTeste.TabIndex = 5;
            this.btnCasoTeste.Text = "Casos de Teste";
            this.btnCasoTeste.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCasoTeste.UseVisualStyleBackColor = false;
            this.btnCasoTeste.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblUsuarioLogado);
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(1, 592);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 39);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usuário:";
            // 
            // lblUsuarioLogado
            // 
            this.lblUsuarioLogado.AutoSize = true;
            this.lblUsuarioLogado.Location = new System.Drawing.Point(55, 9);
            this.lblUsuarioLogado.Name = "lblUsuarioLogado";
            this.lblUsuarioLogado.Size = new System.Drawing.Size(39, 13);
            this.lblUsuarioLogado.TabIndex = 1;
            this.lblUsuarioLogado.Text = "logado";
            // 
            // btnConfig
            // 
            this.btnConfig.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnConfig.Image")));
            this.btnConfig.Location = new System.Drawing.Point(12, 492);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(96, 90);
            this.btnConfig.TabIndex = 7;
            this.btnConfig.Text = "Configurações";
            this.btnConfig.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConfig.UseVisualStyleBackColor = false;
            // 
            // FrmBarraTarefas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(120, 631);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCasoTeste);
            this.Controls.Add(this.btnRelatorio);
            this.Controls.Add(this.btnMinhasTarefas);
            this.Controls.Add(this.btnRevisao);
            this.Controls.Add(this.btnUsuario);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(136, 670);
            this.MinimumSize = new System.Drawing.Size(136, 670);
            this.Name = "FrmBarraTarefas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MyReview";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBarraTarefas_Close);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.Button btnRevisao;
        private System.Windows.Forms.Button btnMinhasTarefas;
        private System.Windows.Forms.Button btnRelatorio;
        private System.Windows.Forms.Button btnCasoTeste;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUsuarioLogado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfig;
    }
}