Public Class Form1
	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Dim acc As New AccCal.Class1
		Dim ifstream As IO.FileStream = New IO.FileStream("in.txt", IO.FileMode.Open)
		Dim num(1000000) As Byte
		Dim i = 0
		MsgBox(acc.UI_Add("1", "3"))
		Do While ifstream.Position < ifstream.Length
			num(i) = ifstream.ReadByte()
			i = i + 1
		Loop

		ifstream.Close()
	End Sub
End Class
