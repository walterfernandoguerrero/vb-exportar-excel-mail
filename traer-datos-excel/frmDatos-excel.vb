Imports System.IO
Imports System.Data
Imports System.Data.OleDb


Public Class frmDatos_excel
    'variables globales
    Dim cadenaUbicacion As String
    Dim area As String
    Dim rango As String

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        Dim dir As String
        Dim fileOpen As New OpenFileDialog 'variable de tipo dialogo
        fileOpen.ShowDialog() 'abrir el dialogo
        dir = fileOpen.FileName 'tomo la cadena del dialog
        txtDireccion.Text = dir
        '--------------primera prueba ok

        cadenaUbicacion = dir
        txtHoja.Focus() 'listo
    End Sub

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        'pasamos los valores para leer el rango y cargar los datos de la hoja de calculo de excel
        area = txtHoja.Text
        rango = txtRango.Text
        funcCargarHoja(cadenaUbicacion, area, rango, dgvListaExcel)
    End Sub

    Private Function funcCargarHoja(ByVal cadenaUbicacion As String, area As String, rango As String, miLista As DataGridView)

        Try
            'comprobar existencia del archivo
            If File.Exists(cadenaUbicacion) Then
                Dim objDataset As DataSet
                Dim objDataAdapter As OleDbDataAdapter

                'declaramos la conexion al archivo proveedor de office 
                Dim cadenaConexion As String
                cadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;" &
                                       "data source= " & cadenaUbicacion & "; " &
                                       "Extended Properties='Excel 12.0 Xml;HDR=Yes'"
                'objeto de conexion instancia
                Dim cnn As OleDbConnection

                cnn = New OleDbConnection(cadenaConexion)
                ' cnn.Open()

                MsgBox("se conecto a el archivo")
                '---------------------prueba 2 ok------------------------------
                Dim consultaSQL As String = "select * from " & "[" & area & "$" & rango & "]" ' ejempllo  [Hoja1 $ A1C12]
                'instancia del objeto Adaptador consulta + conexion
                objDataAdapter = New OleDbDataAdapter(consultaSQL, cnn)
                'instancia del objeto dataset prepara en memoria para copia de datos 
                objDataset = New DataSet
                'paso de la memoria al adaptador de vb
                objDataAdapter.Fill(objDataset)
                cnn.Close()
                With miLista
                    .DataSource = objDataset
                    .DataMember = objDataset.Tables(0).TableName
                End With
            Else
                MsgBox("no se pudo conectar a el archivo: " & cadenaUbicacion)
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function

End Class