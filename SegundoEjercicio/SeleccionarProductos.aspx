<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarProductos.aspx.cs" Inherits="TrabajoPractico6.SegundoEjercicio.SeleccionarProductos" %>

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
            <span class="mdc-typography--headline4">Seleccionar productos</span>
        </div>
        <br />
        <br />
        
            <asp:GridView
                ID="gvej2"
                runat="server"
                AutoGenerateColumns="False"
                OnPageIndexChanging="gvej2_PageIndexChanging"
                AllowPaging="True"
                OnRowCreated="gvej2_RowCreated"
                PageSize="14" 
                AutoGenerateSelectButton="False" 
                OnSelectedIndexChanging="gvej2_SelectedIndexChanging">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="gvProductosItemTemplateBtnSeleccionar" runat="server" CommandName="Select" CssClass="mdc-icon-button mdc-icon-button--danger smaller action">
                                <span class="mdc-icon-button__ripple"></span>
                                <i class="material-icons" aria-hidden="true">add</i>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
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
                <PagerTemplate>
                    <div class="pager">
                        <span class="mdc-typography--body2" style="white-space: nowrap;">Filas por página: </span>
                        <label class="mdc-text-field mdc-text-field--outlined mdc-text-field--no-label page-roll">
                            <span class="mdc-notched-outline">
                                <span class="mdc-notched-outline__leading"></span>
                                <span class="mdc-notched-outline__trailing"></span>
                            </span>
                            <asp:DropDownList ID="ddlFilasPorPaginaPagerTemplate" CssClass="mdc-text-field__input" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlFilasPorPaginaPagerTemplate_SelectedIndexChanged">

                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem Selected="True">14</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>

                            </asp:DropDownList>
                        </label>
                        <div class="pager-space"></div>
                        <asp:LinkButton ID="gvej2PagerFirst" runat="server" CommandName="Page" CommandArgument="First" CssClass="mdc-icon-button mdc-button--primary">
                                <span class="mdc-icon-button__ripple"></span>
                                <i class="material-icons mdc-button__icon" aria-hidden="true">first_page</i>
                                <!--span class="mdc-button__label"></span-->
                        </asp:LinkButton>
                        <asp:LinkButton ID="gvej2PagerPrev" runat="server" CommandName="Page" CommandArgument="Prev" CssClass="mdc-icon-button mdc-button--primary">
                                <span class="mdc-icon-button__ripple"></span>
                                <i class="material-icons mdc-button__icon" aria-hidden="true">chevron_left</i>
                                <!--span class="mdc-button__label"></span-->
                        </asp:LinkButton>
                        <label class="mdc-text-field mdc-text-field--outlined mdc-text-field--no-label page-roll">
                            <span class="mdc-notched-outline">
                                <span class="mdc-notched-outline__leading"></span>
                                <span class="mdc-notched-outline__trailing"></span>
                            </span>
                            <asp:TextBox type="number" CssClass="mdc-text-field__input" ID="gvej2PagerPageTxtBox" runat="server" OnTextChanged="gvProductsPagerPageTxtBox_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </label>
                        <asp:LinkButton ID="gvej2PagerNext" runat="server" CommandName="Page" CommandArgument="Next" CssClass="mdc-icon-button mdc-button--primary">
                                <span class="mdc-icon-button__ripple"></span>
                                <i class="material-icons mdc-button__icon" aria-hidden="true">chevron_right</i>
                                <!--span class="mdc-button__label"></span-->
                        </asp:LinkButton>
                        <asp:LinkButton ID="gvej2PagerLast" runat="server" CommandName="Page" CommandArgument="Last" CssClass="mdc-icon-button mdc-button--primary">
                                <span class="mdc-icon-button__ripple"></span>
                                <i class="material-icons mdc-button__icon" aria-hidden="true">last_page</i>
                                <!--span class="mdc-button__label"></span-->
                        </asp:LinkButton>
                    </div>
                </PagerTemplate>
            </asp:GridView>
            <aside class="mdc-snackbar">
                <div class="mdc-snackbar__surface" role="status" aria-relevant="additions">
                    <div class="mdc-snackbar__label" aria-atomic="false"></div>
                </div>
            </aside>
    </form>
</body>
</html>
