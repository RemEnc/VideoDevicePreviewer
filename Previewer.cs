using GitHub.secile.Video;

namespace VideoDevicePreviewer
{
	public partial class Previewer : Form
	{
		private UsbCamera camera;
		private Bitmap videoFrame;
		private bool isFullscreen = false;
		private Size originalFormSize;
		private Point originalFormLocation;
		private FormBorderStyle originalFormBorderStyle;

		public Previewer()
		{
			InitializeComponent();
			Load += Previewer_Load;
			FormClosing += Previewer_FormClosing;
			devicePreviewPictureBox.Paint += DevicePreviewPictureBox_Paint;
			devicePreviewPictureBox.DoubleClick += DevicePreviewPictureBox_DoubleClick;
			KeyDown += Previewer_KeyDown;
		}

		private void Previewer_Load(object sender, EventArgs e)
		{
			InitializeCamera();
			PopulateDeviceList();
		}
		private void InitializeMenu()
		{
			var menuStrip = new MenuStrip();
			var fullscreenMenuItem = new ToolStripMenuItem("Fullscreen");
			fullscreenMenuItem.Click += FullscreenToolStripMenuItem_Click;
			menuStrip.Items.Add(fullscreenMenuItem);

			var selectDeviceMenuItem = new ToolStripMenuItem("Select Device");
			var devices = UsbCamera.FindDevices();
			foreach (var device in devices)
			{
				var deviceItem = new ToolStripMenuItem(device);
				deviceItem.Click += DeviceItem_Click;
				selectDeviceMenuItem.DropDownItems.Add(deviceItem);
			}
			menuStrip.Items.Add(selectDeviceMenuItem);

			Controls.Add(menuStrip);
			MainMenuStrip = menuStrip;
		}
		private void InitializeCamera()
		{
			string[] devices = UsbCamera.FindDevices();
			if (devices.Length == 0)
			{
				MessageBox.Show("No camera found.");
				return;
			}

			var cameraIndex = 0;
			var formats = UsbCamera.GetVideoFormat(cameraIndex);
			var format = formats[0];

			// Adjust the form size to fit the PictureBox
			ClientSize = new Size(format.Size.Width, format.Size.Height + 24);

			camera = new UsbCamera(cameraIndex, format);
			camera.SetPreviewControl(devicePreviewPictureBox.Handle, devicePreviewPictureBox.ClientSize);
			devicePreviewPictureBox.Resize += (s, ev) => camera.SetPreviewSize(devicePreviewPictureBox.ClientSize);
			camera.Start();
		}
		private void FrameUpdateTimer_Tick(object sender, EventArgs e)
		{
			videoFrame = camera.GetBitmap();
			devicePreviewPictureBox.Invalidate();
		}
		private void DevicePreviewPictureBox_Paint(object sender, PaintEventArgs e)
		{
			if (videoFrame != null)
			{
				e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
				e.Graphics.DrawImage(videoFrame, new Rectangle(0, 0, devicePreviewPictureBox.Width, devicePreviewPictureBox.Height));
			}
		}
		private void Previewer_FormClosing(object sender, FormClosingEventArgs e)
		{
			camera?.Release();
			frameUpdateTimer?.Stop();
		}
		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
		private void DevicePreviewPictureBox_DoubleClick(object sender, EventArgs e)
		{
			ToggleFullscreen();
		}
		private void FullscreenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToggleFullscreen();
		}
		private void ToggleFullscreen()
		{
			if (isFullscreen)
			{
				// Exit fullscreen
				FormBorderStyle = originalFormBorderStyle;
				Size = originalFormSize;
				Location = originalFormLocation;
				menuStrip1.Visible = true;
				isFullscreen = false;
			}
			else
			{
				// Enter fullscreen
				originalFormSize = Size;
				originalFormLocation = Location;
				originalFormBorderStyle = FormBorderStyle;

				FormBorderStyle = FormBorderStyle.None;
				WindowState = FormWindowState.Maximized;
				menuStrip1.Visible = false;
				isFullscreen = true;

				Focus();
			}
		}
		private void Previewer_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape && isFullscreen)
			{
				ToggleFullscreen();
			}
		}
		private void PopulateDeviceList()
		{
			selectDeviceToolStripMenuItem.DropDownItems.Clear();
			var devices = UsbCamera.FindDevices();
			if (devices.Length == 0)
			{
				var noDevicesItem = new ToolStripMenuItem("No devices found");
				noDevicesItem.Enabled = false;
				selectDeviceToolStripMenuItem.DropDownItems.Add(noDevicesItem);
			}
			else
			{
				foreach (var device in devices)
				{
					var deviceItem = new ToolStripMenuItem(device);
					deviceItem.Click += DeviceItem_Click;
					selectDeviceToolStripMenuItem.DropDownItems.Add(deviceItem);
				}
			}
		}
		private void DeviceItem_Click(object sender, EventArgs e)
		{
			var selectedItem = sender as ToolStripMenuItem;
			var deviceIndex = Array.IndexOf(UsbCamera.FindDevices(), selectedItem.Text);

			if (deviceIndex >= 0)
			{
				camera?.Release();
				var formats = UsbCamera.GetVideoFormat(deviceIndex);
				var format = formats[0];


				ClientSize = new Size(format.Size.Width, format.Size.Height + 24);

				camera = new UsbCamera(deviceIndex, format);
				camera.SetPreviewControl(devicePreviewPictureBox.Handle, devicePreviewPictureBox.ClientSize);
				devicePreviewPictureBox.Resize += (s, ev) => camera.SetPreviewSize(devicePreviewPictureBox.ClientSize);
				camera.Start();

				// Update checkmarks
				foreach (ToolStripMenuItem item in selectedItem.GetCurrentParent().Items)
				{
					item.Checked = false;
				}
				selectedItem.Checked = true;
			}
		}
	}
}