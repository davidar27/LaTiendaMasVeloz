using LaTiendaMásVeloz;
using Logica;
using Modelo;

public partial class MainForm : Form
{
    private ProductoLogic productoLogic = new ProductoLogic();

    public MainForm()
    {
        InitializeComponent();
        ConfigurarColumnas();
        CargarProductos();
    }

    private void InitializeComponent()
    {
        dataGridViewProductos = new DataGridView();
        btnAgregar = new Button();
        btnEditar = new Button();
        btnEliminar = new Button();
        ((System.ComponentModel.ISupportInitialize)dataGridViewProductos).BeginInit();
        SuspendLayout();
        // 
        // dataGridViewProductos
        // 
        dataGridViewProductos.ColumnHeadersHeight = 29;
        dataGridViewProductos.Location = new Point(0, 0);
        dataGridViewProductos.Margin = new Padding(4, 5, 4, 5);
        dataGridViewProductos.Name = "dataGridViewProductos";
        dataGridViewProductos.RowHeadersWidth = 51;
        dataGridViewProductos.Size = new Size(320, 231);
        dataGridViewProductos.TabIndex = 4;
        dataGridViewProductos.CellContentClick += dataGridViewProductos_CellContentClick;
        // 
        // btnAgregar
        // 
        btnAgregar.Location = new Point(16, 508);
        btnAgregar.Margin = new Padding(4, 5, 4, 5);
        btnAgregar.Name = "btnAgregar";
        btnAgregar.Size = new Size(100, 35);
        btnAgregar.TabIndex = 1;
        btnAgregar.Text = "Agregar";
        btnAgregar.UseVisualStyleBackColor = true;
        btnAgregar.Click += btnAgregar_Click;
        // 
        // btnEditar
        // 
        btnEditar.Location = new Point(124, 508);
        btnEditar.Margin = new Padding(4, 5, 4, 5);
        btnEditar.Name = "btnEditar";
        btnEditar.Size = new Size(100, 35);
        btnEditar.TabIndex = 2;
        btnEditar.Text = "Editar";
        btnEditar.UseVisualStyleBackColor = true;
        btnEditar.Click += btnEditar_Click;
        // 
        // btnEliminar
        // 
        btnEliminar.Location = new Point(232, 508);
        btnEliminar.Margin = new Padding(4, 5, 4, 5);
        btnEliminar.Name = "btnEliminar";
        btnEliminar.Size = new Size(100, 35);
        btnEliminar.TabIndex = 3;
        btnEliminar.Text = "Eliminar";
        btnEliminar.UseVisualStyleBackColor = true;
        btnEliminar.Click += btnEliminar_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(832, 555);
        Controls.Add(btnEliminar);
        Controls.Add(btnEditar);
        Controls.Add(btnAgregar);
        Controls.Add(dataGridViewProductos);
        Margin = new Padding(4, 5, 4, 5);
        Name = "MainForm";
        Text = "La Tienda Más Veloz - Gestión de Productos";
        ((System.ComponentModel.ISupportInitialize)dataGridViewProductos).EndInit();
        ResumeLayout(false);
    }

    private void ConfigurarColumnas()
    {
        dataGridViewProductos.Columns.Clear();
        dataGridViewProductos.Columns.Add("Id", "ID");
        dataGridViewProductos.Columns.Add("Nombre", "Nombre");
        dataGridViewProductos.Columns.Add("PrecioVenta", "Precio");
        dataGridViewProductos.Columns.Add("Stock", "Stock");
        dataGridViewProductos.Columns["PrecioVenta"].DefaultCellStyle.Format = "C2"; // Formato de moneda
    }

    private void CargarProductos()
    {
        try
        {
            // Obtener la lista de productos desde la capa lógica
            List<Producto> productos = productoLogic.ObtenerProductos();

            // Enlazar la lista al DataGridView
            dataGridViewProductos.DataSource = productos;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error al cargar productos: " + ex.Message);
        }
    }

    private void btnAgregar_Click(object sender, EventArgs e)
    {
        // Abrir el formulario para agregar un nuevo producto
        ProductosForm productosForm = new ProductosForm();
        productosForm.ShowDialog();
        CargarProductos(); // Recargar la lista después de agregar un producto
    }

    private void btnEditar_Click(object sender, EventArgs e)
    {
        if (dataGridViewProductos.SelectedRows.Count > 0)
        {
            // Obtener el ID del producto seleccionado
            int id = (int)dataGridViewProductos.SelectedRows[0].Cells["Id"].Value;

            // Abrir el formulario para editar el producto
            ProductosForm productosForm = new ProductosForm(id);
            productosForm.ShowDialog();
            CargarProductos(); // Recargar la lista después de editar un producto
        }
    }

    private void btnEliminar_Click(object sender, EventArgs e)
    {
        if (dataGridViewProductos.SelectedRows.Count > 0)
        {
            // Obtener el ID del producto seleccionado
            int id = (int)dataGridViewProductos.SelectedRows[0].Cells["Id"].Value;

            try
            {
                // Eliminar el producto
                productoLogic.EliminarProducto(id);
                CargarProductos(); // Recargar la lista después de eliminar un producto
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el producto: " + ex.Message);
            }
        }
    }

    private void MainForm_Load(object sender, EventArgs e)
    {

    }
    private DataGridView dataGridViewProductos;
    private Button btnAgregar;
    private Button btnEditar;
    private Button btnEliminar;
    private Button pepe;

    private void buttonAgregar2_Click(object sender, EventArgs e)
    {

    }

    private void dataGridViewProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }
}