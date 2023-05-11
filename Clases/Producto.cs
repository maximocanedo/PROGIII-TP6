using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
/*
* ID PRODUCTO
NOMBRE PRODUCTO
CANTIDAD POR UNIDAD (NULLABLE)
IDPROVEEDOR (NULLABLE)
PRECIO UNIDAD
*/

namespace TrabajoPractico6.Clases {
    public class Producto {
        /* Propiedades */
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CantidadPorUnidad { get; set; }
        public int IdProveedor { get; set; }
        public double PrecioUnitario { get; set; }
        public bool Suspendido { get; set; }
        /* Columnas */
        public static class Columns {
            public static string Id { get { return "IdProducto";  } }
            public static string Nombre { get { return "NombreProducto";  } }
            public static string CantidadPorUnidad { get { return "CantidadPorUnidad";  } }
            public static string IdProveedor { get { return "IdProveedor";  } }
            public static string PrecioUnitario { get { return "PrecioUnidad";  } }
            public static string Suspendido { get { return "Suspendido"; } }
        }
        /* Constructores */
        public Producto() {}
        /* Métodos */
        public bool SetValuesFromRow(object row) { // Prototipo
            return false;
        }
        public void SetValuesFromEditableRow(ref GridViewRow editingRow) {
            this.Id = GetIntValueFromControl(ref editingRow, "gvProductsEditTemplateID", this.Id);
            this.Nombre = GetTextValueFromControl(ref editingRow, "gvProductsEditTemplateNombre", this.Nombre);
            this.CantidadPorUnidad = GetTextValueFromControl(ref editingRow, "gvProductsEditTemplateCantidadPorUnidad", this.CantidadPorUnidad);
            this.PrecioUnitario = GetDoubleValueFromControl(ref editingRow, "gvProductsEditTemplatePrecioUnitario", this.PrecioUnitario);
            this.IdProveedor = GetIntValueFromControl(ref editingRow, "gvProductsEditTemplateIdProveedor", this.IdProveedor);
        }

        private int GetIntValueFromControl(ref GridViewRow row, string controlID, int defaultValue) {
            var control = (Label)row.FindControl(controlID);
            if (control != null && int.TryParse(control.Text, out int value)) {
                PrimerEjercicio.PrimerEjercicio.ShowSnackbar("Int value received: " + value);
                return value;
            }
            return defaultValue;
        }

        private string GetTextValueFromControl(ref GridViewRow row, string controlID, string defaultValue) {
            var control = (TextBox)row.FindControl(controlID);
            return control?.Text ?? defaultValue;
        }

        private double GetDoubleValueFromControl(ref GridViewRow row, string controlID, double defaultValue) {
            var control = (TextBox)row.FindControl(controlID);
            if (control != null && double.TryParse(control.Text, out double value)) {
                return value;
            }
            return defaultValue;
        }

        public bool GetById(int IdABuscar) {
            return false;
        }
        public bool InsertIntoDatabase() {
            return false;
        }
        public string getSummary() {
            return $"Id: {Id}, Nombre: '{Nombre}', Cantidad Por Unidad: '{CantidadPorUnidad}', Precio Unitario: ${PrecioUnitario}";
        }
        public Response UpdateInDatabase() {
            Connection con = new Connection(Connection.Database.Neptuno);
            return con.Response.ErrorFound
                ? con.Response
                : con.RunTransaction(
                    query: $"UPDATE [dbo].[Productos] SET {Columns.Nombre} = @val1, {Columns.CantidadPorUnidad} = @val2, {Columns.PrecioUnitario} = @val3 WHERE {Columns.Id} = @id",
                    parameters: new Dictionary<string, object> {
                        { "@val1", Nombre },
                        { "@val2", CantidadPorUnidad },
                        { "@val3", PrecioUnitario },
                        { "@id", Id }
                    });
        }
        public Response DeleteFromDatabase() {
            Connection con = new Connection(Connection.Database.Neptuno);
            return con.Response.ErrorFound
                ? con.Response
                : con.RunTransaction(
                    query: $"UPDATE [dbo].[Productos] SET {Columns.Suspendido} = @value WHERE {Columns.Id} = @id",
                    parameters: new Dictionary<string, object> {
                        { "@value", true },
                        { "@id", Id }
                    });
        }
        public Response PermanentlyDeleteFromDatabase() {
            Connection con = new Connection(Connection.Database.Neptuno);
            return con.Response.ErrorFound
                ? con.Response
                : con.RunTransaction(
                    query: $"DELETE FROM [dbo].[Productos] WHERE {Columns.Id} = @id",
                    parameters: new Dictionary<string, object> {
                        { "@id", this.Id }
                    });
        }
        /* Métodos estáticos */
        public static Response GetAllProducts() {
            Connection con = new Connection(Connection.Database.Neptuno);
            return con.Response.ErrorFound
                ? con.Response
                : con.FetchData(
                    query: "SELECT * FROM [dbo].[Productos]"
                    );
        }
        public static Response GetProductsForFirstTask() {
            Connection con = new Connection(Connection.Database.Neptuno);
            return con.Response.ErrorFound
                ? con.Response
                : con.FetchData(
                    query: "SELECT [IdProducto], [NombreProducto], [CantidadPorUnidad], [PrecioUnidad] FROM [dbo].[Productos]"
                    );
        }
        public static Response GetProductsForSecondTask() {
            Connection con = new Connection(Connection.Database.Neptuno);
            return con.Response.ErrorFound
                ? con.Response
                : con.FetchData(
                    query: "SELECT [IdProducto], [NombreProducto], [CantidadPorUnidad], [PrecioUnidad] FROM [dbo].[Productos]"
                    );
        }
    }
}