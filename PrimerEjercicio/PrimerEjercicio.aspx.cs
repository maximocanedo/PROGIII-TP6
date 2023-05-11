using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrabajoPractico6.Clases;

namespace TrabajoPractico6.PrimerEjercicio {

    public partial class PrimerEjercicio : System.Web.UI.Page {
        public static void ShowSnackbar(string mensaje) {
            string script = "MostrarMensaje('" + mensaje + "');";
            ScriptManager.RegisterStartupScript(HttpContext.Current.CurrentHandler as Page, typeof(Page), "MostrarMensaje", script, true);
        }
        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack) {
                CargarDatos();
            }
        }

        protected void CargarDatos() {
            Response datos = Producto.GetProductsForFirstTask();
            if (datos.ObjectReturned != null) {
                gvProductos.DataSource = datos.ObjectReturned;
                gvProductos.DataBind();
            }
        }

        protected void gvProductos_RowEditing(object sender, GridViewEditEventArgs e) {
            //Producto p = new Producto();
            //GridViewRow i = gvProductos.Rows[e.NewEditIndex];
            //p.SetValuesFromEditableRow();
            gvProductos.EditIndex = e.NewEditIndex;
            CargarDatos();
        }

        protected void gvProductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) {
            gvProductos.EditIndex = -1;
            CargarDatos();
        }

        protected void gvProductos_RowUpdating(object sender, GridViewUpdateEventArgs e) {
            Producto p = new Producto();
            GridViewRow editingRow = gvProductos.Rows[e.RowIndex];
            p.SetValuesFromEditableRow(ref editingRow);
            Label1.Text = p.getSummary();
            var operacion = p.UpdateInDatabase();
            if(operacion.ErrorFound) {
                ShowSnackbar(operacion.Details);
                Label1.Text += operacion.Details;
            }
            gvProductos.EditIndex = -1;
            CargarDatos();

        }
    }
}