Public Class Modulo_evento
    Inherits System.Web.UI.Page
    Dim nuevo_evento As New Bd_orquideasDataContext
    Dim evento As New tb_evento
    Dim cantidad_registros As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'llena el gridview con los Registros de los clientes
            Session("minimo") = 0
            mostrar_evento(CInt(Session("minimo")), 10)
        End If
    End Sub
    'abrir modal nuevo evento
    'cerrar modal nuevo evento
    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button10_ModalPopupExtender.Hide()
    End Sub
    Protected Sub button5_click(sende As Object, e As EventArgs) Handles Button5.Click
        'ingreso de Datos a Bd
        With evento
            .codigo_evento = codigo.Text
            .nombre = nombre.Text
            .costo = costo.Text
        End With
        nuevo_evento.tb_evento.InsertOnSubmit(evento)
        nuevo_evento.SubmitChanges()
        codigo.Text = ""
        nombre.Text = ""
        Button10_ModalPopupExtender.Hide()
        mostrar_evento(CInt(Session("minimo")), 10)
    End Sub
    Private Sub mostrar_evento(ByVal minimo As Integer, ByVal maximo As Integer)
        Dim datos = (From tabla In nuevo_evento.tb_evento
                     Select tabla Skip minimo Take maximo)
        GridView1.DataSource = datos
        GridView1.DataBind()
        'cantidad_registros = datos.Count()
    End Sub


    'cerrar modal de actualizacion
    Protected Sub button6_click(sender As Object, e As EventArgs) Handles Button6.Click
        Button1_ModalPopupExtender.Hide()

    End Sub
    'actualizacion de evento
    Protected Sub button7_click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim valor As String = CType(Application("codigo_evento"), String)
        Dim datos = From evento In nuevo_evento.tb_evento
                    Select evento Where evento.codigo_evento = valor
        For Each evento In datos
            evento.codigo_evento = codigo_m.Text
            evento.nombre = nombre_m.Text
        Next
        Try
            nuevo_evento.SubmitChanges()
            Response.Redirect("Modulo_evento.aspx")
        Catch ex As Exception
        End Try
    End Sub
    ' 'llenado de datos para actualizar o eliminar
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        'LLena Los Datos para Actualizar
        If e.CommandName = "actualizar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Application("codigo_evento") = GridView1.Rows(index).Cells(0).Text
            Dim valor As String = CStr(Application("codigo_evento"))
            Dim datos = From evento In nuevo_evento.tb_evento
                        Select evento Where evento.codigo_evento = valor
            For Each evento In datos
                codigo_m.Text = evento.codigo_evento
                nombre_m.Text = evento.nombre
                costo_m.Text = evento.costo
            Next
            Button1_ModalPopupExtender.Show()
        End If
        'llena los datos para Eliminar
        If e.CommandName = "eliminar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Application("codigo_evento") = GridView1.Rows(index).Cells(0).Text
            Dim valor As String = CType(Application("codigo_evento"), String)
            Dim datos = From evento In nuevo_evento.tb_evento
                        Select evento Where evento.codigo_evento = valor
            For Each evento In datos
                codigo_e.Text = evento.codigo_evento
                nombre_e.Text = evento.nombre
                costo_e.Text = evento.costo
            Next
            Button2_ModalPopupExtender.Show()
        End If
    End Sub
    'cerrar modal de eliminacion
    Protected Sub button11_click(sender As Object, e As EventArgs) Handles Button11.Click
        Button2_ModalPopupExtender.Hide()
    End Sub
    'eliminacion de evento
    Protected Sub button12_click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim id As String = CType(Application("codigo_evento"), String)
        Dim eliminar = From evento In nuevo_evento.tb_evento()
                       Where evento.codigo_evento = id
                       Select evento
        Try
            For Each evento As tb_evento In eliminar
                nuevo_evento.tb_evento.DeleteOnSubmit(evento)
            Next
            nuevo_evento.SubmitChanges()
            Response.Redirect("Modulo_evento.aspx")
            codigo_e.Text = ""
            nombre.Text = ""
        Catch ex As Exception
        End Try
    End Sub


    Protected Sub siguiente_click(sender As Object, e As EventArgs) Handles siguiente.ServerClick
        'cargar nmuevamenteo los datos auque no es recomentable mejor ahcerlo por partes
        'GridView1.PageIndex = GridView1.PageIndex + 1

        If CInt(Session("minimo")) <= cantidad_registros Then
            Session("minimo") = CInt(Session("minimo")) + 10
            mostrar_evento(CInt(Session("minimo")), 10)
        Else

        End If

    End Sub
    Protected Sub anterior_click(sender As Object, e As EventArgs) Handles anterior.ServerClick
        If CInt(Session("minimo")) = 0 Then

        Else
            Session("minimo") = CInt(Session("minimo")) - 10
            mostrar_evento(CInt(Session("minimo")), 10)

        End If
    End Sub
    Protected Sub todos_Click(sender As Object, e As EventArgs) Handles todos.ServerClick
        mostrar_evento(0, 10)
    End Sub
    Protected Sub buscar_Click(sender As Object, e As EventArgs) Handles Buscar.ServerClick
        If Len(Trim(TextBox1.Text)) = 0 Then
            MsgBox("el Campo Esta Vacio")
        Else
            Dim datos = (From tabla In nuevo_evento.tb_evento
                         Where tabla.nombre = TextBox1.Text
                         Select tabla)
            GridView1.DataSource = datos
            GridView1.DataBind()
            TextBox1.Text = ""
        End If
    End Sub
    Protected Sub nuevo_Click(sender As Object, e As EventArgs) Handles Nuevo.ServerClick
        Button10_ModalPopupExtender.Show()
    End Sub




End Class