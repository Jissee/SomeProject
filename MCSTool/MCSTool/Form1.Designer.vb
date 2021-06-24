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
        Me.编辑ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.插入ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.和上面对齐ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.键值对ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.节点数组ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.数组值ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.注释ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.和下面对齐ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.删除ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.yml.SuspendLayout()
        Me.ContextMenuStrip_yml.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.文件ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1039, 28)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '文件ToolStripMenuItem
        '
        Me.文件ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.新建ymlToolStripMenuItem, Me.打开ToolStripMenuItem, Me.保存ToolStripMenuItem, Me.另存为ToolStripMenuItem})
        Me.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem"
        Me.文件ToolStripMenuItem.Size = New System.Drawing.Size(53, 24)
        Me.文件ToolStripMenuItem.Text = "文件"
        '
        '新建ymlToolStripMenuItem
        '
        Me.新建ymlToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PropertiesToolStripMenuItem, Me.YmlToolStripMenuItem})
        Me.新建ymlToolStripMenuItem.Name = "新建ymlToolStripMenuItem"
        Me.新建ymlToolStripMenuItem.Size = New System.Drawing.Size(137, 26)
        Me.新建ymlToolStripMenuItem.Text = "新建"
        '
        'PropertiesToolStripMenuItem
        '
        Me.PropertiesToolStripMenuItem.Name = "PropertiesToolStripMenuItem"
        Me.PropertiesToolStripMenuItem.Size = New System.Drawing.Size(173, 26)
        Me.PropertiesToolStripMenuItem.Text = ".properties"
        '
        'YmlToolStripMenuItem
        '
        Me.YmlToolStripMenuItem.Name = "YmlToolStripMenuItem"
        Me.YmlToolStripMenuItem.Size = New System.Drawing.Size(173, 26)
        Me.YmlToolStripMenuItem.Text = ".yml"
        '
        '打开ToolStripMenuItem
        '
        Me.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem"
        Me.打开ToolStripMenuItem.Size = New System.Drawing.Size(137, 26)
        Me.打开ToolStripMenuItem.Text = "打开"
        '
        '保存ToolStripMenuItem
        '
        Me.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem"
        Me.保存ToolStripMenuItem.Size = New System.Drawing.Size(137, 26)
        Me.保存ToolStripMenuItem.Text = "保存"
        '
        '另存为ToolStripMenuItem
        '
        Me.另存为ToolStripMenuItem.Name = "另存为ToolStripMenuItem"
        Me.另存为ToolStripMenuItem.Size = New System.Drawing.Size(137, 26)
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
        Me.TabControl1.Location = New System.Drawing.Point(0, 35)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1039, 505)
        Me.TabControl1.TabIndex = 2
        '
        'properties
        '
        Me.properties.Location = New System.Drawing.Point(4, 25)
        Me.properties.Margin = New System.Windows.Forms.Padding(4)
        Me.properties.Name = "properties"
        Me.properties.Padding = New System.Windows.Forms.Padding(4)
        Me.properties.Size = New System.Drawing.Size(1031, 476)
        Me.properties.TabIndex = 0
        Me.properties.Text = "properties"
        Me.properties.UseVisualStyleBackColor = True
        '
        'yml
        '
        Me.yml.Controls.Add(Me.ListBox1)
        Me.yml.Location = New System.Drawing.Point(4, 25)
        Me.yml.Margin = New System.Windows.Forms.Padding(4)
        Me.yml.Name = "yml"
        Me.yml.Padding = New System.Windows.Forms.Padding(4)
        Me.yml.Size = New System.Drawing.Size(1031, 476)
        Me.yml.TabIndex = 1
        Me.yml.Text = "yml"
        Me.yml.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.ContextMenuStrip = Me.ContextMenuStrip_yml
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 15
        Me.ListBox1.Location = New System.Drawing.Point(0, 0)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(1023, 469)
        Me.ListBox1.TabIndex = 0
        '
        'ContextMenuStrip_yml
        '
        Me.ContextMenuStrip_yml.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip_yml.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.编辑ToolStripMenuItem, Me.插入ToolStripMenuItem, Me.删除ToolStripMenuItem})
        Me.ContextMenuStrip_yml.Name = "ContextMenuStrip_yml"
        Me.ContextMenuStrip_yml.Size = New System.Drawing.Size(149, 76)
        '
        '编辑ToolStripMenuItem
        '
        Me.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem"
        Me.编辑ToolStripMenuItem.Size = New System.Drawing.Size(210, 24)
        Me.编辑ToolStripMenuItem.Text = "编辑"
        '
        '插入ToolStripMenuItem
        '
        Me.插入ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.和上面对齐ToolStripMenuItem, Me.和下面对齐ToolStripMenuItem})
        Me.插入ToolStripMenuItem.Name = "插入ToolStripMenuItem"
        Me.插入ToolStripMenuItem.Size = New System.Drawing.Size(148, 24)
        Me.插入ToolStripMenuItem.Text = "插入(上面)"
        '
        '和上面对齐ToolStripMenuItem
        '
        Me.和上面对齐ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.键值对ToolStripMenuItem, Me.节点数组ToolStripMenuItem, Me.数组值ToolStripMenuItem, Me.注释ToolStripMenuItem})
        Me.和上面对齐ToolStripMenuItem.Name = "和上面对齐ToolStripMenuItem"
        Me.和上面对齐ToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.和上面对齐ToolStripMenuItem.Text = "和上面对齐"
        '
        '键值对ToolStripMenuItem
        '
        Me.键值对ToolStripMenuItem.Name = "键值对ToolStripMenuItem"
        Me.键值对ToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.键值对ToolStripMenuItem.Text = "键/值对"
        '
        '节点数组ToolStripMenuItem
        '
        Me.节点数组ToolStripMenuItem.Name = "节点数组ToolStripMenuItem"
        Me.节点数组ToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.节点数组ToolStripMenuItem.Text = "节点/数组"
        '
        '数组值ToolStripMenuItem
        '
        Me.数组值ToolStripMenuItem.Name = "数组值ToolStripMenuItem"
        Me.数组值ToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.数组值ToolStripMenuItem.Text = "数组值"
        '
        '注释ToolStripMenuItem
        '
        Me.注释ToolStripMenuItem.Name = "注释ToolStripMenuItem"
        Me.注释ToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.注释ToolStripMenuItem.Text = "注释"
        '
        '和下面对齐ToolStripMenuItem
        '
        Me.和下面对齐ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem3, Me.ToolStripMenuItem4, Me.ToolStripMenuItem5})
        Me.和下面对齐ToolStripMenuItem.Name = "和下面对齐ToolStripMenuItem"
        Me.和下面对齐ToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.和下面对齐ToolStripMenuItem.Text = "和下面对齐"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(158, 26)
        Me.ToolStripMenuItem1.Text = "键/值对"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(158, 26)
        Me.ToolStripMenuItem3.Text = "节点/数组"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(158, 26)
        Me.ToolStripMenuItem4.Text = "数组值"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(158, 26)
        Me.ToolStripMenuItem5.Text = "注释"
        '
        '删除ToolStripMenuItem
        '
        Me.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem"
        Me.删除ToolStripMenuItem.Size = New System.Drawing.Size(210, 24)
        Me.删除ToolStripMenuItem.Text = "删除"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 545)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1039, 26)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(54, 20)
        Me.ToolStripStatusLabel2.Text = "文件："
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(79, 20)
        Me.ToolStripStatusLabel3.Text = "(当前文件)"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1039, 571)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.Text = "MCSTool"
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
    Friend WithEvents 插入ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 和上面对齐ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 键值对ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 节点数组ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 数组值ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 注释ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 和下面对齐ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As ToolStripMenuItem
End Class
