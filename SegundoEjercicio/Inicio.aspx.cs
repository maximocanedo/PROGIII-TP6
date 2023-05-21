using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrabajoPractico6.SegundoEjercicio {
    public partial class Inicio : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void lbtnEliminarProdSel_Click(object sender, EventArgs e)
        {
            Session["ProductosSeleccionados"] = null;
            lbl_Mensaje.Text = "Los productos seleccionados se han eliminado correctamente";
            
        }
    }
}