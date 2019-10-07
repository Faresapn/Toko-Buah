Public Class Form2

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

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

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaduser()
    End Sub
    Private Sub loaduser()
        Using Adapter As New TokoDataSetTableAdapters.UserTableAdapter
            Using ds As New TokoDataSet.UserDataTable
                Adapter.Fill(ds)
                DataGridView1.DataSource = ds
            End Using
        End Using
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MessageBox.Show("isi semua")
        Else
            Try


                Using Adapter As New TokoDataSetTableAdapters.UserTableAdapter
                    Dim level As String
                    If RadioButton1.Checked Then
                        level = "admin"
                    Else
                        level = "user"
                    End If
                    Adapter.Insert(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, level)
                    loaduser()

                End Using
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try


            If TextBox1.Text = "" Then
                MessageBox.Show("Pilih Datanya")
            ElseIf TextBox2.Text = "test" Then
                MessageBox.Show("Default Tidak Boleh Di Hapus")
            Else
                Using del As New TokoDataSetTableAdapters.UserTableAdapter
                    del.DeleteQuery(TextBox1.Text)
                    loaduser()
                End Using
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            Else
                Dim level As String
                If RadioButton1.Checked Then
                    level = "Admin"
                Else
                    level = "Petugas"
                End If
                Using adapter As New TokoDataSetTableAdapters.UserTableAdapter
                    adapter.UpdateQuery(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, level, TextBox1.Text)
                    loaduser()
                End Using
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class