VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   3135
   ClientLeft      =   60
   ClientTop       =   405
   ClientWidth     =   4680
   LinkTopic       =   "Form1"
   ScaleHeight     =   3135
   ScaleWidth      =   4680
   StartUpPosition =   3  '窗口缺省
   Begin VB.TextBox Text1 
      Height          =   495
      Left            =   2880
      TabIndex        =   3
      Text            =   "10"
      Top             =   360
      Width           =   975
   End
   Begin VB.ListBox List2 
      Height          =   2580
      Left            =   1200
      TabIndex        =   2
      Top             =   120
      Width           =   735
   End
   Begin VB.ListBox List1 
      Height          =   2580
      Left            =   360
      TabIndex        =   1
      Top             =   120
      Width           =   735
   End
   Begin VB.CommandButton Command1 
      Caption         =   "生成"
      Height          =   615
      Left            =   2760
      TabIndex        =   0
      Top             =   960
      Width           =   1215
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Command1_Click()
Dim num(100), nm(100) As Integer
Dim t, n As Integer
List1.Clear
List2.Clear
Randomize
n = Val(Text1.Text)
For i = 1 To n
    num(i) = Int(Rnd * 100)
    For j = 1 To i - 1
        If num(i) = num(j) Then
            i = i - 1
            Exit For
        End If
    Next
Next
For a = 1 To n
    For b = 1 To n - a
        If num(b) > num(b + 1) Then
            t = num(b): num(b) = num(b + 1): num(b + 1) = t
        End If
    Next
Next
For i = 1 To n
    List1.AddItem num(i)
Next
For i = 1 To n
    If i Mod 2 = 1 Then
        t = (i + 1) / 2
    Else
        t = n + 1 - i / 2
    End If
    nm(t) = num(i)
Next
For i = 1 To n
    List2.AddItem nm(i)
Next
End Sub
