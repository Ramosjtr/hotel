<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/admin.Master" CodeBehind="Modulo_salon.aspx.vb" Inherits="hotel.Modulo_salon" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
               
<div class="panel  panel-primary">
<%--  <div class="panel-heading">Listado De Proveedores</div>--%>
      <div class="panel-heading">
    <h3 class="panel-title">Modulo Salon</h3>
  </div>
  <div class="panel-body">
 <asp:Label ID="Label2" runat="server" Text="buscar: "></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
       <a href="#" class="btn btn-sm btn-info" id="Buscar" runat="server"><span class="glyphicon glyphicon-zoom-in"></span> Buscar</a>
                    <a href="#" class="btn btn-sm btn-info" id="todos" runat="server"><span class="glyphicon glyphicon-th-list"></span> Mostrar</a>
       <a href="#" class="btn btn-sm btn-success" id="Nuevo" runat="server"><span class="glyphicon glyphicon-plus"></span> </a>
  </div>
    <ul class="list-group height:1px">
    <li class="list-group-item">
         <div class="table-responsive">
        <!--aca va el gridview-->
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="codigo_salon" ForeColor="#333333" GridLines="None" OnRowcommand="GridView1_RowCommand" Cssclass="table table-hover">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="codigo_salon" HeaderText="Codigo De Salon" ReadOnly="True" SortExpression="codigo_salon" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
                <asp:BoundField DataField="estado" HeaderText="Estado" SortExpression="estado" />
                <asp:BoundField DataField="costo" HeaderText="Costo" SortExpression="costo" />
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
                <div style="margin-left: 400px; width: 197px;">
                         <a href="#" class="btn btn-sm btn-info" id="anterior" runat="server" ><span class="glyphicon glyphicon-step-backward"></span>Anterior</a>
                         <a href="#" class="btn btn-sm btn-info" id="siguiente" runat="server"><span class="glyphicon glyphicon-step-forward"></span> Siguiente</a>
              </div>
             </div>
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
                                   <asp:TextBox ID="codigo" runat="server" CssClass="estilo1" Value="SA-"></asp:TextBox>
                                    </div>
                                 </div>   
                                   <div class="form-group">
                                    <label  class="col-sm-4 control-label">Nombre:</label>
                                    <div class="col-sm-8">
                                            <asp:TextBox ID="nombre" runat="server" CssClass="estilo1"></asp:TextBox>
                                    </div>
                                 </div> 
                                     <div class="form-group">
                                    <label  class="col-sm-4 control-label">Estado:</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="estilo1" >
                                <asp:ListItem>Disponible</asp:ListItem>
                                <asp:ListItem>Reservado</asp:ListItem>
                            </asp:DropDownList>
                                    </div>
                                 </div>
                                <div class="form-group">
                                    <label  class="col-sm-4 control-label">Costo:</label>
                                    <div class="col-sm-8">
                                            <asp:TextBox ID="costo" runat="server" CssClass="estilo1"></asp:TextBox>
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
    <asp:Button ID="Button2" runat="server" Text="Button" Style="display:none"  />
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
                                      <asp:TextBox ID="codigo_m" runat="server" CssClass="estilo1"></asp:TextBox>
                                    </div>
                                 </div>   
                                   <div class="form-group">
                                    <label  class="col-sm-4 control-label">Nombre:</label>
                                    <div class="col-sm-8">
                                           <asp:TextBox ID="nombre_m" runat="server" CssClass="estilo1"></asp:TextBox>
                                    </div>
                                 </div> 
                                      <div class="form-group">
                                    <label  class="col-sm-4 control-label">Costo:</label>
                                    <div class="col-sm-8">
                                         <asp:TextBox ID="costo_m" runat="server" CssClass="estilo1"></asp:TextBox>
                                    </div>
                                 </div> 
                            <div class="form-group">
                                    <label  class="col-sm-4 control-label">Estado:</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="estilo1" >
                                <asp:ListItem>Disponible</asp:ListItem>
                                <asp:ListItem>Reservado</asp:ListItem>
                            </asp:DropDownList>
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
    <asp:Button ID="Button10" runat="server" Text="Button" Style="display:none" />
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
                                      <asp:TextBox ID="codigo_e" runat="server" CssClass="estilo1"></asp:TextBox>
                                    </div>
                                 </div>   
                                   <div class="form-group">
                                    <label  class="col-sm-4 control-label">Nombre:</label>
                                    <div class="col-sm-8">
                                         <asp:TextBox ID="nombre_e" runat="server" CssClass="estilo1"></asp:TextBox>
                                    </div>
                                 </div> 
                                      <div class="form-group">
                                    <label  class="col-sm-4 control-label">Estado:</label>
                                    <div class="col-sm-8">
                                             <asp:TextBox ID="estado_e" runat="server" CssClass="estilo1"></asp:TextBox>
                                    </div>
                                 </div> 
                                <div class="form-group">
                                    <label  class="col-sm-4 control-label">Costo:</label>
                                    <div class="col-sm-8">
                                            <asp:TextBox ID="costo_e" runat="server" CssClass="estilo1"></asp:TextBox>
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

