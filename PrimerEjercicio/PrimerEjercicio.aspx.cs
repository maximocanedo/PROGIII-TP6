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

            }
        }

    }
}