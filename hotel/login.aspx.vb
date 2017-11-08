Public Class login
    Inherits System.Web.UI.Page
    Dim ctx As New Bd_orquideasDataContext
    Dim bandera As Integer = 1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim buscar = From x In ctx.tb_usuarios Where x.nombre = usuario1.Value Select x
        For Each x In buscar
            If (String.Compare(x.contraseña, contraseña1.Value) = 0) Then
                Response.Redirect("Admin/principal.aspx")
            Else
                MsgBox("Usuario O Contraseña Incorrecta")
            End If
        Next

    End Sub
End Class