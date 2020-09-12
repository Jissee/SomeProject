
Public Class Form1
    Dim fname_p, fname_s As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.InitialDirectory = "D:"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.ShowDialog()
        TextBox1.Text = OpenFileDialog1.FileName
        fname_p = OpenFileDialog1.FileName
        fname_s = OpenFileDialog1.SafeFileName
    End Sub
    Public Function Dec2Bin(dec As Integer) As String
        Dim sum, tmp As String
        sum = ""
        Do While dec > 0 Or Len(sum) Mod 8 <> 0
            tmp = CStr(dec Mod 2)
            sum = tmp & sum
            dec = dec \ 2
        Loop
        Return sum
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If RadioButton1.Checked Then

            ListBox1.Items.Clear()
            Dim psw, pswhash As String
            Dim chasc, rndnum(8), pswlen, byte1(7), byte2(7), byte3(7), byte4(7), binval, proc, pospsw, poshash, rndpos As Byte
            Dim fileleng As Long
            Dim binstr As String
            Dim mhash As New myHash.myHash
            Randomize()
            For i = 1 To 8
                rndnum(i) = Int(Rnd() * 256)
            Next
            rndpos = 1
            psw = TextBox2.Text
            If psw = "" Then
                ListBox1.Items.Add("错误：密码不可为空")
                Exit Sub
            End If
            pospsw = 1
            pswlen = Len(psw)
            pswhash = mhash.my_hash(psw)
            poshash = 1
            Dim ifstream As IO.FileStream = New IO.FileStream(fname_p, IO.FileMode.Open)
            If System.IO.File.Exists(Application.StartupPath + "\tmp.txt") Then
                Kill(Application.StartupPath + "\tmp.txt")
            End If
            Dim ofstream As IO.FileStream = New IO.FileStream("tmp.txt", IO.FileMode.Create)
            fileleng = FileLen(fname_p)
            ''''''''''''''''密码加密输入''''''''''''''''''''
            For i = 1 To 20
                binval = Asc(Mid(mhash.my_hash(psw), i, 1))
                ofstream.WriteByte(binval)
            Next
            ''''''''''''''''文件名加密输入''''''''''''''''''''

            binval = Len(fname_s)
            ofstream.WriteByte(binval)
            For i = 1 To Len(fname_s)
                chasc = Asc(Mid(fname_s, i, 1))
                binstr = Dec2Bin(chasc)
                For j = 0 To 7
                    byte1(j) = Val(Mid(binstr, j + 1, 1))
                Next
                For j = 1 To 7
                    byte1(j) = byte1(j) Xor byte1(j - 1)

                Next
                binval = 0
                For j = 0 To 7
                    binval = binval * 2 + byte1(j)
                Next
                ofstream.WriteByte(binval)
            Next
            '
            ''''''''''''''随机数加密输入'''''''''''''''''''''
            For i = 1 To 8
                chasc = rndnum(i)
                binstr = Dec2Bin(chasc)
                For j = 0 To 7
                    byte1(j) = Val(Mid(binstr, j + 1, 1))
                Next
                For j = 1 To 7
                    byte1(j) = byte1(j) Xor byte1(j - 1)
                Next
                binval = 0
                For j = 0 To 7
                    binval = binval * 2 + byte1(j)
                Next
                ofstream.WriteByte(binval)
            Next

            ''''''''''''''文件加密输入''''''''''''''
            ListBox1.Items.Add("正在加密，请稍后")
            fileleng = FileLen(fname_p)
            For i = 1 To fileleng
                proc = ifstream.ReadByte()
                proc = proc Xor Asc(Mid(psw, pospsw, 1))
                proc = proc Xor Asc(Mid(pswhash, poshash, 1))
                proc = proc Xor rndnum(rndpos)
                pospsw = pospsw Mod pswlen + 1
                poshash = poshash Mod 20 + 1
                rndpos = rndpos Mod 8 + 1
                ofstream.WriteByte(proc)
            Next
            ifstream.Close()
            ofstream.Close()
            Rename(Application.StartupPath + "\tmp.txt", Application.StartupPath + "\" + fname_s + ".encrypted")
            ListBox1.Items.Add("加密完成！")
        ElseIf RadioButton2.Checked Then

            ListBox1.Items.Clear()
            Dim pswget, psw, pswhash, name As String
            Dim chasc, rndnum(8), pswlen, byte1(7), byte2(7), byte3(7), byte4(7), binval, proc, pospsw, poshash, rndpos, namelen As Byte
            Dim fileleng As Long
            Dim binstr As String
            Dim mhash As New myHash.myHash
            Dim ifstream As IO.FileStream = New IO.FileStream(fname_p, IO.FileMode.Open)
            rndpos = 1
            psw = TextBox2.Text
            If psw = "" Then
                ListBox1.Items.Add("错误：密码不可为空")
                ifstream.Close()
                Exit Sub
            End If
            pospsw = 1
            pswlen = Len(psw)
            pswhash = mhash.my_hash(psw)
            poshash = 1

            ''''''''''''''''''密码验证'''''''''''''''''''
            pswget = ""
            For i = 1 To 20
                chasc = ifstream.ReadByte
                pswget = pswget + Chr(chasc)
            Next
            If pswget <> mhash.my_hash(psw) Then
                ListBox1.Items.Add("错误：密码错误或所选文件尚未加密")
                ifstream.Close()
                Exit Sub
            End If

            '''''''''''''''原文件名解密'''''''''''''''''''''
            name = ""
            namelen = ifstream.ReadByte
            For i = 1 To namelen
                binval = ifstream.ReadByte
                binstr = Dec2Bin(binval)
                For j = 0 To 7
                    byte1(j) = Val(Mid(binstr, j + 1, 1))
                Next
                For j = 7 To 1 Step -1
                    byte1(j) = byte1(j) Xor byte1(j - 1)
                Next
                binval = 0
                For j = 0 To 7
                    binval = binval * 2 + byte1(j)
                Next
                name = name & Chr(binval)
            Next
            Dim ofstream As IO.FileStream = New IO.FileStream(name, IO.FileMode.Create)

            ''''''''''''''''''随机数解密'''''''''''''''''''''
            For i = 1 To 8
                chasc = ifstream.ReadByte
                binstr = Dec2Bin(chasc)
                For j = 0 To 7
                    byte1(j) = Val(Mid(binstr, j + 1, 1))
                Next
                For j = 7 To 1 Step -1
                    byte1(j) = byte1(j) Xor byte1(j - 1)
                Next
                binval = 0
                For j = 0 To 7
                    binval = binval * 2 + byte1(j)
                Next
                rndnum(i) = binval
            Next
            ''''
            '''''''''''''''文件解密''''''''''''''''''''''
            fileleng = FileLen(fname_p)
            ListBox1.Items.Add("正在解密，请稍后")
            For i = Len(name) + 30 To fileleng
                proc = ifstream.ReadByte
                proc = proc Xor Asc(Mid(psw, pospsw, 1))
                proc = proc Xor Asc(Mid(pswhash, poshash, 1))
                proc = proc Xor rndnum(rndpos)
                pospsw = pospsw Mod pswlen + 1
                poshash = poshash Mod 20 + 1
                rndpos = rndpos Mod 8 + 1
                ofstream.WriteByte(proc)
            Next
            ListBox1.Items.Add("解密完成！")
            ifstream.Close()
            ofstream.Close()
        Else
            ListBox1.Items.Clear()
            ListBox1.Items.Add("错误：未选择操作方式")
        End If
    End Sub

    Private Sub enc()

    End Sub
    Private Sub dec()

    End Sub
End Class

