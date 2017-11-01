Public Class login
    Inherits System.Web.UI.Page
    Dim ctx As New Bd_orquideasDataContext
    Dim bandera As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'verificacion de cuenta para acceder a la aplicacion
        'Dim buscar = From x In ctx.tb_usuarios Where x.nombre = usuario1.Value Select x
        'For Each x In buscar
        '    If (String.Compare(x.nombre, usuario1.Value) = 0) Then
        '        MsgBox("usuario encontrado")
        '        bandera = 0
        '    End If
        'Next x
        Response.Redirect("Admin/principal.aspx")

    End Sub
End Class