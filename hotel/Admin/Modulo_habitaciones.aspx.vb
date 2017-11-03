Public Class Modulo_habitaciones

    Inherits System.Web.UI.Page
    Dim nueva_habitacion As New Bd_orquideasDataContext
    Dim habitacion As New tb_habitacion
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub
    'abrir modal nueva habitacion
    Protected Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Button1_ModalPopupExtender.Show()
    End Sub
    'cerrar modal para nueva habitacion
    Protected Sub butto4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button1_ModalPopupExtender.Hide()
    End Sub
    Protected Sub button5_click(sender As Object, e As EventArgs) Handles Button5.Click
        'ingreso de Datos a la Bd
        With habitacion
            .codigo_habitacion = codigo.Text
            .metros = metros.Text
            .cantidad_camas = Cantidad_camas.Text
            .costo = Costo.Text
            .estado = Estado.Text
            .tipo_habitacion = Tipo_habitacion.Text
        End With
        nueva_habitacion.tb_habitacion.InsertOnSubmit(habitacion)
        nueva_habitacion.SubmitChanges()
        codigo.Text = ""
        metros.Text = ""
        Cantidad_camas.Text = ""
        Costo.Text = ""
        Estado.Text = ""
        Tipo_habitacion.Text = ""
        Button1_ModalPopupExtender.Hide()

    End Sub
End Class