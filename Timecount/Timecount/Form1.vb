Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim yearnow, monthnow, daynow As Integer
        Dim yearlast, monthlast, daylast As Integer
        Dim sum As Integer
        sum = 0
        yearnow = Date.Now.Year
        monthnow = Date.Now.Month
        daynow = Date.Now.Day
        yearlast = 2021
        monthlast = 6
        daylast = 7
        Do While True
            Do While monthnow <= 12
                Do While daynow <= days(yearnow, monthnow)
                    daynow += 1
                    sum += 1
                    If Not (yearnow < yearlast Or monthnow < monthlast Or daynow < daylast) Then
                        Exit Do
                    End If
                Loop
                If Not (yearnow < yearlast Or monthnow < monthlast Or daynow < daylast) Then
                    Exit Do
                End If
                daynow = 1
                monthnow += 1
            Loop
            If Not (yearnow < yearlast Or monthnow < monthlast Or daynow < daylast) Then
                Exit Do
            End If
            monthnow = 1
            yearnow += 1
        Loop
        Label1.Text = "距离高考还有 ："
        Label2.Text = sum & "天"

    End Sub
    Private Function days(yea As Integer, mon As Integer) As Integer
        Select Case mon
            Case 1, 3, 5, 7, 8, 10, 12
                Return 31
                Exit Function
            Case 4, 6, 9, 11
                Return 30
                Exit Function
            Case 2
                If runnian(yea) = True Then
                    Return 29
                Else
                    Return 28
                End If
                Exit Function
        End Select
    End Function
    Private Function runnian(y As Integer) As Boolean
        If (y Mod 400 = 0) Or (y Mod 4 = 0 And y Mod 100 <> 0) Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
