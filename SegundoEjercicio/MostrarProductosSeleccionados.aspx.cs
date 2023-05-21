using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TrabajoPractico6.SegundoEjercicio {
    public partial class MostrarProductosSeleccionados : System.Web.UI.Page {

        protected void mostrarProductosSeleccionados()
        {
            DataTable dt = (DataTable)Session["ProductosSeleccionados"];
            gvProductosSeleccionados.DataSource = dt;
            gvProductosSeleccionados.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack)
            {
                mostrarProductosSeleccionados();
            }
        }
    }
}