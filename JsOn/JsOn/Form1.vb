Public Class Form1
    ''' <summary>
    ''' 选择发生错误(如无法找到属性)时候的严重性
    ''' 0-忽略；1-提示；2-错误
    ''' </summary>
    Property severity As Integer = 0


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        severity = 0
        Try
            Label1.Text = GetValueByName("json.json", TextBox1.Text)
        Catch ex As NotFoundException
            MsgBox("nf")

        End Try


    End Sub
    Public Function Strbasp(str As String)
        Dim sfinal, c As String
        Dim f As Boolean
        f = False
        sfinal = ""
        For i = Len(str) To 1 Step -1
            c = Mid(str, i, 1)
            If f = True Then
                sfinal = c + sfinal
            End If
            If c = "." Then
                f = True
            End If
        Next
        Return sfinal
    End Function

    Public Function GetValueByName(filepath As String, prop As String) As String
        Dim ifstream As IO.FileStream = New IO.FileStream(filepath, IO.FileMode.Open)
        Dim a, rdstat, rdbegin, found, inquo As Integer
        Dim b, requesttxt, requests(100), key, thiskey, tmpkey, value, sfinal As String

        requesttxt = "." + prop
        sfinal = ""
        key = ""
        value = ""
        thiskey = ""
        tmpkey = ""
        rdstat = 0
        rdbegin = 0
        found = 0
        inquo = 0
        Do While a <> -1
            a = ifstream.ReadByte()

            b = ChrW(a)
            If a = 34 Then
                inquo = 1 - inquo
            End If
            If a = 34 And rdstat <= 1 Then
                rdstat = (rdstat + 1) Mod 4
                rdbegin = 0
            End If
            ':58 ,44
            If (a = 58 Or a = 44) And rdstat >= 2 Then
                rdstat = (rdstat + 1) Mod 4
                rdbegin = 0
            End If

            If rdstat = 1 And rdbegin = 1 Then
                thiskey = thiskey + b
            End If
            If rdstat = 2 Then
                key = key + "." + thiskey
                If key = requesttxt Then
                    found = 1
                End If
                tmpkey = thiskey
                thiskey = ""
                key = Strbasp(key)
            End If
            If rdstat = 3 And b = "{" Then
                key = key + "." + tmpkey
                thiskey = ""
                tmpkey = ""
                rdstat = 0
            End If
            If b = "}" Then
                key = Strbasp(key)
                rdstat = 0
            End If
            If rdstat = 3 And rdbegin = 1 Then
                If found = 1 And (a >= 33 Or inquo = 1) And a <> 34 Then
                    value = value + b
                End If

            End If

            Select Case severity
                Case 1
                    If found = 1 And b = "{" Then
                        MsgBox("qingqiudeshijiedian")
                        Exit Do
                    End If
                    If found = 1 And b = "[" Then
                        MsgBox("qingqiudeshishuzu")
                        Exit Do
                    End If
                Case 2
                    If found = 1 And b = "{" Then
                        ifstream.Close()
                        Throw New WrongTypeException
                        Exit Do
                    End If
                    If found = 1 And b = "[" Then
                        ifstream.Close()
                        Throw New WrongTypeException
                        Exit Do
                    End If
            End Select
            If rdstat = 0 And found = 1 Then
                sfinal = value
                Exit Do
            End If
            rdbegin = 1
        Loop
        If found = 0 Then
            Select Case severity
                Case 1
                    MsgBox("notfound")
                Case 2
                    ifstream.Close()
                    Throw New NotFoundException
            End Select
        End If
        ifstream.Close()
        Return sfinal
    End Function
    Public Class WrongTypeException
        Inherits Exception
        Public Sub New()
            MyBase.New("请求的是节点或数组")
        End Sub
    End Class
    Public Class NotFoundException
        Inherits Exception
        Public Sub New()
            MyBase.New("未找到请求的属性")
        End Sub
    End Class

End Class

