<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/admin.Master" CodeBehind="Modulo_paquetes.aspx.vb" Inherits="hotel.Modulo_paquetes" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
               
<div class="panel  panel-primary">
<%--  <div class="panel-heading">Listado De Proveedores</div>--%>
      <div class="panel-heading">
    <h3 class="panel-title">Gestionar Paquetes</h3>
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
        <!--aca va gridview-->

        </li>
        </ul>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Button ID="Button1" runat="server" Text="Button"  Style="display:none"/>
    <ajaxToolkit:ModalPopupExtender ID="Button1_ModalPopupExtender" runat="server" BehaviorID="Button1_ModalPopupExtender" DynamicServicePath="" TargetControlID="Button1" BackgroundCssClass="modalbakground" PopupControlID="panel1">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" style="display:none; background: white; Width:50%; height:auto">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                     <div class="modal-header">
                          <h3 id="mymodallabel" style="margin-left: 250px;">Nuevo paquete</h3>
                       </div>
                       <div class="modal-body">
                         <%--cuerpo del modal--%>
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label  class="col-sm-4 control-label">Nombre:</label>
                                    <div class="col-sm-8">
                                   <asp:TextBox ID="nombre" runat="server"></asp:TextBox>
                                    </div>
                                 </div>   
                                   <div class="form-group">
                                    <label  class="col-sm-4 control-label">Apellido:</label>
                                    <div class="col-sm-8">
                                            <asp:TextBox ID="apellido" runat="server"></asp:TextBox>
                                    </div>
                                 </div> 
                                      <div class="form-group">
                                    <label  class="col-sm-4 control-label">Nit:</label>
                                    <div class="col-sm-8">
                                           <asp:TextBox ID="nit" runat="server"></asp:TextBox>
                                    </div>
                                 </div> 
                                 <div class="form-group">
                                    <label  class="col-sm-4 control-label">Tipo De Cliente :</label>
                                    <div class="col-sm-8">
                                           <asp:TextBox ID="tipo" runat="server"></asp:TextBox>
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
