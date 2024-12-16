<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.textStudentID = New System.Windows.Forms.TextBox()
        Me.FirstName = New System.Windows.Forms.Label()
        Me.LastName = New System.Windows.Forms.Label()
        Me.ContactNumber = New System.Windows.Forms.Label()
        Me.Course = New System.Windows.Forms.Label()
        Me.textFirstName = New System.Windows.Forms.TextBox()
        Me.textLastName = New System.Windows.Forms.TextBox()
        Me.textContactNumber = New System.Windows.Forms.TextBox()
        Me.textCourse = New System.Windows.Forms.TextBox()
        Me.textEmail = New System.Windows.Forms.TextBox()
        Me.Email = New System.Windows.Forms.Label()
        Me.Add = New System.Windows.Forms.Button()
        Me.Update = New System.Windows.Forms.Button()
        Me.Delete = New System.Windows.Forms.Button()
        Me.SelectData = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(146, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "StudentID"
        '
        'textStudentID
        '
        Me.textStudentID.Location = New System.Drawing.Point(235, 83)
        Me.textStudentID.Name = "textStudentID"
        Me.textStudentID.Size = New System.Drawing.Size(153, 26)
        Me.textStudentID.TabIndex = 1
        '
        'FirstName
        '
        Me.FirstName.AutoSize = True
        Me.FirstName.Location = New System.Drawing.Point(146, 144)
        Me.FirstName.Name = "FirstName"
        Me.FirstName.Size = New System.Drawing.Size(82, 20)
        Me.FirstName.TabIndex = 2
        Me.FirstName.Text = "FirstName"
        '
        'LastName
        '
        Me.LastName.AutoSize = True
        Me.LastName.Location = New System.Drawing.Point(146, 201)
        Me.LastName.Name = "LastName"
        Me.LastName.Size = New System.Drawing.Size(82, 20)
        Me.LastName.TabIndex = 3
        Me.LastName.Text = "LastName"
        '
        'ContactNumber
        '
        Me.ContactNumber.AutoSize = True
        Me.ContactNumber.Location = New System.Drawing.Point(108, 256)
        Me.ContactNumber.Name = "ContactNumber"
        Me.ContactNumber.Size = New System.Drawing.Size(121, 20)
        Me.ContactNumber.TabIndex = 4
        Me.ContactNumber.Text = "ContactNumber"
        '
        'Course
        '
        Me.Course.AutoSize = True
        Me.Course.Location = New System.Drawing.Point(168, 320)
        Me.Course.Name = "Course"
        Me.Course.Size = New System.Drawing.Size(60, 20)
        Me.Course.TabIndex = 5
        Me.Course.Text = "Course"
        '
        'textFirstName
        '
        Me.textFirstName.Location = New System.Drawing.Point(235, 138)
        Me.textFirstName.Name = "textFirstName"
        Me.textFirstName.Size = New System.Drawing.Size(153, 26)
        Me.textFirstName.TabIndex = 6
        '
        'textLastName
        '
        Me.textLastName.Location = New System.Drawing.Point(235, 195)
        Me.textLastName.Name = "textLastName"
        Me.textLastName.Size = New System.Drawing.Size(153, 26)
        Me.textLastName.TabIndex = 7
        '
        'textContactNumber
        '
        Me.textContactNumber.Location = New System.Drawing.Point(235, 256)
        Me.textContactNumber.Name = "textContactNumber"
        Me.textContactNumber.Size = New System.Drawing.Size(153, 26)
        Me.textContactNumber.TabIndex = 8
        '
        'textCourse
        '
        Me.textCourse.Location = New System.Drawing.Point(235, 314)
        Me.textCourse.Name = "textCourse"
        Me.textCourse.Size = New System.Drawing.Size(153, 26)
        Me.textCourse.TabIndex = 9
        '
        'textEmail
        '
        Me.textEmail.Location = New System.Drawing.Point(235, 369)
        Me.textEmail.Name = "textEmail"
        Me.textEmail.Size = New System.Drawing.Size(153, 26)
        Me.textEmail.TabIndex = 11
        '
        'Email
        '
        Me.Email.AutoSize = True
        Me.Email.Location = New System.Drawing.Point(171, 369)
        Me.Email.Name = "Email"
        Me.Email.Size = New System.Drawing.Size(48, 20)
        Me.Email.TabIndex = 10
        Me.Email.Text = "Email"
        '
        'Add
        '
        Me.Add.Location = New System.Drawing.Point(15, 433)
        Me.Add.Name = "Add"
        Me.Add.Size = New System.Drawing.Size(204, 46)
        Me.Add.TabIndex = 12
        Me.Add.Text = "Add"
        Me.Add.UseVisualStyleBackColor = True
        '
        'Update
        '
        Me.Update.Location = New System.Drawing.Point(246, 433)
        Me.Update.Name = "Update"
        Me.Update.Size = New System.Drawing.Size(204, 46)
        Me.Update.TabIndex = 13
        Me.Update.Text = "Update"
        Me.Update.UseVisualStyleBackColor = True
        '
        'Delete
        '
        Me.Delete.Location = New System.Drawing.Point(483, 433)
        Me.Delete.Name = "Delete"
        Me.Delete.Size = New System.Drawing.Size(204, 46)
        Me.Delete.TabIndex = 14
        Me.Delete.Text = "Delete"
        Me.Delete.UseVisualStyleBackColor = True
        '
        'SelectData
        '
        Me.SelectData.Location = New System.Drawing.Point(715, 433)
        Me.SelectData.Name = "SelectData"
        Me.SelectData.Size = New System.Drawing.Size(204, 46)
        Me.SelectData.TabIndex = 15
        Me.SelectData.Text = "Select"
        Me.SelectData.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1251, 546)
        Me.Controls.Add(Me.SelectData)
        Me.Controls.Add(Me.Delete)
        Me.Controls.Add(Me.Update)
        Me.Controls.Add(Me.Add)
        Me.Controls.Add(Me.textEmail)
        Me.Controls.Add(Me.Email)
        Me.Controls.Add(Me.textCourse)
        Me.Controls.Add(Me.textContactNumber)
        Me.Controls.Add(Me.textLastName)
        Me.Controls.Add(Me.textFirstName)
        Me.Controls.Add(Me.Course)
        Me.Controls.Add(Me.ContactNumber)
        Me.Controls.Add(Me.LastName)
        Me.Controls.Add(Me.FirstName)
        Me.Controls.Add(Me.textStudentID)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents textStudentID As TextBox
    Friend WithEvents FirstName As Label
    Friend WithEvents LastName As Label
    Friend WithEvents ContactNumber As Label
    Friend WithEvents Course As Label
    Friend WithEvents textFirstName As TextBox
    Friend WithEvents textLastName As TextBox
    Friend WithEvents textContactNumber As TextBox
    Friend WithEvents textCourse As TextBox
    Friend WithEvents textEmail As TextBox
    Friend WithEvents Email As Label
    Friend WithEvents Add As Button
    Friend WithEvents Update As Button
    Friend WithEvents Delete As Button
    Friend WithEvents SelectData As Button
End Class
