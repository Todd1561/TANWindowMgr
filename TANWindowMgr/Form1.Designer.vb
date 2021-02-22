<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.lvApps = New System.Windows.Forms.ListView()
        Me.Application = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.WindowTitle = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSaveAll = New System.Windows.Forms.Button()
        Me.cboProfiles = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnDelProfile = New System.Windows.Forms.Button()
        Me.btnAddProfile = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lvApps
        '
        Me.lvApps.CheckBoxes = True
        Me.lvApps.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Application, Me.WindowTitle})
        Me.lvApps.HideSelection = False
        Me.lvApps.Location = New System.Drawing.Point(12, 29)
        Me.lvApps.Name = "lvApps"
        Me.lvApps.Size = New System.Drawing.Size(478, 251)
        Me.lvApps.TabIndex = 0
        Me.lvApps.UseCompatibleStateImageBehavior = False
        Me.lvApps.View = System.Windows.Forms.View.Details
        '
        'Application
        '
        Me.Application.Text = "Application"
        Me.Application.Width = 120
        '
        'WindowTitle
        '
        Me.WindowTitle.Text = "Window Title"
        Me.WindowTitle.Width = 354
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(318, 285)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 23)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save Selected"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(222, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Select the applications and the profile to save"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(415, 285)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSaveAll
        '
        Me.btnSaveAll.Location = New System.Drawing.Point(234, 285)
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveAll.TabIndex = 4
        Me.btnSaveAll.Text = "Save All"
        Me.btnSaveAll.UseVisualStyleBackColor = True
        '
        'cboProfiles
        '
        Me.cboProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProfiles.FormattingEnabled = True
        Me.cboProfiles.Location = New System.Drawing.Point(50, 287)
        Me.cboProfiles.Name = "cboProfiles"
        Me.cboProfiles.Size = New System.Drawing.Size(118, 21)
        Me.cboProfiles.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 291)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Profile"
        '
        'btnDelProfile
        '
        Me.btnDelProfile.BackColor = System.Drawing.Color.Transparent
        Me.btnDelProfile.FlatAppearance.BorderSize = 0
        Me.btnDelProfile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnDelProfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnDelProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelProfile.ForeColor = System.Drawing.Color.Transparent
        Me.btnDelProfile.Image = Global.TANWindowMgr.My.Resources.Resources.x
        Me.btnDelProfile.Location = New System.Drawing.Point(191, 285)
        Me.btnDelProfile.Name = "btnDelProfile"
        Me.btnDelProfile.Size = New System.Drawing.Size(21, 23)
        Me.btnDelProfile.TabIndex = 7
        Me.btnDelProfile.UseVisualStyleBackColor = False
        '
        'btnAddProfile
        '
        Me.btnAddProfile.BackColor = System.Drawing.Color.Transparent
        Me.btnAddProfile.FlatAppearance.BorderSize = 0
        Me.btnAddProfile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnAddProfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnAddProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddProfile.ForeColor = System.Drawing.Color.Transparent
        Me.btnAddProfile.Image = Global.TANWindowMgr.My.Resources.Resources.greenPlus
        Me.btnAddProfile.Location = New System.Drawing.Point(170, 285)
        Me.btnAddProfile.Name = "btnAddProfile"
        Me.btnAddProfile.Size = New System.Drawing.Size(21, 23)
        Me.btnAddProfile.TabIndex = 8
        Me.btnAddProfile.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(502, 316)
        Me.Controls.Add(Me.btnAddProfile)
        Me.Controls.Add(Me.btnDelProfile)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboProfiles)
        Me.Controls.Add(Me.btnSaveAll)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lvApps)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TAN Window Manager"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lvApps As ListView
    Friend WithEvents Application As ColumnHeader
    Friend WithEvents WindowTitle As ColumnHeader
    Friend WithEvents btnSave As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSaveAll As Button
    Friend WithEvents cboProfiles As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnDelProfile As Button
    Friend WithEvents btnAddProfile As Button
End Class
