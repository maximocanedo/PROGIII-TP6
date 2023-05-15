<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TrabajoPractico6.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 170px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                    <td class="auto-style2"><h1>Nº Grupo:</h1 </td>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Ej1.aspx">Ejercicio 1</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="Ej2.aspx">Ejercico 2</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
