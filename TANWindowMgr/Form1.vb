Imports System.Runtime.InteropServices
Imports System.Diagnostics
Imports System.IO

Public Class Form1
    Public WindowList As New Dictionary(Of String, Process)
    'Public TWMAppContext As AppContext

    Private Declare Function GetWindowPlacement Lib "user32" (ByVal hwnd As IntPtr, ByRef lpwndpl As WINDOWPLACEMENT) As Integer
    <DllImport("user32.dll")>
    Private Shared Function SetWindowPlacement(ByVal hWnd As IntPtr, ByRef lpwndpl As WINDOWPLACEMENT) As Boolean
    End Function
    <DllImport("user32.dll")>
    Private Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As Boolean
    End Function

    '<DllImport("user32.dll", SetLastError:=True)>
    'Private Shared Function FindWindow(idThread As Integer, lpWindowName As String) As IntPtr
    'End Function

    Private Structure POINTAPI
        Public x As Integer
        Public y As Integer
    End Structure

    Private Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure

    Private Structure WINDOWPLACEMENT
        Public Length As Integer
        Public flags As Integer
        Public showCmd As Integer
        Public ptMinPosition As POINTAPI
        Public ptMaxPosition As POINTAPI
        Public rcNormalPosition As RECT
    End Structure

    Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        GetWindowList()

        Dim lines As New List(Of String)

        'read in current settings file, convert to list, and remove any settings for the selected profile
        If File.Exists("Settings.ini") Then

            lines = File.ReadAllLines("Settings.ini").ToList

            For Each line In lines.ToList
                Dim specs() = line.Split(",")

                If (cboProfiles.SelectedItem = "Default" And specs.Length = 6) OrElse (specs.Length = 7 AndAlso specs(6) = cboProfiles.SelectedItem) Then
                    lines.Remove(line)
                End If
            Next
        End If

        'iterate over all selected apps and add to list
        For Each item As ListViewItem In lvApps.Items
            If item.Checked Then

                Dim hWnd As IntPtr = WindowList(item.Text).MainWindowHandle ' FindWindow(WindowList(item.Text).Id, Nothing)
                Dim wpTemp As WINDOWPLACEMENT
                GetWindowPlacement(hWnd, wpTemp)

                lines.Add(item.Text & "," & wpTemp.rcNormalPosition.Left & "," & wpTemp.rcNormalPosition.Top & "," & wpTemp.rcNormalPosition.Bottom & "," & wpTemp.rcNormalPosition.Right & "," & wpTemp.showCmd & "," & cboProfiles.SelectedItem)

            End If
        Next

        'save list to settings file
        File.WriteAllLines("Settings.ini", lines)

        Me.Close()

    End Sub

    Sub GetWindowList()

        Dim pList() = Process.GetProcesses
        WindowList.Clear()

        For Each proc As Process In pList
            If Not String.IsNullOrEmpty(proc.MainWindowTitle) Then

                Try
                    If Not WindowList.ContainsKey(proc.ProcessName) And proc.Responding And proc.ProcessName <> "ApplicationFrameHostx" And proc.ProcessName <> "TANWindowMgr" And proc.MainWindowTitle <> "" Then WindowList.Add(proc.ProcessName, proc) 'applicationframehost is needed for metro apps like sticky notes
                Catch ex As Exception
                    Debug.WriteLine(ex.Message)
                End Try

            End If

        Next
    End Sub

    Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        GetWindowList()

        For Each window As KeyValuePair(Of String, Process) In WindowList
            Dim lvi As New ListViewItem(window.Key)
            lvi.SubItems.Add(window.Value.MainWindowTitle)
            lvApps.Items.Add(lvi)
        Next

    End Sub

    Sub RestoreMenuProfile(sender As Object, e As EventArgs)
        Dim profName As String = CType(sender, ToolStripMenuItem).Tag
        RestoreSettings(profName)
    End Sub
    Sub RestoreSettings(ProfName As String)
        If File.Exists("Settings.ini") Then
            GetWindowList()

            Dim file As StreamReader = My.Computer.FileSystem.OpenTextFileReader("Settings.ini")

            Do Until file.EndOfStream

                Dim specs() = file.ReadLine().Split(",")

                If (ProfName.ToLower = "default" And specs.Length = 6) OrElse (specs.Length = 7 AndAlso specs(6).ToLower = ProfName.ToLower) Then

                    If WindowList.ContainsKey(specs(0)) Then

                        Dim hWnd As IntPtr = WindowList(specs(0)).MainWindowHandle ' FindWindow(Nothing, WindowList(specs(0)).MainWindowTitle)

                        Dim wpTemp As WINDOWPLACEMENT
                        GetWindowPlacement(hWnd, wpTemp)
                        wpTemp.showCmd = 1
                        SetWindowPlacement(hWnd, wpTemp)
                        SetForegroundWindow(hWnd)
                        wpTemp.rcNormalPosition.Left = specs(1)
                        wpTemp.rcNormalPosition.Top = specs(2)
                        wpTemp.rcNormalPosition.Bottom = specs(3)
                        wpTemp.rcNormalPosition.Right = specs(4)
                        wpTemp.showCmd = specs(5)

                        SetWindowPlacement(hWnd, wpTemp)

                    End If

                End If

            Loop

            file.Close()
        Else
            MsgBox("Settings file does not exist!")
            'TWMAppContext.Tray.BalloonTipText = "Settings file does not exist!"
            'TWMAppContext.Tray.ShowBalloonTip(5000)
        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Sub CheckAllWindows()
        For Each item As ListViewItem In lvApps.Items
            item.Checked = True
        Next
    End Sub

    Sub btnSaveAll_Click(sender As Object, e As EventArgs) Handles btnSaveAll.Click
        CheckAllWindows()
        btnSave.PerformClick()
    End Sub
    Private Sub btnDelProfile_Click(sender As Object, e As EventArgs) Handles btnDelProfile.Click

        If cboProfiles.SelectedItem = "Default" Then
            MsgBox("You can't delete the Default profile.")
        Else

            Dim lines As List(Of String) = File.ReadAllLines("Settings.ini").ToList

            For Each line In lines.ToList
                Dim specs() = line.Split(",")

                If (specs.Length = 7 AndAlso specs(6) = cboProfiles.SelectedItem) Then
                    lines.Remove(line)
                End If
            Next

            cboProfiles.Items.Remove(cboProfiles.SelectedItem)
            cboProfiles.SelectedIndex = 0

            File.WriteAllLines("Settings.ini", lines)
        End If
    End Sub

    Private Sub btnAddProfile_Click(sender As Object, e As EventArgs) Handles btnAddProfile.Click
        Dim response As String = InputBox("Supply a profile name", "Add Profile").Replace(",", "").Replace("""", "").Trim

        If response.ToLower = "default" Then
            MsgBox("'Default' is a reserved profile name.")
        ElseIf cboProfiles.Items.Contains(response) Then
            MsgBox("This profile name already exists.")
        ElseIf response <> "" Then
            cboProfiles.Items.Add(response)
            cboProfiles.SelectedItem = response
        End If
    End Sub
End Class
