Module LaunchApp

    Public Sub Main(ByVal args() As String)
        Dim AutoExit As Boolean = False
        'Form1.TWMAppContext = New AppContext

        For Each arg As String In args
            If arg.ToLower = "/saveall" Or arg.ToLower = "-saveall" Then
                Dim f As New Form1

                f.Form1_Load(Nothing, Nothing)
                f.CheckAllWindows()
                f.btnSave_Click(Nothing, Nothing)
            End If

            If arg.ToLower = "/restore" Or arg.ToLower = "-restore" Then
                Dim f As New Form1
                f.RestoreSettings("Default")

            End If

            If arg.StartsWith("/restore=") Or arg.StartsWith("-restore=") Then
                Dim f As New Form1
                f.RestoreSettings(arg.Substring(9))

            End If

            If arg.ToLower = "/autoexit" Or arg.ToLower = "-autoexit" Then AutoExit = True

        Next

        If AutoExit Then Exit Sub

        Application.EnableVisualStyles()
        Application.Run(New AppContext)

    End Sub

End Module
