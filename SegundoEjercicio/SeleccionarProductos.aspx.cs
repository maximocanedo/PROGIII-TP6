using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrabajoPractico6.Clases;

namespace TrabajoPractico6.SegundoEjercicio {
    public partial class SeleccionarProductos : System.Web.UI.Page {
        public void ShowSnackbar(string mensaje) {
            string script = $"ShowSnackbar('{mensaje}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "ShowSnackbar", script, true);
        }
        SelectedProductsTable tabla;
        protected void Page_Load(object sender, EventArgs e) {
            bool primeraCarga = !IsPostBack && CargarDatos();
            if(!IsPostBack) {
                if(Session[SelectedProductsTable.Key] == null) {
                    Session[SelectedProductsTable.Key] = new SelectedProductsTable();
                }
            }
        }
        protected bool CargarDatos() {
            Response datos = Producto.GetProductsForSecondTask();
            if (datos.ObjectReturned != null) {
                gvej2.DataSource = datos.ObjectReturned;
                gvej2.DataBind();
            }
            return true;
        }

        protected void gvej2_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            gvej2.PageIndex = e.NewPageIndex;
            CargarDatos();
        }

        protected void gvej2_RowCreated(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.Pager) {
                TextBox txtPagerTextBox = e.Row.FindControl("gvej2PagerPageTxtBox") as TextBox;
                if (txtPagerTextBox != null) {
                    txtPagerTextBox.Text = (gvej2.PageIndex + 1) + "";
                }
                DropDownList ddlPager = e.Row.FindControl("ddlFilasPorPaginaPagerTemplate") as DropDownList;
                if (ddlPager != null) {
                    ddlPager.SelectedValue = gvej2.PageSize + "";
                }
            }
        }
        protected void gvProductsPagerPageTxtBox_TextChanged(object sender, EventArgs e) {
            int intendedPage = int.Parse(((TextBox)sender).Text) - 1;
            if (intendedPage <= gvej2.PageCount - 1) {
                gvej2.PageIndex = intendedPage;
                CargarDatos();
            }
            else {
                ((TextBox)sender).Text = gvej2.PageIndex + "";
            }
        }

        protected void ddlFilasPorPaginaPagerTemplate_SelectedIndexChanged(object sender, EventArgs e) {
            int filasPorPaginaN = int.Parse(((DropDownList)sender).SelectedValue);
            if (filasPorPaginaN > 0) {
                gvej2.PageSize = filasPorPaginaN;
                CargarDatos();
            }
        }

        protected void gvej2_SelectedIndexChanging(object sender, GridViewSelectEventArgs e) {
            Producto productoSeleccionado = new Producto();
            GridViewRow row = gvej2.Rows[e.NewSelectedIndex];
            row.CssClass = "__selected";
            productoSeleccionado.SetValuesFromRow(ref row);
            bool seAgrego = ((SelectedProductsTable)Session[SelectedProductsTable.Key]).AddRow(productoSeleccionado);
            ShowSnackbar(seAgrego
                ? $"Producto agregado: {productoSeleccionado.Nombre}. "
                : "El producto ya existe. ");
        }
    }
}