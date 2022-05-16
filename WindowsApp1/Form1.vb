Public Class Form1

    Private Const path As String = "C:\Users\yueka\Desktop\test\"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim xml As String = My.Resources.xml

        Dim lbl1 As String = Me.TextBox1.Text
        Dim lbl2 As String = Me.TextBox2.Text

        xml = xml.Replace("$$str$$", lbl1)
        xml = xml.Replace("$$query$$", lbl2)

        ' 戻り値を格納する変数を宣言する
        Dim hStream As System.IO.FileStream

        ' hStream が破棄されることを保証するために Try ～ Finally を使用する
        Try
            ' hStream が閉じられることを保証するために Try ～ Finally を使用する
            Try
                ' 指定したパスのファイルを作成する
                hStream = System.IO.File.Create(path & "test.xml")
            Finally
                ' 作成時に返される FileStream を利用して閉じる
                If Not hStream Is Nothing Then
                    hStream.Close()
                End If
            End Try
        Finally
            ' hStream を破棄する
            If Not hStream Is Nothing Then
                Dim cDisposable As System.IDisposable = hStream
                cDisposable.Dispose()
            End If
        End Try

        Dim sw As New System.IO.StreamWriter(path & "test.xml", False, System.Text.Encoding.GetEncoding("shift_jis"))
        sw.WriteLine(xml)
        sw.Close()

    End Sub
End Class
