Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            If 1 / 0 Then
                'Throw New NumberTooLongException("数字太大")
            End If
        Catch ex As AccessViolationException
            MsgBox(ex.Message)
        End Try
        Dim s As String
        Dim a, b, t As Int64
        Dim cmpres As Boolean

        Do
            a = Int(Rnd() * 10000000)
            b = Int(Rnd() * 10000000)
            'a = 248
            'b = 456
            If a < b Then
                t = a : a = b : b = t
            End If
            If a - b = UI_Sub(CStr(a), CStr(b)) Then

            Else
                Throw New Exception
            End If

        Loop

    End Sub
    Public Function UI_Add(leftnum As String, rightnum As String) As String
        If Len(leftnum) > 2000 Or Len(rightnum) > 2000 Then
            Throw New NumberTooLargeException("数字太大")
        End If

        Dim l(2000), r(2000), s(2000), lenleft, lenright, lenmax As Integer
        Dim stsum As String
        Dim flag As Boolean
        lenleft = Len(leftnum)
        lenright = Len(rightnum)
        If lenleft > lenright Then lenmax = lenleft Else lenmax = lenright
        flag = False
        stsum = ""
        For i = 1 To lenleft
            l(i - 1) = Val(Mid(leftnum, Len(leftnum) - i + 1, 1))
        Next
        For i = 1 To lenright
            r(i - 1) = Val(Mid(rightnum, Len(rightnum) - i + 1, 1))
        Next
        For i = 0 To lenmax
            s(i) = l(i) + r(i)
        Next
        For i = 0 To lenmax + 1
            If s(i) >= 10 Then
                s(i + 1) = s(i + 1) + 1
                s(i) = s(i) - 10
            End If
        Next
        For i = lenmax + 1 To 0 Step -1
            If s(i) <> 0 Then
                flag = True
            End If
            If flag Then
                stsum = stsum & CStr(s(i))
            End If
        Next
        Return stsum
    End Function
    Public Function UI_Sub(leftnum As String, rightnum As String) As String
        If Len(leftnum) > 2000 Or Len(rightnum) > 2000 Then
            Throw New NumberTooLargeException("数字太大")
        End If
        If SI_Cmp(leftnum, rightnum) < 0 Then
            Throw New LessThanZeroException("结果小于0")
        End If
        Dim l(2000), r(2000), s(2000), lenleft, lenright As Integer
        Dim stsum As String
        Dim flag As Boolean
        lenleft = Len(leftnum)
        lenright = Len(rightnum)
        stsum = ""
        For i = 1 To lenleft
            l(i - 1) = Val(Mid(leftnum, Len(leftnum) - i + 1, 1))
        Next
        For i = 1 To lenright
            r(i - 1) = Val(Mid(rightnum, Len(rightnum) - i + 1, 1))
        Next
        For i = 0 To lenleft
            s(i) = l(i) - r(i)
        Next
        For i = 0 To lenleft
            If s(i) < 0 Then
                s(i + 1) = s(i + 1) - 1
                s(i) = s(i) + 10
            End If
        Next
        For i = lenleft + 1 To 0 Step -1
            If s(i) <> 0 Then
                flag = True
            End If
            If flag Then
                stsum = stsum & CStr(s(i))
            End If
        Next
        Return stsum
    End Function
    Public Function SI_Mul(leftnum As String, rightnum As String) As Integer
        If Len(leftnum) > 1000 Or Len(rightnum) > 1000 Then
            Throw New NumberTooLargeException("数字太大(乘法因数小于1000位)")
        End If
        Dim l(2000), r(2000), s(2000), lenleft, lenright, lenmax As Integer
        Dim stsum As String
        Dim flag As Boolean
        lenleft = Len(leftnum)
        lenright = Len(rightnum)
        If lenleft > lenright Then lenmax = lenleft Else lenmax = lenright
        stsum = ""
        For i = 1 To lenleft
            l(i - 1) = Val(Mid(leftnum, Len(leftnum) - i + 1, 1))
        Next
        For i = 1 To lenright
            r(i - 1) = Val(Mid(rightnum, Len(rightnum) - i + 1, 1))
        Next

    End Function
    Public Function SI_Cmp(leftnum As String, rightnum As String) As Integer
        Dim result As Integer
        If leftnum = rightnum Then
            Return 0
        Else
            If Mid(leftnum, 1, 1) = "-" And Mid(rightnum, 1, 1) <> "-" Then
                Return -1
            ElseIf Mid(leftnum, 1, 1) <> "-" And Mid(rightnum, 1, 1) = "-" Then
                Return 1
            ElseIf Mid(leftnum, 1, 1) = "-" And Mid(rightnum, 1, 1) = "-" Then
                If Len(leftnum) > Len(rightnum) Then
                    Return -1
                ElseIf Len(leftnum) < Len(rightnum) Then
                    Return 1
                Else
                    For i = 2 To Len(leftnum)
                        If Mid(leftnum, i, 1) > Mid(rightnum, i, 1) Then
                            Return -1
                        ElseIf Mid(leftnum, i, 1) < Mid(rightnum, i, 1) Then
                            Return 1
                        End If
                    Next
                End If
            Else
                If Len(leftnum) > Len(rightnum) Then
                    Return 1
                ElseIf Len(leftnum) < Len(rightnum) Then
                    Return -1
                Else
                    For i = 1 To Len(leftnum)
                        If Mid(leftnum, i, 1) > Mid(rightnum, i, 1) Then
                            Return 1
                        ElseIf Mid(leftnum, i, 1) < Mid(rightnum, i, 1) Then
                            Return -1
                        End If
                    Next
                End If
            End If
        End If
        Return result
    End Function
End Class

Public Class NumberTooLargeException : Inherits Exception

    Public Sub New(mes As String)
        MyBase.New(mes)
    End Sub

End Class
Public Class LessThanZeroException : Inherits Exception

    Public Sub New(mes As String)
        MyBase.New(mes)
    End Sub

End Class

