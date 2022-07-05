using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace CameraApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        private void button1_Click(object sender, EventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[selectCamera.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();

        }
        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs e)
        {
            pictureBox1.Image = (Bitmap)e.Frame.Clone();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach(FilterInfo filterInfo in filterInfoCollection)
            {
                selectCamera.Items.Add(filterInfo.Name);
            }
            selectCamera.SelectedIndex = 0;
            videoCaptureDevice = new VideoCaptureDevice();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(videoCaptureDevice.IsRunning==true)
            {
                videoCaptureDevice.Stop();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (videoCaptureDevice.IsRunning == true)
            {
                videoCaptureDevice.Stop();

            }
            pictureBox1.Hide();
        }
    }
}
