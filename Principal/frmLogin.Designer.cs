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
            labelLogin = new Label();
            txb = new TextBox();
            txbContraseña = new TextBox();
            btnEntrar = new Button();
            SuspendLayout();
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Location = new Point(347, 52);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(37, 15);
            labelLogin.TabIndex = 0;
            labelLogin.Text = "Login";
            // 
            // txb
            // 
            txb.Location = new Point(315, 80);
            txb.Name = "txb";
            txb.Size = new Size(100, 23);
            txb.TabIndex = 1;
            // 
            // txbContraseña
            // 
            txbContraseña.Location = new Point(315, 137);
            txbContraseña.Name = "txbContraseña";
            txbContraseña.Size = new Size(100, 23);
            txbContraseña.TabIndex = 2;
            // 
            // btnEntrar
            // 
            btnEntrar.Location = new Point(315, 189);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(100, 23);
            btnEntrar.TabIndex = 3;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = true;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEntrar);
            Controls.Add(txbContraseña);
            Controls.Add(txb);
            Controls.Add(labelLogin);
            Name = "frmLogin";
            Text = "frmLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelLogin;
        private TextBox txb;
        private TextBox txbContraseña;
        private Button btnEntrar;
    }
}