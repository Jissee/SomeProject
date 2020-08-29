Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fname_p, fname_s, psw, pswhash, name As String
        Dim chasc, rndnum(8), pswlen, byte1(7), byte2(7), byte3(7), byte4(7), binval, proc, pospsw, poshash, rndpos As Byte
        Dim fileleng As Long
        Dim binstr As String
        Dim mhash As New myHash.myHash
        Randomize()
        For i = 1 To 8
            rndnum(i) = Int(Rnd() * 256)
        Next
        rndpos = 1
        psw = "123"
        pospsw = 1
        name = "filee"
        pswlen = Len(psw)
        pswhash = mhash.my_hash(psw)
        poshash = 1


        OpenFileDialog1.InitialDirectory = "D:"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.ShowDialog()
        fname_p = OpenFileDialog1.FileName
        fname_s = OpenFileDialog1.SafeFileName
        FileOpen(1, fname_p, OpenMode.Binary)
        If System.IO.File.Exists(Application.StartupPath + "\tmp.txt") Then
            Kill(Application.StartupPath + "\tmp.txt")
        End If
        FileOpen(2, "tmp.txt", OpenMode.Binary)
        fileleng = FileLen(fname_p)
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = fileleng
        ProgressBar1.Value = 0

        ''''''''''''''''文件名加密输入''''''''''''''''''''

        binval = Len(fname_s)
        FilePut(2, binval)
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
            FilePut(2, binval)
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
            FilePut(2, binval)
        Next
        '

        ''''''''''''''文件加密输入''''''''''''''
        fileleng = FileLen(fname_p)
        For i = 1 To fileleng
            FileGet(1, proc)

            binstr = Dec2Bin(proc)
            For j = 0 To 7
                byte1(j) = Val(Mid(binstr, j + 1, 1))
            Next

            chasc = Asc(Mid(psw, pospsw, 1))
            binstr = Dec2Bin(chasc)
            For j = 0 To 7
                byte2(j) = Val(Mid(binstr, j + 1, 1))
            Next
            pospsw = pospsw Mod pswlen + 1


            chasc = Asc(Mid(pswhash, poshash, 1))
            binstr = Dec2Bin(chasc)
            For j = 0 To 7
                byte3(j) = Val(Mid(binstr, j + 1, 1))
            Next
            poshash = poshash Mod 20 + 1


            chasc = rndnum(rndpos)
            binstr = Dec2Bin(chasc)
            For j = 0 To 7
                byte4(j) = Val(Mid(binstr, j + 1, 1))
            Next
            rndpos = rndpos Mod 8 + 1

            proc = 0
            For j = 0 To 7
                byte1(j) = byte1(j) Xor byte2(j)
                byte1(j) = byte1(j) Xor byte3(j)
                byte1(j) = byte1(j) Xor byte4(j)
                proc = proc * 2 + byte1(j)
            Next
            FilePut(2, proc)
            'ProgressBar1.Value = i
            'Label1.Text = i
        Next

        FileClose(2)
        FileClose(1)
        'Kill(Application.StartupPath + "\tmp.txt")
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
        Dim fname_p, fname_s, psw, pswhash, name As String
        Dim chasc, rndnum(8), pswlen, byte1(7), byte2(7), byte3(7), byte4(7), binval, proc, pospsw, poshash, rndpos, namelen As Byte
        Dim fileleng As Long
        Dim binstr As String
        Dim mhash As New myHash.myHash
        FileOpen(1, "tmp.txt", OpenMode.Binary)

        FileGet(1, namelen)

        rndpos = 1
        psw = "123"
        pospsw = 1
        pswlen = Len(psw)
        pswhash = mhash.my_hash(psw)
        poshash = 1

        '''''''''''''''原文件名解密'''''''''''''''''''''
        name = ""
        For i = 1 To namelen
            FileGet(1, binval)
            binstr = Dec2Bin(binval)
            For j = 0 To 7
                byte1(j) = Val(Mid(binstr, j + 1, 1))
            Next
            For j = 7 To 1 Step -1
                If byte1(j) = byte1(j - 1) Then
                    byte1(j) = 0
                Else
                    byte1(j) = 1
                End If
            Next
            binval = 0
            For j = 0 To 7
                binval = binval * 2 + byte1(j)
            Next
            name = name & Chr(binval)
        Next
        FileOpen(2, name, OpenMode.Binary)

        ''''''''''''''''''随机数解密'''''''''''''''''''''
        For i = 1 To 8
            FileGet(1, chasc)
            binstr = Dec2Bin(chasc)
            For j = 0 To 7
                byte1(j) = Val(Mid(binstr, j + 1, 1))
            Next
            For j = 7 To 1 Step -1
                If byte1(j) = byte1(j - 1) Then
                    byte1(j) = 0
                Else
                    byte1(j) = 1
                End If
            Next
            binval = 0
            For j = 0 To 7
                binval = binval * 2 + byte1(j)
            Next
            rndnum(i) = binval
        Next
        ''''
        '''''''''''''''文件解密''''''''''''''''''''''
        fileleng = FileLen("tmp.txt")
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = fileleng
        ProgressBar1.Value = 0
        For i = Len(name) + 10 To fileleng
            FileGet(1, proc)

            binstr = Dec2Bin(proc)
            For j = 0 To 7
                byte1(j) = Val(Mid(binstr, j + 1, 1))
            Next

            chasc = Asc(Mid(psw, pospsw, 1))
            binstr = Dec2Bin(chasc)
            For j = 0 To 7
                byte2(j) = Val(Mid(binstr, j + 1, 1))
            Next
            pospsw = pospsw Mod pswlen + 1

            chasc = Asc(Mid(pswhash, poshash, 1))
            binstr = Dec2Bin(chasc)
            For j = 0 To 7
                byte3(j) = Val(Mid(binstr, j + 1, 1))
            Next
            poshash = poshash Mod 20 + 1

            chasc = rndnum(rndpos)
            binstr = Dec2Bin(chasc)
            For j = 0 To 7
                byte4(j) = Val(Mid(binstr, j + 1, 1))
            Next
            rndpos = rndpos Mod 8 + 1

            proc = 0
            For j = 0 To 7
                byte1(j) = byte1(j) Xor byte4(j)
                byte1(j) = byte1(j) Xor byte3(j)
                byte1(j) = byte1(j) Xor byte2(j)
                proc = proc * 2 + byte1(j)
            Next
            FilePut(2, proc)
            ' ProgressBar1.Value = i
        Next
        FileClose(2)
        FileClose(1)
    End Sub


End Class

