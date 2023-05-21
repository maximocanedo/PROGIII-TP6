<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarProductos.aspx.cs" Inherits="TrabajoPractico6.SegundoEjercicio.SeleccionarProductos" %>

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
    <style type="text/css">
        .auto-style1 {
            margin-left: 0px;
            margin-top: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <asp:GridView ID="gvProductos" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanging="gvProductos_SelectedIndexChanging" AllowPaging="True" AutoGenerateColumns="False" CssClass="auto-style1" PageSize="14" Width="1080px" OnPageIndexChanging="gvProductos_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="ID Producto">
                    <ItemTemplate>
                        <asp:Label ID="lbl_IDProducto" runat="server" Text='<%# Bind("IdProducto") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BackColor="#003399" ForeColor="White" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Blue" BorderStyle="Solid" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nombre Producto">
                    <ItemTemplate>
                        <asp:Label ID="lbl_NombreProducto" runat="server" Text='<%# Bind("NombreProducto") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BackColor="#003399" ForeColor="White" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Blue" BorderStyle="Solid" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ID Proveedor">
                    <ItemTemplate>
                        <asp:Label ID="lbl_IDProveedor" runat="server" Text='<%# Bind("IdProveedor") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BackColor="#003399" ForeColor="White" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Blue" BorderStyle="Solid" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Precio Unitario">
                    <ItemTemplate>
                        <asp:Label ID="lbl_PrecioUnitario" runat="server" Text='<%# Bind("PrecioUnidad") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BackColor="#003399" ForeColor="White" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Blue" BorderStyle="Solid" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div>
            <br />
            <asp:Label ID="lblProductosAgregados" runat="server" Text="Productos agregados: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <br />
            <asp:HyperLink ID="hlVolver" runat="server" NavigateUrl="Inicio.aspx">Volver al Inicio</asp:HyperLink>
        </div>
    </form>
</body>
</html>
