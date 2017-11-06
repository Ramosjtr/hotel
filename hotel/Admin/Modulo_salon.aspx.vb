Public Class Modulo_salon
    Inherits System.Web.UI.Page
    Dim nuevo_salon As New Bd_orquideasDataContext
    Dim salon As New tb_salon
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'llena el gridview con los Registros de los clientes
            Session("minimo") = 0
            mostrar_salon(CInt(Session("minimo")), 10)
        End If
    End Sub
    'abre modal de nuevo salon
    Protected Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Button1_ModalPopupExtender.Show()
    End Sub
    'cierra modal de nuevo salon
    Protected Sub button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button1_ModalPopupExtender.Hide()
    End Sub
    'ingreso de datos a la Bd
    Protected Sub button5_click(sender As Object, e As EventArgs) Handles Button5.Click
        With salon
            .codigo_salon = codigo.Text
            .nombre = nombre.Text
            .estado = estado.Text
        End With
        nuevo_salon.tb_salon.InsertOnSubmit(salon)
        nuevo_salon.SubmitChanges()
        codigo.Text = ""
        nombre.Text = ""
        estado.Text = ""
        Button1_ModalPopupExtender.Hide()
        mostrar_salon(CInt(Session("minimo")), 10)
    End Sub
    Private Sub mostrar_salon(ByVal minimo As Integer, ByVal maximo As Integer)
        Dim datos = (From tabla In nuevo_salon.tb_salon
                     Select tabla Skip minimo Take maximo)
        GridView1.DataSource = datos
        GridView1.DataBind()
        'cantidad_registros = datos.Count()
    End Sub
    'cerrar modal de actualizacion
    Protected Sub button6_click(sender As Object, e As EventArgs) Handles Button6.Click
        Button2_ModalPopupExtender.Hide()
    End Sub
    'Actualizar salon
    Protected Sub button7_click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim valor As String = CType(Application("codigo_salon"), String)
        Dim datos = From salon In nuevo_salon.tb_salon
                    Select salon Where salon.codigo_salon = valor
        For Each salon In datos
            salon.codigo_salon = codigo_m.Text
            salon.nombre = nombre_m.Text
            salon.estado = estado_m.Text
        Next
        Try
            nuevo_salon.SubmitChanges()
            Response.Redirect("Modulo_salon.aspx")
        Catch ex As Exception
        End Try


    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        'LLena Los Datos para Actualizar
        If e.CommandName = "actualizar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            Application("codigo_salon") = GridView1.Rows(index).Cells(0).Text
            Dim valor As String = CStr(Application("codigo_salon"))
            Dim datos = From salon In nuevo_salon.tb_salon
                        Select salon Where salon.codigo_salon = valor
            For Each salon In datos
                codigo_m.Text = salon.codigo_salon
                nombre_m.Text = salon.nombre
                estado_m.Text = salon.estado
            Next
            Button2_ModalPopupExtender.Show()
        End If
        'llena los datos para Eliminar
        If e.CommandName = "eliminar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Application("codigo_salon") = GridView1.Rows(index).Cells(0).Text
            Dim valor As String = CType(Application("codigo_salon"), String)
            Dim datos = From salon In nuevo_salon.tb_salon
                        Select salon Where salon.codigo_salon = valor
            For Each salon In datos
                codigo_e.Text = salon.codigo_salon
                nombre_e.Text = salon.nombre
                estado_e.Text = salon.estado
            Next
            Button10_ModalPopupExtender.Show()
        End If
    End Sub
    'cerrar modal de eliminacion
    Protected Sub button11_click(sender As Object, e As EventArgs) Handles Button11.Click
        Button10_ModalPopupExtender.Hide()
    End Sub
    'eliminar datos
    Protected Sub button12_click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim id As String = CType(Application("codigo_salon"), String)
        Dim eliminar = From salon In nuevo_salon.tb_salon()
                       Where salon.codigo_salon = id
                       Select salon
        Try
            For Each salon As tb_salon In eliminar
                nuevo_salon.tb_salon.DeleteOnSubmit(salon)
            Next
            nuevo_salon.SubmitChanges()
            Response.Redirect("Modulo_salon.aspx")
            codigo_e.Text = ""
            nombre_e.Text = ""
            estado_e.Text = ""
        Catch ex As Exception
        End Try
    End Sub

End Class