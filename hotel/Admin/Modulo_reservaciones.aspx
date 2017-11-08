<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/admin.Master" CodeBehind="Modulo_reservaciones.aspx.vb" Inherits="hotel.Modulo_reservaciones" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
               
<div class="panel  panel-primary">
<%--  <div class="panel-heading">Listado De Proveedores</div>--%>
      <div class="panel-heading">
    <h3 class="panel-title">Gestionar Reservaciones</h3>
  </div>
  <div class="panel-body">
 <asp:Label ID="Label2" runat="server" Text="buscar: "></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
      <a href="#" class="btn btn-sm btn-info" id="Buscar" runat="server"><span class="glyphicon glyphicon-zoom-in"></span> Buscar</a>
                    <a href="#" class="btn btn-sm btn-info" id="todos" runat="server"><span class="glyphicon glyphicon-th-list"></span> Mostrar</a>
  </div>
    <ul class="list-group height:1px">
    <li class="list-group-item">
          <div class="table-responsive">
        <!--aca va Gridview-->
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"  ForeColor="#333333" GridLines="None" Cssclass="table table-hover">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="codigo_reservacion" HeaderText="Codigo" SortExpression="codigo_reservacion" />
                <asp:BoundField DataField="codigo_habitacion" HeaderText="Codigo Habitacion" SortExpression="codigo_habitacion" />
                <asp:BoundField DataField="fecha_inicio" HeaderText="Inicio" SortExpression="fecha_inicio" />
                <asp:BoundField DataField="fecha_finalizacion" HeaderText="Finalizacion" SortExpression="fecha_finalizacion" />
                <asp:BoundField DataField="codigo_paquete" HeaderText="Codigo Paquete" SortExpression="codigo_paquete" />
                <asp:BoundField DataField="numero_documento" HeaderText="Numero Documento" SortExpression="numero_documento" />
                <asp:BoundField DataField="total" HeaderText="Total" SortExpression="total" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
                <asp:BoundField DataField="apellido" HeaderText="Apellido" SortExpression="apellido" />
                <asp:BoundField DataField="tb_tarjeta" HeaderText="N Tarjeta" SortExpression="tb_tarjeta" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
              <div style="margin-left: 400px; width: 197px;">
                         <a href="#" class="btn btn-sm btn-info" id="anterior" runat="server" ><span class="glyphicon glyphicon-step-backward"></span>Anterior</a>
                         <a href="#" class="btn btn-sm btn-info" id="siguiente" runat="server"><span class="glyphicon glyphicon-step-forward"></span> Siguiente</a>
              </div>
              </div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BD_orquideasConnectionString %>" SelectCommand="SELECT DISTINCT * FROM [vista_reservacion]"></asp:SqlDataSource>
        </li>
        </ul>

    </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
