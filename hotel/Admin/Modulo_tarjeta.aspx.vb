Public Class Modulo_tarjeta
    Inherits System.Web.UI.Page
    Dim nueva_tarjeta As New Bd_orquideasDataContext
    Dim tarjeta As New tb_tarjeta
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    'abre modal de nueva tarjeta
    Protected Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Button1_ModalPopupExtender.Show()
    End Sub
    'cierra modal de nueva tarjeta
    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button1_ModalPopupExtender.Hide()
    End Sub
    'ingreso de datos a la Bd
    Protected Sub button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        With tarjeta
            .titular = titular.Text
            .numero_tarjeta = codigo.Text
        End With
        nueva_tarjeta.tb_tarjeta.InsertOnSubmit(tarjeta)
        nueva_tarjeta.SubmitChanges()
        titular.Text = ""
        codigo.Text = ""
        Button1_ModalPopupExtender.Hide()
        MsgBox("Guardado Correctamente")

    End Sub
End Class