using Logica;
using Principal;

namespace Principal
{
    public partial class frmLogin : Form
    {
        private UsuarioL usuarioL = new UsuarioL();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(txtContraseña.Text))
            {
                if (usuarioL.ValidarUsuarioL(txtUsuario.Text, txtContraseña.Text))
                {
                    GlobalVariables.Rol = "Administrador";
                    frmProductos frm = new frmProductos();

                    

                    this.Hide();
                    frm.ShowDialog();
                    this.Show();
                }
                else
                {
                    lbError.Text = "Usuario o contraseña incorrecta";
                    lbError.Visible = true;
                }
            }
            else
            {
                lbError.Text = "Debe ingresar usuario y contraseña";
                lbError.Visible = true;
            }
        }
    }
}