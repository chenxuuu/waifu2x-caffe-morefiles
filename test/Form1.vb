Public Class Form1
    Private Sub TxtFile1_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TextBox1.DragDrop
        Dim str() As String = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
        If str.Length > 1 Then
            Exit Sub
        Else
            TextBox1.Text = str(0)
        End If
    End Sub
    Private Sub TxtFile1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TextBox1.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If (CheckBox1.Checked) Then
            Dim loopsum, loopnow As Integer
            loopsum = Val(TextBox3.Text)
            For loopnow = 1 To loopsum
                TextBox2.Text = "执行中。。。(" & loopnow & "/" & loopsum & ")" & vbNewLine & TextBox2.Text
                If (CheckBox2.Checked) Then
                    TextBox2.Text = "完毕，执行信息：" & vbNewLine & CMD(Application.StartupPath & "\waifu2x-caffe\waifu2x-caffe-cui.exe -i " & TextBox1.Text & " -m noise_scale --scale_ratio 2.0 --noise_level 2 -o " & TextBox1.Text & "x2.png") & vbNewLine & TextBox2.Text
                    TextBox1.Text = TextBox1.Text & "x2.png"
                Else
                    TextBox2.Text = "完毕，执行信息：" & vbNewLine & CMD(Application.StartupPath & "\waifu2x-caffe\waifu2x-caffe-cui.exe -i " & TextBox1.Text & " -m noise_scale --scale_ratio 2.0 --noise_level 2 -o " & TextBox1.Text & "x2.jpg") & vbNewLine & TextBox2.Text
                    TextBox1.Text = TextBox1.Text & "x2.jpg"
                End If
            Next
        Else
            If (CheckBox2.Checked) Then
                TextBox2.Text = "执行中。。。" & vbNewLine & TextBox2.Text
                'TextBox1.Text = "E:\Desktop\waifu2x-caffe\waifu2x-caffe-cui.exe -i " & TextBox1.Text & " -m noise_scale --scale_ratio 2.0 --noise_level 2"

                TextBox2.Text = "完毕，执行信息：" & vbNewLine & CMD(Application.StartupPath & "\waifu2x-caffe\waifu2x-caffe-cui.exe -i " & TextBox1.Text & " -m noise_scale --scale_ratio 2.0 --noise_level 2 -o " & TextBox1.Text & "x2.png") & vbNewLine & TextBox2.Text

            Else

                TextBox2.Text = "执行中。。。" & vbNewLine & TextBox2.Text
                'TextBox1.Text = "E:\Desktop\waifu2x-caffe\waifu2x-caffe-cui.exe -i " & TextBox1.Text & " -m noise_scale --scale_ratio 2.0 --noise_level 2"

                TextBox2.Text = "完毕，执行信息：" & vbNewLine & CMD(Application.StartupPath & "\waifu2x-caffe\waifu2x-caffe-cui.exe -i " & TextBox1.Text & " -m noise_scale --scale_ratio 2.0 --noise_level 2 -o " & TextBox1.Text & "x2.jpg") & vbNewLine & TextBox2.Text
            End If
        End If
    End Sub
    Function CMD(ByVal Data As String) As String
        Try
            Dim p As New Process()
            p.StartInfo.FileName = "cmd.exe"
            p.StartInfo.UseShellExecute = False
            p.StartInfo.RedirectStandardInput = True
            p.StartInfo.RedirectStandardOutput = True
            p.StartInfo.RedirectStandardError = True
            p.StartInfo.CreateNoWindow = True
            p.Start()
            Application.DoEvents()
            p.StandardInput.WriteLine(Data)
            p.StandardInput.WriteLine("Exit")
            Dim strRst As String = p.StandardOutput.ReadToEnd()
            p.Close()
            Return strRst
        Catch ex As Exception
            Return ""
        End Try
    End Function

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Label1.Text = TextBox1.Text
    '    Process.Start("cmd.exe /c E: \Desktop\waifu2x-caffe\waifu2x-caffe-cui.exe" & "-i " & TextBox1.Text & "-m noise_scale --scale_ratio 2.0 --noise_level 2" & "&&pause")
    'End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Label1.Text = Application.StartupPath
        'For Each foundFile As String In My.Computer.FileSystem.GetFiles(TextBox1.Text)
        '    MsgBox(foundFile)
        'Next
        If (CheckBox1.Checked) Then
            Dim filesum, sumnow As ULong
            filesum = 0
            sumnow = 0
            For Each foundFile As String In My.Computer.FileSystem.GetFiles(TextBox1.Text)
                filesum = filesum + 1
            Next
            For Each foundFile As String In My.Computer.FileSystem.GetFiles(TextBox1.Text)


                Dim loopsum, loopnow As Integer
                loopsum = Val(TextBox3.Text)
                sumnow = sumnow + 1
                For loopnow = 1 To loopsum
                    TextBox2.Text = "(" & sumnow & "/" & filesum & ") " & "单个进度(" & loopnow & "/" & loopsum & ")" & "正在处理文件:" & vbNewLine & foundFile & vbNewLine & TextBox2.Text
                    If (CheckBox2.Checked) Then
                        TextBox2.Text = "完毕，执行信息：" & vbNewLine & CMD(Application.StartupPath & "\waifu2x-caffe\waifu2x-caffe-cui.exe -i " & foundFile & " -m noise_scale --scale_ratio 2.0 --noise_level 2 -o " & foundFile & "x2.png") & vbNewLine & TextBox2.Text
                        foundFile = foundFile & "x2.png"
                    Else

                        TextBox2.Text = "完毕，执行信息：" & vbNewLine & CMD(Application.StartupPath & "\waifu2x-caffe\waifu2x-caffe-cui.exe -i " & foundFile & " -m noise_scale --scale_ratio 2.0 --noise_level 2 -o " & foundFile & "x2.jpg") & vbNewLine & TextBox2.Text
                        foundFile = foundFile & "x2.jpg"
                    End If
                Next


            Next
                Else
            Dim filesum, sumnow As Integer
            filesum = 0
            sumnow = 0
            For Each foundFile As String In My.Computer.FileSystem.GetFiles(TextBox1.Text)
                filesum = filesum + 1
            Next
            For Each foundFile As String In My.Computer.FileSystem.GetFiles(TextBox1.Text)
                sumnow = sumnow + 1
                TextBox2.Text = "(" & sumnow & "/" & filesum & ") 正在处理文件:" & vbNewLine & foundFile & vbNewLine & TextBox2.Text
                If (CheckBox2.Checked) Then
                    TextBox2.Text = "完毕，执行信息：" & vbNewLine & CMD(Application.StartupPath & "\waifu2x-caffe\waifu2x-caffe-cui.exe -i " & foundFile & " -m noise_scale --scale_ratio 2.0 --noise_level 2 -o " & foundFile & "x2.png") & vbNewLine & TextBox2.Text
                Else
                    TextBox2.Text = "完毕，执行信息：" & vbNewLine & CMD(Application.StartupPath & "\waifu2x-caffe\waifu2x-caffe-cui.exe -i " & foundFile & " -m noise_scale --scale_ratio 2.0 --noise_level 2 -o " & foundFile & "x2.jpg") & vbNewLine & TextBox2.Text
                End If
            Next
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MsgBox("批量图片放大" & vbNewLine & "by 晨旭" & vbNewLine & "chenxublog.com")
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If (CheckBox1.Checked) Then
            If (Val(TextBox3.Text) > 5) Then
                TextBox3.Text = 5
            ElseIf (Val(TextBox3.Text) < 1) Then
                TextBox3.Text = 1
            Else
                Label2.Text = "次。(现为放大" & 2 ^ Val(TextBox3.Text) & "倍)"
            End If
        Else
                Label2.Text = "次。(现为放大2倍)"
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox2.Text = ""
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If (CheckBox1.Checked) Then
            If (Val(TextBox3.Text) > 5) Then
                TextBox3.Text = 5
            ElseIf (Val(TextBox3.Text) < 1) Then
                TextBox3.Text = 1
            Else
                Label2.Text = "次。(现为放大" & 2 ^ Val(TextBox3.Text) & "倍)"
            End If
        Else
            Label2.Text = "次。(现为放大2倍)"
        End If
    End Sub
End Class
