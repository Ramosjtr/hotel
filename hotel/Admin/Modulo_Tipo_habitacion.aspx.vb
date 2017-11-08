Public Class Modulo_Tipo_habitacion
    Inherits System.Web.UI.Page
    Dim nuevo_tipo As New Bd_orquideasDataContext
    Dim tipo As New tb_tipo
    Dim cantidad_registros As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'llena el gridview con los Registros de los clientes
            Session("minimo") = 0
            mostrar_Tipo(CInt(Session("minimo")), 10)
        End If
    End Sub
    'cerrar modal nuevo tipo
    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button1_ModalPopupExtender.Hide()
    End Sub
    Protected Sub button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        With tipo
            .codigo_Tipo = codigo.Text
            .nombre = nombre.Text
            .descripcion = descripcion.Text
        End With
        nuevo_tipo.tb_tipo.InsertOnSubmit(tipo)
        nuevo_tipo.SubmitChanges()
        codigo.Text = ""
        nombre.Text = ""
        descripcion.Text = ""
        Button1_ModalPopupExtender.Hide()
        mostrar_Tipo(CInt(Session("minimo")), 10)
    End Sub
    Private Sub mostrar_Tipo(ByVal minimo As Integer, ByVal maximo As Integer)
        Dim datos = (From tabla In nuevo_tipo.tb_tipo
                     Select tabla Skip minimo Take maximo)
        GridView1.DataSource = datos
        GridView1.DataBind()
        'cantidad_registros = datos.Count()
    End Sub
    Protected Sub button6_click(sender As Object, e As EventArgs) Handles Button6.Click
        Button2_ModalPopupExtender.Hide()
    End Sub

    'actualizar tipo de habitacion
    Protected Sub button7_click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim valor As String = CType(Application("codigo_tipo"), String)
        Dim datos = From tipo In nuevo_tipo.tb_tipo
                    Select tipo Where tipo.codigo_Tipo = valor
        For Each tipo In datos
            tipo.codigo_Tipo = codigo_m.Text
            tipo.nombre = nombre_m.Text
            tipo.descripcion = descripcion_m.Text
        Next
        Try
            nuevo_tipo.SubmitChanges()
            Response.Redirect("Modulo_Tipo_habitacion.aspx")
        Catch ex As Exception
        End Try
    End Sub
    'cerrar modal de eliminacion
    Protected Sub button11_click(sender As Object, e As EventArgs) Handles Button11.Click
        Button10_ModalPopupExtender.Hide()
    End Sub
    'Eliminar Tipo De Habitacion
    Protected Sub button12_click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim id As String = CType(Application("codigo_tipo"), String)
        Dim eliminar = From tipo In nuevo_tipo.tb_tipo()
                       Where tipo.codigo_Tipo = id
                       Select tipo
        Try
            For Each tipo As tb_tipo In eliminar
                nuevo_tipo.tb_tipo.DeleteOnSubmit(tipo)
            Next
            nuevo_tipo.SubmitChanges()
            Response.Redirect("Modulo_Tipo_habitacion.aspx")
            codigo_e.Text = ""
            nombre_e.Text = ""
            descripcion_e.Text = ""
        Catch ex As Exception
        End Try
    End Sub
    ''llenado de datos para actualizar o eliminar
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        'LLena Los Datos para Actualizar
        If e.CommandName = "actualizar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Application("codigo_tipo") = GridView1.Rows(index).Cells(0).Text
            Dim valor As String = CStr(Application("codigo_tipo"))
            Dim datos = From tipo In nuevo_tipo.tb_tipo
                        Select tipo Where tipo.codigo_Tipo = valor
            For Each tipo In datos
                codigo_m.Text = tipo.codigo_Tipo
                nombre_m.Text = tipo.nombre
                descripcion_m.Text = tipo.descripcion
            Next
            Button2_ModalPopupExtender.Show()
        End If
        'llena los datos para Eliminar
        If e.CommandName = "eliminar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Application("codigo_tipo") = GridView1.Rows(index).Cells(0).Text
            Dim valor As String = CType(Application("codigo_tipo"), String)
            Dim datos = From tipo In nuevo_tipo.tb_tipo
                        Select tipo Where tipo.codigo_Tipo = valor
            For Each tipo In datos
                codigo_e.Text = tipo.codigo_Tipo
                nombre_e.Text = tipo.nombre
                descripcion_e.Text = tipo.descripcion
            Next
            Button10_ModalPopupExtender.Show()
        End If
    End Sub
    Protected Sub siguiente_click(sender As Object, e As EventArgs) Handles siguiente.ServerClick
        'cargar nmuevamenteo los datos auque no es recomentable mejor ahcerlo por partes
        'GridView1.PageIndex = GridView1.PageIndex + 1
        If CInt(Session("minimo")) <= cantidad_registros Then
            Session("minimo") = CInt(Session("minimo")) + 10
            mostrar_Tipo(CInt(Session("minimo")), 10)
        Else
        End If
    End Sub
    Protected Sub anterior_click(sender As Object, e As EventArgs) Handles anterior.ServerClick
        If CInt(Session("minimo")) = 0 Then
        Else
            Session("minimo") = CInt(Session("minimo")) - 10
            mostrar_Tipo(CInt(Session("minimo")), 10)
        End If
    End Sub
    Protected Sub todos_Click(sender As Object, e As EventArgs) Handles todos.ServerClick
        mostrar_Tipo(0, 10)
    End Sub
    Protected Sub buscar_Click(sender As Object, e As EventArgs) Handles Buscar.ServerClick
        If Len(Trim(TextBox1.Text)) = 0 Then
            MsgBox("el Campo Esta Vacio")
        Else
            Dim datos = (From tabla In nuevo_tipo.tb_tipo
                         Where tabla.nombre = TextBox1.Text
                         Select tabla)
            GridView1.DataSource = datos
            GridView1.DataBind()
            TextBox1.Text = ""
        End If
    End Sub
    Protected Sub nuevo_Click(sender As Object, e As EventArgs) Handles nuevo.ServerClick
        Button1_ModalPopupExtender.Show()
    End Sub
End Class