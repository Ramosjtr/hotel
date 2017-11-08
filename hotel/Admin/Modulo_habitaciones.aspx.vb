Public Class Modulo_habitaciones

    Inherits System.Web.UI.Page
    Dim nueva_habitacion As New Bd_orquideasDataContext
    Dim habitacion As New tb_habitacion
    Dim cantidad_registros As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'llena el gridview con los Registros de los clientes
            Session("minimo") = 0
            mostrar_habitaciones(CInt(Session("minimo")), 10)
        End If
        DropDownList1.Items.Add("ocupado")
    End Sub

    'cerrar modal para nueva habitacion
    Protected Sub butto4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button1_ModalPopupExtender.Hide()
    End Sub
    Protected Sub button5_click(sender As Object, e As EventArgs) Handles Button5.Click
        'ingreso de Datos a la Bd
        With habitacion
            .codigo_habitacion = codigo.Text
            .metros = metros.Text
            .cantidad_camas = Cantidad_camas.Text
            .costo = Costo.Text
            .estado = DropDownList1.SelectedItem.Value
            .tipo_habitacion = Tipo_habitacion.Text
        End With
        nueva_habitacion.tb_habitacion.InsertOnSubmit(habitacion)
        nueva_habitacion.SubmitChanges()
        codigo.Text = ""
        metros.Text = ""
        Cantidad_camas.Text = ""
        Costo.Text = ""
        Tipo_habitacion.Text = ""
        Button1_ModalPopupExtender.Hide()
        mostrar_habitaciones(CInt(Session("minimo")), 10)
    End Sub
    Private Sub mostrar_habitaciones(ByVal minimo As Integer, ByVal maximo As Integer)
        Dim datos = (From tabla In nueva_habitacion.tb_habitacion
                     Select tabla Skip minimo Take maximo)
        GridView1.DataSource = datos
        GridView1.DataBind()
        'cantidad_registros = datos.Count()
    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        'LLena Los Datos para Actualizar
        If e.CommandName = "actualizar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            Application("codigo_habitacion") = GridView1.Rows(index).Cells(0).Text
            Dim valor As String = CStr(Application("codigo_habitacion"))
            Dim datos = From habitacion In nueva_habitacion.tb_habitacion
                        Select habitacion Where habitacion.codigo_habitacion = valor
            For Each habitacion In datos
                codigo_m.Text = habitacion.codigo_habitacion
                metros_m.Text = habitacion.metros
                cantidad_m.Text = habitacion.cantidad_camas
                costo_m.Text = habitacion.costo
                estado_m.Text = habitacion.estado
                tipo_m.Text = habitacion.tipo_habitacion
            Next
            Button2_ModalPopupExtender.Show()
        End If
        'llena los datos para Eliminar
        If e.CommandName = "eliminar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Application("codigo_habitacion") = GridView1.Rows(index).Cells(0).Text
            Dim valor As String = CType(Application("codigo_habitacion"), String)
            Dim datos = From habitacion In nueva_habitacion.tb_habitacion
                        Select habitacion Where habitacion.codigo_habitacion = valor
            For Each habitacion In datos
                codigo_e.Text = habitacion.codigo_habitacion
                metros_e.Text = habitacion.metros
                cantidad_e.Text = habitacion.cantidad_camas
            Next
            Button10_ModalPopupExtender.Show()
        End If


    End Sub
    'cerrar modal de habitaciones
    Protected Sub button6_click(sender As Object, e As EventArgs) Handles Button6.Click
        Button2_ModalPopupExtender.Hide()
    End Sub
    'Actualizar habitaciones
    Protected Sub button7_click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim valor As String = CType(Application("codigo_habitacion"), String)
        Dim datos = From habitacion In nueva_habitacion.tb_habitacion
                    Select habitacion Where habitacion.codigo_habitacion = valor
        For Each habitacion In datos
            habitacion.codigo_habitacion = codigo_m.Text
            habitacion.metros = metros_m.Text
            habitacion.cantidad_camas = cantidad_m.Text
            habitacion.costo = costo_m.Text
            habitacion.estado = estado_m.Text
            habitacion.tipo_habitacion = tipo_m.Text
        Next
        Try
            nueva_habitacion.SubmitChanges()
            Response.Redirect("Modulo_habitaciones.aspx")
        Catch ex As Exception
        End Try
    End Sub
    'cerrar modal de eliminacion de habitacion
    Protected Sub button11_click(sender As Object, e As EventArgs) Handles Button11.Click
        Button10_ModalPopupExtender.Hide()
    End Sub
    'eliminacion de habitacion
    Protected Sub button12_click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim id As String = CType(Application("codigo_habitacion"), String)
        Dim eliminar = From habitacion In nueva_habitacion.tb_habitacion()
                       Where habitacion.codigo_habitacion = id
                       Select habitacion
        Try
            For Each habitacion As tb_habitacion In eliminar
                nueva_habitacion.tb_habitacion.DeleteOnSubmit(habitacion)
            Next
            nueva_habitacion.SubmitChanges()
            Response.Redirect("Modulo_habitaciones.aspx")
            codigo_e.Text = ""
            metros_e.Text = ""
            cantidad_e.Text = ""
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub siguiente_click(sender As Object, e As EventArgs) Handles siguiente.ServerClick
        'cargar nmuevamenteo los datos auque no es recomentable mejor ahcerlo por partes
        'GridView1.PageIndex = GridView1.PageIndex + 1

        If CInt(Session("minimo")) <= cantidad_registros Then
            Session("minimo") = CInt(Session("minimo")) + 10
            mostrar_habitaciones(CInt(Session("minimo")), 10)
        Else

        End If

    End Sub
    Protected Sub anterior_click(sender As Object, e As EventArgs) Handles anterior.ServerClick
        If CInt(Session("minimo")) = 0 Then

        Else
            Session("minimo") = CInt(Session("minimo")) - 10
            mostrar_habitaciones(CInt(Session("minimo")), 10)

        End If
    End Sub
    Protected Sub todos_Click(sender As Object, e As EventArgs) Handles todos.ServerClick
        mostrar_habitaciones(0, 10)
    End Sub
    Protected Sub buscar_Click(sender As Object, e As EventArgs) Handles Buscar.ServerClick
        If Len(Trim(TextBox1.Text)) = 0 Then
            MsgBox("el Campo Esta Vacio")
        Else
            Dim datos = (From tabla In nueva_habitacion.tb_habitacion
                         Where tabla.codigo_habitacion = TextBox1.Text
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