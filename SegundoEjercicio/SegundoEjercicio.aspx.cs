using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrabajoPractico6.Clases;

namespace TrabajoPractico6.SegundoEjercicio {
    public partial class SegundoEjercicio : System.Web.UI.Page {
        public void ShowSnackbar(string mensaje) {
            string script = $"ShowSnackbar('{mensaje}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "ShowSnackbar", script, true);
        }
        protected void Page_Load(object sender, EventArgs e) {
        }
        public void BorrarProductosSeleccionados() {
            if(Session[SelectedProductsTable.Key] == null) {
                ShowSnackbar("No había productos seleccionados que borrar.");
            } else {
                Session[SelectedProductsTable.Key] = null;
                ShowSnackbar("Se borraron con éxito los productos seleccionados.");
            }
        }

        protected void btnEliminarProductosSeleccionados_Click(object sender, EventArgs e) {
            BorrarProductosSeleccionados();
        }
    }
}