Public Class Modulo_usuarios
    Inherits System.Web.UI.Page
    Dim nuevo_usuario As New Bd_orquideasDataContext
    Dim usuario As New tb_usuarios
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'llena el gridview con los Registros de los clientes
            Session("minimo") = 0
            mostrar_usuarios(CInt(Session("minimo")), 10)
        End If
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
        mostrar_usuarios(CInt(Session("minimo")), 10)
    End Sub
    Private Sub mostrar_usuarios(ByVal minimo As Integer, ByVal maximo As Integer)
        Dim datos = (From tabla In nuevo_usuario.tb_usuarios
                     Select tabla Skip minimo Take maximo)
        GridView1.DataSource = datos
        GridView1.DataBind()
        'cantidad_registros = datos.Count()
    End Sub

End Class