using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace TrabajoPractico6.Clases {
    public class SelectedProductsTable {
        public DataTable Table { get; set; }
        public static string Key { get { return "_SelectedProductsTable"; } }
        public SelectedProductsTable() {
            Table = new DataTable();
            DataColumn _id = new DataColumn(Producto.Columns.Id, typeof(int));
            DataColumn _no = new DataColumn(Producto.Columns.Nombre, typeof(string));
            DataColumn _cu = new DataColumn(Producto.Columns.CantidadPorUnidad, typeof(string));
            DataColumn _ip = new DataColumn(Producto.Columns.IdProveedor, typeof(string));
            DataColumn _pu = new DataColumn(Producto.Columns.PrecioUnitario, typeof(double));
            Table.Columns.Add(_id);
            Table.Columns.Add(_no);
            Table.Columns.Add(_cu);
            Table.Columns.Add(_ip);
            Table.Columns.Add(_pu);

        }
        public bool Exists(int id) {
            foreach (DataRow row in Table.Rows) {
                if (Convert.ToInt32(row[Producto.Columns.Id]) == id) {
                    return true;
                }
            }
            return false;
        }
        public bool AddRow(Producto p) {
            if (!Exists(p.Id)) {
                DataRow row = p.GetRow(this.Table);
                Table.Rows.Add(row);
                return true;
            }
            return false;
        }
    }
}