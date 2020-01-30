<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.CboxPlans = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtOwner = New System.Windows.Forms.TextBox()
        Me.TxtActualStatus = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtLastSubmit = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtLastApprove = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtApprover = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtSME = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtPlanType = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtLeadApprover = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtBFLead = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtStaff = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtPriority = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtManager = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtDirector = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'CboxPlans
        '
        Me.CboxPlans.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboxPlans.FormattingEnabled = True
        Me.CboxPlans.Location = New System.Drawing.Point(54, 29)
        Me.CboxPlans.Name = "CboxPlans"
        Me.CboxPlans.Size = New System.Drawing.Size(691, 24)
        Me.CboxPlans.Sorted = True
        Me.CboxPlans.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(56, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Owner"
        '
        'TxtOwner
        '
        Me.TxtOwner.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOwner.Location = New System.Drawing.Point(116, 93)
        Me.TxtOwner.Name = "TxtOwner"
        Me.TxtOwner.Size = New System.Drawing.Size(211, 22)
        Me.TxtOwner.TabIndex = 4
        '
        'TxtActualStatus
        '
        Me.TxtActualStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtActualStatus.Location = New System.Drawing.Point(116, 126)
        Me.TxtActualStatus.Name = "TxtActualStatus"
        Me.TxtActualStatus.Size = New System.Drawing.Size(269, 22)
        Me.TxtActualStatus.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Approval Status"
        '
        'TxtLastSubmit
        '
        Me.TxtLastSubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLastSubmit.Location = New System.Drawing.Point(116, 159)
        Me.TxtLastSubmit.Name = "TxtLastSubmit"
        Me.TxtLastSubmit.Size = New System.Drawing.Size(211, 22)
        Me.TxtLastSubmit.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(17, 162)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Last Submitted"
        '
        'TxtLastApprove
        '
        Me.TxtLastApprove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLastApprove.Location = New System.Drawing.Point(116, 192)
        Me.TxtLastApprove.Name = "TxtLastApprove"
        Me.TxtLastApprove.Size = New System.Drawing.Size(211, 22)
        Me.TxtLastApprove.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(18, 195)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Last Approved"
        '
        'TxtApprover
        '
        Me.TxtApprover.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtApprover.Location = New System.Drawing.Point(534, 87)
        Me.TxtApprover.Name = "TxtApprover"
        Me.TxtApprover.Size = New System.Drawing.Size(211, 22)
        Me.TxtApprover.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(438, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Plan Approver"
        '
        'TxtSME
        '
        Me.TxtSME.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSME.Location = New System.Drawing.Point(534, 113)
        Me.TxtSME.Name = "TxtSME"
        Me.TxtSME.Size = New System.Drawing.Size(211, 22)
        Me.TxtSME.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(482, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "SME"
        '
        'TxtPlanType
        '
        Me.TxtPlanType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPlanType.Location = New System.Drawing.Point(116, 225)
        Me.TxtPlanType.Name = "TxtPlanType"
        Me.TxtPlanType.Size = New System.Drawing.Size(211, 22)
        Me.TxtPlanType.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(39, 228)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Plan Type"
        '
        'TxtLeadApprover
        '
        Me.TxtLeadApprover.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLeadApprover.Location = New System.Drawing.Point(534, 139)
        Me.TxtLeadApprover.Name = "TxtLeadApprover"
        Me.TxtLeadApprover.Size = New System.Drawing.Size(211, 22)
        Me.TxtLeadApprover.TabIndex = 18
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(407, 142)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(124, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Leadership Approver"
        '
        'TxtBFLead
        '
        Me.TxtBFLead.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBFLead.Location = New System.Drawing.Point(534, 165)
        Me.TxtBFLead.Name = "TxtBFLead"
        Me.TxtBFLead.Size = New System.Drawing.Size(211, 22)
        Me.TxtBFLead.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(392, 168)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(142, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Business Function Lead"
        '
        'TxtStaff
        '
        Me.TxtStaff.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStaff.Location = New System.Drawing.Point(534, 191)
        Me.TxtStaff.Name = "TxtStaff"
        Me.TxtStaff.Size = New System.Drawing.Size(211, 22)
        Me.TxtStaff.TabIndex = 22
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(443, 194)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Staff Contact"
        '
        'TxtPriority
        '
        Me.TxtPriority.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPriority.Location = New System.Drawing.Point(116, 258)
        Me.TxtPriority.Name = "TxtPriority"
        Me.TxtPriority.Size = New System.Drawing.Size(211, 22)
        Me.TxtPriority.TabIndex = 24
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(56, 261)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Priority"
        '
        'TxtManager
        '
        Me.TxtManager.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtManager.Location = New System.Drawing.Point(534, 217)
        Me.TxtManager.Name = "TxtManager"
        Me.TxtManager.Size = New System.Drawing.Size(211, 22)
        Me.TxtManager.TabIndex = 26
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(439, 220)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(85, 13)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Plan Manager"
        '
        'TxtDirector
        '
        Me.TxtDirector.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDirector.Location = New System.Drawing.Point(534, 243)
        Me.TxtDirector.Name = "TxtDirector"
        Me.TxtDirector.Size = New System.Drawing.Size(211, 22)
        Me.TxtDirector.TabIndex = 28
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(444, 246)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(81, 13)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "Plan Director"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(12, 32)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(32, 13)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "Plan"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(686, 292)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(118, 13)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "PRODUCTION 1.30.20"
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(816, 314)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TxtDirector)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TxtManager)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxtPriority)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TxtStaff)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TxtBFLead)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TxtLeadApprover)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TxtPlanType)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtSME)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtApprover)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtLastApprove)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtLastSubmit)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtActualStatus)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtOwner)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CboxPlans)
        Me.Name = "FrmMain"
        Me.Text = "PlansRUs"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnGO As Button
    Friend WithEvents CboxPlans As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtOwner As TextBox
    Friend WithEvents TxtActualStatus As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtLastSubmit As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtLastApprove As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtApprover As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtSME As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtPlanType As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtLeadApprover As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TxtBFLead As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TxtStaff As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TxtPriority As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TxtManager As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TxtDirector As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
End Class
