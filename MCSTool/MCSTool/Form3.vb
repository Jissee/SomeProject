Imports System.ComponentModel

Public Class Form3
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim str As String = ""
        For i = 1 To depth
            str = str + " "
        Next
        str = str + TextBox1.Text + ": "
        Form1.ListBox1.Items(itemindex) = str
        Close()
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = prop
    End Sub

    Private Sub Form3_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        TextBox1.Text = ""
        prop = ""
        valu = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub
End Class