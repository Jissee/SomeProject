Public Class Form1
    ''' <summary>
    ''' 每行最大长度
    ''' </summary>
    ReadOnly Maxlen As Integer = 108
    Dim yh As String = ChrW(34)
    Dim leng(14) As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    ''' <summary>
    ''' 每个字符的长度
    ''' </summary>
    ''' <param name="x">输入字符、</param>
    ''' <returns></returns>
    Function Chrlen(x As String) As Integer
        Dim res As Integer
        If AscW(x) < 128 Then
            res = 4
        ElseIf AscW(x) >= 19968 And AscW(x) <= 40869 Then
            res = 9
        End If
        Select Case AscW(x)
            Case 102, 105, 106, 108, 116, 73, 49
                res = 3
            Case 65281
                res = 2
            Case 33
                res = 1
            Case 10
                res = 0
        End Select
        Return res
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim allstr, ch As String
        Dim linelen, j As Integer
        Dim txt(14) As String
        j = 1
        allstr = RichTextBox1.Text
        For i = 1 To Len(allstr)
            ch = Mid(allstr, i, 1)
            If j = 15 Then
                Exit For
            End If
            If linelen + Chrlen(ch) > Maxlen Or Chrlen(ch) = 0 Then
                j = j + 1
                linelen = 0
            Else
                txt(j) = txt(j) + ch
                linelen = linelen + Chrlen(ch)
            End If
        Next
        RichTextBox1.Text = ""
        For i = 1 To 13
            RichTextBox1.Text = RichTextBox1.Text + txt(i) + ChrW(10)
        Next
        RichTextBox1.Text = RichTextBox1.Text + txt(14)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim allstr, ch As String
        Dim linelen, j As Integer
        Dim txt(14), sfinal As String
        Dim title, author As String
        title = TextBox2.Text
        author = TextBox3.Text
        j = 1
        allstr = RichTextBox1.Text
        sfinal = ""
        For i = 1 To Len(allstr)
            ch = Mid(allstr, i, 1)
            If j = 15 Then
                Exit For
            End If
            If linelen + Chrlen(ch) > Maxlen Or Chrlen(ch) = 0 Then
                j = j + 1
                linelen = 0
            Else
                txt(j) = txt(j) + ch
                linelen = linelen + Chrlen(ch)
            End If
        Next
        For i = 1 To 13
            sfinal = sfinal + txt(i) + "\\n"
        Next
        sfinal = sfinal + txt(14)
        TextBox1.Text = "/give @p written_book{pages:['{" + yh + "text" + yh + ":" + yh + sfinal + yh + "}'],title:" + yh + title + yh + ",author:" + yh + author + yh + "}"
    End Sub
    Sub tmpsave()
        Dim allstr, ch As String
        Dim linelen, j As Integer
        Dim txt(14) As String
        j = 1
        allstr = RichTextBox1.Text
        For i = 1 To Len(allstr)
            ch = Mid(allstr, i, 1)
            If j = 15 Then
                Exit For
            End If
            If linelen + Chrlen(ch) > Maxlen Or Chrlen(ch) = 0 Then
                j = j + 1
                linelen = 0
            Else
                txt(j) = txt(j) + ch
                linelen = linelen + Chrlen(ch)
            End If
        Next
        RichTextBox1.Text = ""
        For i = 1 To 13
            RichTextBox1.Text = RichTextBox1.Text + txt(i) + ChrW(10)
        Next
        RichTextBox1.Text = RichTextBox1.Text + txt(14)

    End Sub
    '/give @p written_book{pages:['{"text" : "Example\\nExample2\\ nExanple3"}'],title:Example,author:Example}
End Class
