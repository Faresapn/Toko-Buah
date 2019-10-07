Public Class Form1
    Public Sub login(kodee As String, lvl As String)

        If lvl = "Admin" Then
            change(Form2)

        Else
            change(Pembelian)
            Lap_jual.Visible = False
            Lap_beli.Visible = False
        End If
    End Sub
    Private Sub change(frm As Form)
        frm.TopLevel = False
        frm.TopMost = True
        Panel1.Controls.Add(frm)
        frm.Show()

    End Sub
    Private Sub closse()
        For Each form In Panel1.Controls.OfType(Of Form).ToList
            form.Close()

        Next
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub UserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserToolStripMenuItem.Click
        Form2.Show()
    End Sub

    Private Sub PembelianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PembelianToolStripMenuItem.Click
        Pembelian.Show()
    End Sub

    Private Sub Penjualan_Click(sender As Object, e As EventArgs) Handles PenjualanToolStripMenuItem.Click
        Penjualan.Show()
    End Sub
End Class
