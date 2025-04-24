namespace Principal
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            labelLogin = new Label();
            txtUsuario = new TextBox();
            txtContraseña = new TextBox();
            btnEntrar = new Button();
            pictureBox1 = new PictureBox();
            lbContraseña = new Label();
            label1 = new Label();
            lbError = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelLogin.Location = new Point(105, 9);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(160, 60);
            labelLogin.TabIndex = 0;
            labelLogin.Text = "LOGIN";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(40, 225);
            txtUsuario.Margin = new Padding(3, 4, 3, 4);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(296, 27);
            txtUsuario.TabIndex = 1;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(40, 301);
            txtContraseña.Margin = new Padding(3, 4, 3, 4);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(296, 27);
            txtContraseña.TabIndex = 2;
            // 
            // btnEntrar
            // 
            btnEntrar.Location = new Point(133, 386);
            btnEntrar.Margin = new Padding(3, 4, 3, 4);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(114, 31);
            btnEntrar.TabIndex = 3;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = true;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(122, 72);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 125);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // lbContraseña
            // 
            lbContraseña.AutoSize = true;
            lbContraseña.Location = new Point(40, 277);
            lbContraseña.Name = "lbContraseña";
            lbContraseña.Size = new Size(83, 20);
            lbContraseña.TabIndex = 5;
            lbContraseña.Text = "Contraseña";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 201);
            label1.Name = "label1";
            label1.Size = new Size(59, 20);
            label1.TabIndex = 6;
            label1.Text = "Usuario";
            // 
            // lbError
            // 
            lbError.AutoSize = true;
            lbError.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbError.ForeColor = Color.Red;
            lbError.Location = new Point(13, 337);
            lbError.Name = "lbError";
            lbError.Size = new Size(357, 31);
            lbError.TabIndex = 7;
            lbError.Text = "Usuario o Contraseña incorrecta";
            lbError.Visible = false;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(388, 456);
            Controls.Add(lbError);
            Controls.Add(label1);
            Controls.Add(lbContraseña);
            Controls.Add(pictureBox1);
            Controls.Add(btnEntrar);
            Controls.Add(txtContraseña);
            Controls.Add(txtUsuario);
            Controls.Add(labelLogin);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "frmLogin";
            Text = "frmLogin";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelLogin;
        private TextBox txtUsuario;
        private TextBox txtContraseña;
        private Button btnEntrar;
        private PictureBox pictureBox1;
        private Label lbContraseña;
        private Label label1;
        private Label lbError;
    }
}