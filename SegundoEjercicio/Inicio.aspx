<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TrabajoPractico6.SegundoEjercicio.Inicio" %>

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
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblInicio" runat="server" Font-Bold="True" Font-Size="Large" Text="Inicio"></asp:Label>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="hlSeleccionarProductos" runat="server" NavigateUrl="SeleccionarProductos.aspx">Seleccionar Productos</asp:HyperLink>
            <br />
&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="lbtnEliminarProdSel" runat="server" OnClick="lbtnEliminarProdSel_Click">Eliminar Productos Seleccionados</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbl_Mensaje" runat="server"></asp:Label>
            <br />
&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="hlMostrarProductos" runat="server" NavigateUrl="MostrarProductosSeleccionados.aspx">Mostrar Productos Seleccionados</asp:HyperLink>
        </div>
    </form>
</body>
</html>
