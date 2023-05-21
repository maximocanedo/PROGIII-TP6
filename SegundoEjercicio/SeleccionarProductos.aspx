<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarProductos.aspx.cs" Inherits="TrabajoPractico6.SegundoEjercicio.SeleccionarProductos" %>

<%@ Import Namespace="TrabajoPractico6.Clases" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Título y descripción -->
    <title>Seleccionar Productos [EJ2] · T.P. N.º 6</title>
    <meta name="description" content="
        Página 'Seleccionar Productos' del segundo ejercicio del Trabajo Práctico N.º 6 para la materia Programación III. 
        Universidad Tecnológica Nacional, Facultad Regional General Pacheco. 
        Repositorio disponible aquí:  https://github.com/maximocanedo/PROGIII-TP6" />
    <!-- Integrantes -->
    <meta name="author" content="Ezequiel Martínez" />
    <meta name="author" content="Javier Torales" />
    <meta name="author" content="Jean Pierre Esquén" />
    <meta name="author" content="María Olivia Hanczyc" />
    <meta name="author" content="Máximo Canedo" />
    <!-- Otras metaetiquetas útiles -->
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <!-- Librerías utilizadas -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ENjdO4Dr2bkBIFxQpeoTz1HIcje39Wm4jDKdf19U8gI4ddQ3GYNS7NTKfAdVQSZe" crossorigin="anonymous"></script>
    <!-- Archivos usados -->
    <link rel="icon" href="utn.ico" type="image/x-icon" />
    <link href="/Recursos/index.css" rel="stylesheet" />
    <script src="/Recursos/index.js"></script>
</head>
<body>
    <form id="form1" class="centered-form" runat="server">
        <br />
        <h2>Seleccionar Productos</h2>
        <br />
        <asp:GridView ID="gvProductos" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanging="gvProductos_SelectedIndexChanging" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-hover" PageSize="14" Width="1080px" OnPageIndexChanging="gvProductos_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="ID Producto">
                    <ItemTemplate>
                        <asp:Label ID="lbl_IDProducto" runat="server" Text='<%# Eval(Producto.Columns.Id) %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nombre Producto">
                    <ItemTemplate>
                        <asp:Label ID="lbl_NombreProducto" runat="server" Text='<%# Eval(Producto.Columns.Nombre) %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ID Proveedor">
                    <ItemTemplate>
                        <asp:Label ID="lbl_IDProveedor" runat="server" Text='<%# Eval(Producto.Columns.IdProveedor) %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Precio Unitario">
                    <ItemTemplate>
                        <asp:Label ID="lbl_PrecioUnitario" runat="server" Text='<%# Eval(Producto.Columns.PrecioUnitario) %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle VerticalAlign="Middle" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div>
            <asp:HyperLink ID="hlVolver" runat="server" CssClass="btn btn-primary" NavigateUrl="Inicio.aspx">Volver al Inicio</asp:HyperLink>
        </div>
        <div class="toast-container position-fixed bottom-0 end-0 p-3">
            <div id="liveToast" class="toast" role="alert" aria-live="assertive" aria-atomic="true">
                <div class="d-flex">
                    <div class="toast-body">
                    </div>
                    <button type="button" class="btn-close me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
