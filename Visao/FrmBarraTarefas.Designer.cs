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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnRelatorio = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsuarioLogado = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUsuario
            // 
            this.btnUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnUsuario.Image")));
            this.btnUsuario.Location = new System.Drawing.Point(12, 12);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(96, 90);
            this.btnUsuario.TabIndex = 0;
            this.btnUsuario.Text = "Usuários";
            this.btnUsuario.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUsuario.UseVisualStyleBackColor = true;
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(12, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 90);
            this.button1.TabIndex = 1;
            this.button1.Text = "Revisões";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(12, 204);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 90);
            this.button2.TabIndex = 2;
            this.button2.Text = "Minhas Tarefas";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnRelatorio
            // 
            this.btnRelatorio.Image = ((System.Drawing.Image)(resources.GetObject("btnRelatorio.Image")));
            this.btnRelatorio.Location = new System.Drawing.Point(12, 300);
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.Size = new System.Drawing.Size(96, 90);
            this.btnRelatorio.TabIndex = 3;
            this.btnRelatorio.Text = "Relatórios";
            this.btnRelatorio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRelatorio.UseVisualStyleBackColor = true;
            this.btnRelatorio.Click += new System.EventHandler(this.btnRelatorio_click);
            // 
            // button5
            // 
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(12, 396);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(96, 90);
            this.button5.TabIndex = 5;
            this.button5.Text = "Casos de Teste";
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblUsuarioLogado);
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
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblUsuarioLogado
            // 
            this.lblUsuarioLogado.AutoSize = true;
            this.lblUsuarioLogado.Location = new System.Drawing.Point(55, 9);
            this.lblUsuarioLogado.Name = "lblUsuarioLogado";
            this.lblUsuarioLogado.Size = new System.Drawing.Size(39, 13);
            this.lblUsuarioLogado.TabIndex = 1;
            this.lblUsuarioLogado.Text = "logado";
            this.lblUsuarioLogado.Click += new System.EventHandler(this.lblUsuarioLogado_Click);
            // 
            // button4
            // 
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(12, 492);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 90);
            this.button4.TabIndex = 7;
            this.button4.Text = "Configurações";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // FrmBarraTarefas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(120, 631);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnRelatorio);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnUsuario);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(136, 670);
            this.MinimumSize = new System.Drawing.Size(136, 670);
            this.Name = "FrmBarraTarefas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MyReview";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBarraTarefas_Close);
            this.Load += new System.EventHandler(this.FrmBarraTarefas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnRelatorio;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUsuarioLogado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
    }
}