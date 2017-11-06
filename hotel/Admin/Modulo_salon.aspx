<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/admin.Master" CodeBehind="Modulo_salon.aspx.vb" Inherits="hotel.Modulo_salon" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
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

      <asp:Button ID="Button9" runat="server" Text="Nuevo"  CssClass="btn btn-success" />
  </div>
    <ul class="list-group height:1px">
    <li class="list-group-item">
        <!--aca va el gridview-->
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="codigo_salon" ForeColor="#333333" GridLines="None" OnRowcommand="GridView1_RowCommand">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="codigo_salon" HeaderText="Codigo De Salon" ReadOnly="True" SortExpression="codigo_salon" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
                <asp:BoundField DataField="estado" HeaderText="Estado" SortExpression="estado" />
                  <asp:TemplateField HeaderText="Modificar">
                                     <ItemTemplate>
                                         <asp:Button ID="modifBtn" runat="server" commandArgument="<%#Container.DataItemIndex %>" CommandName="actualizar" CssClass="btn btn-primary btn-sm" Text="editar" />
                                     </ItemTemplate>
                                     <HeaderStyle Width="80px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Eliminar">
                                     <ItemTemplate>
                                         <asp:Button ID="eliminarBtn" runat="server" commandArgument="<%#Container.DataItemIndex %>" CommandName="eliminar" CssClass="btn btn-danger btn-sm" Text="eliminar" />
                                     </ItemTemplate>
                                 </asp:TemplateField>
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BD_orquideasConnectionString %>" SelectCommand="SELECT DISTINCT * FROM [tb_salon]"></asp:SqlDataSource>
        </li>
        </ul>
    </div>
                </ContentTemplate>
    </asp:UpdatePanel>  
            <!--nuevo salon-->

            <asp:Button ID="Button1" runat="server" Text="Button" Style="display:none" />
            <ajaxToolkit:ModalPopupExtender ID="Button1_ModalPopupExtender" runat="server" BehaviorID="Button1_ModalPopupExtender" DynamicServicePath="" TargetControlID="Button1" BackgroundCssClass="modalbakground" PopupControlID="panel1">
            </ajaxToolkit:ModalPopupExtender>
             <asp:Panel ID="Panel1" runat="server" style="display:none; background: white; Width:50%; height:auto">
          
                     <div class="modal-header">
                          <h3 id="mymodallabel" >Nuevo Salon</h3>
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
                                    <label  class="col-sm-4 control-label">Nombre:</label>
                                    <div class="col-sm-8">
                                            <asp:TextBox ID="nombre" runat="server"></asp:TextBox>
                                    </div>
                                 </div> 
                                      <div class="form-group">
                                    <label  class="col-sm-4 control-label">estado:</label>
                                    <div class="col-sm-8">
                                            <asp:TextBox ID="estado" runat="server"></asp:TextBox>
                                    </div>
                                 </div> 
                            </div> 
                       </div>     
                       <div class="modal-footer">
                            <asp:Button ID="Button4" runat="server" Text="close" class="btn" data-dismiss="modal" aria-hidden="true" />
                            <asp:Button ID="Button5" runat="server" Text="Guardar" CssClass="btn btn-success" />
                       </div>
         
        </asp:Panel>
 <!--Actualizacion de Salon-->
    <asp:Button ID="Button2" runat="server" Text="Button" />
    <ajaxToolkit:ModalPopupExtender ID="Button2_ModalPopupExtender" runat="server" BehaviorID="Button2_ModalPopupExtender"  TargetControlID="Button2" BackgroundCssClass="modalbakground" PopupControlID="panel2">
    </ajaxToolkit:ModalPopupExtender>
     <asp:Panel ID="Panel2" runat="server"  style="display:none; background: white; Width:50%; height:auto">
          <asp:UpdatePanel ID="UpdatePanel2" runat="server">
              <ContentTemplate>
                  <div class="modal-header modal-primary"  >
                   <h3 id="modalupdate" > Actualizar Salon</h3>
                       </div>
                        <div class="modal-body" >
                         <%--cuerpo del modal--%>
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label  class="col-sm-4 control-label">Codigo:</label>
                                    <div class="col-sm-8">
                                      <asp:TextBox ID="codigo_m" runat="server"></asp:TextBox>
                                    </div>
                                 </div>   
                                   <div class="form-group">
                                    <label  class="col-sm-4 control-label">Nombre:</label>
                                    <div class="col-sm-8">
                                           <asp:TextBox ID="nombre_m" runat="server"></asp:TextBox>
                                    </div>
                                 </div> 
                                      <div class="form-group">
                                    <label  class="col-sm-4 control-label">Estado:</label>
                                    <div class="col-sm-8">
                                         <asp:TextBox ID="estado_m" runat="server"></asp:TextBox>
                                    </div>
                                 </div> 
                            </div>
                            </div> 
                       <div class="modal-footer">
                            <asp:Button ID="Button6" runat="server" Text="close" class="btn" data-dismiss="modal" aria-hidden="true" />
                            <asp:Button ID="Button7" runat="server" Text="Actualizar" CssClass="btn btn-primary" />
                       </div>
              </ContentTemplate>
          </asp:UpdatePanel>
    </asp:Panel>
  <!--Eliminacion de salon-->
    <asp:Button ID="Button10" runat="server" Text="Button" />
    <ajaxToolkit:ModalPopupExtender ID="Button10_ModalPopupExtender" runat="server" BehaviorID="Button10_ModalPopupExtender"  TargetControlID="Button10" BackgroundCssClass="modalbakground" PopupControlID="panel3">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="Panel3" runat="server" style="display:none; background: white; Width:50%; height:auto">
         <asp:UpdatePanel ID="UpdatePanel3" runat="server">
             <ContentTemplate>
 <div class="modal-header">
                          <h3 id="mymodallabel2" "> Eliminacion De Salon</h3>
                       </div>
                       <div class="modal-body">
                         <%--cuerpo del modal--%>
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label  class="col-sm-4 control-label">Codigo:</label>
                                    <div class="col-sm-8">
                                      <asp:TextBox ID="codigo_e" runat="server"></asp:TextBox>
                                    </div>
                                 </div>   
                                   <div class="form-group">
                                    <label  class="col-sm-4 control-label">Nombre:</label>
                                    <div class="col-sm-8">
                                         <asp:TextBox ID="nombre_e" runat="server"></asp:TextBox>
                                    </div>
                                 </div> 
                                      <div class="form-group">
                                    <label  class="col-sm-4 control-label">Estado:</label>
                                    <div class="col-sm-8">
                                             <asp:TextBox ID="estado_e" runat="server"></asp:TextBox>
                                    </div>
                                 </div> 
                            </div>
                       </div>     
                       <div class="modal-footer">
                            <asp:Button ID="Button11" runat="server" Text="close" class="btn" data-dismiss="modal" aria-hidden="true" />
                            <asp:Button ID="Button12" runat="server" Text="Eliminar" CssClass="btn btn-danger" />
                       </div>     
             </ContentTemplate>
         </asp:UpdatePanel>
           
    </asp:Panel>

    

 

</asp:Content>
