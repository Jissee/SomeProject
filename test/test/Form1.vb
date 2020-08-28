Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim codes(61) As String
        Dim process(5), posnow As ULong
        Dim tmp As Integer
        Dim src, str, sfinal As String
        posnow = 1
        str = ""
        sfinal = ""
        For i = 0 To 25
            codes(i) = Chr(i + 65)
            codes(i + 26) = Chr(i + 97)
        Next
        For i = 0 To 9
            codes(i + 52) = CStr(i)
        Next
        src = TextBox1.Text
        For i = 1 To 1000
            For j = 1 To 4
                process(j) = process(j + 1)
            Next
            process(5) = ((process(5) + process(5) * posnow + Asc(Mid(src, posnow, 1) * i)) Mod 1000000000000) \ 2
            process(5) = ((process(5) + process(5) * i + Asc(Mid(src, posnow, 1) * posnow)) Mod 1000000000000) \ 2
            posnow = posnow Mod Len(src) + 1
        Next
        For i = 1 To 5
            str = CStr(process(i)) + str
        Next
        For i = 5 To 45 Step 2
            tmp = Val(Mid(str, i, 2))
            tmp = tmp / 99 * 61
            sfinal = sfinal + codes(tmp)
        Next
        TextBox2.Text = sfinal

    End Sub
End Class
