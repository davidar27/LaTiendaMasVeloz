using Logica;

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

            if (txtUsuario.Text != "" || txtContraseña.Text != "")
            {
                var validar = usuarioL.ValidarUsuarioL(txtUsuario.Text, txtContraseña.Text);
                if (validar)
                {
                    frmProductos frm = new frmProductos();
                    this.Hide();
                    frm.ShowDialog();
                    this.Show();
                }
                else
                {
                    lbError.Text = "Usuario o contraseña Incorrecta";
                    lbError.Visible = true;
                }

            }
            else
            {
                lbError.Text = "Usuario o contraseña faltantes";
                lbError.Visible = true;
            }
        }

        private void txbContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }




    }
}
