Public Class Modulo_clientes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Button11_ModalPopupExtender.Show()

    End Sub
    Protected Sub button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button11_ModalPopupExtender.Hide()
    End Sub

End Class