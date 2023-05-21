using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrabajoPractico6.SegundoEjercicio {
    public partial class Inicio : System.Web.UI.Page {
        public static void ShowSnackbar(string mensaje) {
            string script = "MostrarMensaje('" + mensaje + "');";
            ScriptManager.RegisterStartupScript(HttpContext.Current.CurrentHandler as Page, typeof(Page), "MostrarMensaje", script, true);
        }
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void lbtnEliminarProdSel_Click(object sender, EventArgs e) {
            Session["ProductosSeleccionados"] = null;
            ShowSnackbar("Acción realizada exitosamente");

        }
    }
}