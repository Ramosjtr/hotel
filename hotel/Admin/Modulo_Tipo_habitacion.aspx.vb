Public Class Modulo_Tipo_habitacion
    Inherits System.Web.UI.Page
    Dim nuevo_tipo As New Bd_orquideasDataContext
    Dim tipo As New tb_tipo
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    'abrir modal nuevo tipo
    Protected Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Button1_ModalPopupExtender.Show()
    End Sub
    'cerrar modal nuevo tipo
    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button1_ModalPopupExtender.Hide()
    End Sub
    Protected Sub button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        With tipo
            .codigo_Tipo = codigo.Text
            .nombre = nombre.Text
            .cantidad_personas = cantidad_personas.Text
        End With
        nuevo_tipo.tb_tipo.InsertOnSubmit(tipo)
        nuevo_tipo.SubmitChanges()
        codigo.Text = ""
        nombre.Text = ""
        cantidad_personas.Text = ""
        Button1_ModalPopupExtender.Hide()
        MsgBox("Guardado Correctamente")

    End Sub
End Class