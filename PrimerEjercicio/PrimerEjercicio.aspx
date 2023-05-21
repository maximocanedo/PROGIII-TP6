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
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ENjdO4Dr2bkBIFxQpeoTz1HIcje39Wm4jDKdf19U8gI4ddQ3GYNS7NTKfAdVQSZe" crossorigin="anonymous"></script>
    <script src="/Recursos/index.js"></script>
    <link href="/Recursos/index.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" class="centered-form" runat="server">
        <br />
        <h1>Primer Ejercicio</h1>
        <br />
        <div>
           <!-- GridView acá -->
            <asp:GridView ID="GrdProducto" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GrdProducto_PageIndexChanging" OnRowDeleting="GrdProducto_RowDeleting" OnRowCancelingEdit="GrdProducto_RowCancelingEdit" OnRowEditing="GrdProducto_RowEditing" OnRowUpdating="GrdProducto_RowUpdating" >
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton type="button" runat="server" CommandName="Edit" class="btn btn-primary special-button">Editar</asp:LinkButton>
                            <asp:LinkButton type="button" runat="server" CommandName="Delete" class="btn btn-danger special-button">Eliminar</asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton type="button" runat="server" CommandName="Update" class="btn btn-success">Actualizar</asp:LinkButton>
                            <asp:LinkButton type="button" runat="server" CommandName="Cancel" class="btn btn-danger">Cancelar</asp:LinkButton>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Id">
                        <EditItemTemplate>
                            <asp:Label ID="LB_ID" runat="server" Text='<%# Eval(Producto.Columns.Id) %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LBL_ID" runat="server" Text='<%# Eval(Producto.Columns.Id) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <EditItemTemplate>
                              <asp:TextBox 
                                  type="text" 
                                  maxlength="40" 
                                  runat="server" 
                                  class="form-control" 
                                  ID="TB_Nombre" 
                                  value="<%# Eval(Producto.Columns.Nombre) %>" 
                                  placeholder="<%# Eval(Producto.Columns.Nombre) %>" 
                                  ></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LBNombre" runat="server" Text='<%# Eval(Producto.Columns.Nombre) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cantidad">
                        <EditItemTemplate>
                            <asp:TextBox 
                                  type="text" 
                                  maxlength="20" 
                                  runat="server" 
                                  class="form-control" 
                                  ID="TB_Cantidad" 
                                  value="<%# Eval(Producto.Columns.CantidadPorUnidad) %>" 
                                  placeholder="<%# Eval(Producto.Columns.CantidadPorUnidad) %>" 
                                  ></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LBCantidad" runat="server" Text='<%# Eval(Producto.Columns.CantidadPorUnidad) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Precio">
                        <EditItemTemplate>
                            <div class="input-group">
                              <span class="input-group-text" id="basic-addon1">$</span>
                              <asp:TextBox 
                                  type="number"
                                  step="0.01"
                                  class="form-control"
                                  runat="server" 
                                  ID="TB_Precio"
                                  value="<%# Eval(Producto.Columns.PrecioUnitario) %>"
                                  placeholder="" 
                                  ></asp:TextBox>
                            </div>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("PrecioUnidad") %>'></asp:Label>
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
