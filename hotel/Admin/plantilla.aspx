<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/admin.Master" CodeBehind="plantilla.aspx.vb" Inherits="hotel.plantilla1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
               
<div class="panel  panel-primary">
<%--  <div class="panel-heading">Listado De Proveedores</div>--%>
      <div class="panel-heading">
    <h3 class="panel-title">plantilla</h3>
  </div>
  <div class="panel-body">
 <asp:Label ID="Label2" runat="server" Text="buscar: "></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
                    <asp:Button ID="Button3" runat="server" Text="B" CssClass="btn btn-info btn-sm" />
                    <asp:Button ID="Button8" runat="server" Text="Todos" CssClass="btn btn-info" Height="36px" Width="82px"/>

      <asp:Button ID="Button9" runat="server" Text="Nuevo"  style="margin-left: 600px;" CssClass="btn btn-success" />
  </div>
    <ul class="list-group height:1px">
    <li class="list-group-item">


        </li>
        </ul>
    </div>





        </ContentTemplate>
    </asp:UpdatePanel>
    

 



</asp:Content>
