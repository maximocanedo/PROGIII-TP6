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
    <form id="form1" class="centered-form" runat="server">
        <br />
        <div class="flex-vertical">
            <span class="mdc-typography--headline4">Primer Ejercicio</span>
        </div>
        <br />
        <br />
        <div>
            <asp:GridView
                ID="gvProductos"
                runat="server"
                AutoGenerateColumns="False"
                OnRowCancelingEdit="gvProductos_RowCancelingEdit"
                OnRowEditing="gvProductos_RowEditing"
                OnRowUpdating="gvProductos_RowUpdating"
                OnPageIndexChanging="gvProductos_PageIndexChanging"
                AllowPaging="True"
                OnRowCreated="gvProductos_RowCreated" 
                OnRowDeleting="gvProductos_RowDeleting"
                >
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="gvProductosItemTemplateBtnEditar" runat="server" CommandName="Edit" CssClass="mdc-icon-button mdc-icon-button--danger smaller action">
                                <span class="mdc-icon-button__ripple"></span>
                                <i class="material-icons" aria-hidden="true">edit</i>
                            </asp:LinkButton>
                            <asp:LinkButton ID="gvProductosItemTemplateBtnBorrar" runat="server" CommandName="Delete" CssClass="mdc-icon-button mdc-button--primary smaller danger">
                                <span class="mdc-icon-button__ripple"></span>
                                <i class="material-icons" aria-hidden="true">delete</i>
                                <!--span class="mdc-button__label"></span-->
                            </asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="gvProductosItemTemplateBtnActualizar" runat="server" CommandName="Update" CssClass="mdc-icon-button mdc-button--primary smaller action">
                                <span class="mdc-icon-button__ripple"></span>
                                <i class="material-icons mdc-button__icon" aria-hidden="true">save</i>
                                <!--span class="mdc-button__label"></span-->
                            </asp:LinkButton>
                            <asp:LinkButton ID="gvProductosItemTemplateBtnCancelar" runat="server" CommandName="Cancel" CssClass="mdc-icon-button mdc-button--primary smaller danger">
                                <span class="mdc-icon-button__ripple"></span>
                                <i class="material-icons" aria-hidden="true">close</i>
                                <!--span class="mdc-button__label"></span-->
                            </asp:LinkButton>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ID">
                        <EditItemTemplate>
                            <asp:Label 
                                CssClass="mdc-typography--body2" 
                                ID="ProductoEditItemTemplateView__ID" 
                                runat="server" 
                                Text="<%# Eval(Producto.Columns.Id) %>">
                            </asp:Label>
                        </EditItemTemplate>
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
                        <EditItemTemplate>
                            <label class="mdc-text-field mdc-text-field--outlined mdc-text-field--no-label  edititemtemplate-txtbox">
                                <span class="mdc-notched-outline">
                                    <span class="mdc-notched-outline__leading"></span>
                                    <span class="mdc-notched-outline__trailing"></span>
                                </span>
                                <asp:TextBox 
                                    CssClass="mdc-text-field__input" 
                                    type="text" 
                                    aria-labelledby="my-label-id" 
                                    maxlength="40"
                                    ID="ProductoEditItemTemplateView__Nombre" 
                                    runat="server" 
                                    Text="<%# Eval(Producto.Columns.Nombre) %>">
                                </asp:TextBox>
                            </label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label
                                CssClass="mdc-typography--body2"
                                ID="ProductoItemTemplateView__Nombre"
                                runat="server"
                                Text='<%# Eval(Producto.Columns.Nombre) %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Cantidad por Unidad">
                        <EditItemTemplate>
                            <label class="mdc-text-field mdc-text-field--outlined mdc-text-field--no-label  edititemtemplate-txtbox">
                                <span class="mdc-notched-outline">
                                    <span class="mdc-notched-outline__leading"></span>
                                    <span class="mdc-notched-outline__trailing"></span>
                                </span>
                                <asp:TextBox 
                                    CssClass="mdc-text-field__input" 
                                    type="text" 
                                    aria-labelledby="gvet2" 
                                    ID="ProductoEditItemTemplateView__CantidadPorUnidad" 
                                    runat="server" 
                                    maxlength="20"
                                    Text="<%# Eval(Producto.Columns.CantidadPorUnidad) %>">
                                </asp:TextBox>
                            </label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label
                                CssClass="mdc-typography--body2"
                                ID="ProductoItemTemplateView__CantidadPorUnidad"
                                runat="server"
                                Text='<%# Eval(Producto.Columns.CantidadPorUnidad) %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Precio Unitario">
                        <EditItemTemplate>
                            <label class="mdc-text-field mdc-text-field--outlined mdc-text-field--no-label  edititemtemplate-txtbox">
                                <span class="mdc-notched-outline">
                                    <span class="mdc-notched-outline__leading"></span>
                                    <span class="mdc-notched-outline__trailing"></span>
                                </span>
                                <asp:TextBox 
                                    CssClass="mdc-text-field__input" 
                                    type="number" 
                                    step="0.01" 
                                    aria-labelledby="gvet3" 
                                    ID="ProductoEditItemTemplateView__PrecioUnitario" 
                                    runat="server" 
                                    Text="<%# Eval(Producto.Columns.PrecioUnitario) %>">
                                </asp:TextBox>
                            </label>
                        </EditItemTemplate>
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

                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem Selected="True">10</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>

                            </asp:DropDownList>
                        </label>
                        <div class="pager-space"></div>
                        <asp:LinkButton ID="gvProductosPagerFirst" runat="server" CommandName="Page" CommandArgument="First" CssClass="mdc-icon-button mdc-button--primary">
                                <span class="mdc-icon-button__ripple"></span>
                                <i class="material-icons mdc-button__icon" aria-hidden="true">first_page</i>
                                <!--span class="mdc-button__label"></span-->
                        </asp:LinkButton>
                        <asp:LinkButton ID="gvProductosPagerPrev" runat="server" CommandName="Page" CommandArgument="Prev" CssClass="mdc-icon-button mdc-button--primary">
                                <span class="mdc-icon-button__ripple"></span>
                                <i class="material-icons mdc-button__icon" aria-hidden="true">chevron_left</i>
                                <!--span class="mdc-button__label"></span-->
                        </asp:LinkButton>
                        <label class="mdc-text-field mdc-text-field--outlined mdc-text-field--no-label page-roll">
                            <span class="mdc-notched-outline">
                                <span class="mdc-notched-outline__leading"></span>
                                <span class="mdc-notched-outline__trailing"></span>
                            </span>
                            <asp:TextBox type="number" CssClass="mdc-text-field__input" ID="gvProductsPagerPageTxtBox" runat="server" OnTextChanged="gvProductsPagerPageTxtBox_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </label>
                        <asp:LinkButton ID="gvProductosPagerNext" runat="server" CommandName="Page" CommandArgument="Next" CssClass="mdc-icon-button mdc-button--primary">
                                <span class="mdc-icon-button__ripple"></span>
                                <i class="material-icons mdc-button__icon" aria-hidden="true">chevron_right</i>
                                <!--span class="mdc-button__label"></span-->
                        </asp:LinkButton>
                        <asp:LinkButton ID="gvProductosPagerLast" runat="server" CommandName="Page" CommandArgument="Last" CssClass="mdc-icon-button mdc-button--primary">
                                <span class="mdc-icon-button__ripple"></span>
                                <i class="material-icons mdc-button__icon" aria-hidden="true">last_page</i>
                                <!--span class="mdc-button__label"></span-->
                        </asp:LinkButton>
                    </div>
                </PagerTemplate>
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
