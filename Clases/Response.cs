using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/*
 Esta clase es muy importante porque es la vía de comunicación entre SQL y nosotros.

Vean las propiedades. ErrorFound, Message, Details, ObjectReturned, AffectedRows, Exception.

Esta clase tendrá todos los detalles sobre la consulta que hagamos.

Si hacemos SELECT, podemos devolver un Response con un ObjectReturned como DataSet con los datos que pedimos,
Si hacemos UPDATE, DELETE, podemos devolver un Response con un AffectedRows que nos indique cuántas filas se afectaron.

También la podemos usar si se encontró un error en la consulta, mediante ErrorFound, Message y Details, o simplemente con Exception.

Si les es complicado entender cómo funciona pueden preguntarme o fijarse cómo se usa esta clase en Producto, Conexion.

 */

namespace TrabajoPractico6.Clases {
    public class Response {
        public bool ErrorFound { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
        public object ObjectReturned { get; set; }
        public int AffectedRows { get; set; }
        public Exception Exception { get; set; }
        public Response() {
            this.ErrorFound = false;
            this.Message = "";
            this.Details = "";
            this.ObjectReturned = null;
            this.AffectedRows = 0;
            this.Exception = null;
        }
    }
}