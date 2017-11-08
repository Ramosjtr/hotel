<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="login.aspx.vb" Inherits="hotel.login" %>
<!DOCTYPE html>
<html >
<head> 
    <link href="Content/style_login.css" rel="stylesheet" />
  <meta charset="UTF-8">
  <title>Login Hotel Las Orquideas</title>
    <style type="text/css">
        .auto-style1 {
            color: #FFFFFF;
        }
    </style>
</head>
<body>
    <div id="particles-js">
  <div class="container">
  <div class="form-container flip">
      <h1 class="auto-style1" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Hotel Las Orquideas</h1>
    <form class="login-form" runat="server">
      <h3 class="title">Bienvenido.</h3>
      <div class="form-group" id="username">
        <input class="form-input" tooltip-class="username-tooltip" placeholder="usuario" required="required" runat="server" id="usuario1" autofocus="" value=""/>
        <span id="username-tool"class="tooltip username-tooltip">Ingrese su Usuario</span>
      </div>
      <div class="form-group" id="password">
        <input type="password" class="form-input" tooltip-class="password-tooltip" placeholder="contraseña" runat="server" id="contraseña1"/>
        <span class="tooltip password-tooltip">Ingrese Su Contraseña</span>
      </div>
      
      <div class="form-group">
  <asp:Button ID="Button1" runat="server" Text="Acceder"  Font-Size="Larger" ForeColor="White" Width="108px" BackColor="#336699" BorderColor="#3366FF" />
      </div>
    </form>
  </div>
</div>
    </div>
    <script src="Scripts/jquery.min.js"></script>
    <script src="Scripts/jquery-3.1.1.min.js"></script>
<script src="Scripts/login.js"></script>

   <!--lib particulas-->
  <script src="Scripts/particles.js"></script>
    <script src="Scripts/app.js"></script>
    <script src="Scripts/stats.js"></script>
    
</body>
</html>

