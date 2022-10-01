Imports System.Data.SqlClient

Public Class Form1
    Dim c As New Crud

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub ekle_Click(sender As Object, e As EventArgs) Handles ekle.Click

        Dim sql As String = "Insert into personell(Adı,Soyadı,Telefon,Tarih) values('" & txtAd.Text & "','" & txtSoyad.Text & "','" & txtTel.Text & "',@Tarih)"
        Dim command As New SqlCommand()

        command.Parameters.Add("@Tarih", SqlDbType.Date).Value = DateTimePicker1.Value

        c.CUD(command, sql)
        Listele()
        BtnTemizle()



    End Sub

    Private Sub guncelle_Click(sender As Object, e As EventArgs) Handles guncelle.Click

        Dim sql As String = "update personell set Adı='" & txtAd.Text & "',Soyadı='" & txtSoyad.Text & "', Telefon='" & txtTel.Text & "',Tarih=@Tarih where id='" & Integer.Parse(txtId.Text) & "'"

        Dim command As New SqlCommand()

        command.Parameters.Add("@Tarih", SqlDbType.Date).Value = DateTimePicker1.Value
        c.CUD(command, sql)
        Listele()
        BtnTemizle()


    End Sub

    Private Sub sil_Click(sender As Object, e As EventArgs) Handles sil.Click
        Dim sql As String = "delete from personell where id='" & DataGridView1.CurrentRow.Cells(0).Value & "'"

        Dim command As New SqlCommand()

        c.CUD(command, sql)

        Listele()
        BtnTemizle()


    End Sub

    Sub Listele()
        DataGridView1.DataSource = c.List("Select * from personell")
        BtnTemizle()


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Listele()



    End Sub

    Sub BtnTemizle()
        txtId.Text = ""
        txtAd.Text = ""
        txtSoyad.Text = ""
        txtTel.Text = ""
        DateTimePicker1.Value = DateTime.Now





    End Sub
    Private Sub temizle_Click(sender As Object, e As EventArgs) Handles temizle.Click
        BtnTemizle()


    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        txtId.Text = DataGridView1.CurrentRow.Cells(0).Value
        txtAd.Text = DataGridView1.CurrentRow.Cells(1).Value
        txtSoyad.Text = DataGridView1.CurrentRow.Cells(2).Value
        txtTel.Text = DataGridView1.CurrentRow.Cells(3).Value
        DateTimePicker1.Value = DataGridView1.CurrentRow.Cells(4).Value


    End Sub

    Private Sub txtAra_TextChanged(sender As Object, e As EventArgs) Handles txtAra.TextChanged

        DataGridView1.DataSource = c.List("Select * from personell where Adı like '%" & txtAra.Text & "%' or Soyadı like'%" & txtAra.Text & "%'")




    End Sub
End Class
