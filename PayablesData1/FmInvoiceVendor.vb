Imports System.Windows.Forms

Public Class FmInvoiceVendor
    Private vendor As Vendor
    Private vendorList As List(Of Vendor)
    Private invoiceList As List(Of Invoice)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.GetVendorList()
        Me.GetVendorData()
    End Sub

    Private Sub GetVendorList()
        Try
            ' Get the list of Vendor objects and bind the combo box to the list
            vendorList = VendorDB.GetVendorsWithBalanceDue
            NameComboBox.DataSource = vendorList
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.GetType.ToString)
        End Try
    End Sub

    Private Sub GetVendorData()
        Dim vendorID As Integer = CInt(NameComboBox.SelectedValue)
        Try
            'get a vendor object for the selected vendor
            'and bind the text boxes to the object
            vendor = VendorDB.GetVendorNameAndAddress(vendorID)
            VendorBindingSource.Clear()
            VendorBindingSource.Add(vendor)
            'get the list of Invoice objects and bind the datagridview contrl to the list
            invoiceList = InvoiceDB.GetUnpaidVendorInvoices(vendorID)
            InvoiceDataGridView.DataSource = invoiceList
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.GetType.ToString)
        End Try
    End Sub

    Private Sub NameComboBox_SelectedIndexChanged(ByVal sender As System.Object,
         ByVal e As System.EventArgs) Handles NameComboBox.SelectedIndexChanged
        Me.GetVendorData()
    End Sub
End Class