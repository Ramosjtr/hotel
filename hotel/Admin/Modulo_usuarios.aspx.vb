﻿Public Class Modulo_usuarios
    Inherits System.Web.UI.Page
    Dim nuevo_usuario As New Bd_orquideasDataContext
    Dim usuario As New tb_usuarios
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    'abrir modal nuevo usuario
    Protected Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Button1_ModalPopupExtender.Show()
    End Sub
    'cerrar modal nuevo usuario
    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button1_ModalPopupExtender.Hide()
    End Sub
    'ingreso de Datos a Bd
    Protected Sub button5_click(sender As Object, e As EventArgs) Handles Button5.Click
        With usuario
            .nombre = nombre.Text
            .contraseña = contraseña.Text
        End With
        nuevo_usuario.tb_usuarios.InsertOnSubmit(usuario)
        nuevo_usuario.SubmitChanges()
        nombre.Text = ""
        contraseña.Text = ""
        Button1_ModalPopupExtender.Hide()
        MsgBox("Guardado Correctamente")
    End Sub

End Class