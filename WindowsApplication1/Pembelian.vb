Public Class Pembelian
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Then
            MessageBox.Show("Form Masih Kosong")
        Else
            Dim row As Integer = DataGridView1.Rows.Add
            DataGridView1.Rows.Item(row).Cells(0).Value = TextBox4.Text
            DataGridView1.Rows.Item(row).Cells(1).Value = TextBox5.Text
            DataGridView1.Rows.Item(row).Cells(2).Value = TextBox6.Text
            Dim total As Integer
            If total = 0 Then
                total = DataGridView1.Rows.Item(row).Cells(1).Value * DataGridView1.Rows.Item(row).Cells(2).Value
                TextBox7.Text = total
            Else
                total = DataGridView1.Rows.Item(row).Cells(1).Value * DataGridView1.Rows.Item(row).Cells(2).Value
                TextBox7.Text = CInt(TextBox7.Text) + total
            End If
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
        End If
    End Sub
    Private Sub validasi(txt As TextBox)
        Try
            If Not Math.Abs(CInt(txt.Text)) = CInt(txt.Text) Then
                MessageBox.Show("Harus Positif")
            End If
        Catch ex As Exception
            MessageBox.Show("Harus Angka")

        End Try
    End Sub

    Private Sub Pembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Visible = False
        Label4.Visible = False
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Label4.Visible = False
        DateTimePicker1.Visible = False
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Label4.Visible = True
        DateTimePicker1.Visible = True
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        validasi(TextBox3)
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        validasi(TextBox6)
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        validasi(TextBox5)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        pilihuser.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        pilihsupplier.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        pilihbuah.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If RadioButton1.Checked Then
            If CInt(TextBox3.Text) < CInt(TextBox7.Text) Then
                MessageBox.Show("Uang Kurang")
            Else
                Using Adapter As New TokoDataSetTableAdapters.pembelianTableAdapter
                    Dim kode As String
                    Dim max As String = Adapter.ScalarQuery
                    If max = "" Then
                        max = "1"
                        While max.Length < 5
                            max = "0" + max
                        End While
                        kode = Now.Year.ToString + Now.Month.ToString + max
                    Else
                        Dim temp As Integer = CInt(max.Substring(5, max.Length - 5)) + 1
                        max = temp.ToString
                        While max.Length < 5
                            max = "0" + max
                        End While
                        kode = Now.Year.ToString + Now.Month.ToString + max
                    End If
                    Adapter.Insert(kode, TextBox1.Text, TextBox2.Text, Now.Date, Now.Date, 1)
                    For i As Integer = 0 To DataGridView1.Rows.Count - 2
                        Using produk As New TokoDataSetTableAdapters.produkTableAdapter
                            Using ds As New TokoDataSet.produkDataTable
                                Dim Old As Integer
                                produk.FillBy(ds, DataGridView1.Rows(i).Cells(0).Value)
                                Old = CInt(ds.Rows(0)(5).ToString)
                                Dim now As Integer = DataGridView1.Rows(i).Cells(1).Value + Old
                                produk.UpdateQuery(now, DataGridView1.Rows(i).Cells(2).Value, DataGridView1.Rows(i).Cells(0).Value.ToString)
                                Using detail As New TokoDataSetTableAdapters.pembeliandetailTableAdapter
                                    detail.InsertQuery(DataGridView1.Rows(i).Cells(0).Value, kode, DataGridView1.Rows(i).Cells(1).Value, DataGridView1.Rows(i).Cells(2).Value.ToString)
                                End Using
                            End Using
                        End Using
                    Next
                    DataGridView1.Rows.Clear()
                    kode = ""
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox3.Text = ""
                    TextBox7.Text = ""
                End Using
            End If
        End If
    End Sub
End Class