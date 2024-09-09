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
			selectVideoDeviceToolStripMenuItem = new ToolStripMenuItem();
			noDevicesFoundToolStripMenuItem = new ToolStripMenuItem();
			selectAudioDeviceToolStripMenuItem = new ToolStripMenuItem();
			noDevicesFoundToolStripMenuItem1 = new ToolStripMenuItem();
			filteringTypeToolStripMenuItem = new ToolStripMenuItem();
			nearestNeighborToolStripMenuItem = new ToolStripMenuItem();
			biliniarToolStripMenuItem = new ToolStripMenuItem();
			bicubicToolStripMenuItem = new ToolStripMenuItem();
			biliToolStripMenuItem = new ToolStripMenuItem();
			bicubicToolStripMenuItem1 = new ToolStripMenuItem();
			nearestNeighborToolStripMenuItem1 = new ToolStripMenuItem();
			hQBilinearToolStripMenuItem = new ToolStripMenuItem();
			hQBicubicToolStripMenuItem = new ToolStripMenuItem();
			frameUpdateTimer = new System.Windows.Forms.Timer(components);
			((System.ComponentModel.ISupportInitialize)devicePreviewPictureBox).BeginInit();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// devicePreviewPictureBox
			// 
			devicePreviewPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			devicePreviewPictureBox.Location = new Point(0, 24);
			devicePreviewPictureBox.Name = "devicePreviewPictureBox";
			devicePreviewPictureBox.Size = new Size(1920, 1080);
			devicePreviewPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
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
			exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
			exitToolStripMenuItem.Size = new Size(180, 22);
			exitToolStripMenuItem.Text = "Exit";
			exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
			// 
			// viewToolStripMenuItem
			// 
			viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { fullscreenToolStripMenuItem, selectVideoDeviceToolStripMenuItem, selectAudioDeviceToolStripMenuItem, filteringTypeToolStripMenuItem });
			viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			viewToolStripMenuItem.Size = new Size(61, 20);
			viewToolStripMenuItem.Text = "Options";
			// 
			// fullscreenToolStripMenuItem
			// 
			fullscreenToolStripMenuItem.Name = "fullscreenToolStripMenuItem";
			fullscreenToolStripMenuItem.ShortcutKeys = Keys.F11;
			fullscreenToolStripMenuItem.Size = new Size(180, 22);
			fullscreenToolStripMenuItem.Text = "Fullscreen";
			fullscreenToolStripMenuItem.Click += FullscreenToolStripMenuItem_Click;
			// 
			// selectVideoDeviceToolStripMenuItem
			// 
			selectVideoDeviceToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { noDevicesFoundToolStripMenuItem });
			selectVideoDeviceToolStripMenuItem.Name = "selectVideoDeviceToolStripMenuItem";
			selectVideoDeviceToolStripMenuItem.Size = new Size(180, 22);
			selectVideoDeviceToolStripMenuItem.Text = "Select Video Device";
			// 
			// noDevicesFoundToolStripMenuItem
			// 
			noDevicesFoundToolStripMenuItem.Enabled = false;
			noDevicesFoundToolStripMenuItem.Name = "noDevicesFoundToolStripMenuItem";
			noDevicesFoundToolStripMenuItem.Size = new Size(167, 22);
			noDevicesFoundToolStripMenuItem.Text = "No devices found";
			// 
			// selectAudioDeviceToolStripMenuItem
			// 
			selectAudioDeviceToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { noDevicesFoundToolStripMenuItem1 });
			selectAudioDeviceToolStripMenuItem.Name = "selectAudioDeviceToolStripMenuItem";
			selectAudioDeviceToolStripMenuItem.Size = new Size(180, 22);
			selectAudioDeviceToolStripMenuItem.Text = "Select Audio Device";
			// 
			// noDevicesFoundToolStripMenuItem1
			// 
			noDevicesFoundToolStripMenuItem1.Enabled = false;
			noDevicesFoundToolStripMenuItem1.Name = "noDevicesFoundToolStripMenuItem1";
			noDevicesFoundToolStripMenuItem1.Size = new Size(167, 22);
			noDevicesFoundToolStripMenuItem1.Text = "No devices found";
			// 
			// filteringTypeToolStripMenuItem
			// 
			filteringTypeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nearestNeighborToolStripMenuItem, biliniarToolStripMenuItem, bicubicToolStripMenuItem, biliToolStripMenuItem, bicubicToolStripMenuItem1, nearestNeighborToolStripMenuItem1, hQBilinearToolStripMenuItem, hQBicubicToolStripMenuItem });
			filteringTypeToolStripMenuItem.Name = "filteringTypeToolStripMenuItem";
			filteringTypeToolStripMenuItem.Size = new Size(180, 22);
			filteringTypeToolStripMenuItem.Text = "Resampling Mode";
			// 
			// nearestNeighborToolStripMenuItem
			// 
			nearestNeighborToolStripMenuItem.Checked = true;
			nearestNeighborToolStripMenuItem.CheckState = CheckState.Checked;
			nearestNeighborToolStripMenuItem.Name = "nearestNeighborToolStripMenuItem";
			nearestNeighborToolStripMenuItem.Size = new Size(167, 22);
			nearestNeighborToolStripMenuItem.Text = "Default";
			// 
			// biliniarToolStripMenuItem
			// 
			biliniarToolStripMenuItem.Name = "biliniarToolStripMenuItem";
			biliniarToolStripMenuItem.Size = new Size(167, 22);
			biliniarToolStripMenuItem.Text = "Low";
			// 
			// bicubicToolStripMenuItem
			// 
			bicubicToolStripMenuItem.Name = "bicubicToolStripMenuItem";
			bicubicToolStripMenuItem.Size = new Size(167, 22);
			bicubicToolStripMenuItem.Text = "High";
			// 
			// biliToolStripMenuItem
			// 
			biliToolStripMenuItem.Name = "biliToolStripMenuItem";
			biliToolStripMenuItem.Size = new Size(167, 22);
			biliToolStripMenuItem.Text = "Bilinear";
			// 
			// bicubicToolStripMenuItem1
			// 
			bicubicToolStripMenuItem1.Name = "bicubicToolStripMenuItem1";
			bicubicToolStripMenuItem1.Size = new Size(167, 22);
			bicubicToolStripMenuItem1.Text = "Bicubic";
			// 
			// nearestNeighborToolStripMenuItem1
			// 
			nearestNeighborToolStripMenuItem1.Name = "nearestNeighborToolStripMenuItem1";
			nearestNeighborToolStripMenuItem1.Size = new Size(167, 22);
			nearestNeighborToolStripMenuItem1.Text = "Nearest Neighbor";
			// 
			// hQBilinearToolStripMenuItem
			// 
			hQBilinearToolStripMenuItem.Name = "hQBilinearToolStripMenuItem";
			hQBilinearToolStripMenuItem.Size = new Size(167, 22);
			hQBilinearToolStripMenuItem.Text = "HQ Bilinear";
			// 
			// hQBicubicToolStripMenuItem
			// 
			hQBicubicToolStripMenuItem.Name = "hQBicubicToolStripMenuItem";
			hQBicubicToolStripMenuItem.Size = new Size(167, 22);
			hQBicubicToolStripMenuItem.Text = "HQ Bicubic";
			// 
			// frameUpdateTimer
			// 
			frameUpdateTimer.Enabled = true;
			frameUpdateTimer.Interval = 17;
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
		private ToolStripMenuItem selectVideoDeviceToolStripMenuItem;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.Timer frameUpdateTimer;
		private ToolStripMenuItem noDevicesFoundToolStripMenuItem;
		private ToolStripMenuItem selectAudioDeviceToolStripMenuItem;
		private ToolStripMenuItem noDevicesFoundToolStripMenuItem1;
		private ToolStripMenuItem filteringTypeToolStripMenuItem;
		private ToolStripMenuItem nearestNeighborToolStripMenuItem;
		private ToolStripMenuItem biliniarToolStripMenuItem;
		private ToolStripMenuItem bicubicToolStripMenuItem;
		private ToolStripMenuItem biliToolStripMenuItem;
		private ToolStripMenuItem bicubicToolStripMenuItem1;
		private ToolStripMenuItem nearestNeighborToolStripMenuItem1;
		private ToolStripMenuItem hQBilinearToolStripMenuItem;
		private ToolStripMenuItem hQBicubicToolStripMenuItem;
	}
}
