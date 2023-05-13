using System;
using System.Collections.Generic;
using System.Data;
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
            public static string Id { get { return "IdProducto"; } }
            public static string Nombre { get { return "NombreProducto"; } }
            public static string CantidadPorUnidad { get { return "CantidadPorUnidad"; } }
            public static string IdProveedor { get { return "IdProveedor"; } }
            public static string PrecioUnitario { get { return "PrecioUnidad"; } }
            public static string Suspendido { get { return "Suspendido"; } }
        }
        /* Constructores */
        public Producto() { }
        /* Métodos */
        public bool SetValuesFromDataSet(DataSet data, int rowIndex = 0) {
            DataTable source = data.Tables[0];
            DataRow row = source.Rows[rowIndex];
            Id = (int)(row[Columns.Id] ?? Id);
            Nombre = (string)(row[Columns.Nombre] ?? Nombre);
            CantidadPorUnidad = (string)(row[Columns.CantidadPorUnidad] ?? CantidadPorUnidad);
            IdProveedor = (int)(row[Columns.IdProveedor] ?? IdProveedor);
            PrecioUnitario = (double)(row[Columns.PrecioUnitario] ?? PrecioUnitario);
            Suspendido = (bool)(row[Columns.Suspendido] ?? Suspendido);
            return (source != null && row != null);
        }
        public void SetValuesFromEditableRow(ref GridViewRow editingRow) {
            this.Id = GetIntValueFromLabel(ref editingRow, "gvProductsEditTemplateID", this.Id);
            this.Nombre = GetTextValueFromTextBox(ref editingRow, "gvProductsEditTemplateNombre", this.Nombre);
            this.CantidadPorUnidad = GetTextValueFromTextBox(ref editingRow, "gvProductsEditTemplateCantidadPorUnidad", this.CantidadPorUnidad);
            this.PrecioUnitario = GetDoubleValueFromTextBox(ref editingRow, "gvProductsEditTemplatePrecioUnitario", this.PrecioUnitario);
            this.IdProveedor = GetIntValueFromTextBox(ref editingRow, "gvProductsEditTemplateIdProveedor", this.IdProveedor);
        }
        public void SetValuesFromRow(ref GridViewRow row) {
            this.Id = GetIntValueFromLabel(ref row, "gvProductosTemplateID", this.Id);
            this.Nombre = GetTextValueFromLabel(ref row, "gvProductosTemplateNombre", this.Nombre);
            this.CantidadPorUnidad = GetTextValueFromLabel(ref row, "gvProductosTemplateCantidadPorUnidad", this.CantidadPorUnidad);
            this.PrecioUnitario = GetDoubleValueFromLabel(ref row, "gvProductosTemplatePrecioUnitario", this.PrecioUnitario);
            this.IdProveedor = GetIntValueFromLabel(ref row, "gvProductsTemplateIdProveedor", this.IdProveedor);
        }

        private int GetIntValueFromLabel(ref GridViewRow row, string controlID, int defaultValue) {
            var control = (Label)row.FindControl(controlID);
            if (control != null && int.TryParse(control.Text, out int value)) {
                return value;
            }
            return defaultValue;
        }
        private string GetTextValueFromLabel(ref GridViewRow row, string controlID, string defaultValue) {
            var control = (Label)row.FindControl(controlID);
            return control?.Text ?? defaultValue;
        }
        private double GetDoubleValueFromLabel(ref GridViewRow row, string controlID, double defaultValue) {
            var control = (Label)row.FindControl(controlID);
            if (control != null && double.TryParse(control.Text, out double value)) {
                return value;
            }
            return defaultValue;
        }

        private int GetIntValueFromTextBox(ref GridViewRow row, string controlID, int defaultValue) {
            var control = (TextBox)row.FindControl(controlID);
            if (control != null && int.TryParse(control.Text, out int value)) {
                return value;
            }
            return defaultValue;
        }
        private string GetTextValueFromTextBox(ref GridViewRow row, string controlID, string defaultValue) {
            var control = (TextBox)row.FindControl(controlID);
            return control?.Text ?? defaultValue;
        }
        private double GetDoubleValueFromTextBox(ref GridViewRow row, string controlID, double defaultValue) {
            var control = (TextBox)row.FindControl(controlID);
            if (control != null && double.TryParse(control.Text, out double value)) {
                return value;
            }
            return defaultValue;
        }

        public bool GetById(int IdABuscar) {
            Connection con = new Connection(Connection.Database.Neptuno);
            if (con.Response.ErrorFound) {
                Response res = con.FetchData(
                        query: $"SELECT * FROM [dbo].[Productos] WHERE {Columns.Id} = @id",
                        parameters: new Dictionary<string, object> {
                            { "@id", IdABuscar }
                        }
                    );
                if (!res.ErrorFound && res.ObjectReturned != null) {
                    DataSet db = (DataSet)res.ObjectReturned;
                    return SetValuesFromDataSet(db, 0);
                }
            }
            return false;
        }
        public Response InsertIntoDatabase() {
            Connection con = new Connection(Connection.Database.Neptuno);
            return con.Response.ErrorFound
                ? con.Response
                : con.RunTransaction(
                    query: $"INSERT INTO [dbo].[Productos] ({Columns.Nombre}, {Columns.CantidadPorUnidad}, {Columns.PrecioUnitario}, {Columns.IdProveedor}) " +
                    $"VALUES ( @nombre, @cantidadporunidad, @preciounitario, @idproveedor)",
                    parameters: new Dictionary<string, object> {
                        { "@nombre", this.Nombre },
                        { "@cantidadporunidad", this.CantidadPorUnidad },
                        { "@preciounitario", this.PrecioUnitario },
                        { "@idproveedor", this.IdProveedor }
                    });
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