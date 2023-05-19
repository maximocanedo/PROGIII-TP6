<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MostrarProductosSeleccionados.aspx.cs" Inherits="TrabajoPractico6.SegundoEjercicio.MostrarProductosSeleccionados" %>

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
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblProductosSel" runat="server" Text="Productos seleccionados por el usuario:"></asp:Label>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:GridView ID="gvProductosSeleccionados" runat="server" AutoGenerateColumns="False" Width="865px">
                <Columns>
                    <asp:TemplateField HeaderText="ID Producto">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IDProducto" runat="server" Text='<%# Bind("IdProducto") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BackColor="#003399" ForeColor="White" />
                        <ItemStyle BorderColor="Blue" BorderStyle="Solid" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre Producto">
                        <ItemTemplate>
                            <asp:Label ID="lbl_NombreProducto" runat="server" Text='<%# Bind("NombreProducto") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BackColor="#003399" ForeColor="White" />
                        <ItemStyle BorderColor="Blue" BorderStyle="Solid" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ID Proveedor">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IDProveedor" runat="server" Text='<%# Bind("IdProveedor") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BackColor="#003399" ForeColor="White" />
                        <ItemStyle BorderColor="Blue" BorderStyle="Solid" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Precio Unidad">
                        <ItemTemplate>
                            <asp:Label ID="lbl_PrecioUnidad" runat="server" Text='<%# Bind("PrecioUnidad") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BackColor="#003399" ForeColor="White" />
                        <ItemStyle BorderColor="Blue" BorderStyle="Solid" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:HyperLink ID="hlVolver" runat="server" NavigateUrl="Inicio.aspx">Volver al Inicio</asp:HyperLink>
        </div>
    </form>
</body>
</html>
