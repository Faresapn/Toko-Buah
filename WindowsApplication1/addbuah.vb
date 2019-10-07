Public Class addbuah
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = " " Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Then
            MessageBox.Show("isi semua")
        Else
            Try


                Using Adapter As New TokoDataSetTableAdapters.produkTableAdapter
                    Adapter.Insert(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text)
                    loaduser()
                End Using
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub loaduser()
        Using Adapter As New TokoDataSetTableAdapters.produkTableAdapter
            Using ds As New TokoDataSet.produkDataTable
                Adapter.Fill(ds)
                DataGridView1.DataSource = ds
            End Using
        End Using
    End Sub

    Private Sub addbuah_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaduser()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        baris()
    End Sub

    Private Sub baris()
        Dim Row As DataGridViewRow = DataGridView1.CurrentRow
        TextBox1.Text = Row.Cells(0).Value.ToString
        TextBox2.Text = Row.Cells(1).Value.ToString
        TextBox3.Text = Row.Cells(2).Value.ToString
        TextBox4.Text = Row.Cells(3).Value.ToString
        TextBox5.Text = Row.Cells(4).Value.ToString
        TextBox6.Text = Row.Cells(5).Value.ToString

    End Sub
End Class