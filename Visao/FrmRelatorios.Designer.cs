namespace MyReview.Visao
{
    partial class FrmRelatorios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelatorios));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInicial = new System.Windows.Forms.MaskedTextBox();
            this.txtFinal = new System.Windows.Forms.MaskedTextBox();
            this.txtRelatorio = new System.Windows.Forms.RichTextBox();
            this.btnGerar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Inicial:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data Final:";
            // 
            // txtInicial
            // 
            this.txtInicial.Location = new System.Drawing.Point(19, 42);
            this.txtInicial.Mask = "00/00/0000 90:00";
            this.txtInicial.Name = "txtInicial";
            this.txtInicial.Size = new System.Drawing.Size(99, 20);
            this.txtInicial.TabIndex = 3;
            this.txtInicial.ValidatingType = typeof(System.DateTime);
            // 
            // txtFinal
            // 
            this.txtFinal.Location = new System.Drawing.Point(124, 42);
            this.txtFinal.Mask = "00/00/0000 90:00";
            this.txtFinal.Name = "txtFinal";
            this.txtFinal.Size = new System.Drawing.Size(99, 20);
            this.txtFinal.TabIndex = 4;
            this.txtFinal.ValidatingType = typeof(System.DateTime);
            // 
            // txtRelatorio
            // 
            this.txtRelatorio.Location = new System.Drawing.Point(18, 70);
            this.txtRelatorio.Name = "txtRelatorio";
            this.txtRelatorio.Size = new System.Drawing.Size(309, 198);
            this.txtRelatorio.TabIndex = 6;
            this.txtRelatorio.Text = "";
            // 
            // btnGerar
            // 
            this.btnGerar.Location = new System.Drawing.Point(229, 42);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(98, 22);
            this.btnGerar.TabIndex = 7;
            this.btnGerar.Text = "&Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmRelatorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 284);
            this.Controls.Add(this.btnGerar);
            this.Controls.Add(this.txtRelatorio);
            this.Controls.Add(this.txtFinal);
            this.Controls.Add(this.txtInicial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmRelatorios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyReview - Gerar Relatório";
            this.Load += new System.EventHandler(this.FrmRelatorios_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtInicial;
        private System.Windows.Forms.MaskedTextBox txtFinal;
        private System.Windows.Forms.RichTextBox txtRelatorio;
        private System.Windows.Forms.Button btnGerar;
    }
}