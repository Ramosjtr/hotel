<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/admin.Master" CodeBehind="Modulo_habitaciones.aspx.vb" Inherits="hotel.Modulo_habitaciones" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
               
<div class="panel  panel-primary">
<%--  <div class="panel-heading">Listado De Proveedores</div>--%>
      <div class="panel-heading">
    <h3 class="panel-title">Gestionar Habitaciones</h3>
  </div>
  <div class="panel-body">
 <asp:Label ID="Label2" runat="server" Text="buscar: "></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
                    <asp:Button ID="Button3" runat="server" Text="B" CssClass="btn btn-info btn-sm" />
                    <asp:Button ID="Button8" runat="server" Text="Todos" CssClass="btn btn-info" Height="36px" Width="82px"/>

      <asp:Button ID="Button9" runat="server" Text="Nuevo"  CssClass="btn btn-success" />
  </div>
    <ul class="list-group height:1px">
    <li class="list-group-item">
        <!--aca va gridview-->
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="codigo_habitacion" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="codigo_habitacion" HeaderText="Codigo" ReadOnly="True" SortExpression="codigo_habitacion" />
                <asp:BoundField DataField="metros" HeaderText="Metros" SortExpression="metros" />
                <asp:BoundField DataField="cantidad_camas" HeaderText="Cantidad De Camas" SortExpression="cantidad_camas" />
                <asp:BoundField DataField="costo" HeaderText="Costo" SortExpression="costo" />
                <asp:BoundField DataField="estado" HeaderText="Estado" SortExpression="estado" />
                <asp:BoundField DataField="tipo_habitacion" HeaderText="Tipo De Habitacion" SortExpression="tipo_habitacion" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BD_orquideasConnectionString %>" SelectCommand="SELECT DISTINCT * FROM [tb_habitacion]"></asp:SqlDataSource>
        </li>
        </ul>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <!--nueva Habitacion-->


    <asp:Button ID="Button1" runat="server" Text="Button" Style="display:none" />
    <ajaxToolkit:ModalPopupExtender ID="Button1_ModalPopupExtender" runat="server" BehaviorID="Button1_ModalPopupExtender" DynamicServicePath="" TargetControlID="Button1" BackgroundCssClass="modalbakground" PopupControlID="panel1">
    </ajaxToolkit:ModalPopupExtender>
      <asp:Panel ID="Panel1" runat="server" style="display:none; background: white; Width:50%; height:auto">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                     <div class="modal-header">
                          <h3 id="mymodallabel" >Nueva Habitacion</h3>
                       </div>
                       <div class="modal-body">
                         <%--cuerpo del modal--%>
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label  class="col-sm-4 control-label">Codigo:</label>
                                    <div class="col-sm-8">
                                   <asp:TextBox ID="codigo" runat="server"></asp:TextBox>
                                    </div>
                                 </div>   
                                   <div class="form-group">
                                    <label  class="col-sm-4 control-label">Metros:</label>
                                    <div class="col-sm-8">
                                            <asp:TextBox ID="metros" runat="server"></asp:TextBox>
                                    </div>
                                 </div> 
                                      <div class="form-group">
                                    <label  class="col-sm-4 control-label">Cantida de Camas:</label>
                                    <div class="col-sm-8">
                                           <asp:TextBox ID="Cantidad_camas" runat="server"></asp:TextBox>
                                    </div>
                                 </div> 
                                 <div class="form-group">
                                    <label  class="col-sm-4 control-label">Costo:</label>
                                    <div class="col-sm-8">
                                           <asp:TextBox ID="Costo" runat="server"></asp:TextBox>
                                    </div>
                                 </div>
                                    <div class="form-group">
                                    <label  class="col-sm-4 control-label">Estado:</label>
                                    <div class="col-sm-8">
                                           <asp:TextBox ID="Estado" runat="server"></asp:TextBox>
                                    </div>
                                 </div>
                                 <div class="form-group">
                                    <label  class="col-sm-4 control-label">Tipo De Habitacion:</label>
                                    <div class="col-sm-8">
                                           <asp:TextBox ID="Tipo_habitacion" runat="server"></asp:TextBox>
                                    </div>
                                 </div>
                            </div> 
                       </div>     
                       <div class="modal-footer">
                            <asp:Button ID="Button4" runat="server" Text="close" class="btn" data-dismiss="modal" aria-hidden="true" />
                            <asp:Button ID="Button5" runat="server" Text="Guardar" CssClass="btn btn-success" />
                       </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    

 



</asp:Content>
