Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ComboBox1.Items.Add("TEXT - to - BINARY")
        ComboBox1.Items.Add("BINARY - to - TEXT")
        TextBox1.Visible = False : Label1.Visible = False
        TextBox2.Visible = False : Label2.Visible = False
        TextBox3.Visible = False : Label3.Visible = False
        TextBox4.Visible = False : Label4.Visible = False
        Button1.Visible = False
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        If ComboBox1.SelectedIndex = 0 Then
            TextBox1.Visible = True : Label1.Visible = True
            TextBox2.Visible = True : Label2.Visible = True
            TextBox1.Focus()
            TextBox3.Visible = False : Label3.Visible = False
            TextBox4.Visible = False : Label4.Visible = False
            If TextBox1.Text = "" Then
                Button1.Visible = False
            Else
                Button1.Visible = True
            End If
        ElseIf ComboBox1.SelectedIndex = 1 Then
            TextBox3.Visible = True : Label3.Visible = True
            TextBox4.Visible = True : Label4.Visible = True
            TextBox3.Focus()
            TextBox1.Visible = False : Label1.Visible = False
            TextBox2.Visible = False : Label2.Visible = False
            If TextBox3.Text = "" Then
                Button1.Visible = False
            Else
                Button1.Visible = True
            End If
        End If
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Button1.Visible = True
        Dim Temp As String = ""
        Dim txtBuilder As New System.Text.StringBuilder
        Try
            For Each Character As Byte In System.Text.ASCIIEncoding.ASCII.GetBytes(TextBox1.Text)
                txtBuilder.Append(Convert.ToString(Character, 2).PadLeft(8, "0"))
                txtBuilder.Append(" ")
            Next
            Temp = txtBuilder.ToString.Substring(0, txtBuilder.ToString.Length - 0)
            TextBox2.Text = Temp
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        Button1.Visible = True
        Dim tempString As String = ""
        Dim Character As String = System.Text.RegularExpressions.Regex.Replace(TextBox3.Text, "[^01]", "")
        Dim Bytes((Character.Length / 8) - 1) As Byte
        Try
            For Index As Integer = 0 To Bytes.Length - 1
                Bytes(Index) = Convert.ToByte(Character.Substring(Index * 8, 8), 2)
            Next
            tempString = System.Text.ASCIIEncoding.ASCII.GetString(Bytes)
            TextBox4.Text = tempString
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboBox1.SelectedIndex = 0 Then
            TextBox1.Focus()
            TextBox1.Text = ""
        ElseIf ComboBox1.SelectedIndex = 1 Then
            TextBox3.Focus()
            TextBox3.Text = ""
        End If
        Button1.Visible = False
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Beep()
        Application.Exit()
    End Sub
End Class
