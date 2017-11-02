Public Class Modulo_salon
    Inherits System.Web.UI.Page
    Dim nuevo_salon As New Bd_orquideasDataContext
    Dim salon As New tb_salon
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    'abre modal de nuevo salon
    Protected Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Button1_ModalPopupExtender.Show()
    End Sub
    'cierra modal de nuevo salon
    Protected Sub button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button1_ModalPopupExtender.Hide()
    End Sub
    'ingreso de datos a la Bd
    Protected Sub button5_click(sender As Object, e As EventArgs) Handles Button5.Click
        With salon
            .codigo_salon = codigo.Text
            .nombre = nombre.Text
            .estado = estado.Text
        End With
        nuevo_salon.tb_salon.InsertOnSubmit(salon)
        nuevo_salon.SubmitChanges()
        codigo.Text = ""
        nombre.Text = ""
        estado.Text = ""
        Button1_ModalPopupExtender.Hide()
        MsgBox("Guardado Correctamente")
    End Sub
End Class