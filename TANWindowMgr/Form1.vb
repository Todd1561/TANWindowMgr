﻿Imports System.Runtime.InteropServices
Imports System.Diagnostics

Public Class Form1

    Public WindowList As New Dictionary(Of String, String)

    Private Declare Function GetWindowPlacement Lib "user32" (ByVal hwnd As IntPtr, ByRef lpwndpl As WINDOWPLACEMENT) As Integer
    <DllImport("user32.dll")>
    Private Shared Function SetWindowPlacement(ByVal hWnd As IntPtr, ByRef lpwndpl As WINDOWPLACEMENT) As Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function FindWindow(idThread As Integer, lpWindowName As String) As IntPtr
    End Function

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

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        GetWindowList()

        Dim file As System.IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter("Settings.ini", False)

        For Each item As ListViewItem In lvApps.Items
            If item.Checked Then

                Dim hWnd As IntPtr = FindWindow(Nothing, WindowList(item.Text))
                Dim wpTemp As WINDOWPLACEMENT
                GetWindowPlacement(hWnd, wpTemp)

                file.WriteLine(item.Text & "," & wpTemp.rcNormalPosition.Left & "," & wpTemp.rcNormalPosition.Top & "," & wpTemp.rcNormalPosition.Bottom & "," & wpTemp.rcNormalPosition.Right & "," & wpTemp.showCmd)

            End If
        Next

        file.Close()
        Me.Close()

    End Sub

    Sub GetWindowList()

        Dim pList() = Process.GetProcesses
        WindowList.Clear()

        For Each proc As Process In pList
            If Not String.IsNullOrEmpty(proc.MainWindowTitle) Then

                Try
                    If Not WindowList.ContainsKey(proc.ProcessName) And proc.Responding And proc.ProcessName <> "ApplicationFrameHostx" And proc.ProcessName <> "TANWindowMgr" Then WindowList.Add(proc.ProcessName, proc.MainWindowTitle)
                Catch ex As Exception
                    Debug.WriteLine(ex.Message)
                End Try

            End If

        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        GetWindowList()

        For Each window As KeyValuePair(Of String, String) In WindowList
            Dim lvi As New ListViewItem(window.Key)
            lvi.SubItems.Add(window.Value)
            lvApps.Items.Add(lvi)
        Next

    End Sub

    Sub RestoreSettings()

        GetWindowList()

        Dim file As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader("Settings.ini")

        Do Until file.EndOfStream

            Dim specs() = file.ReadLine().Split(",")

            If WindowList.ContainsKey(specs(0)) Then

                Dim hWnd As IntPtr = FindWindow(Nothing, WindowList(specs(0)))
                Dim wpTemp As WINDOWPLACEMENT
                GetWindowPlacement(hWnd, wpTemp)
                wpTemp.showCmd = 1
                SetWindowPlacement(hWnd, wpTemp)
                wpTemp.rcNormalPosition.Left = specs(1)
                wpTemp.rcNormalPosition.Top = specs(2)
                wpTemp.rcNormalPosition.Bottom = specs(3)
                wpTemp.rcNormalPosition.Right = specs(4)
                wpTemp.showCmd = specs(5)
                SetWindowPlacement(hWnd, wpTemp)

            End If

        Loop

        file.Close()

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class