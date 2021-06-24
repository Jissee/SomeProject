Imports System.ComponentModel

Public Class Form2
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim str As String = ""
        For i = 1 To depth
            str = str + " "
        Next
        str = str + TextBox1.Text + ": " + TextBox2.Text
        If TextBox1.Text = "" Then
            MsgBox("未填入属性名")
            Exit Sub
        End If
        If TextBox2.Text = "" Then
            MsgBox("未填入属性值")
            Exit Sub
        End If
        Form1.ListBox1.Items(itemindex) = str
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = prop
        TextBox2.Text = valu
    End Sub

    Private Sub Form2_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        TextBox1.Text = ""
        TextBox2.Text = ""
        prop = ""
        valu = ""
    End Sub

End Class