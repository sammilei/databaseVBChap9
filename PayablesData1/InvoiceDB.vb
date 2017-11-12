Imports System.Data.SqlClient

Public Class InvoiceDB

    Public Shared Function GetUnpaidVendorInvoices(
             ByVal vendorID As Integer) As List(Of Invoice)
        Dim invoiceList As New List(Of Invoice)
        Dim connection As SqlConnection = PayablesDB.GetConnection
        Dim selectStatement As String =
            "SELECT InvoiceID, VendorID, InvoiceNumber, InvoiceDate, " &
             "InvoiceTotal, PaymentTotal, CreditTotal, " &
             "TermsID, DueDate, PaymentDate " &
             "FROM Invoices " &
             "WHERE VendorID = @VendorID " &
             "  AND InvoiceTotal - PaymentTotal - CreditTotal > 0 " &
             "ORDER BY InvoiceDate"
        Dim selectCommand As New SqlCommand(selectStatement, connection)
        selectCommand.Parameters.AddWithValue("@VendorID", vendorID)
        Try
            connection.Open()
            Dim reader As SqlDataReader = selectCommand.ExecuteReader()
            Dim invoice As Invoice
            Do While reader.Read
                invoice = New Invoice
                invoice.InvoiceID = CInt(reader("InvoiceID"))
                invoice.VendorID = CInt(reader("VendorID"))
                invoice.InvoiceNumber = reader("InvoiceNumber").ToString
                invoice.InvoiceDate = CDate(reader("InvoiceDate"))
                invoice.InvoiceTotal = CDec(reader("InvoiceTotal"))
                invoice.PaymentTotal = CDec(reader("PaymentTotal"))
                invoice.CreditTotal = CDec(reader("CreditTotal"))
                invoice.TermsID = CInt(reader("TermsID"))
                invoice.DueDate = CDate(reader("DueDate"))
                If IsDBNull(reader("PaymentDate")) Then
                    invoice.PaymentDate = Nothing
                Else
                    invoice.PaymentDate = CDate(reader("PaymentDate"))
                End If
                invoiceList.Add(invoice)
            Loop
            reader.Close()
        Catch ex As SqlException
            Throw ex
        Finally
            connection.Close()
        End Try
        Return invoiceList
    End Function

    Public Shared Function UpdatePayment(ByVal oldInvoice As Invoice,
            ByVal newInvoice As Invoice) As Boolean
        Dim connection As SqlConnection = PayablesDB.GetConnection
        Dim updateStatement As String =
            "UPDATE Invoices " &
            "SET PaymentTotal = @NewPaymentTotal, " &
            "PaymentDate = @NewPaymentDate " &
            "WHERE InvoiceID = @OldInvoiceID " &
            "  AND VendorID = @OldVendorID " &
            "  AND InvoiceNumber = @OldInvoiceNumber " &
            "  AND InvoiceDate = @OldInvoiceDate " &
            "  AND InvoiceTotal = @OldInvoiceTotal " &
            "  AND PaymentTotal = @OldPaymentTotal " &
            "  AND CreditTotal = @OldCreditTotal " &
            "  AND TermsID = @OldTermsID " &
            "  AND DueDate = @OldDueDate " &
            "  AND (PaymentDate = @OldPaymentDate " &
            "   OR PaymentDate IS NULL AND @OldPaymentDate IS NULL)"
        Dim updateCommand As New SqlCommand(updateStatement, connection)
        updateCommand.Parameters.AddWithValue("@NewPaymentTotal", newInvoice.PaymentTotal)
        updateCommand.Parameters.AddWithValue("@NewPaymentDate", newInvoice.PaymentDate)
        updateCommand.Parameters.AddWithValue("@OldInvoiceID", oldInvoice.InvoiceID)
        updateCommand.Parameters.AddWithValue("@OldVendorID", oldInvoice.VendorID)

        updateCommand.Parameters.AddWithValue("@OldInvoiceNumber", oldInvoice.InvoiceNumber)
        updateCommand.Parameters.AddWithValue("@OldInvoiceDate", oldInvoice.InvoiceDate)
        updateCommand.Parameters.AddWithValue("@OldInvoiceTotal", oldInvoice.InvoiceTotal)
        updateCommand.Parameters.AddWithValue("@OldPaymentTotal", oldInvoice.PaymentTotal)
        updateCommand.Parameters.AddWithValue("@OldCreditTotal", oldInvoice.CreditTotal)
        updateCommand.Parameters.AddWithValue("@OldTermsID", oldInvoice.TermsID)
        updateCommand.Parameters.AddWithValue("@OldDueDate", oldInvoice.DueDate)
        If Not oldInvoice.PaymentDate.HasValue Then
            updateCommand.Parameters.AddWithValue("@OldPaymentDate", DBNull.Value)
        Else
            updateCommand.Parameters.AddWithValue("@OldPaymentDate", oldInvoice.PaymentDate)
        End If

        Try
            connection.Open()
            Dim count As Integer = updateCommand.ExecuteNonQuery
            If count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As SqlException
            Throw ex
        Finally
            connection.Close()
        End Try
    End Function

End Class
