﻿Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OpenFileDialog1.InitialDirectory = "D:"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "服务器属性|server.properties|yml|*.yml"
        SaveFileDialog1.InitialDirectory = "D:"
        SaveFileDialog1.FileName = "server.properties"
        SaveFileDialog1.Filter = "服务器属性|server.properties|yml|*.yml"

        'SaveFileDialog1.ShowDialog()
    End Sub

    Private Sub 打开ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开ToolStripMenuItem.Click

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            If Strings.Right(OpenFileDialog1.SafeFileName, 3) = "yml" Then
                Dim ifreader As New IO.StreamReader(OpenFileDialog1.FileName)
                ListBox1.Items.Clear()
                Do While Not ifreader.EndOfStream
                    ListBox1.Items.Add(ifreader.ReadLine())
                Loop
                TabControl1.SelectTab(yml)


                ifreader.Close()
            ElseIf Strings.Right(OpenFileDialog1.SafeFileName, 10) = "properties" Then

                TabControl1.SelectTab(properties)
            Else
                MsgBox("文件格式不正确")
            End If
        End If
    End Sub

    Private Sub 保存ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 保存ToolStripMenuItem.Click
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            If Strings.Right(OpenFileDialog1.SafeFileName, 3) = "yml" Then

                TabControl1.SelectTab(yml)
            ElseIf Strings.Right(OpenFileDialog1.SafeFileName, 10) = "properties" Then

                TabControl1.SelectTab(properties)
            Else
                MsgBox("文件格式不正确")
            End If
        End If
    End Sub


    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        编辑ToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub 编辑ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 编辑ToolStripMenuItem.Click
        Dim str As String
        Dim ch As String
        Dim flag As Integer = 1
        str = ListBox1.SelectedItem.ToString()
        For i = 1 To Len(str)
            ch = Mid(str, i, 1)

            If ch = ":" Then flag = True

            If flag = False And ch <> " " Then
                prop += ch
            ElseIf ch <> " " Then
                valu += ch
            End If
        Next
        Form2.Show()
    End Sub
End Class