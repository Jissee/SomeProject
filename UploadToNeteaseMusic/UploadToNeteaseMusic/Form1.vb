Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fhead(&H2B), bt(3) As Byte
        Dim fname As String
        Dim fileleng As Long
        fname = Label1.Text
        fhead(&H0) = Asc("R")
        fhead(&H1) = Asc("I")
        fhead(&H2) = Asc("F")
        fhead(&H3) = Asc("F")

        fhead(&H8) = Asc("W")
        fhead(&H9) = Asc("A")
        fhead(&HA) = Asc("V")
        fhead(&HB) = Asc("E")
        fhead(&HC) = Asc("f")
        fhead(&HD) = Asc("m")
        fhead(&HE) = Asc("t")
        fhead(&HF) = Asc(" ")

        fhead(&H10) = 16
        fhead(&H11) = 0
        fhead(&H12) = 0
        fhead(&H13) = 0

        fhead(&H14) = 1
        fhead(&H15) = 0

        fhead(&H16) = 1
        fhead(&H17) = 0

        fhead(&H18) = &H44
        fhead(&H19) = &HAC
        fhead(&H1A) = &H0
        fhead(&H1B) = &H0


        fhead(&H1C) = &H10
        fhead(&H1D) = &HB1
        fhead(&H1E) = &H2
        fhead(&H1F) = &H0

        fhead(&H20) = &H4
        fhead(&H21) = &H0
        fhead(&H22) = &H10
        fhead(&H23) = &H0

        fhead(&H24) = Asc("d")
        fhead(&H25) = Asc("a")
        fhead(&H26) = Asc("t")
        fhead(&H27) = Asc("a")

        fhead(&H28) = 0
        fhead(&H29) = 0
        fhead(&H2A) = 0
        fhead(&H2B) = 0

        Dim ifstream As IO.FileStream = New IO.FileStream(fname, IO.FileMode.Open)

        fileleng = FileLen(fname)

        For i = 0 To 3
            fhead(&H28 + i) = fileleng Mod 256
            fileleng = fileleng \ 256
        Next

        fileleng = FileLen(fname) + &H24

        For i = 0 To 3
            fhead(&H4 + i) = fileleng Mod 256
            fileleng = fileleng \ 256
        Next

        Dim ofstream As IO.FileStream = New IO.FileStream(fname + ".wav", IO.FileMode.Create)

        For i = 0 To &H2B
            ofstream.WriteByte(fhead(i))
        Next

        fileleng = FileLen(fname)
        For i = 1 To fileleng
            ofstream.WriteByte(ifstream.ReadByte())
        Next

        ifstream.Close()
        ofstream.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OpenFileDialog1.Filter = "波形文件(*.wav)|*.wav|所有文件(*.*)|*.*"
        OpenFileDialog1.ShowDialog()
        Label1.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim fname As String
        Dim offset, leng As Long
        fname = Label1.Text
        Dim ifstream As IO.FileStream = New IO.FileStream(fname, IO.FileMode.Open)
        Dim ofstream As IO.FileStream = New IO.FileStream(Strings.Left(fname, Len(fname) - 4), IO.FileMode.Create)
        For i = 0 To &H2B
            offset = ifstream.ReadByte()
        Next
        leng = FileLen(fname)
        offset = &H2C

        Do While offset < leng
            ofstream.WriteByte(ifstream.ReadByte())
            offset = offset + 1
        Loop
        ifstream.Close()
        ofstream.Close()

    End Sub
End Class
