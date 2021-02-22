Imports System.Runtime.InteropServices
Imports System.Diagnostics

Public Class AppContext
    Inherits ApplicationContext

    Public WithEvents Tray As NotifyIcon
    Public WithEvents MainMenu As ContextMenuStrip
    Private WithEvents mnuSaveSettings As ToolStripMenuItem
    Private WithEvents mnuHelpAbout As ToolStripMenuItem
    Private WithEvents mnuSep1 As ToolStripSeparator
    Private WithEvents mnuExit As ToolStripMenuItem

    Public Sub New()
        'Initialize the menus
        mnuSaveSettings = New ToolStripMenuItem("Manage Profiles")
        mnuHelpAbout = New ToolStripMenuItem("About TAN Window Manager")
        mnuSep1 = New ToolStripSeparator()
        mnuExit = New ToolStripMenuItem("Exit")
        MainMenu = New ContextMenuStrip
        MainMenu.Items.AddRange(New ToolStripItem() {mnuHelpAbout, mnuSaveSettings, mnuSep1, mnuExit})

        'Initialize the tray
        Tray = New NotifyIcon
        Tray.Icon = My.Resources.TrayIcon
        Tray.ContextMenuStrip = MainMenu
        Tray.Text = "TAN Window Manager"

        'Display
        Tray.Visible = True

        'Form1.TWMAppContext = Me
    End Sub

    Private Sub AppContext_ThreadExit(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles Me.ThreadExit
        'Guarantees that the icon will not linger.
        Tray.Visible = False
    End Sub

    Private Sub mnuSaveSettings_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles mnuSaveSettings.Click
        If Not Form1.Visible Then Form1.Show() : Form1.Activate()
    End Sub

    Private Sub mnuHelpAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles mnuHelpAbout.Click
        If Not frmAbout.Visible Then frmAbout.Show() : frmAbout.Activate()
    End Sub

    Private Sub mnuExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles mnuExit.Click
        Application.Exit()
    End Sub

    Private Sub Tray_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles Tray.DoubleClick

        If Not frmAbout.Visible Then frmAbout.Show() : frmAbout.Activate()

    End Sub

    Private Sub Tray_Click(sender As Object, e As EventArgs) Handles Tray.Click

        Form1.cboProfiles.Items.Clear()
        Form1.cboProfiles.Items.Add("Default")
        Form1.cboProfiles.SelectedIndex = 0

        If Not IO.File.Exists("Settings.ini") Then Exit Sub

        Dim lines As List(Of String) = IO.File.ReadAllLines("Settings.ini").ToList
        Dim lstMenuItems As New List(Of String)

        For i As Integer = MainMenu.Items.Count - 1 To 0 Step -1
            If TypeOf (MainMenu.Items(i)) Is ToolStripMenuItem Then
                If CType(MainMenu.Items(i), ToolStripMenuItem).Text.StartsWith("Load Profile: ") Then MainMenu.Items.Remove(MainMenu.Items(i))
            End If
        Next

        For Each line In lines.ToList
            Dim specs() = line.Split(",")

            If specs.Length = 7 Then
                If Not Form1.cboProfiles.Items.Contains(specs(6)) Then
                    Form1.cboProfiles.Items.Add(specs(6))

                    Dim profMnu = New ToolStripMenuItem("Load Profile: " & specs(6)) With {.Tag = specs(6)}
                    MainMenu.Items.Insert(3, profMnu)
                    AddHandler profMnu.Click, AddressOf Form1.RestoreMenuProfile
                End If

            End If
        Next

        Dim profMnuDef = New ToolStripMenuItem("Load Profile: Default") With {.Tag = "Default"}
        MainMenu.Items.Insert(3, profMnuDef)
        AddHandler profMnuDef.Click, AddressOf Form1.RestoreMenuProfile

        'Form1.TWMAppContext = Me
    End Sub
End Class