<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="pagina_inicio.aspx.vb" Inherits="hotel.pagina_inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="redes">
<div id="facebook"><a href="#" target="none" class="fa fa-facebook"></a></div>
<div id="youtube"><a href="#" target="none" class="fa fa-youtube-play"></a></div>
<div id="twitter"><a href="#" target="none" class="fa fa-twitter"></a></div>
<div id="correo"><a href="#" target="none" class="fa fa-envelope"></a></div>
</div>
<header>
	<div class="ancho">
		<div class="logo">
			<p><a href="#">hice un cambio aca verificar</a></p>
		</div>
		<nav>
			<ul>				
			<li><a href="index.html">jajajaja</a></li>
				<li><a href="somos.html">Quiénes somos</a></li>
				<li><a href="eventos.html">Eventos</a></li>
				<li><a href="ofertas.html">Ofertas</a></li>
			<li><a  data-toggle="modal" data-target="#ingreso" >Sugerencias</a></li>
			</ul>
		</nav>
	</div>
</header>
	<div class="ancho-letras">
		<div class="letras-slider">
			<h1 class="animated zoomIn">cambio de sergio isem</h1>
			<p class="animated slideInUp">...</p>
		</div>
	</div>
	
		<div id="particles-js"></div>
<section class="wrap">
	<section class="bienvenidos">
	<h2>Servicios personalizados</h2>
		<h3>Tu satisfacción es nuestro deber principal, y haremos lo mejor para que disfrutes al máximo de tu estadía en nuestro hotel
        ofreciéndote atención y el servicio personalizado que te mereces</h3>

	</section>
	<section class="contenedor-columnas">
		<div class="columnas-p">
			<img src="images/hotel-gastronomia.png" alt="">
			<h4>Gastronomía</h4>
			<h5>Descubre</h5>
			<p>Una gran variedad gastronómica de calidad</p>
		</div>
		<div class="columnas-p">
			<img src="images/hotel-habitacion.png" alt="">
			<h4>Habitaciones</h4>
			<h5>Elige</h5>
			<p>Entre todo tipo de habitaciones para tu mayor comodidad</p>
		</div>
		<div class="columnas-p">
			<img src="images/hotel-alojar.png" alt="">
			<h4>Alojamiento</h4>
			<h5>Disfruta y vive</h5>
			<p>La experiencia más completa con los mejores servicios al mejor precio</p>
		</div>
	
	</section>
	<!--<section class="testimonios">
		<div class="slider">
			<img src="images/f-1.jpg" alt="">
		</div>
	</section>
	-->
</section>
 <div class="modal fade" id="ingreso" role="dialog">
    <div class="modal-dialog">
      <!-- contenido de la ventana modal-->
      <div class="modal-content">
        <div class="modal-header bg-primary">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Sugerencias</h4>
        </div>
        <div class="modal-body">
        	<!--aca de pasa a la pagina envio.php para ser procesado-->
        <form class="form-horizontal"  action="envio.php" method="POST">
			  <div class="form-group">
			    <label class="control-label col-sm-2">Nombre :</label>
			    	<div class="col-sm-10">
			      		<input type="text" class="form-control" name="nombre" placeholder="Ingrese su Nombre" required>
			    	</div>
			  </div>
			  <div class="form-group">
			    <label class="control-label col-sm-2">Correo:</label>
			    	<div class="col-sm-10">
			      		<input type="email" class="form-control"  name="correo" placeholder="Ingrese su Correo" required>
			    	</div>
			  </div>
			  <div class="form-group">
			    <label class="control-label col-sm-2">Telefono:</label>
			   		 <div class="col-sm-10">
			      		<input type="text" class="form-control"  name="telefono" placeholder="Ingrese su telefono" required>
			    	 </div>
			  </div>
			  <div class="form-group">
				<label class="control-label col-sm-2" >Comentario:</label>
					 <div class="col-sm-10">
						<textarea class="form-control" rows="3" name="contacto"></textarea>
				     </div>
			  </div>
        </div>
        <div class="modal-footer"> 
        	<button type="submit" class="btn btn-success">Enviar</button>
        </div>
        </form>
      </div>
    </div>
  </div>
</asp:Content>
