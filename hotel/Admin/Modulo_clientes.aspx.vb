Imports System.Data
Public Class Modulo_clientes
    Inherits System.Web.UI.Page
    Dim nuevo_cliente As New Bd_orquideasDataContext
    Dim cliente As New tb_cliente
    Dim cantidad_registros As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'llena el gridview con los Registros de los clientes
            Session("minimo") = 0
            mostrar_clientes(CInt(Session("minimo")), 10)
        End If
    End Sub

    'cerrar modal nuevo cliente
    Protected Sub button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button11_ModalPopupExtender.Hide()
        mostrar_clientes(CInt(Session("minimo")), 10)
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
        tarjeta.Text = ""
        Button11_ModalPopupExtender.Hide()

        mostrar_clientes(CInt(Session("minimo")), 10)
    End Sub
    Private Sub mostrar_clientes(ByVal minimo As Integer, ByVal maximo As Integer)
        Dim datos = (From tabla In nuevo_cliente.tb_cliente
                     Select tabla Skip minimo Take maximo)
        GridView1.DataSource = datos
        GridView1.DataBind()
        cantidad_registros = datos.Count()
    End Sub
    'llenado de datos para actualizar o eliminar
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        'LLena Los Datos para Actualizar
        If e.CommandName = "actualizar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            Application("codigo_cliente") = GridView1.Rows(index).Cells(0).Text
            Dim valor As String = CStr(Application("codigo_cliente"))
            Dim datos = From cliente In nuevo_cliente.tb_cliente
                        Select cliente Where cliente.codigo_cliente = valor
            For Each cliente In datos
                codigo_m.Text = cliente.codigo_cliente
                nombre_m.Text = cliente.nombre
                apellido_m.Text = cliente.apellido
                direccion_m.Text = cliente.direccion
                telefono_m.Text = cliente.telefono
                correo_m.Text = cliente.correo
                Tarjeta_m.Text = cliente.tb_tarjeta
                '' cargo1. = empleado.cargo
            Next
            Button1_ModalPopupExtender.Show()
        End If
        'llena los datos para Eliminar
        If e.CommandName = "eliminar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Application("codigo_cliente") = GridView1.Rows(index).Cells(0).Text
            Dim valor As String = CType(Application("codigo_cliente"), String)
            Dim datos = From cliente In nuevo_cliente.tb_cliente
                        Select cliente Where cliente.codigo_cliente = valor
            For Each cliente In datos
                nombre_e.Text = cliente.nombre
                apellido_e.Text = cliente.apellido
                telefono_e.Text = cliente.telefono
            Next
            Button2_ModalPopupExtender.Show()
        End If
    End Sub
    'cerrar modal de actualizar
    Protected Sub button6_click(sender As Object, e As EventArgs) Handles Button6.Click
        Button1_ModalPopupExtender.Hide()
        mostrar_clientes(CInt(Session("minimo")), 10)
    End Sub
    'Guarda Datos de actualizacion
    Protected Sub button7_click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim valor As String = CType(Application("codigo_cliente"), String)
        Dim datos = From cliente In nuevo_cliente.tb_cliente
                    Select cliente Where cliente.codigo_cliente = valor
        For Each cliente In datos
            cliente.codigo_cliente = codigo_m.Text
            cliente.nombre = nombre_m.Text
            cliente.apellido = apellido_m.Text
            cliente.direccion = direccion_m.Text
            cliente.telefono = telefono_m.Text
            cliente.tb_tarjeta = Tarjeta_m.Text
        Next
        Try
            nuevo_cliente.SubmitChanges()
            Response.Redirect("Modulo_clientes.aspx")
        Catch ex As Exception
        End Try
    End Sub
    'cierra modal de eliminacion
    Protected Sub button10_click(sender As Object, e As EventArgs) Handles Button10.Click
        Button2_ModalPopupExtender.Hide()
    End Sub
    'Elimina de La Bd
    Protected Sub button12_click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim id As String = CType(Application("codigo_cliente"), String)
        Dim eliminar = From cliente In nuevo_cliente.tb_cliente()
                       Where cliente.codigo_cliente = id
                       Select cliente
        Try
            For Each cliente As tb_cliente In eliminar
                nuevo_cliente.tb_cliente.DeleteOnSubmit(cliente)
            Next
            nuevo_cliente.SubmitChanges()
            Response.Redirect("Modulo_clientes.aspx")
            nombre.Text = ""
            apellido.Text = ""
            telefono.Text = ""
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub siguiente_click(sender As Object, e As EventArgs) Handles siguiente.ServerClick
        'cargar nmuevamenteo los datos auque no es recomentable mejor ahcerlo por partes
        'GridView1.PageIndex = GridView1.PageIndex + 1

        If CInt(Session("minimo")) <= cantidad_registros Then
            Session("minimo") = CInt(Session("minimo")) + 10
            mostrar_clientes(CInt(Session("minimo")), 10)
        Else

        End If

    End Sub
    Protected Sub anterior_click(sender As Object, e As EventArgs) Handles anterior.ServerClick
        If CInt(Session("minimo")) = 0 Then

        Else
            Session("minimo") = CInt(Session("minimo")) - 10
            mostrar_clientes(CInt(Session("minimo")), 10)

        End If
    End Sub

    Protected Sub todos_Click(sender As Object, e As EventArgs) Handles todos.ServerClick
        mostrar_clientes(0, 10)
    End Sub
    Protected Sub buscar_Click(sender As Object, e As EventArgs) Handles Buscar.ServerClick
        If Len(Trim(TextBox1.Text)) = 0 Then
            MsgBox("el Campo Esta Vacio")
        Else
            Dim datos = (From tabla In nuevo_cliente.tb_cliente
                         Where tabla.nombre = TextBox1.Text
                         Select tabla)
            GridView1.DataSource = datos
            GridView1.DataBind()
            TextBox1.Text = ""
        End If
    End Sub
    Protected Sub nuevo_Click(sender As Object, e As EventArgs) Handles Nuevo.ServerClick
        Button11_ModalPopupExtender.Show()
    End Sub


End Class