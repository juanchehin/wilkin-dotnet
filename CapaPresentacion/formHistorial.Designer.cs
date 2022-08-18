namespace CapaPresentacion
{
    partial class formHistorial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formHistorial));
            this.lblHistorico = new System.Windows.Forms.Label();
            this.dataListadoHistorico = new System.Windows.Forms.DataGridView();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.lblTotalHistorico = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoHistorico)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHistorico
            // 
            this.lblHistorico.AutoSize = true;
            this.lblHistorico.Font = new System.Drawing.Font("Impact", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistorico.Location = new System.Drawing.Point(36, 9);
            this.lblHistorico.Name = "lblHistorico";
            this.lblHistorico.Size = new System.Drawing.Size(192, 48);
            this.lblHistorico.TabIndex = 16;
            this.lblHistorico.Text = "HIstorico : ";
            // 
            // dataListadoHistorico
            // 
            this.dataListadoHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListadoHistorico.Location = new System.Drawing.Point(44, 104);
            this.dataListadoHistorico.Name = "dataListadoHistorico";
            this.dataListadoHistorico.Size = new System.Drawing.Size(921, 384);
            this.dataListadoHistorico.TabIndex = 17;
            // 
            // btnAnterior
            // 
            this.btnAnterior.Location = new System.Drawing.Point(796, 494);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(75, 23);
            this.btnAnterior.TabIndex = 18;
            this.btnAnterior.Text = "<< Anterior";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(890, 494);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(75, 23);
            this.btnSiguiente.TabIndex = 19;
            this.btnSiguiente.Text = "Siguiente >>";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // lblTotalHistorico
            // 
            this.lblTotalHistorico.AutoSize = true;
            this.lblTotalHistorico.Location = new System.Drawing.Point(678, 85);
            this.lblTotalHistorico.Name = "lblTotalHistorico";
            this.lblTotalHistorico.Size = new System.Drawing.Size(68, 13);
            this.lblTotalHistorico.TabIndex = 20;
            this.lblTotalHistorico.Text = "totalHistorico";
            // 
            // formHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 529);
            this.Controls.Add(this.lblTotalHistorico);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.dataListadoHistorico);
            this.Controls.Add(this.lblHistorico);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formHistorial";
            this.Text = "Historial";
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoHistorico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHistorico;
        private System.Windows.Forms.DataGridView dataListadoHistorico;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Label lblTotalHistorico;
    }
}