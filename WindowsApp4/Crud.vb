Imports System.Data.SqlClient

Public Class Crud

    Dim v As New Conn


    Public Function CUD(command As SqlCommand, sql As String) As Boolean

        command.CommandText = sql
        command.Connection = v.baglanti
        v.baglanti.Open()
        command.ExecuteNonQuery()
        Try

            Return True



        Catch ex As Exception
            Return False



        Finally
            v.baglanti.Close()

        End Try

    End Function

    Public Function List(sql As String) As DataTable
        Dim tbl As New DataTable
        Dim adtr As New SqlDataAdapter(sql, v.baglanti)
        adtr.Fill(tbl)

        Return tbl

    End Function


End Class
