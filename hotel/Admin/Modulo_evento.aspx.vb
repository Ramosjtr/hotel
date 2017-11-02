Public Class Modulo_evento
    Inherits System.Web.UI.Page
    Dim nuevo_evento As New Bd_orquideasDataContext
    Dim evento As New tb_evento


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    'abrir modal nuevo evento
    Protected Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Button10_ModalPopupExtender.Show()
    End Sub
    'cerrar modal nuevo evento
    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button10_ModalPopupExtender.Hide()
    End Sub
    Protected Sub button5_click(sende As Object, e As EventArgs) Handles Button5.Click
        'ingreso de Datos a Bd
        With evento
            .codigo_evento = codigo.Text
            .nombre = nombre.Text
        End With
        nuevo_evento.tb_evento.InsertOnSubmit(evento)
        nuevo_evento.SubmitChanges()
        codigo.Text = ""
        nombre.Text = ""
        Button10_ModalPopupExtender.Hide()
        MsgBox("Guardado Correctamente")



    End Sub
End Class