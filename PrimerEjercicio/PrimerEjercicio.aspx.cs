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
            var operacion = p.UpdateInDatabase();
            if(operacion.ErrorFound) {
                ShowSnackbar(operacion.Details);
            }
            gvProductos.EditIndex = -1;
            CargarDatos();

        }
        protected void gvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            gvProductos.PageIndex = e.NewPageIndex;
            CargarDatos();
        }
        protected void gvProductos_RowCreated(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.Pager) {
                TextBox txtPagerTextBox = e.Row.FindControl("gvProductsPagerPageTxtBox") as TextBox;
                if (txtPagerTextBox != null) {
                    txtPagerTextBox.Text = (gvProductos.PageIndex+1) + "";
                }
                DropDownList ddlPager = e.Row.FindControl("ddlFilasPorPaginaPagerTemplate") as DropDownList;
                if(ddlPager != null) {
                    ddlPager.SelectedValue = gvProductos.PageSize + "";
                }
            }
        }

        protected void gvProductsPagerPageTxtBox_TextChanged(object sender, EventArgs e) {
            int intendedPage = int.Parse(((TextBox)sender).Text) - 1;
            if(intendedPage <= gvProductos.PageCount -1) {
                gvProductos.PageIndex = intendedPage;
                CargarDatos();
            }
            else {
                ((TextBox)sender).Text = gvProductos.PageIndex + "";
            }
        }

        protected void ddlFilasPorPaginaPagerTemplate_SelectedIndexChanged(object sender, EventArgs e) {
            int filasPorPaginaN = int.Parse(((DropDownList)sender).SelectedValue);
            if(filasPorPaginaN > 0) {
                gvProductos.PageSize = filasPorPaginaN;
                CargarDatos();
            }
        }

        protected void gvProductos_RowDeleting(object sender, GridViewDeleteEventArgs e) {
            Producto p = new Producto();
            GridViewRow editingRow = gvProductos.Rows[e.RowIndex];
            p.SetValuesFromRow(ref editingRow);
            var operacion = p.PermanentlyDeleteFromDatabase();
            if (operacion.ErrorFound) {
                ShowSnackbar("Hubo un problema al intentar eliminar el registro. ");
            } else {
                ShowSnackbar("El registro se ha eliminado correctamente. ");
            }
            //Label1.Text = p.getSummary();
            CargarDatos();
        }
    }
}