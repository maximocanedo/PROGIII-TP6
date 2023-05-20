using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrabajoPractico6.Clases;
using System.Data;

namespace TrabajoPractico6.SegundoEjercicio {
    public partial class SeleccionarProductos : System.Web.UI.Page {
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

        /*---------------------------FUNCION DE OLI-----------------------------
        protected bool verificarEnLista(ListItemCollection lista, string nombreProd)
        {
            foreach (ListItem nombre in lista)
            {
                if (nombre.Text == nombreProd) // Se comparan los nombres de la lista con el nombre del nuevo producto seleccionado. Si el nombre ya se encuentra en la lista, la función retorna true.
                {
                    return true;
                }
            }
            return false; // Caso contrario (si no se repite), retorna false.
        }
        *///----------------------------FUNCION DE OLI----------------------

        protected void gvProductos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
      
            string s_IDProducto = ((Label)gvProductos.Rows[e.NewSelectedIndex].FindControl("lbl_IDProducto")).Text;
            string s_NombreProducto = ((Label)gvProductos.Rows[e.NewSelectedIndex].FindControl("lbl_NombreProducto")).Text;
            string s_IDProveedor = ((Label)gvProductos.Rows[e.NewSelectedIndex].FindControl("lbl_IDProveedor")).Text;
            string s_PrecioUnitario = ((Label)gvProductos.Rows[e.NewSelectedIndex].FindControl("lbl_PrecioUnitario")).Text;

            
            if(Session["ProductosSeleccionados"]==null)//SI LA VARIABLE SESSION NO EXISTE, SE CREA
            {
                //INICIALIZACION DEL DATATABLE Y SESSION
                DataTable dt = new DataTable();
                dt.Columns.Add("IDProducto", typeof(string));
                dt.Columns.Add("NombreProducto", typeof(string));
                dt.Columns.Add("IDProveedor", typeof(string));
                dt.Columns.Add("PrecioUnitario", typeof(string));
                Session["ProductosSeleccionados"] = dt;
            }
            DataTable dtProductosSel = (DataTable)Session["ProductosSeleccionados"];
            //VERIFICACION DE PRODUCTO REPETIDO
            bool productoExistente = false;
            foreach (DataRow row in dtProductosSel.Rows)
             {
               if (row["IDProducto"].ToString() == s_IDProducto)
               {
                 productoExistente = true;
                 break;
               }
             }
            //SI NO SE REPITE, SE AGREGA
            if (!productoExistente)
            {
               DataRow newRow = dtProductosSel.NewRow();
               newRow["IDProducto"] = s_IDProducto;
               newRow["NombreProducto"] = s_NombreProducto;
               newRow["IDProveedor"] = s_IDProveedor;
               newRow["PrecioUnitario"] = s_PrecioUnitario;
               dtProductosSel.Rows.Add(newRow);

                //CARGAR TABLA ACTUALIZADA A LA VARIABLE SESSION
                Session["ProductosSeleccionados"] = dtProductosSel;
                lblProductosAgregados.Text += "</br>" + "-" + s_NombreProducto;
            }
            
            
            //------------------------------------------------------CODIGO DE OLI------------------------------------
            /*
            // Voy listando en el Label los productos que el usuario seleccione:
            ListItemCollection lista = new ListItemCollection(); 
            if (Session["NombresProductosSel"] == null)
            {
                Session["NombresProductosSel"] = new ListItemCollection();
                lista = (ListItemCollection)Session["NombresProductosSel"];

                lblProductosAgregados.Text += "</br>" + "-" + s_NombreProducto; // Con la etiqueta </br> se crea un salto de línea, listando todos los productos que el usuario agregue.
                lista.Add(s_NombreProducto); // agrego el nombre del producto a la lista, para que la próxima vez que el usuario haga una selección, comparar los nombres de la lista con el nombre del nuevo producto.
                guardarProductos(s_IDProducto, s_NombreProducto, s_IDProveedor, s_PrecioUnitario);
            }
            if(!verificarEnLista(lista, s_NombreProducto)) // si la función devuelve false (no se repite el nombre en la lista), entonces:
            {
                lblProductosAgregados.Text += "</br>" + "-" + s_NombreProducto;
                Session["NombresProductosSel"] = s_NombreProducto;
                guardarProductos(s_IDProducto, s_NombreProducto, s_IDProveedor, s_PrecioUnitario);
            }
            */
            //------------------------------------------------------------------------------------------------------
        }

        protected void gvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProductos.PageIndex = e.NewPageIndex;
            cargarGridView();
        }

        /*-------------------------------FUNCION DE OLI-----------------------------------------------------
        protected void guardarProductos(string IDProducto_Sel, string NombreProducto_Sel, string IDProveedor_Sel, string PrecioUnitario_Sel)
        {
            DataTable dt;
            Producto producto = new Producto()
            {
                Id = Convert.ToInt32(IDProducto_Sel),
                Nombre = NombreProducto_Sel,
                IdProveedor = Convert.ToInt32(IDProveedor_Sel),
                PrecioUnitario = Convert.ToDouble(PrecioUnitario_Sel)
            };
            if (Session["Tabla"] == null)
            {
                Session["Tabla"] = new DataTable();
                dt = (DataTable)Session["Tabla"];

                DataColumn dc = new DataColumn(Producto.Columns.Id, System.Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn(Producto.Columns.Nombre, System.Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn(Producto.Columns.IdProveedor, System.Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn(Producto.Columns.PrecioUnitario, System.Type.GetType("System.String"));
                dt.Columns.Add(dc);
            }
            dt = (DataTable)Session["Tabla"]; 
            dt.Rows.Add(producto.GetRow(dt));
        }
        *///---------------------------------------------------------------------------------------------------------
    }
}