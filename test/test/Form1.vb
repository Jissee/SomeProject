
Public Class Form1
    Dim fname_p, fname_s As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Text = ""
        OpenFileDialog1.InitialDirectory = "D:"
        OpenFileDialog1.RestoreDirectory = False
        OpenFileDialog1.FileName = ""
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
        If fname_p = "" Then
            Label3.Text = "错误：文件未选择"
            CheckBox1.Checked = False
            Exit Sub
        End If
        If RadioButton1.Checked Then

            Dim psw, pswhash As String
            Dim rndnum(8), pswlen, byte1(7), byte2(7), byte3(7), byte4(7), binval1, binval2, proc, pospsw, poshash, rndpos As Byte
            Dim fileleng As Long
            Dim chasc1, chasc2 As Integer
            Dim binstr1, binstr2 As String
            Dim mhash As New myHash.myHash
            Randomize()
            For i = 1 To 8
                rndnum(i) = Int(Rnd() * 256)
            Next
            rndpos = 1
            psw = TextBox2.Text
            If psw = "" Then
                Label3.Text = "错误：密码不可为空"
                CheckBox1.Checked = False
                Exit Sub
            End If
            pospsw = 1
            pswlen = Len(psw)
            pswhash = mhash.my_hash(psw)
            poshash = 1
            If System.IO.File.Exists(fname_p) = False Then
                Label3.Text = "错误：文件不存在"
                CheckBox1.Checked = False
                Exit Sub
            End If
            Dim ifstream As IO.FileStream = New IO.FileStream(fname_p, IO.FileMode.Open)
            If System.IO.File.Exists(Application.StartupPath + "\tmp.txt") Then
                Kill(Application.StartupPath + "\tmp.txt")
            End If
            Dim ofstream As IO.FileStream = New IO.FileStream("tmp.txt", IO.FileMode.Create)
            fileleng = FileLen(fname_p)
            ''''''''''''''''密码加密输入''''''''''''''''''''
            For i = 1 To 20
                binval1 = Asc(Mid(mhash.my_hash(pswhash), i, 1))
                ofstream.WriteByte(binval1)
            Next
            ''''''''''''''''文件名加密输入''''''''''''''''''''

            binval1 = Len(fname_s)
            ofstream.WriteByte(binval1)
            For i = 1 To Len(fname_s)
                chasc1 = AscW(Mid(fname_s, i, 1))
                chasc2 = chasc1 Mod 256
                chasc1 = chasc1 \ 256
                binstr1 = Dec2Bin(chasc1)
                binstr2 = Dec2Bin(chasc2)
                For j = 0 To 7
                    byte1(j) = Val(Mid(binstr1, j + 1, 1))
                    byte2(j) = Val(Mid(binstr2, j + 1, 1))
                Next
                For j = 1 To 7
                    byte1(j) = byte1(j) Xor byte1(j - 1)
                    byte2(j) = byte2(j) Xor byte2(j - 1)
                Next
                binval1 = 0
                binval2 = 0
                For j = 0 To 7
                    binval1 = binval1 * 2 + byte1(j)
                    binval2 = binval2 * 2 + byte2(j)
                Next
                ofstream.WriteByte(binval1)
                ofstream.WriteByte(binval2)
            Next
            '
            ''''''''''''''随机数加密输入'''''''''''''''''''''
            For i = 1 To 8
                chasc1 = rndnum(i)
                binstr1 = Dec2Bin(chasc1)
                For j = 0 To 7
                    byte1(j) = Val(Mid(binstr1, j + 1, 1))
                Next
                For j = 1 To 7
                    byte1(j) = byte1(j) Xor byte1(j - 1)
                Next
                binval1 = 0
                For j = 0 To 7
                    binval1 = binval1 * 2 + byte1(j)
                Next
                ofstream.WriteByte(binval1)
            Next

            ''''''''''''''文件加密输入''''''''''''''
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
            If System.IO.File.Exists(Application.StartupPath + "\" + fname_s + ".encrypted") Then
                IO.File.Delete(Application.StartupPath + "\" + fname_s + ".encrypted")
            End If
            Rename(Application.StartupPath + "\tmp.txt", Application.StartupPath + "\" + fname_s + ".encrypted")
            If CheckBox1.Checked Then
                IO.File.Delete(fname_p)
            End If
            Label3.Text = "加密完成！"

        ElseIf RadioButton2.Checked Then ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim pswget, psw, pswhash, name As String
            Dim rndnum(8), pswlen, byte1(7), byte2(7), byte3(7), byte4(7), binval1, binval2, proc, pospsw, poshash, rndpos, namelen As Byte
            Dim fileleng As Long
            Dim chasc1 As Integer
            Dim binstr1, binstr2 As String
            Dim mhash As New myHash.myHash
            If System.IO.File.Exists(fname_p) = False Then
                Label3.Text = "错误：文件不存在"
                CheckBox1.Checked = False
                Exit Sub
            End If
            rndpos = 1
            psw = TextBox2.Text
            If psw = "" Then
                Label3.Text = "错误：密码不可为空"
                CheckBox1.Checked = False
                Exit Sub
            End If
            Dim ifstream As IO.FileStream = New IO.FileStream(fname_p, IO.FileMode.Open)
            pospsw = 1
            pswlen = Len(psw)
            pswhash = mhash.my_hash(psw)
            poshash = 1

            ''''''''''''''''''密码验证'''''''''''''''''''
            pswget = ""
            For i = 1 To 20
                chasc1 = ifstream.ReadByte
                pswget = pswget + Chr(chasc1)
            Next
            If pswget <> mhash.my_hash(mhash.my_hash(psw)) Then
                Label3.Text = "错误：密码错误或所选文件尚未加密"
                ifstream.Close()
                CheckBox1.Checked = False
                Exit Sub
            End If

            '''''''''''''''原文件名解密'''''''''''''''''''''
            name = ""
            namelen = ifstream.ReadByte
            For i = 1 To namelen
                binval1 = ifstream.ReadByte
                binval2 = ifstream.ReadByte
                binstr1 = Dec2Bin(binval1)
                binstr2 = Dec2Bin(binval2)
                For j = 0 To 7
                    byte1(j) = Val(Mid(binstr1, j + 1, 1))
                    byte2(j) = Val(Mid(binstr2, j + 1, 1))
                Next
                For j = 7 To 1 Step -1
                    byte1(j) = byte1(j) Xor byte1(j - 1)
                    byte2(j) = byte2(j) Xor byte2(j - 1)
                Next
                binval1 = 0
                binval2 = 0
                For j = 0 To 7
                    binval1 = binval1 * 2 + byte1(j)
                    binval2 = binval2 * 2 + byte2(j)
                Next
                name = name & ChrW(binval1 * 256 + binval2)
            Next
            Dim ofstream As IO.FileStream = New IO.FileStream(name, IO.FileMode.Create)

            ''''''''''''''''''随机数解密'''''''''''''''''''''
            For i = 1 To 8
                chasc1 = ifstream.ReadByte
                binstr1 = Dec2Bin(chasc1)
                For j = 0 To 7
                    byte1(j) = Val(Mid(binstr1, j + 1, 1))
                Next
                For j = 7 To 1 Step -1
                    byte1(j) = byte1(j) Xor byte1(j - 1)
                Next
                binval1 = 0
                For j = 0 To 7
                    binval1 = binval1 * 2 + byte1(j)
                Next
                rndnum(i) = binval1
            Next
            ''''
            '''''''''''''''文件解密''''''''''''''''''''''
            fileleng = FileLen(fname_p)
            For i = Len(name) * 2 + 30 To fileleng
                proc = ifstream.ReadByte
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
            If CheckBox1.Checked Then
                IO.File.Delete(fname_p)
            End If
            Label3.Text = "解密完成！"
        Else
            Label3.Text = "错误：未选择操作方式"
        End If
        CheckBox1.Checked = False
    End Sub
End Class

