namespace WindowsFormsApplication1
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.TirarDado = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dadopb = new System.Windows.Forms.PictureBox();
            this.tablero = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dadopb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablero)).BeginInit();
            this.SuspendLayout();
            // 
            // TirarDado
            // 
            this.TirarDado.Location = new System.Drawing.Point(831, 465);
            this.TirarDado.Name = "TirarDado";
            this.TirarDado.Size = new System.Drawing.Size(113, 30);
            this.TirarDado.TabIndex = 2;
            this.TirarDado.Text = "Tirar";
            this.TirarDado.UseVisualStyleBackColor = true;
            this.TirarDado.Click += new System.EventHandler(this.TirarDado_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dadopb
            // 
            this.dadopb.Image = global::WindowsFormsApplication1.Properties.Resources._1;
            this.dadopb.InitialImage = null;
            this.dadopb.Location = new System.Drawing.Point(830, 345);
            this.dadopb.Name = "dadopb";
            this.dadopb.Size = new System.Drawing.Size(114, 114);
            this.dadopb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.dadopb.TabIndex = 1;
            this.dadopb.TabStop = false;
            // 
            // tablero
            // 
            this.tablero.Image = global::WindowsFormsApplication1.Properties.Resources.tableroca;
            this.tablero.Location = new System.Drawing.Point(12, 12);
            this.tablero.Name = "tablero";
            this.tablero.Size = new System.Drawing.Size(796, 648);
            this.tablero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.tablero.TabIndex = 0;
            this.tablero.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 672);
            this.Controls.Add(this.TirarDado);
            this.Controls.Add(this.dadopb);
            this.Controls.Add(this.tablero);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dadopb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablero)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox tablero;
        private System.Windows.Forms.PictureBox dadopb;
        private System.Windows.Forms.Button TirarDado;
        private System.Windows.Forms.Timer timer1;
    }
}