<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Vistas/Maestro.Master" CodeBehind="incio.aspx.vb" Inherits="hotel.incio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="inner-headline">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <h2 class="pageTitle">CENTRO DE CONVENCIONES Y EVENTOS</h2>
                </div>
            </div>
        </div>
    </section>
    <section id="content">
        <section class="section-padding">
            <section class="section-padding gray-bg">
                <div class="container">
                    <div class="row">
                        <div class="col-md-6 col-sm-6">
                            <div class="about-image">
                                <img src="img/eventos/evento1.jpg" alt="About Images">
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-6">
                            <div class="about-text">
                                <h3>Grandes Eventos</h3>
                                <p style="text-align: justify;">Hotel las Golondrinas es el lugar perfecto para realizar convenciones, reuniones, conferencias, matrimonios y otros </p>
                                <p style="text-align: justify;">Cuenta con 3 amplios salones con luz natural, toda la tecnologia para realizar diferentes montajes y la mas amplia carta de banqueteria con: </p>
                                <p>- Desayuno</p>
                                <p>- Coffe Breaks</p>
                                <p>- Almuerzos</p>
                                <p>- Cocktails</p>
                                <p>- Cenas</p>
                                <p>- Todo segun necesidad</p>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </section>
    </section>

    <section id="content">
        <div class="container">
            <div class="about">                  
                <div class="row service-v1 margin-bottom-40">
                    <div class="col-md-4 md-margin-bottom-40">
                        <div class="card small">
                            <div class="card-image">
                                <img class="img-responsive" src="img/eventos/evento2.jpg" alt="">
                            </div>
                            <div class="card-content">
                                <p>
                                    <h4>Salon "El pilar"</h4>
                                    <h5>Las Golondrinas</h5>
                                    <a href="reserva.aspx" class="btn btn-details">Reserva</a>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 md-margin-bottom-40">
                        <div class="card small">
                            <div class="card-image">
                                <img class="img-responsive" src="img/eventos/evento3.jpg" alt="">
                            </div>
                            <div class="card-content">
                                <p>
                                    <h4>Salon "El Diamante"</h4>
                                    <h5>Las Golondrinas</h5>
                                    <a href="reserva.html" class="btn btn-details">Reserva</a>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 md-margin-bottom-40">
                        <div class="card small">
                            <div class="card-image">
                                <img class="img-responsive" src="img/eventos/evento4.jpg" alt="">
                            </div>
                            <div class="card-content">
                                <p>
                                    <h4>Salon "La Perla"</h4>
                                    <h5>Las Golondrinas</h5>
                                    <a href="reserva.html" class="btn btn-details">Reserva</a>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
