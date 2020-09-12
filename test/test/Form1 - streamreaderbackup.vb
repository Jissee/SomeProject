Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fname_p, fname_s, psw, pswhash, name As String
        Dim chasc, rndnum(8), pswlen, bt(19), binval(0), allbt(), pospsw, poshash, rndpos As Byte
        Dim fileleng As Long
        Dim binstr As String
        Dim mhash As New myHash.myHash
        Randomize()
        For i = 1 To 8
            rndnum(i) = Int(Rnd() * 256)
        Next
        rndpos = 1
        psw = "123333333"
        pospsw = 1
        pswlen = Len(psw)
        pswhash = mhash.my_hash(psw)
        poshash = 1


        OpenFileDialog1.InitialDirectory = "D:"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.ShowDialog()
        fname_p = OpenFileDialog1.FileName
        fname_s = OpenFileDialog1.SafeFileName

        If IO.File.Exists(Application.StartupPath + "\tmp.txt") Then
            Kill(Application.StartupPath + "\tmp.txt")
        End If
        fileleng = FileLen(fname_p)



        ''''''''''''''''密码加密输入''''''''''''''''''''
        For i = 1 To 20
            bt(i - 1) = Asc(Mid(pswhash, i, 1))
        Next
        My.Computer.FileSystem.WriteAllBytes("tmp.txt", bt, True)
        ''''''''''''''''文件名加密输入''''''''''''''''''''

        binval(0) = Len(fname_s)
        My.Computer.FileSystem.WriteAllBytes("tmp.txt", binval, True)
        For i = 1 To Len(fname_s)
            chasc = Asc(Mid(fname_s, i, 1))
            binstr = Dec2Bin(chasc)
            For j = 0 To 7
                bt(j) = Val(Mid(binstr, j + 1, 1))
            Next
            For j = 1 To 7
                bt(j) = bt(j) Xor bt(j - 1)

            Next
            binval(0) = 0
            For j = 0 To 7
                binval(0) = binval(0) * 2 + bt(j)
            Next
            My.Computer.FileSystem.WriteAllBytes("tmp.txt", binval, True)
        Next
        '
        ''''''''''''''随机数加密输入'''''''''''''''''''''
        For i = 1 To 8
            chasc = rndnum(i)
            binstr = Dec2Bin(chasc)
            For j = 0 To 7
                bt(j) = Val(Mid(binstr, j + 1, 1))
            Next
            For j = 1 To 7
                bt(j) = bt(j) Xor bt(j - 1)
            Next
            binval(0) = 0
            For j = 0 To 7
                binval(0) = binval(0) * 2 + bt(j)
            Next
            My.Computer.FileSystem.WriteAllBytes("tmp.txt", binval, True)
        Next

        ''''''''''''''文件加密输入''''''''''''''
        fileleng = FileLen(fname_p)
        allbt = My.Computer.FileSystem.ReadAllBytes(fname_p)
        For i = 1 To fileleng
            allbt(i - 1) = allbt(i - 1)
            allbt(i - 1) = allbt(i - 1) Xor Asc(Mid(psw, pospsw, 1))
            allbt(i - 1) = allbt(i - 1) Xor Asc(Mid(pswhash, poshash, 1))
            allbt(i - 1) = allbt(i - 1) Xor rndnum(rndpos)
            pospsw = pospsw Mod pswlen + 1
            poshash = poshash Mod 20 + 1
            rndpos = rndpos Mod 8 + 1
        Next
        My.Computer.FileSystem.WriteAllBytes("tmp.txt", allbt, True)

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
        Dim pswget, psw, pswhash, name As String
        Dim chasc, rndnum(8), pswlen, byte1(7), byte2(7), byte3(7), byte4(7), binval, proc, pospsw, poshash, rndpos, namelen As Byte
        Dim fileleng As Long
        Dim binstr As String
        Dim mhash As New myHash.myHash
        FileOpen(1, "tmp.txt", OpenMode.Binary)

        rndpos = 1
        psw = "123333333"
        pospsw = 1
        pswlen = Len(psw)
        pswhash = mhash.my_hash(psw)
        poshash = 1

        ''''''''''''''''''密码验证'''''''''''''''''''
        pswget = ""
        For i = 1 To 20
            FileGet(1, chasc)
            pswget = pswget + Chr(chasc)
        Next
        If pswget <> mhash.my_hash(psw) Then
            MsgBox("no")
            FileClose(1)
            Exit Sub
        End If

        '''''''''''''''原文件名解密'''''''''''''''''''''
        name = ""
        FileGet(1, namelen)
        For i = 1 To namelen
            FileGet(1, binval)
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
        FileOpen(2, name, OpenMode.Binary)

        ''''''''''''''''''随机数解密'''''''''''''''''''''
        For i = 1 To 8
            FileGet(1, chasc)
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
        fileleng = FileLen("tmp.txt")

        For i = Len(name) + 30 To fileleng
            FileGet(1, proc)
            proc = proc Xor Asc(Mid(psw, pospsw, 1))
            proc = proc Xor Asc(Mid(pswhash, poshash, 1))
            proc = proc Xor rndnum(rndpos)
            pospsw = pospsw Mod pswlen + 1
            poshash = poshash Mod 20 + 1
            rndpos = rndpos Mod 8 + 1
            FilePut(2, proc)
        Next
        FileClose(2)
        FileClose(1)
    End Sub


End Class

