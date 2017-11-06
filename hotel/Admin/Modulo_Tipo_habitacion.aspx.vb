Public Class Modulo_Tipo_habitacion
    Inherits System.Web.UI.Page
    Dim nuevo_tipo As New Bd_orquideasDataContext
    Dim tipo As New tb_tipo
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'llena el gridview con los Registros de los clientes
            Session("minimo") = 0
            mostrar_Tipo(CInt(Session("minimo")), 10)
        End If
    End Sub
    'abrir modal nuevo tipo
    Protected Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Button1_ModalPopupExtender.Show()
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
End Class