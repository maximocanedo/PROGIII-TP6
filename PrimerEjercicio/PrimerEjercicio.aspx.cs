﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrabajoPractico6.Clases;
using System.Data;

namespace TrabajoPractico6.PrimerEjercicio {
    public partial class PrimerEjercicio : System.Web.UI.Page {
        public static void ShowSnackbar(string mensaje) {
            string script = "MostrarMensaje('" + mensaje + "');";
            ScriptManager.RegisterStartupScript(HttpContext.Current.CurrentHandler as Page, typeof(Page), "MostrarMensaje", script, true);
        }
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                CargarGridview();

            }

        }
        public void CargarGridview() {
            Response res = Producto.GetProductsForFirstTask();
            if (res.ErrorFound) {
                ShowSnackbar("Error. " + res.Details);
            }
            DataSet productos = (DataSet)res.ObjectReturned;
            GrdProducto.DataSource = productos;
            GrdProducto.DataBind();
        }

        protected void GrdProducto_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            GrdProducto.PageIndex = e.NewPageIndex;
            CargarGridview();
        }

        protected void GrdProducto_RowDeleting(object sender, GridViewDeleteEventArgs e) {
            string S_ID = ((Label)GrdProducto.Rows[e.RowIndex].FindControl("LBL_ID")).Text;
            Producto pro = new Producto() {
                Id = Convert.ToInt32(S_ID)
            };
            Response resultado = pro.PermanentlyDeleteFromDatabase();
            ShowSnackbar(resultado.ErrorFound
                    ? $"Error al intentar eliminar. {resultado.Details}"
                    : "Se eliminó correctamente el registro. "
                );
            CargarGridview();
        }

        protected void GrdProducto_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) {
            GrdProducto.EditIndex = -1;
            CargarGridview();
        }

        protected void GrdProducto_RowEditing(object sender, GridViewEditEventArgs e) {
            GrdProducto.EditIndex = e.NewEditIndex;
            CargarGridview();
        }

        protected void GrdProducto_RowUpdating(object sender, GridViewUpdateEventArgs e) {
            string s_IDProducto = ((Label)GrdProducto.Rows[e.RowIndex].FindControl("LB_ID")).Text;
            string s_NombreProducto = ((TextBox)GrdProducto.Rows[e.RowIndex].FindControl("TB_Nombre")).Text;
            string s_Unidades = ((TextBox)GrdProducto.Rows[e.RowIndex].FindControl("TB_Cantidad")).Text;
            string s_Precio = ((TextBox)GrdProducto.Rows[e.RowIndex].FindControl("TB_Precio")).Text;

            Producto pro = new Producto() {
                Id = Convert.ToInt32(s_IDProducto),
                Nombre = s_NombreProducto,
                CantidadPorUnidad = s_Unidades,
                PrecioUnitario = Convert.ToDouble(s_Precio)
            };

            Response operacion = pro.UpdateInDatabase();
            ShowSnackbar(operacion.ErrorFound
                    ? $"Hubo un error al intentar actualizar los datos. {operacion.Details}"
                    : "Se actualizó correctamente el registro. "
                );

            GrdProducto.EditIndex = -1;
            CargarGridview();
        }

    }
}



