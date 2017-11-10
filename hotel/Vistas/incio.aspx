<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Vistas/Maestro.Master" CodeBehind="incio.aspx.vb" Inherits="hotel.incio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Slider -->
    <div id="demo-1" data-zs-src='["img/photos/img1.jpg", "img/photos/img2.jpg", "img/photos/img3.jpg", "img/photos/img4.jpg"]' data-zs-overlay="dots">
        <div class="demo-inner-content">
            <h1><span>Las Golondrinas</span></h1>
            <br />
            <p>El mejor lugar para tomarse un descanso</p>
        </div>
    </div>
    <section class="projects">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="aligncenter">
                        <h2 class="aligncenter">Lo mejor de "las Golondrinas"</h2>
                        Cultura y calidad plasmado en cada rincón. En plano centro de Coban A.V. donde se desarrollan las principales actividades comerciales y culturales de la ciudad.
                        <br />
                        Hotel Golondrinas le invita a vivir una cálida experiencia en servicios y disfrutando de nuestra originalidad</div>
                    <br />
                </div>
            </div>

            <div class="row service-v1 margin-bottom-40">
                <div class="col-md-4 md-margin-bottom-40">
                    <div class="card small">
                        <div class="card-image">
                            <img class="img-responsive" src="img/service1.jpg" alt="">
                        </div>
                        <div class="card-content">
                            <p>
                                <span class="price">RESTAURANTE</span>
                                <h4>Lo mejor en platillos tipicos</h4>
                                <h5>Platillos para toca ocasion</h5>
                                <a href="rasturante.aspx" class="btn btn-details">Mas Info</a>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 md-margin-bottom-40">
                    <div class="card small">
                        <div class="card-image">
                            <img class="img-responsive" src="img/service2.jpg" alt="">
                        </div>
                        <div class="card-content">
                            <p>
                                <span class="price">BAR</span>
                                <h4>Excelentes vinos</h4>
                                <h5>Zonas Fumadores</h5>
                                <a href="rasturante.aspx" class="btn btn-details">Mas Info</a>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 md-margin-bottom-40">
                    <div class="card small">
                        <div class="card-image">
                            <img class="img-responsive" src="img/service3.jpg" alt="">
                        </div>
                        <div class="card-content">
                            <p>
                                <span class="price">SALA DE CONVENCIONES</span>
                                <h4>Preparativos especiales</h4>
                                <h5>Todas las ocaciones</h5>
                                <a href="eventos.aspx" class="btn btn-details">Mas Info</a>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>



</asp:Content>
