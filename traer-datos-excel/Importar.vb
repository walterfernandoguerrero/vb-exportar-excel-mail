Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System
Imports Microsoft.VisualBasic
'Imports Microsoft.Office.Interop.Excel




Module Importar

    Sub importarExcel(ByVal tabla As DataGridView)
        Dim myFileDialog As New OpenFileDialog()
        Dim xSheet As String = ""

        With myFileDialog
            .Filter = "Excel Files |*.xlsx"
            .Title = "Open File"
            .ShowDialog()
        End With

        If myFileDialog.FileName.ToString <> "" Then

            Dim ExcelFile As String = myFileDialog.FileName.ToString

            Dim ds As New DataSet
            Dim da As OleDbDataAdapter
            Dim dt As DataTable
            Dim conn As OleDbConnection

            xSheet = InputBox("digite el nombre de la hoja que decea importar (debe ser como esta en su planilla)", "Completar")

            conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" &
                                       "data source= " & ExcelFile & "; " &
                                       "Extended Properties='Excel 12.0 Xml;HDR=Yes'")

            MsgBox("si se conecto ")

            Try
                da = New OleDbDataAdapter("select * from [" & xSheet & "$]", conn)
                conn.Open()
                da.Fill(ds, "MyData")
                dt = ds.Tables("MyData")
                tabla.DataSource = ds
                tabla.DataMember = "MyData"


            Catch ex As Exception
                MsgBox("no se pudo")
            End Try


        End If


    End Sub




End Module
