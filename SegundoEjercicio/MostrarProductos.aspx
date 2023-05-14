<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MostrarProductos.aspx.cs" Inherits="TrabajoPractico6.SegundoEjercicio.MostrarProductos" %>

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
    <form id="form1" class="centered-form" runat="server">
        <br />
        <div>
            <span class="mdc-typography--headline4">Productos seleccionados</span>
        </div>
        <br />
        <br />
        <div runat="server" id="nopro" class="NoProductsSection">
            <span class="material-icons">production_quantity_limits</span>
            <span class="mdc-typography--subtitle1">No hay productos seleccionados</span>
        </div>
        <asp:GridView
            ID="gvej2"
            runat="server"
            AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label
                            CssClass="mdc-typography--body2"
                            ID="ProductoItemTemplateView__ID"
                            runat="server"
                            Text='<%# Eval(Producto.Columns.Id) %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate>
                        <asp:Label
                            CssClass="mdc-typography--body2"
                            ID="ProductoItemTemplateView__Nombre"
                            runat="server"
                            Text='<%# Eval(Producto.Columns.Nombre) %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ID Proveedor">
                    <ItemTemplate>
                        <asp:Label
                            CssClass="mdc-typography--body2"
                            ID="ProductoItemTemplateView__IDProveedor"
                            runat="server"
                            Text='<%# Eval(Producto.Columns.IdProveedor) %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Precio Unitario">
                    <ItemTemplate>
                        <asp:Label
                            CssClass="mdc-typography--body2"
                            ID="ProductoItemTemplateView__PrecioUnitario"
                            runat="server"
                            Text='<%# Eval(Producto.Columns.PrecioUnitario) %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
        <br />
        <br />
        <div class="flex-horizontal">
            
            <asp:HyperLink ID="hlAgregarProductos" runat="server" NavigateUrl="/SegundoEjercicio/SeleccionarProductos.aspx" CssClass="mdc-button mdc-button--outlined mdc-button--icon-leading">
            <span class="mdc-button__ripple"></span>
            <i class="material-icons mdc-button__icon" aria-hidden="true">launch</i>
            <span class="mdc-button__label">Agregar productos</span>
        </asp:HyperLink><asp:HyperLink ID="hlVolver" runat="server" NavigateUrl="/SegundoEjercicio/SegundoEjercicio.aspx" CssClass="mdc-button mdc-button--raised">
            <span class="mdc-button__ripple"></span>
            <span class="mdc-button__label">Volver</span>
        </asp:HyperLink>
        </div>
    </form>
</body>
</html>
