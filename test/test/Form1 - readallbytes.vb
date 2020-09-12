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
        Dim chasc, rndnum(8), pswlen, bt(), byt(7), binval(0), pospsw, poshash, rndpos, namelen As Byte
        Dim fileleng As Long
        Dim binstr As String
        Dim mhash As New myHash.myHash
        'FileOpen(1, "tmp.txt", OpenMode.Binary)
        rndpos = 1
        psw = "123333333"
        pospsw = 1
        pswlen = Len(psw)
        pswhash = mhash.my_hash(psw)
        poshash = 1
        ''''''''''''''''''密码验证'''''''''''''''''''
        pswget = ""
        '       For i = 1 To 20
        '                'FileGet(1, chasc)
        '       pswget = pswget + Chr(chasc)
        '       Next
        bt = My.Computer.FileSystem.ReadAllBytes("tmp.txt")
        For i = 1 To 20
            pswget = pswget + Chr(bt(i - 1))
        Next
        If pswget <> mhash.my_hash(psw) Then
            MsgBox("no")
            'FileClose(1)
            Exit Sub
        End If

        '''''''''''''''原文件名解密'''''''''''''''''''''
        name = ""
        namelen = bt(20)
        For i = 1 To namelen
            binval(0) = bt(20 + i)
            binstr = Dec2Bin(binval(0))
            For j = 0 To 7
                byt(j) = Val(Mid(binstr, j + 1, 1))
            Next
            For j = 7 To 1 Step -1
                byt(j) = byt(j) Xor byt(j - 1)
            Next
            binval(0) = 0
            For j = 0 To 7
                binval(0) = binval(0) * 2 + byt(j)
            Next
            name = name & Chr(binval(0))
        Next
        FileOpen(2, name, OpenMode.Output)
        FileClose(2)
        '0~19:hash code
        '20:name length(i)
        '21~20+i:name
        '21+i~28+i:random number
        '29+i~ filelen-1:file
        ''''''''''''''''''随机数解密'''''''''''''''''''''
        For i = 1 To 8
            'FileGet(1, chasc)
            binstr = Dec2Bin(bt(20 + namelen + i))
            For j = 0 To 7
                byt(j) = Val(Mid(binstr, j + 1, 1))
            Next
            For j = 7 To 1 Step -1
                byt(j) = byt(j) Xor byt(j - 1)
            Next
            binval(0) = 0
            For j = 0 To 7
                binval(0) = binval(0) * 2 + byt(j)
            Next
            rndnum(i) = binval(0)
        Next
        '''''''''''''''文件解密''''''''''''''''''''''
        fileleng = FileLen("tmp.txt")
        For i = namelen + 29 To fileleng - 1
            'FileGet(1, bt(i-1))
            binval(0) = bt(i) Xor Asc(Mid(psw, pospsw, 1))
            binval(0) = bt(i) Xor Asc(Mid(pswhash, poshash, 1))
            binval(0) = bt(i) Xor rndnum(rndpos)
            pospsw = pospsw Mod pswlen + 1
            poshash = poshash Mod 20 + 1
            rndpos = rndpos Mod 8 + 1
            My.Computer.FileSystem.WriteAllBytes(name, binval, True)
            'FilePut(2, bt(i-1))
        Next

        'FileClose(2)
        'FileClose(1)
    End Sub


End Class

