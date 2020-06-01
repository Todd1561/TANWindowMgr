Imports System.Runtime.InteropServices
Imports System.Diagnostics

Public Class AppContext
    Inherits ApplicationContext

    Private WithEvents Tray As NotifyIcon
    Private WithEvents MainMenu As ContextMenuStrip
    Private WithEvents mnuSaveSettings As ToolStripMenuItem
    Private WithEvents mnuRestoreSettings As ToolStripMenuItem
    Private WithEvents mnuHelpAbout As ToolStripMenuItem
    Private WithEvents mnuSep1 As ToolStripSeparator
    Private WithEvents mnuExit As ToolStripMenuItem

    Public Sub New()
        'Initialize the menus
        mnuSaveSettings = New ToolStripMenuItem("Save Window Locations")
        mnuRestoreSettings = New ToolStripMenuItem("Restore Window Locations")
        mnuHelpAbout = New ToolStripMenuItem("About TAN Window Manager")
        mnuSep1 = New ToolStripSeparator()
        mnuExit = New ToolStripMenuItem("Exit")
        MainMenu = New ContextMenuStrip
        MainMenu.Items.AddRange(New ToolStripItem() {mnuHelpAbout, mnuSaveSettings, mnuRestoreSettings, mnuSep1, mnuExit})

        'Initialize the tray
        Tray = New NotifyIcon
        Tray.Icon = My.Resources.TrayIcon
        Tray.ContextMenuStrip = MainMenu
        Tray.Text = "TAN Window Manager"

        'Display
        Tray.Visible = True
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

    Private Sub mnuRestoreSettings_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles mnuRestoreSettings.Click
        If My.Computer.FileSystem.FileExists("Settings.ini") Then
            Form1.RestoreSettings()
        Else
            Tray.BalloonTipText = "Settings file does not exist!"
            Tray.ShowBalloonTip(5000)
        End If
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

End Class