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
using ZXing;
using ZXing.QrCode.Internal;


namespace Check_in_out
{
    public partial class Form1 : Form
    {
        DB DB;
        int prevID = -1;
        DateTime prevtime = DateTime.Now;

        public Form1()
        {
            InitializeComponent();
            DB = new DB();
            
        }
        FilterInfoCollection infoCollection;  // Declaring variables
        VideoCaptureDevice videocaptureDevice; //Declaring variables

        private void VideocaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)//FinalFrame_NewFrame event handler allows to capture image from camera.
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }


        private void Form1_Load(object sender, EventArgs e) //Form load event handler to detect camera of the pc
        {

            infoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filter in infoCollection)
            comboBox1.Items.Add(filter.Name);
            comboBox1.SelectedIndex = 0;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)//to stop  webcam on form closing.
        {
            if (videocaptureDevice.IsRunning)
                videocaptureDevice.Stop();
        }

        private void button1_Click(object sender, EventArgs e) // Shows camera image in picturebox control
        {
            label3.Text = null;
            videocaptureDevice = new VideoCaptureDevice(infoCollection[comboBox1.SelectedIndex].MonikerString);
            videocaptureDevice.NewFrame += VideocaptureDevice_NewFrame;
            videocaptureDevice.Start();
            timer1.Start();
        }
        //
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                BarcodeReader reader = new BarcodeReader
                {
                    AutoRotate = true,
                    Options =
                    {
                         TryHarder = true,
                            PossibleFormats = new List<BarcodeFormat> {BarcodeFormat.QR_CODE}
                    }
                };
                Result rzlt = reader.Decode((Bitmap)pictureBox1.Image);
                if (rzlt != null)
                {
                    var EmpID = Convert.ToInt32(rzlt.ToString());
                    TimeSpan time = DateTime.Now - prevtime;
                    if (EmpID != prevID || (EmpID == prevID && time.Seconds > 10))
                    {

                        prevID = EmpID;
                        prevtime = DateTime.Now;

                        var checkedInOut = DB.GetCheckInOrCheckOut(EmpID);
                        if (checkedInOut == null)// For example new employee comes with new id which is not there. Query will return null
                        {
                            checkedInOut = new Checkin_out(EmpID, 0);
                        }
                        if (DB.ChangeStatus(checkedInOut))
                        {
                           label3.Text= checkedInOut.ShowMessage();


                            if (checkedInOut.Status == 1)
                            {
                                label1.Text = "Checkout here";
                            }
                            else if (checkedInOut.Status == 0)
                            {
                                label1.Text = "Checkin here";
                            }



                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Wait");
                    }
                    timer1.Stop();
                    if (videocaptureDevice.IsRunning)
                        videocaptureDevice.Stop();
                }


            }
        }

      
       
    }
}

