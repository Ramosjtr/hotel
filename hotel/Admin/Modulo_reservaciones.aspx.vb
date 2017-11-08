Public Class Modulo_reservaciones
    Inherits System.Web.UI.Page
    Dim nueva_reservacion As New Bd_orquideasDataContext
    Dim reservacion As New vista_reservacion
    Dim cantidad_registros As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'llena el gridview con los Registros de los clientes
            Session("minimo") = 0
            mostrar_reservacion(CInt(Session("minimo")), 10)
        End If
    End Sub
    Private Sub mostrar_reservacion(ByVal minimo As Integer, ByVal maximo As Integer)
        Dim datos = (From tabla In nueva_reservacion.vista_reservacion
                     Select tabla Skip minimo Take maximo)
        GridView1.DataSource = datos
        GridView1.DataBind()
        cantidad_registros = datos.Count()
    End Sub
    Protected Sub siguiente_click(sender As Object, e As EventArgs) Handles siguiente.ServerClick
        'cargar nmuevamenteo los datos auque no es recomentable mejor ahcerlo por partes
        'GridView1.PageIndex = GridView1.PageIndex + 1

        If CInt(Session("minimo")) <= cantidad_registros Then
            Session("minimo") = CInt(Session("minimo")) + 10
            mostrar_reservacion(CInt(Session("minimo")), 10)
        Else

        End If

    End Sub
    Protected Sub anterior_click(sender As Object, e As EventArgs) Handles anterior.ServerClick
        If CInt(Session("minimo")) = 0 Then

        Else
            Session("minimo") = CInt(Session("minimo")) - 10
            mostrar_reservacion(CInt(Session("minimo")), 10)

        End If
    End Sub
    Protected Sub todos_Click(sender As Object, e As EventArgs) Handles todos.ServerClick
        mostrar_reservacion(0, 10)
    End Sub
    Protected Sub buscar_Click(sender As Object, e As EventArgs) Handles Buscar.ServerClick
        If Len(Trim(TextBox1.Text)) = 0 Then
            MsgBox("el Campo Esta Vacio")
        Else
            Dim datos = (From tabla In nueva_reservacion.vista_reservacion
                         Where tabla.numero_documento = TextBox1.Text
                         Select tabla)
            GridView1.DataSource = datos
            GridView1.DataBind()
            TextBox1.Text = ""
        End If
    End Sub



End Class