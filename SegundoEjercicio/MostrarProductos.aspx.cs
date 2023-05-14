using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrabajoPractico6.Clases;

namespace TrabajoPractico6.SegundoEjercicio {
    public partial class MostrarProductos : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (Session[SelectedProductsTable.Key] == null) {
                    // Mostrar cuadro de error.
                    nopro.Style.Add("Display", "flex");
                } else {
                    gvej2.DataSource = ((SelectedProductsTable)Session[SelectedProductsTable.Key]).Table;
                    gvej2.DataBind();
                }
            }
        }
    }
}