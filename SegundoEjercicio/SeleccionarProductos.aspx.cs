using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrabajoPractico6.Clases;
using System.Data;

namespace TrabajoPractico6.SegundoEjercicio {
    public partial class SeleccionarProductos : System.Web.UI.Page {
        protected const string TablaProductosSeleccionados = "ProductosSeleccionados";
        protected void cargarGridView() {
            Response productos = Producto.GetProductsForSecondTask();
            if (productos.ObjectReturned != null) {
                gvProductos.DataSource = productos.ObjectReturned;
                gvProductos.DataBind();
            }
        }
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                cargarGridView();

            }
        }
        protected void gvProductos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e) {
            string s_IDProducto = ((Label)gvProductos.Rows[e.NewSelectedIndex].FindControl("lbl_IDProducto")).Text;
            string s_NombreProducto = ((Label)gvProductos.Rows[e.NewSelectedIndex].FindControl("lbl_NombreProducto")).Text;
            string s_IDProveedor = ((Label)gvProductos.Rows[e.NewSelectedIndex].FindControl("lbl_IDProveedor")).Text;
            string s_PrecioUnitario = ((Label)gvProductos.Rows[e.NewSelectedIndex].FindControl("lbl_PrecioUnitario")).Text;

            if (Session[TablaProductosSeleccionados] == null) {
                //INICIALIZACION DEL DATATABLE Y SESSION
                DataTable dt = new DataTable();
                dt.Columns.Add(Producto.Columns.Id, typeof(string));
                dt.Columns.Add(Producto.Columns.Nombre, typeof(string));
                dt.Columns.Add(Producto.Columns.IdProveedor, typeof(string));
                dt.Columns.Add(Producto.Columns.PrecioUnitario, typeof(string));
                Session[TablaProductosSeleccionados] = dt;
            }

            DataTable dtProductosSel = (DataTable)Session[TablaProductosSeleccionados];

            //VERIFICACION DE PRODUCTO REPETIDO
            bool productoExistente = dtProductosSel.AsEnumerable()
                .Any(row => row.Field<string>(Producto.Columns.Id) == s_IDProducto);

            //SI NO SE REPITE, SE AGREGA
            if (!productoExistente) {
                DataRow newRow = dtProductosSel.NewRow();
                newRow[Producto.Columns.Id] = s_IDProducto;
                newRow[Producto.Columns.Nombre] = s_NombreProducto;
                newRow[Producto.Columns.IdProveedor] = s_IDProveedor;
                newRow[Producto.Columns.PrecioUnitario] = s_PrecioUnitario;
                dtProductosSel.Rows.Add(newRow);

                //CARGAR TABLA ACTUALIZADA A LA VARIABLE SESSION
                Session[TablaProductosSeleccionados] = dtProductosSel;
                lblProductosAgregados.Text += "</br>" + "-" + s_NombreProducto;
            }
        }

        protected void gvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            gvProductos.PageIndex = e.NewPageIndex;
            cargarGridView();
        }
    }
}