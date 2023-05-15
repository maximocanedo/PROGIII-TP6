<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrimerEjercicio.aspx.cs" Inherits="TrabajoPractico6.PrimerEjercicio.PrimerEjercicio" %>

<%@ Import Namespace="TrabajoPractico6.Clases" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://unpkg.com/material-components-web@latest/dist/material-components-web.min.css" rel="stylesheet" />
    <script src="https://unpkg.com/material-components-web@latest/dist/material-components-web.min.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@material/icon-button@6.0.0/dist/mdc.icon-button.min.css" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons" />
    <script src="/Recursos/index.js"></script>
    <link href="/Recursos/index.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" class="ejercicio1-grdview-form" runat="server">
        <br />
        Producto<br />
        <br />
        <div>
           <!-- GridView acá -->
            <asp:GridView ID="GrdProducto" runat="server">
            </asp:GridView>
        </div>
    </form>
    <aside class="mdc-snackbar">
        <div class="mdc-snackbar__surface" role="status" aria-relevant="additions">
            <div class="mdc-snackbar__label" aria-atomic="false"></div>
        </div>
    </aside>
</body>
</html>
