Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim a As Integer
            If 1 / 0 Then
                'Throw New NumberTooLongException("数字太大")
            End If
        Catch ex As AccessViolationException
            MsgBox(ex.Message)
        End Try
        Dim s As String
        Dim i As UInt64
        i = 0
        MsgBox(Plus("9", "1"))

    End Sub
    Public Function Plus(leftnum As String, rightnum As String) As String
        If Len(leftnum) > 2000 Or Len(rightnum) > 2000 Then
            Throw New NumberTooLargeException("数字太大")
        End If

        Dim l(2000), r(2000), s(2000) As Integer
        Dim stsum As String
        Dim flag As Boolean
        flag = False
        stsum = ""
        For i = 0 To 2000
            l(i) = 0
            r(i) = 0
        Next
        For i = 1 To Len(leftnum)
            l(i - 1) = Val(Mid(leftnum, Len(leftnum) - i + 1, 1))
        Next
        For i = 1 To Len(rightnum)
            r(i - 1) = Val(Mid(rightnum, Len(rightnum) - i + 1, 1))
        Next
        For i = 0 To 2000
            s(i) = l(i) + r(i)
        Next
        For i = 0 To 2000
            If s(i) >= 10 Then
                s(i + 1) = s(i + 1) + s(i) \ 10
                s(i) = s(i) Mod 10
            End If
        Next
        For i = 2000 To 0 Step -1
            If s(i) <> 0 Then
                flag = True
            End If
            If flag Then
                stsum = stsum & CStr(s(i))
            End If
        Next
        Return stsum
    End Function
    Public Function Minus(leftnum As String, rightnum As String) As String
        If Len(leftnum) > 2000 Or Len(rightnum) > 2000 Then
            Throw New NumberTooLargeException("数字太大")
        End If
        Dim l(2000), r(2000), s(2000) As Integer
        Dim stsum As String
        Dim flag As Boolean

    End Function
    Public Function IsLargerThan(leftnum As String, rightnum As String) As Integer
        If leftnum = rightnum Then
            Return 0
        Else
            If Mid(leftnum, 1, 1) = "-" And Mid(rightnum, 1, 1) <> "-" Then
                Return -1
                Exit Function
            ElseIf Mid(leftnum, 1, 1) <> "-" And Mid(rightnum, 1, 1) = "-" Then
                Return 1
                Exit Function
            ElseIf Mid(leftnum, 1, 1) = "-" And Mid(rightnum, 1, 1) = "-" Then
                If Len(leftnum) > Len(rightnum) Then
                    Return -1
                    Exit Function
                Else
                    For i = 2 To Len(leftnum)
                        Return 1
                        If Mid(leftnum, i, 1) > Mid(rightnum, i, 1) Then
                            Return -1
                            Exit For
                        End If
                    Next
                End If
            Else
                If Len(leftnum) > Len(rightnum) Then
                    Return 1
                    Exit Function
                Else
                    For i = 1 To Len(leftnum)
                        Return -1
                        If Mid(leftnum, i, 1) > Mid(rightnum, i, 1) Then
                            Return 1
                            Exit For
                        End If
                    Next
                End If
            End If
        End If
    End Function
End Class

Public Class NumberTooLargeException : Inherits Exception

    Public Sub New(mes As String)
        MyBase.New(mes)
    End Sub

End Class
