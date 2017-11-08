Public Class Modulo_usuarios
    Inherits System.Web.UI.Page
    Dim nuevo_usuario As New Bd_orquideasDataContext
    Dim usuario As New tb_usuarios
    Dim cantidad_registros As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'llena el gridview con los Registros de los clientes
            Session("minimo") = 0
            mostrar_usuarios(CInt(Session("minimo")), 10)
        End If
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

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        'LLena Los Datos para Actualizar
        If e.CommandName = "actualizar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            Application("codigo_usuario") = GridView1.Rows(index).Cells(0).Text
            Dim valor As String = CStr(Application("codigo_usuario"))
            Dim datos = From usuario In nuevo_usuario.tb_usuarios
                        Select usuario Where usuario.codigo_usuario = valor
            For Each usuario In datos
                usuario_m.Text = usuario.nombre
                contraseña_m.Text = usuario.contraseña
            Next
            Button2_ModalPopupExtender.Show()
        End If
        'llena los datos para Eliminar
        If e.CommandName = "eliminar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Application("codigo_usuario") = GridView1.Rows(index).Cells(0).Text
            Dim valor As String = CType(Application("codigo_usuario"), String)
            Dim datos = From usuario In nuevo_usuario.tb_usuarios
                        Select usuario Where usuario.codigo_usuario = valor
            For Each usuario In datos
                usuario_e.Text = usuario.nombre
                contraseña_e.Text = usuario.contraseña
            Next
            Button10_ModalPopupExtender.Show()
        End If
    End Sub
    'cerrar modal de actualizacion 
    Protected Sub button6_click(sender As Object, e As EventArgs) Handles Button6.Click
        Button2_ModalPopupExtender.Hide()
    End Sub
    'actualizacion de usuarios
    Protected Sub button7_click(sender As Object, e As EventArgs) Handles Button7.Click

        Dim valor As String = CType(Application("codigo_usuario"), String)
        Dim datos = From usuario In nuevo_usuario.tb_usuarios
                    Select usuario Where usuario.codigo_usuario = valor
        For Each usuario In datos
            usuario.nombre = usuario_m.Text
            usuario.contraseña = contraseña_m.Text
        Next
        Try
            nuevo_usuario.SubmitChanges()
            Response.Redirect("Modulo_usuarios.aspx")
        Catch ex As Exception
        End Try
    End Sub
    'cerrar modal de eliminacion
    Protected Sub button11_click(sender As Object, e As EventArgs) Handles Button11.Click
        Button10_ModalPopupExtender.Hide()
    End Sub
    'Eliminar Usuario
    Protected Sub button12_click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim id As String = CType(Application("codigo_usuario"), String)
        Dim eliminar = From usuario In nuevo_usuario.tb_usuarios()
                       Where usuario.codigo_usuario = id
                       Select usuario
        Try
            For Each usuario As tb_usuarios In eliminar
                nuevo_usuario.tb_usuarios.DeleteOnSubmit(usuario)
            Next
            nuevo_usuario.SubmitChanges()
            Response.Redirect("Modulo_usuarios.aspx")
            usuario_e.Text = ""
            contraseña_e.Text = ""
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub siguiente_click(sender As Object, e As EventArgs) Handles siguiente.ServerClick
        'cargar nmuevamenteo los datos auque no es recomentable mejor ahcerlo por partes
        'GridView1.PageIndex = GridView1.PageIndex + 1

        If CInt(Session("minimo")) <= cantidad_registros Then
            Session("minimo") = CInt(Session("minimo")) + 10
            mostrar_usuarios(CInt(Session("minimo")), 10)
        Else

        End If

    End Sub
    Protected Sub anterior_click(sender As Object, e As EventArgs) Handles anterior.ServerClick
        If CInt(Session("minimo")) = 0 Then

        Else
            Session("minimo") = CInt(Session("minimo")) - 10
            mostrar_usuarios(CInt(Session("minimo")), 10)

        End If
    End Sub
    Protected Sub todos_Click(sender As Object, e As EventArgs) Handles todos.ServerClick
        mostrar_usuarios(0, 10)
    End Sub
    Protected Sub buscar_Click(sender As Object, e As EventArgs) Handles Buscar.ServerClick
        If Len(Trim(TextBox1.Text)) = 0 Then
            MsgBox("el Campo Esta Vacio")
        Else
            Dim datos = (From tabla In nuevo_usuario.tb_usuarios
                         Where tabla.nombre = TextBox1.Text
                         Select tabla)
            GridView1.DataSource = datos
            GridView1.DataBind()
            TextBox1.Text = ""
        End If
    End Sub
    Protected Sub nuevo_Click(sender As Object, e As EventArgs) Handles Nuevo.ServerClick
        Button1_ModalPopupExtender.Show()
    End Sub

End Class