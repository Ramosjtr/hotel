Public Class Modulo_paquetes
    Inherits System.Web.UI.Page
    Dim nuevo_paquete As New Bd_orquideasDataContext
    Dim paquete As New tb_paquete
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'llena el gridview con los Registros de los clientes
            Session("minimo") = 0
            mostrar_paquetes(CInt(Session("minimo")), 10)
        End If
    End Sub
    'abrir modal de nuevo paquete
    Protected Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Button1_ModalPopupExtender.Show()
    End Sub
    'cerrar modal de nuevo paquete
    Protected Sub button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button1_ModalPopupExtender.Hide()
    End Sub
    'ingreso de Datos en La Bd
    Protected Sub button5_click(sender As Object, e As EventArgs) Handles Button5.Click
        With paquete
            .codigo_paquete = codigo.Text
            .nombre = nombre.Text
            .costo = costo.Text
        End With
        nuevo_paquete.tb_paquete.InsertOnSubmit(paquete)
        nuevo_paquete.SubmitChanges()
        codigo.Text = ""
        nombre.Text = ""
        costo.Text = ""
        Button1_ModalPopupExtender.Hide()
        mostrar_paquetes(CInt(Session("minimo")), 10)
    End Sub
    Private Sub mostrar_paquetes(ByVal minimo As Integer, ByVal maximo As Integer)
        Dim datos = (From tabla In nuevo_paquete.tb_paquete
                     Select tabla Skip minimo Take maximo)
        GridView1.DataSource = datos
        GridView1.DataBind()
        'cantidad_registros = datos.Count()
    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        'LLena Los Datos para Actualizar
        If e.CommandName = "actualizar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)

            Application("codigo_paquete") = GridView1.Rows(index).Cells(0).Text
            Dim valor As String = CStr(Application("codigo_paquete"))
            Dim datos = From paquete In nuevo_paquete.tb_paquete
                        Select paquete Where paquete.codigo_paquete = valor
            For Each paquete In datos
                codigo_m.Text = paquete.codigo_paquete
                nombre_m.Text = paquete.nombre
                costo_m.Text = paquete.costo
                '' cargo1. = empleado.cargo
            Next
            Button2_ModalPopupExtender.Show()
        End If
        'llena los datos para Eliminar
        If e.CommandName = "eliminar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Application("codigo_cliente") = GridView1.Rows(index).Cells(0).Text
            Dim valor As String = CType(Application("codigo_cliente"), String)
            Dim datos = From paquete In nuevo_paquete.tb_paquete
                        Select paquete Where paquete.codigo_paquete = valor
            For Each paquete In datos
                codigo_e.Text = paquete.codigo_paquete
                nombre_e.Text = paquete.nombre
                costo_e.Text = paquete.costo
            Next
            Button10_ModalPopupExtender.Show()
        End If
    End Sub
    'cerrar modal de actualizacion
    Protected Sub button6_click(sender As Object, e As EventArgs) Handles Button6.Click
        Button2_ModalPopupExtender.Hide()
    End Sub
    'actualizar paquete
    Protected Sub button7_click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim valor As String = CType(Application("codigo_paquete"), String)
        Dim datos = From paquete In nuevo_paquete.tb_paquete
                    Select paquete Where paquete.codigo_paquete = valor
        For Each paquete In datos
            paquete.codigo_paquete = codigo_m.Text
            paquete.nombre = nombre_m.Text
            paquete.costo = costo_m.Text
        Next
        Try
            nuevo_paquete.SubmitChanges()
            Response.Redirect("Modulo_paquetes.aspx")
        Catch ex As Exception
        End Try
    End Sub
    'cerrar modal de eliminacion de paquete
    Protected Sub button11_click(sender As Object, e As EventArgs) Handles Button11.Click
        Button10_ModalPopupExtender.Hide()
    End Sub
    'Eliminacion de paquete
    Protected Sub button12_click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim id As String = CType(Application("codigo_paquete"), String)
        Dim eliminar = From paquete In nuevo_paquete.tb_paquete()
                       Where paquete.codigo_paquete = id
                       Select paquete
        Try
            For Each paquete As tb_paquete In eliminar
                nuevo_paquete.tb_paquete.DeleteOnSubmit(paquete)
            Next
            nuevo_paquete.SubmitChanges()
            Response.Redirect("Modulo_paquetes.aspx")
            codigo_e.Text = ""
            nombre_e.Text = ""
            costo_e.Text = ""
        Catch ex As Exception
        End Try
    End Sub

End Class