using GitHub.secile.Video;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using System.Drawing.Drawing2D;

namespace VideoDevicePreviewer
{
	public partial class Previewer : Form
	{
		private UsbCamera camera;
		private Bitmap videoFrame;
		private InterpolationMode interpolationMode;
		private double aspectRatio;
		private bool isFullscreen = false;
		private Size originalFormSize;
		private Point originalFormLocation;
		private FormBorderStyle originalFormBorderStyle;
		private WaveInEvent waveIn;
		private WaveOutEvent waveOut;
		private BufferedWaveProvider bufferedWaveProvider;
		private bool justPressed = false;

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
			InitializeResamplingModes();
			PopulateVideoDeviceList();
			PopulateAudioDeviceList();
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
			aspectRatio = (double)format.Size.Width / (double)format.Size.Height;

			camera = new UsbCamera(cameraIndex, format);
			//camera.SetPreviewControl(devicePreviewPictureBox.Handle, devicePreviewPictureBox.ClientSize);
			//devicePreviewPictureBox.Resize += (s, ev) => camera.SetPreviewSize(devicePreviewPictureBox.ClientSize);
			camera.Start();
		}
		private void FrameUpdateTimer_Tick(object sender, EventArgs e)
		{
			videoFrame?.Dispose();
			videoFrame = camera.GetBitmap();
			devicePreviewPictureBox.Invalidate();
		}
		private void DevicePreviewPictureBox_Paint(object sender, PaintEventArgs e)
		{
			if (videoFrame != null)
			{
				e.Graphics.InterpolationMode = interpolationMode;
				e.Graphics.DrawImage(videoFrame, KeepAspectRatio(aspectRatio, devicePreviewPictureBox.Width, devicePreviewPictureBox.Height));
			}
		}
		public static Rectangle KeepAspectRatio(double aspectRatio, int width, int height)
		{
			int newWidth = width;
			int newHeight = height;
			int offsetX = 0;
			int offsetY = 0;

			int calculatedHeight = (int)(width / aspectRatio);

			if (calculatedHeight <= height)
			{
				// Width is the smallest dimension
				newHeight = (int)(width / aspectRatio);
				offsetY = (height - newHeight) / 2;
			}
			else
			{
				// Height is the smallest dimension
				newWidth = (int)(height * aspectRatio);
				offsetX = (width - newWidth) / 2;
			}
			return new Rectangle(offsetX, offsetY, newWidth, newHeight);
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
			if (!justPressed)
			{
				ToggleFullscreen();
				justPressed = true;
			}
			else
			{
				justPressed = false;
			}
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
				ShowTaskbar();
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
				HideTaskbar();
			}
		}
		private void HideTaskbar()
		{
			var taskbar = FindWindow("Shell_TrayWnd", "");
			ShowWindow(taskbar, SW_HIDE);
		}

		private void ShowTaskbar()
		{
			var taskbar = FindWindow("Shell_TrayWnd", "");
			ShowWindow(taskbar, SW_SHOW);
		}

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern int FindWindow(string className, string windowText);

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern int ShowWindow(int hwnd, int command);

		private const int SW_HIDE = 0;
		private const int SW_SHOW = 5;

		private void Previewer_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape && isFullscreen)
			{
				ToggleFullscreen();
			}
		}
		private void InitializeResamplingModes()
		{
			foreach (ToolStripMenuItem t in filteringTypeToolStripMenuItem.DropDownItems)
			{
				t.Click += ResamplingMode_Click;
			}
		}
		private void ResamplingMode_Click(object sender, EventArgs e)
		{
			var selectedItem = sender as ToolStripMenuItem;

			interpolationMode = selectedItem?.Text switch
			{
				"Default" => InterpolationMode.Default,
				"Low" => InterpolationMode.Low,
				"High" => InterpolationMode.High,
				"Bilinear" => InterpolationMode.Bilinear,
				"Bicubic" => InterpolationMode.Bicubic,
				"Nearest Neighbor" => InterpolationMode.NearestNeighbor,
				"HQ Bilinear" => InterpolationMode.HighQualityBilinear,
				"HQ Bicubic" => InterpolationMode.HighQualityBicubic,
				_ => InterpolationMode.Default
			};

			foreach (ToolStripMenuItem item in selectedItem.GetCurrentParent().Items)
			{
				item.Checked = false;
			}
			selectedItem.Checked = true;
		}
		private void PopulateVideoDeviceList()
		{
			selectVideoDeviceToolStripMenuItem.DropDownItems.Clear();
			var devices = UsbCamera.FindDevices();
			if (devices.Length == 0)
			{
				var noDevicesItem = new ToolStripMenuItem("No devices found");
				noDevicesItem.Enabled = false;
				selectVideoDeviceToolStripMenuItem.DropDownItems.Add(noDevicesItem);
			}
			else
			{
				foreach (var device in devices)
				{
					var deviceItem = new ToolStripMenuItem(device);
					deviceItem.Click += DeviceItem_Click;
					selectVideoDeviceToolStripMenuItem.DropDownItems.Add(deviceItem);
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
				aspectRatio = (double)format.Size.Width / (double)format.Size.Height;

				camera = new UsbCamera(deviceIndex, format);
				//camera.SetPreviewControl(devicePreviewPictureBox.Handle, devicePreviewPictureBox.ClientSize);
				//devicePreviewPictureBox.Resize += (s, ev) => camera.SetPreviewSize(devicePreviewPictureBox.ClientSize);
				camera.Start();

				// Update checkmarks
				foreach (ToolStripMenuItem item in selectedItem.GetCurrentParent().Items)
				{
					item.Checked = false;
				}
				selectedItem.Checked = true;
			}
		}
		private void PopulateAudioDeviceList()
		{
			selectAudioDeviceToolStripMenuItem.DropDownItems.Clear();
			MMDeviceEnumerator devices = new MMDeviceEnumerator();
			if (WaveIn.DeviceCount == 0)
			{
				var noDevicesItem = new ToolStripMenuItem("No audio devices found");
				noDevicesItem.Enabled = false;
				selectAudioDeviceToolStripMenuItem.DropDownItems.Add(noDevicesItem);
			}
			else
			{
				var initialDeviceItem = new ToolStripMenuItem("None");
				initialDeviceItem.Click += AudioDeviceItem_Click;
				selectAudioDeviceToolStripMenuItem.DropDownItems.Add(initialDeviceItem);
				for (int i = 0; i < WaveIn.DeviceCount; i++)
				{
					var deviceItem = new ToolStripMenuItem(devices.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active)[i].DeviceFriendlyName);
					deviceItem.Click += AudioDeviceItem_Click;
					selectAudioDeviceToolStripMenuItem.DropDownItems.Add(deviceItem);
				}
			}
		}
		private void AudioDeviceItem_Click(object sender, EventArgs e)
		{
			var selectedItem = sender as ToolStripMenuItem;
			var deviceIndex = selectAudioDeviceToolStripMenuItem.DropDownItems.IndexOf(selectedItem);

			if (deviceIndex >= 0)
			{
				StartAudioCapture(deviceIndex);
				// Update checkmarks
				foreach (ToolStripMenuItem item in selectAudioDeviceToolStripMenuItem.DropDownItems)
				{
					item.Checked = false;
				}
				selectedItem.Checked = true;
			}
		}
		private void StartAudioCapture(int deviceIndex)
		{
			waveIn?.Dispose();
			waveOut?.Dispose();
			bufferedWaveProvider = null;

			waveIn = new WaveInEvent
			{
				DeviceNumber = deviceIndex,
				WaveFormat = new WaveFormat(44100, 2)
			};

			bufferedWaveProvider = new BufferedWaveProvider(waveIn.WaveFormat);
			waveOut = new WaveOutEvent();

			waveIn.DataAvailable += (s, a) =>
			{
				bufferedWaveProvider.AddSamples(a.Buffer, 0, a.BytesRecorded);
			};

			waveOut.Init(bufferedWaveProvider);
			waveIn.StartRecording();
			waveOut.Play();
		}
	}
}