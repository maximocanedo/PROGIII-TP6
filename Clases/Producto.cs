using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrabajoPractico6.Clases {
    public class Producto {
        private string _nombre = "", _cpu = "";
        /* Propiedades */
        public int Id { get; set; }
        public string Nombre { get { return _nombre; } set { _nombre = value.Length > 40 ? value.Substring(0, 40) : value; } }
        public string CantidadPorUnidad { get { return _cpu; } set { _cpu = value.Length > 20 ? value.Substring(0, 20) : value; } }
        public int IdProveedor { get; set; }
        public double PrecioUnitario { get; set; }
        public bool Suspendido { get; set; }
        /* Columnas */
        // Los nombres de los campos, tal como aparecen en la base de datos.
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
        /// <summary>
        /// Configura las propiedades del Producto a partir de un DataSet (Por ejemplo, si realizás una consulta SQL y la metés acá, te carga Producto con los valores de la primer fila del DataSet.
        /// </summary>
        /// <param name="data">El DataSet</param>
        /// <param name="rowIndex">El índice de la fila que querés cargar. Recomendado dejar en blanco.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Devuelve los datos del Producto en forma de DataRow (Fila de una tabla DataTable)
        /// </summary>
        /// <param name="tabla">La tabla modelo.</param>
        /// <returns>Un DataRow.</returns>
        public DataRow GetRow(DataTable tabla) {
            DataRow row = tabla.NewRow();
            row[Columns.Id] = Id;
            row[Columns.Nombre] = Nombre;
            row[Columns.IdProveedor] = IdProveedor;
            row[Columns.PrecioUnitario] = PrecioUnitario;
            return row;
        }
        /// <summary>
        /// Establece los valores de Producto a partir de un Row del EditTemplate de los GridView.
        /// Significa que cuando presionás "Editar" al lado de una fila, esta función permitirá acceder a los valores que el usuario va ingresando.
        /// </summary>
        /// <param name="editingRow"></param>
        public void SetValuesFromEditableRow(ref GridViewRow editingRow) {
            this.Id = GetIntValueFromLabel(
                row: ref editingRow,
                controlID: "ProductoEditItemTemplateView__ID",
                defaultValue: this.Id
                );
            this.Nombre = GetTextValueFromTextBox(
                row: ref editingRow,
                controlID: "ProductoEditItemTemplateView__Nombre",
                defaultValue: this.Nombre
                );
            this.CantidadPorUnidad = GetTextValueFromTextBox(
                row: ref editingRow,
                controlID: "ProductoEditItemTemplateView__CantidadPorUnidad",
                defaultValue: this.CantidadPorUnidad
                );
            this.PrecioUnitario = GetDoubleValueFromTextBox(
                row: ref editingRow,
                controlID: "ProductoEditItemTemplateView__PrecioUnitario",
                defaultValue: this.PrecioUnitario
                );
            this.IdProveedor = GetIntValueFromTextBox(
                row: ref editingRow,
                controlID: "ProductoEditItemTemplateView__IdProveedor",
                defaultValue: this.IdProveedor
                );
        }
        /// <summary>
        /// Similar al anterior, pero sólo para ItemTemplate comunes.
        /// Permite acceder a los datos de un Row en forma normal.
        /// </summary>
        /// <param name="row"></param>
        public void SetValuesFromRow(ref GridViewRow row) {
            this.Id = GetIntValueFromLabel(
                row: ref row,
                controlID: "ProductoItemTemplateView__ID",
                defaultValue: this.Id
                );
            this.Nombre = GetTextValueFromLabel(
                row: ref row,
                controlID: "ProductoItemTemplateView__Nombre",
                defaultValue: this.Nombre
                );
            this.CantidadPorUnidad = GetTextValueFromLabel(
                row: ref row,
                controlID: "ProductoItemTemplateView__CantidadPorUnidad",
                defaultValue: this.CantidadPorUnidad
                );
            this.PrecioUnitario = GetDoubleValueFromLabel(
                row: ref row,
                controlID: "ProductoItemTemplateView__PrecioUnitario",
                defaultValue: this.PrecioUnitario
                );
            this.IdProveedor = GetIntValueFromLabel(
                row: ref row,
                controlID: "ProductoItemTemplateView__IdProveedor",
                defaultValue: this.IdProveedor
                );
        }

        // NO HAGAN CASO A ESTAS FUNCIONES Get * From * (), porque son AUXILIARES para las funciones de arriba.
        // No las van a tener que usar.
        private int GetIntValueFromLabel(ref GridViewRow row, string controlID, int defaultValue) {
            var control = (Label)row.FindControl(controlID);
            return (control != null && int.TryParse(control.Text, out int value))
                ? value
                : defaultValue;
        }
        private string GetTextValueFromLabel(ref GridViewRow row, string controlID, string defaultValue) {
            var control = (Label)row.FindControl(controlID);
            return control?.Text ?? defaultValue ?? "";
        }
        private double GetDoubleValueFromLabel(ref GridViewRow row, string controlID, double defaultValue) {
            var control = (Label)row.FindControl(controlID);
            return (control != null && double.TryParse(control.Text, out double value))
                ? value
                : defaultValue;
        }

        private int GetIntValueFromTextBox(ref GridViewRow row, string controlID, int defaultValue) {
            var control = (TextBox)row.FindControl(controlID);
            return (control != null && int.TryParse(control.Text, out int value))
                ? value
                : defaultValue;
        }
        private string GetTextValueFromTextBox(ref GridViewRow row, string controlID, string defaultValue) {
            var control = (TextBox)row.FindControl(controlID);
            return control?.Text ?? defaultValue ?? "";
        }
        private double GetDoubleValueFromTextBox(ref GridViewRow row, string controlID, double defaultValue) {
            var control = (TextBox)row.FindControl(controlID);
            return (control != null && double.TryParse(control.Text, out double value))
                ? value
                : defaultValue;
        }


        /// <summary>
        /// Configura PRoducto con los valores de un registro en la base de datos que tenga un ID que coincida con el buscado.
        /// </summary>
        /// <param name="IdABuscar">ID a buscar.</param>
        /// <returns>True si el ID existe y se logró configurar; False en otro caso.</returns>
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
        // Realiza un INSERT en la base de datos Neptuno, tabla Productos con los datos de este objeto Producto.
        // Devuelve un Response. Como es un comando INSERT, las propiedades que les sirven son Response.AffectedRows (Filas afectadas)
        // ... Y Response.ErrorFound (Error al intentar conectar)
        public Response InsertIntoDatabase() {
            Connection con = new Connection(Connection.Database.Neptuno);
            return con.Response.ErrorFound
                ? con.Response
                : con.RunTransaction(
                    query: $"INSERT INTO [dbo].[Productos] ([{Columns.Nombre}], [{Columns.CantidadPorUnidad}], [{Columns.PrecioUnitario}], [{Columns.IdProveedor}]) " +
                    $"VALUES ( @nombre, @cantidadporunidad, @preciounitario, @idproveedor)",
                    parameters: new Dictionary<string, object> {
                        { "@nombre", this.Nombre },
                        { "@cantidadporunidad", this.CantidadPorUnidad },
                        { "@preciounitario", this.PrecioUnitario },
                        { "@idproveedor", this.IdProveedor }
                    });
        }

        // Devuelve un string simple para debuggear rápido y ver si todo está en órden.
        public string getSummary() {
            return $"Id: {Id}, Nombre: '{Nombre}', Cantidad Por Unidad: '{CantidadPorUnidad}', Precio Unitario: ${PrecioUnitario}";
        }

        // Realiza un UPDATE del Producto actual en la base de datos Neptuno, tabla Productos.
        // Es una transacción, por lo que los valores que van a necesitar son Response.AffectedRows (Que deberá ser 1), y Response.ErrorFound.
        public Response UpdateInDatabase() {
            Connection con = new Connection(Connection.Database.Neptuno);
            return con.Response.ErrorFound
                ? con.Response
                : con.RunTransaction(
                    query: $"UPDATE [dbo].[Productos] SET [{Columns.Nombre}] = @val1, [{Columns.CantidadPorUnidad}] = @val2, [{Columns.PrecioUnitario}] = @val3 WHERE [{Columns.Id}] = @id",
                    parameters: new Dictionary<string, object> {
                        { "@val1", Nombre },
                        { "@val2", CantidadPorUnidad },
                        { "@val3", PrecioUnitario },
                        { "@id", Id }
                    });
        }

        // Esta función NO ELIMINA un registro de la base de datos. Le cambia la propiedad 'Suspendido' a FALSE.
        public Response DeleteFromDatabase() {
            Connection con = new Connection(Connection.Database.Neptuno);
            return con.Response.ErrorFound
                ? con.Response
                : con.RunTransaction(
                    query: $"UPDATE [dbo].[Productos] SET [{Columns.Suspendido}] = @value WHERE [{Columns.Id}] = @id",
                    parameters: new Dictionary<string, object> {
                        { "@value", true },
                        { "@id", Id }
                    });
        }

        // Esta función SÍ ELIMINA PERMANENTEMENTE un registro de la base de datos. Fíjense que hace DELETE.
        // Valores que necesitarán del Response que devuelve esta función: Response.AffectedRows, y Response.ErrorFound.
        public Response PermanentlyDeleteFromDatabase() {
            Connection con = new Connection(Connection.Database.Neptuno);
            return con.Response.ErrorFound
                ? con.Response
                : con.RunTransaction(
                    query: $"DELETE FROM [dbo].[Productos] WHERE [{Columns.Id}] = @id",
                    parameters: new Dictionary<string, object> {
                        { "@id", this.Id }
                    });
        }
        /* Métodos estáticos */
        // Estos métodos estáticos no requieren constructor. Podés llamarlos simplemente así: Producto.GetAllProducts();
        // Por ejemplo. Response res = Producto.GetAllProducts();
        // Esta función realiza un SELECT de todos los productos con todas las columnas.
        // El valor que les importa de lo que devuelve es Response.ObjectReturn que será un DataSet con los productos.
        // 
        public static Response GetAllProducts() {
            Connection con = new Connection(Connection.Database.Neptuno);
            return con.Response.ErrorFound
                ? con.Response
                : con.FetchData(
                    query: "SELECT * FROM [dbo].[Productos]"
                    );
        }
        // Función ATAJO para el primer ejercicio.
        public static Response GetProductsForFirstTask() {
            Connection con = new Connection(Connection.Database.Neptuno);
            return con.Response.ErrorFound
                ? con.Response
                : con.FetchData(
                    query: $"SELECT [{Columns.Id}], [{Columns.Nombre}], [{Columns.CantidadPorUnidad}], [{Columns.PrecioUnitario}] FROM [dbo].[Productos]"
                    );
        }
        // Función ATAJO para el segundo ejercicio.
        public static Response GetProductsForSecondTask() {
            Connection con = new Connection(Connection.Database.Neptuno);
            return con.Response.ErrorFound
                ? con.Response
                : con.FetchData(
                    query: $"SELECT [{Columns.Id}], [{Columns.Nombre}], [{Columns.IdProveedor}], [{Columns.PrecioUnitario}] FROM [dbo].[Productos]"
                    );
        }
    }
}