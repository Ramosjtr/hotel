Imports System.Data
Public Class Modulo_clientes
    Inherits System.Web.UI.Page
    Dim nuevo_cliente As New Bd_orquideasDataContext
    Dim cliente As New tb_cliente
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    'abrir modal nuevo cliente
    Protected Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Button11_ModalPopupExtender.Show()
    End Sub
    'cerrar modal nuevo cliente
    Protected Sub button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button11_ModalPopupExtender.Hide()
    End Sub
    Protected Sub button5_click(sender As Object, e As EventArgs) Handles Button5.Click
        'ingreso de datos a BD
        With cliente
            .codigo_cliente = codigo.Text
            .nombre = nombre.Text
            .apellido = apellido.Text
            .direccion = direccion.Text
            .telefono = telefono.Text
            .correo = correo.Text
            .tb_tarjeta = tarjeta.Text
        End With
        nuevo_cliente.tb_cliente.InsertOnSubmit(cliente)
        nuevo_cliente.SubmitChanges()
        codigo.Text = ""
        nombre.Text = ""
        apellido.Text = ""
        direccion.Text = ""
        telefono.Text = ""
        correo.Text = ""
        Button11_ModalPopupExtender.Hide()
        MsgBox("Guardado Correctamente")
    End Sub
End Class