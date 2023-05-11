<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrimerEjercicio.aspx.cs" Inherits="TrabajoPractico6.PrimerEjercicio.PrimerEjercicio" %>
<%@ Import Namespace="TrabajoPractico6.Clases" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://unpkg.com/material-components-web@latest/dist/material-components-web.min.css" rel="stylesheet" />
    <script src="https://unpkg.com/material-components-web@latest/dist/material-components-web.min.js"></script>
    <script src="/Recursos/index.js"></script>
    <link href="/Recursos/index.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <div>
            <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True" AutoGenerateSelectButton="True" OnRowCancelingEdit="gvProductos_RowCancelingEdit" OnRowEditing="gvProductos_RowEditing" OnRowUpdating="gvProductos_RowUpdating" AllowPaging="True">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <EditItemTemplate>
                            <asp:Label ID="gvProductsEditTemplateID" runat="server" Text="<%# Eval(Producto.Columns.Id) %>"></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label 
                                ID="gvProductosTemplateID" 
                                runat="server" 
                                Text='<%# Eval(Producto.Columns.Id) %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <EditItemTemplate>
                            <asp:TextBox ID="gvProductsEditTemplateNombre" runat="server" Text="<%# Eval(Producto.Columns.Nombre) %>"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label 
                                ID="gvProductosTemplateNombre" 
                                runat="server" 
                                Text='<%# Eval(Producto.Columns.Nombre) %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cantidad por Unidad">
                        <EditItemTemplate>
                            <asp:TextBox ID="gvProductsEditTemplateCantidadPorUnidad" runat="server" Text="<%# Eval(Producto.Columns.CantidadPorUnidad) %>"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label 
                                ID="gvProductosTemplateCantidadPorUnidad" 
                                runat="server" 
                                Text='<%# Eval(Producto.Columns.CantidadPorUnidad) %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Precio Unitario">
                        <EditItemTemplate>
                            <asp:TextBox ID="gvProductsEditTemplatePrecioUnitario" runat="server" Text="<%# Eval(Producto.Columns.PrecioUnitario) %>"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label 
                                ID="gvProductosTemplatePrecioUnitario" 
                                runat="server" 
                                Text='<%# Eval(Producto.Columns.PrecioUnitario) %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
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
