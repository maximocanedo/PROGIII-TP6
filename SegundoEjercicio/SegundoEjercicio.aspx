<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SegundoEjercicio.aspx.cs" Inherits="TrabajoPractico6.SegundoEjercicio.SegundoEjercicio" %>

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
        <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
        <br />
        <div>
            <span class="mdc-typography--headline4">Segundo Ejercicio</span>
        </div>
        <br />
        <br />
        <ul class="list mdc-list mdc-list--two-line">

            <asp:HyperLink ID="hlSeleccionarProductos" NavigateUrl="/SegundoEjercicio/SeleccionarProductos.aspx" CssClass="mdc-list-item" runat="server">
                    <li>
                        <span class="mdc-list-item__ripple"></span>
                        <span class="mdc-list-item__text">
                          <span class="__icon">
                              <span class="material-icons cmn">post_add</span>
                          </span>
                          <div class="__text">
                              <span class="mdc-list-item__primary-text">Seleccionar Productos</span>
                                <span class="mdc-list-item__secondary-text">Elegir productos que se guardarán localmente</span>
                          </div>
                        </span>
                    </li>
            </asp:HyperLink>
            <asp:HyperLink NavigateUrl="/SegundoEjercicio/MostrarProductos.aspx" ID="hlMostrarProductos" CssClass="mdc-list-item" runat="server">
                    <li>
                        <span class="mdc-list-item__ripple"></span>
                        <span class="mdc-list-item__text">
                          <span class="__icon">
                              <span class="material-icons cmn">visibility</span>
                          </span>
                          <div class="__text">
                              <span class="mdc-list-item__primary-text">Ver selección</span>
                                <span class="mdc-list-item__secondary-text">Ver productos guardados</span>
                          </div>
                        </span>
                    </li>
            </asp:HyperLink>
            <asp:LinkButton AutoPostback="False" ID="btnEliminarProductosSeleccionados" runat="server" CssClass="mdc-list-item" OnClick="btnEliminarProductosSeleccionados_Click">
                    <li >
                        <span class="mdc-list-item__ripple"></span>
                        <span class="mdc-list-item__text">
                          <span class="__icon">
                              <span class="material-icons dng">delete</span>
                          </span>
                          <div class="__text">
                              <span class="mdc-list-item__primary-text">Eliminar selección</span>
                                <span class="mdc-list-item__secondary-text">Eliminar productos almacenados localmente</span>
                          </div>
                        </span>
                    </li>
            </asp:LinkButton>
            
        </ul>
        <aside class="mdc-snackbar">
            <div class="mdc-snackbar__surface" role="status" aria-relevant="additions">
                <div class="mdc-snackbar__label" aria-atomic="false"></div>
            </div>
        </aside>
    </form>
</body>
</html>
