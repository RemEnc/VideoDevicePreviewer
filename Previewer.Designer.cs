namespace VideoDevicePreviewer
{
	partial class Previewer
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			devicePreviewPictureBox = new PictureBox();
			menuStrip1 = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			exitToolStripMenuItem = new ToolStripMenuItem();
			viewToolStripMenuItem = new ToolStripMenuItem();
			fullscreenToolStripMenuItem = new ToolStripMenuItem();
			selectDeviceToolStripMenuItem = new ToolStripMenuItem();
			noDevicesFoundToolStripMenuItem = new ToolStripMenuItem();
			frameUpdateTimer = new System.Windows.Forms.Timer(components);
			((System.ComponentModel.ISupportInitialize)devicePreviewPictureBox).BeginInit();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// devicePreviewPictureBox
			// 
			devicePreviewPictureBox.Dock = DockStyle.Fill;
			devicePreviewPictureBox.Location = new Point(0, 24);
			devicePreviewPictureBox.Name = "devicePreviewPictureBox";
			devicePreviewPictureBox.Size = new Size(1920, 1080);
			devicePreviewPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
			devicePreviewPictureBox.TabIndex = 0;
			devicePreviewPictureBox.TabStop = false;
			devicePreviewPictureBox.Paint += DevicePreviewPictureBox_Paint;
			devicePreviewPictureBox.DoubleClick += DevicePreviewPictureBox_DoubleClick;
			// 
			// menuStrip1
			// 
			menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, viewToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(1920, 24);
			menuStrip1.TabIndex = 1;
			menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new Size(37, 20);
			fileToolStripMenuItem.Text = "File";
			// 
			// exitToolStripMenuItem
			// 
			exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			exitToolStripMenuItem.Size = new Size(93, 22);
			exitToolStripMenuItem.Text = "Exit";
			exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
			// 
			// viewToolStripMenuItem
			// 
			viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { fullscreenToolStripMenuItem, selectDeviceToolStripMenuItem });
			viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			viewToolStripMenuItem.Size = new Size(44, 20);
			viewToolStripMenuItem.Text = "View";
			// 
			// fullscreenToolStripMenuItem
			// 
			fullscreenToolStripMenuItem.Name = "fullscreenToolStripMenuItem";
			fullscreenToolStripMenuItem.Size = new Size(143, 22);
			fullscreenToolStripMenuItem.Text = "Fullscreen";
			fullscreenToolStripMenuItem.Click += FullscreenToolStripMenuItem_Click;
			// 
			// selectDeviceToolStripMenuItem
			// 
			selectDeviceToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { noDevicesFoundToolStripMenuItem });
			selectDeviceToolStripMenuItem.Name = "selectDeviceToolStripMenuItem";
			selectDeviceToolStripMenuItem.Size = new Size(143, 22);
			selectDeviceToolStripMenuItem.Text = "Select Device";
			// 
			// noDevicesFoundToolStripMenuItem
			// 
			noDevicesFoundToolStripMenuItem.Enabled = false;
			noDevicesFoundToolStripMenuItem.Name = "noDevicesFoundToolStripMenuItem";
			noDevicesFoundToolStripMenuItem.Size = new Size(167, 22);
			noDevicesFoundToolStripMenuItem.Text = "No devices found";
			// 
			// frameUpdateTimer
			// 
			frameUpdateTimer.Interval = 30;
			frameUpdateTimer.Tick += FrameUpdateTimer_Tick;
			// 
			// Previewer
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.Desktop;
			ClientSize = new Size(1920, 1104);
			Controls.Add(devicePreviewPictureBox);
			Controls.Add(menuStrip1);
			MainMenuStrip = menuStrip1;
			Name = "Previewer";
			Text = "Video Device Previewer";
			KeyDown += Previewer_KeyDown;
			((System.ComponentModel.ISupportInitialize)devicePreviewPictureBox).EndInit();
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private PictureBox devicePreviewPictureBox;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem viewToolStripMenuItem;
		private ToolStripMenuItem fullscreenToolStripMenuItem;
		private ToolStripMenuItem selectDeviceToolStripMenuItem;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.Timer frameUpdateTimer;
		private ToolStripMenuItem noDevicesFoundToolStripMenuItem;
	}
}
