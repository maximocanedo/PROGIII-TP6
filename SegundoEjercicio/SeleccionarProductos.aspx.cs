using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrabajoPractico6.Clases;
using System.Data;

namespace TrabajoPractico6.SegundoEjercicio {

    // Clase auxiliar para contar las selecciones.
    public class Contador
    {
        // propiedad.
        public int contador { get; set; }
       
        // constructor.
        public Contador(int c=0) { contador = c; }

        // set y get:
        public void setContador(int c) { contador = c; }
        public int getContador() { return contador; }
    };

    public partial class SeleccionarProductos : System.Web.UI.Page {

        // Variables globales:
        Contador contador = new Contador();
        string aux;

        protected void cargarGridView()
        {
            Response productos = Producto.GetProductsForSecondTask();
            if(productos.ObjectReturned != null)
            {
                gvProductos.DataSource = productos.ObjectReturned;
                gvProductos.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack)
            {
                cargarGridView();
            }
        }

        protected void gvProductos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string s_NombreProducto = ((Label)gvProductos.Rows[e.NewSelectedIndex].FindControl("lbl_NombreProducto")).Text;
            if (contador.getContador() == 0)
            {
                lblProductosAgregados.Text += "</br>" + "-" + s_NombreProducto; // Con la etiqueta </br> se crea un salto de línea, listando todos los productos que el usuario agregue.
                aux = s_NombreProducto; // guardo el nombre del producto, para que la próxima vez que el usuario haga una selección, se compare el nuevo producto con aux.
                                               // Si es el mismo, no se vuelve a listar.
                contador.setContador(1);
            } else if(contador.getContador() >= 1)
            {
                if(s_NombreProducto != aux)
                {
                    lblProductosAgregados.Text += "</br>" + "-" + s_NombreProducto;
                }   
            }
        }

        protected void gvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProductos.PageIndex = e.NewPageIndex;
            cargarGridView();
        }

        protected void guardarProductos()
        {

        }
    }
}