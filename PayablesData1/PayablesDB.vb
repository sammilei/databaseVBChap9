Imports System.Data.SqlClient

Public Class PayablesDB

    Public Shared Function GetConnection() As SqlConnection
        Dim connectionString As String _
            = "Data Source=localhost\sqlexpress;Initial Catalog=Payables;" &
            "Integrated Security=True"
        Return New SqlConnection(connectionString)
    End Function

End Class
