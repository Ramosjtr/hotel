Public Class Modulo_paquetes
    Inherits System.Web.UI.Page
    Dim nuevo_paquete As New Bd_orquideasDataContext
    Dim paquete As New tb_paquete
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    'abrir modal de nuevo paquete
    Protected Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Button1_ModalPopupExtender.Show()
    End Sub
    'cerrar modal de nuevo paquete
    Protected Sub button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button1_ModalPopupExtender.Hide()
    End Sub
    'ingreso de Datos en La Bd
    Protected Sub button5_click(sender As Object, e As EventArgs) Handles Button5.Click
        With paquete
            .codigo_paquete = codigo.Text
            .nombre = nombre.Text
            .costo = costo.Text
        End With
        nuevo_paquete.tb_paquete.InsertOnSubmit(paquete)
        nuevo_paquete.SubmitChanges()
        codigo.Text = ""
        nombre.Text = ""
        costo.Text = ""
        Button1_ModalPopupExtender.Hide()
        MsgBox("Guardado Correctamente")
    End Sub

End Class