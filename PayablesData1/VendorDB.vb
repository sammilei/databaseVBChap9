Imports System.Data.SqlClient

Public Class VendorDB

    Public Shared Function GetVendorsWithBalanceDue() As List(Of Vendor)
        Dim vendorList As New List(Of Vendor)
        Dim connection As SqlConnection = PayablesDB.GetConnection
        Dim selectStatement As String =
            "SELECT VendorID, Name " &
             "FROM Vendors " &
             "WHERE (SELECT SUM(InvoiceTotal - PaymentTotal - CreditTotal) " &
             "       FROM Invoices " &
             "       WHERE Invoices.VendorID = Vendors.VendorID) " &
             "      > 0 " &
             "ORDER BY Name"
        Dim selectCommand As New SqlCommand(selectStatement, connection)
        Try
            connection.Open()
            Dim reader As SqlDataReader = selectCommand.ExecuteReader()
            Dim vendor As Vendor
            Do While reader.Read
                vendor = New Vendor
                vendor.VendorID = CInt(reader("VendorID"))
                vendor.Name = reader("Name").ToString
                vendorList.Add(vendor)
            Loop
            reader.Close()
        Catch ex As SqlException
            Throw ex
        Finally
            connection.Close()
        End Try
        Return vendorList
    End Function

    Public Shared Function GetVendorNameAndAddress(ByVal vendorID As Integer) As Vendor
        Dim vendor As New Vendor
        Dim connection As SqlConnection = PayablesDB.GetConnection
        Dim selectStatement As String =
            "SELECT VendorID, Name, Address1, Address2, City, State, ZipCode " &
            "FROM Vendors " &
            "WHERE VendorID = @VendorID"
        Dim selectCommand As New SqlCommand(selectStatement, connection)
        selectCommand.Parameters.AddWithValue("@VendorID", vendorID)

        Try
            connection.Open()
            Dim reader As SqlDataReader =
                selectCommand.ExecuteReader(CommandBehavior.SingleRow)
            If reader.Read Then
                vendor.VendorID = CInt(reader("VendorID"))
                vendor.Name = reader("Name").ToString
                vendor.Address1 = reader("Address1").ToString
                vendor.Address2 = reader("Address2").ToString
                vendor.City = reader("City").ToString
                vendor.State = reader("State").ToString
                vendor.ZipCode = reader("ZipCode").ToString
            Else
                vendor = Nothing
            End If
            reader.Close()
        Catch ex As SqlException
            Throw ex
        Finally
            connection.Close()
        End Try
        Return vendor
    End Function

End Class
