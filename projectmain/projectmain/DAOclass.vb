Imports System.Data.SqlClient

Public Class DAOclass
    Private conn As SqlConnection

    Public Sub New()
        conn = New SqlConnection("Data Source=103.212.121.67;Initial Catalog=Data_Stu2;Persist Security Info=True;User ID=data_stu2;Password=Lovecoding@6750")
        Try
            conn.Open()
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("ex.message")
        End Try
    End Sub
    Public Sub closeconnection()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub
    Public Function getdata(ByVal str As String) As SqlDataReader
        Dim obj As SqlDataReader
        conn.Open()
        Dim cmd As New SqlCommand(str, conn)
        obj = cmd.ExecuteReader
        Return obj
        conn.Close()
    End Function

    Public Sub modifydata(ByVal str As String)
        Dim cmd As New SqlCommand(str, conn)
        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub

    Public Function loaddata(ByVal str As String) As Data.DataSet
        Dim ds As New Data.DataSet
        Dim da As New SqlDataAdapter(str, conn)
        conn.Open()
        da.SelectCommand.ExecuteReader()
        conn.Close()
        da.Fill(ds)
        Return ds
    End Function

    Public Function number_valdate(ByVal c As Char, ByVal hc As Integer) As Boolean
        Dim f As Boolean = True
        If (c <> "" And IsNumeric(c)) Or hc = 524296 Or hc = 3014702 Then 'for allowing backspace and dot'
            f = False
        End If
        Return f
    End Function

    Public Function Isalpha_valdate(ByVal c As Char, ByVal hc As Integer) As Boolean
        Dim f As Boolean = True
        If (UCase(c) >= "A" And UCase(c) <= "Z") Or IsNumeric(c) Or hc = 524296 Or hc = 3014702 Or c = " " Then
            f = False
        End If
        Return f
    End Function
    Public Function validate(ByVal str As String) As Integer
        Dim f As Integer = 0
        Dim obj As SqlDataReader
        obj = getdata(str)
        While obj.Read()
            f = 1

        End While
        conn.Close()
        Return f
    End Function
End Class
