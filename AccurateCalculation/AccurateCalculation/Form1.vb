
Public Class Form1
    Const NUMMAX = 2000
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
        MsgBox(UI_Pow("10", "10"))
    End Sub
    Public Function UI_Add(leftnum As String, rightnum As String) As String
        leftnum = SF_Adj(leftnum)
        rightnum = SF_Adj(rightnum)
        If Len(leftnum) > NUMMAX Or Len(rightnum) > NUMMAX Then
            Throw New NumberTooLargeException("数字太大")
        End If

        Dim l(NUMMAX), r(NUMMAX), s(NUMMAX), lenleft, lenright, lenmax As Integer
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
        leftnum = SF_Adj(leftnum)
        rightnum = SF_Adj(rightnum)
        If Len(leftnum) > NUMMAX Or Len(rightnum) > NUMMAX Then
            Throw New NumberTooLargeException("数字太大")
        End If
        If SI_Cmp(leftnum, rightnum) < 0 Then
            Throw New LessThanZeroException("结果小于0")
        End If
        Dim l(NUMMAX), r(NUMMAX), s(NUMMAX), lenleft, lenright As Integer
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
    Public Function UI_Mul(leftnum As String, rightnum As String) As String
        leftnum = SF_Adj(leftnum)
        rightnum = SF_Adj(rightnum)
        If Len(leftnum) > NUMMAX \ 2 Or Len(rightnum) > NUMMAX \ 2 Then
            Throw New NumberTooLargeException("数字太大(乘法因数小于1000位)")
        End If
        Dim l(NUMMAX \ 2), r(NUMMAX \ 2), s(1000, NUMMAX), ss(NUMMAX), lenleft, lenright, lenmax As Integer
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
        For i = 0 To lenright
            For j = 0 To lenleft
                s(i, j + i) = l(j) * r(i)
            Next
        Next
        For i = 1 To lenright + lenleft + 1
            For j = 0 To lenright + lenleft + 1
                s(0, j + i) = s(0, j + i) + s(i, j + i)
            Next
        Next
        For i = 0 To lenright + lenleft + 1
            ss(i) = ss(i) + s(0, i)
        Next
        For i = 0 To lenright + lenleft + 1
            ss(i + 1) = ss(i + 1) + ss(i) \ 10
            ss(i) = ss(i) Mod 10
        Next
        For i = lenright + lenleft + 1 To 0 Step -1
            If ss(i) <> 0 Then
                flag = True
            End If
            If flag Then
                stsum = stsum & CStr(ss(i))
            End If
        Next
        Return stsum
    End Function
    Public Function UI_Div(leftnum As String, rightnum As String) As String
        leftnum = SF_Adj(leftnum)
        rightnum = SF_Adj(rightnum)
        If Len(leftnum) > NUMMAX Or Len(rightnum) > NUMMAX Then
            Throw New NumberTooLargeException("数字太大")
        End If
        If rightnum = 0 Or rightnum = "" Then
            Throw New DivideByZeroException
        End If
        If SI_Cmp(leftnum, rightnum) = 0 Then
            Return "1"
        End If
        If SI_Cmp(leftnum, rightnum) = -1 Then
            Return "0"
        End If
        Dim lenleft, lenright, numnow As Integer
        Dim stsum, subnow, lft, lftrest, rgt, subprev As String
        Dim last, start As Boolean
        stsum = ""
        last = False
        start = False
        lenleft = Len(leftnum)
        lenright = Len(rightnum)
        rgt = rightnum
        lft = Mid(leftnum, 1, lenright)
        lftrest = Mid(leftnum, lenright + 1)
        If Len(lftrest) = 0 Then
            last = True
        End If
        Do
            numnow = 1
            subnow = rgt
            subprev = "0"
            Do While SI_Cmp(subnow, lft) <= 0
                numnow += 1
                subprev = subnow
                subnow = UI_Add(subnow, rgt)
            Loop
            numnow -= 1
            If numnow > 0 Then
                start = True
            End If
            If start = True Then
                stsum = stsum + CStr(numnow)
            End If
            lft = UI_Sub(lft, subprev)
            lft = lft + Mid(lftrest, 1, 1)
            lftrest = Mid(lftrest, 2)
            If last = True Then
                Return stsum
            End If
            If Len(lftrest) = 0 Then
                last = True
            End If
        Loop
    End Function
    Public Function UI_Mod(leftnum As String, rightnum As String) As String
        leftnum = SF_Adj(leftnum)
        rightnum = SF_Adj(rightnum)
        ' a mod b =a-(a div b)*b
        Return SF_Adj(UI_Sub(leftnum, UI_Mul(UI_Div(leftnum, rightnum), rightnum)))
    End Function
    Public Function UI_Pow(leftnum As String, rightnum As String) As String
        leftnum = SF_Adj(leftnum)
        rightnum = SF_Adj(rightnum)
        Dim result, numnow As String
        result = 1
        numnow = "0"
        Do While SI_Cmp(numnow, rightnum) < 0
            result = UI_Mul(result, leftnum)
            numnow = UI_Add(numnow, "1")
        Loop
        Return result

    End Function
    Public Function SI_Cmp(leftnum As String, rightnum As String) As Integer
        leftnum = SF_Adj(leftnum)
        rightnum = SF_Adj(rightnum)
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
    Public Function SF_Adj(numstr As String) As String
        Dim tail, ptr As Integer
        Dim reslft, resrgt, ch, ptrlft, ptrrgt As String
        Dim start As Boolean
        'flag0 "-" 0000  1 flag1 23456789  "." flag2 tail flag3
        '0.0
        ptr = 0
        ch = ""

        If numstr = "" Then
            Return "0"
        End If
        For i = 1 To Len(numstr)
            If Mid(numstr, i, 1) = "." Then
                ptr = i
                Exit For
            End If
        Next
        If ptr = 0 Then
            ptr = Len(numstr) + 1
        End If
        ptrlft = Mid(numstr, 1, ptr - 1)
        ptrrgt = Mid(numstr, ptr + 1)
        For i = 1 To Len(ptrlft)
            ch = Mid(ptrlft, i, 1)

            If ch = "-" And i >= 2 Then
                Throw New WrongTypeException("数字错误")
            End If
            If ch = "-" Then
                reslft = "-"
            End If
            If ch <> "-" And ch <> "0" Then
                start = True
            End If
            If start = True Then
                reslft = reslft + ch
            End If
        Next
        tail = True
        For i = Len(ptrrgt) To 1 Step -1
            ch = Mid(ptrrgt, i, 1)
            If ch = "." Or ch = "-" Then
                Throw New WrongTypeException("数字错误")
            End If
            If ch <> "0" Then
                tail = False
            End If
            If tail = False Then
                resrgt = ch + resrgt
            End If
        Next
        If ptr = Len(numstr) + 1 Or ptrrgt = "" Then
            Return reslft
        ElseIf reslft = "" And resrgt = "" Then
            Return "0"
        Else
            Return reslft + "." + resrgt
        End If


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
Public Class WrongTypeException : Inherits Exception

    Public Sub New(mes As String)
        MyBase.New(mes)
    End Sub

End Class


