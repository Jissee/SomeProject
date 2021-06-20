<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.新建ymlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.YmlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.打开ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.保存ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.另存为ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.properties = New System.Windows.Forms.TabPage()
        Me.yml = New System.Windows.Forms.TabPage()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip_yml = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.编辑ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.删除ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.yml.SuspendLayout()
        Me.ContextMenuStrip_yml.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.文件ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(779, 25)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '文件ToolStripMenuItem
        '
        Me.文件ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.新建ymlToolStripMenuItem, Me.打开ToolStripMenuItem, Me.保存ToolStripMenuItem, Me.另存为ToolStripMenuItem})
        Me.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem"
        Me.文件ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.文件ToolStripMenuItem.Text = "文件"
        '
        '新建ymlToolStripMenuItem
        '
        Me.新建ymlToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PropertiesToolStripMenuItem, Me.YmlToolStripMenuItem})
        Me.新建ymlToolStripMenuItem.Name = "新建ymlToolStripMenuItem"
        Me.新建ymlToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.新建ymlToolStripMenuItem.Text = "新建"
        '
        'PropertiesToolStripMenuItem
        '
        Me.PropertiesToolStripMenuItem.Name = "PropertiesToolStripMenuItem"
        Me.PropertiesToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.PropertiesToolStripMenuItem.Text = ".properties"
        '
        'YmlToolStripMenuItem
        '
        Me.YmlToolStripMenuItem.Name = "YmlToolStripMenuItem"
        Me.YmlToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.YmlToolStripMenuItem.Text = ".yml"
        '
        '打开ToolStripMenuItem
        '
        Me.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem"
        Me.打开ToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.打开ToolStripMenuItem.Text = "打开"
        '
        '保存ToolStripMenuItem
        '
        Me.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem"
        Me.保存ToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.保存ToolStripMenuItem.Text = "保存"
        '
        '另存为ToolStripMenuItem
        '
        Me.另存为ToolStripMenuItem.Name = "另存为ToolStripMenuItem"
        Me.另存为ToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.另存为ToolStripMenuItem.Text = "另存为"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.properties)
        Me.TabControl1.Controls.Add(Me.yml)
        Me.TabControl1.Location = New System.Drawing.Point(0, 28)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(779, 404)
        Me.TabControl1.TabIndex = 2
        '
        'properties
        '
        Me.properties.Location = New System.Drawing.Point(4, 22)
        Me.properties.Name = "properties"
        Me.properties.Padding = New System.Windows.Forms.Padding(3)
        Me.properties.Size = New System.Drawing.Size(771, 378)
        Me.properties.TabIndex = 0
        Me.properties.Text = "properties"
        Me.properties.UseVisualStyleBackColor = True
        '
        'yml
        '
        Me.yml.Controls.Add(Me.ListBox1)
        Me.yml.Location = New System.Drawing.Point(4, 22)
        Me.yml.Name = "yml"
        Me.yml.Padding = New System.Windows.Forms.Padding(3)
        Me.yml.Size = New System.Drawing.Size(771, 378)
        Me.yml.TabIndex = 1
        Me.yml.Text = "yml"
        Me.yml.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.ContextMenuStrip = Me.ContextMenuStrip_yml
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 12
        Me.ListBox1.Location = New System.Drawing.Point(0, 0)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(768, 376)
        Me.ListBox1.TabIndex = 0
        '
        'ContextMenuStrip_yml
        '
        Me.ContextMenuStrip_yml.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.编辑ToolStripMenuItem, Me.删除ToolStripMenuItem})
        Me.ContextMenuStrip_yml.Name = "ContextMenuStrip_yml"
        Me.ContextMenuStrip_yml.Size = New System.Drawing.Size(181, 70)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 435)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(779, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(44, 17)
        Me.ToolStripStatusLabel2.Text = "文件："
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(64, 17)
        Me.ToolStripStatusLabel3.Text = "(当前文件)"
        '
        '编辑ToolStripMenuItem
        '
        Me.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem"
        Me.编辑ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.编辑ToolStripMenuItem.Text = "编辑"
        '
        '删除ToolStripMenuItem
        '
        Me.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem"
        Me.删除ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.删除ToolStripMenuItem.Text = "删除"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(779, 457)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.yml.ResumeLayout(False)
        Me.ContextMenuStrip_yml.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 文件ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 新建ymlToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 打开ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 保存ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 另存为ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PropertiesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents YmlToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents properties As TabPage
    Friend WithEvents yml As TabPage
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ContextMenuStrip_yml As ContextMenuStrip
    Friend WithEvents 编辑ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 删除ToolStripMenuItem As ToolStripMenuItem
End Class
