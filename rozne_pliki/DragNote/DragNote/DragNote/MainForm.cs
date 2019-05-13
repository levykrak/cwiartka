using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragNoteApp
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Stopwatch swTime = new Stopwatch();

        public MainForm()
        {
            InitializeComponent();
            spLevy.Open();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {                
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void timLeftTrack_Tick(object sender, EventArgs e)
        {
            z.Text = String.Format("{0}:{1}:{2}", swTime.Elapsed.Minutes.ToString().PadLeft(2, '0'), swTime.Elapsed.Seconds.ToString().PadLeft(2, '0'), swTime.Elapsed.Milliseconds.ToString().PadLeft(3, '0'));
            digitalGauge2.Text = String.Format("{0}:{1}:{2}", swTime.Elapsed.Minutes.ToString().PadLeft(2, '0'), swTime.Elapsed.Seconds.ToString().PadLeft(2, '0'), swTime.Elapsed.Milliseconds.ToString().PadLeft(3, '0'));
        }

        private void btnLeftTrackStart_Click(object sender, EventArgs e)
        {
            swTime.Reset();
            timLeftTrack.Enabled = true;
            timLeftTrack.Start();
            swTime.Start();
        }

        private void btnLeftTrackReset_Click(object sender, EventArgs e)
        {
            timLeftTrack.Stop();
            swTime.Stop();
            swTime.Reset();
            z.Text = "0:00:000";
            digitalGauge2.Text = "0:00:000";
        }

        private void btnLeftTrackStop_Click(object sender, EventArgs e)
        {
            swTime.Stop();

            timLeftTrack.Stop();

            z.Text = String.Format("{0}:{1}:{2}", swTime.Elapsed.Minutes.ToString().PadLeft(2, '0'), swTime.Elapsed.Seconds.ToString().PadLeft(2, '0'), swTime.Elapsed.Milliseconds.ToString().PadLeft(3, '0'));
            digitalGauge2.Text = String.Format("{0}:{1}:{2}", swTime.Elapsed.Minutes.ToString().PadLeft(2, '0'), swTime.Elapsed.Seconds.ToString().PadLeft(2, '0'), swTime.Elapsed.Milliseconds.ToString().PadLeft(3, '0'));

            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblLDriver.Text = "Selected Driver: " + (xpCollection1[gridView1.GetSelectedRows()[0]] as DragNote.Driver).name + " , Car No. " + (xpCollection1[gridView1.GetSelectedRows()[0]] as DragNote.Driver).car_no;
            lblLCar.Text = "Selected Car: " +(xpCollection1[gridView1.GetSelectedRows()[0]] as DragNote.Driver).car;
            lblL_Id.Text = (xpCollection1[gridView1.GetSelectedRows()[0]] as DragNote.Driver).id.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblRDriver.Text = "Selected Driver: " + (xpCollection1[gridView1.GetSelectedRows()[0]] as DragNote.Driver).name + " , Car No. " + (xpCollection1[gridView1.GetSelectedRows()[0]] as DragNote.Driver).car_no;
            lblRCar.Text = "Selected Car: " + (xpCollection1[gridView1.GetSelectedRows()[0]] as DragNote.Driver).car;
            lblR_Id.Text = (xpCollection1[gridView1.GetSelectedRows()[0]] as DragNote.Driver).id.ToString();
        }

        private void spLevy_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

        }


        //private static void port_OnReceiveDatazz(object sender,
        //                          SerialDataReceivedEventArgs e)
        //{
        //    SerialPort spL = (SerialPort)sender;
        //    byte[] buf = new byte[spL.BytesToRead];
        //    Console.WriteLine("DATA RECEIVED!");
        //    spL.Read(buf, 0, buf.Length);
        //    foreach (Byte b in buf)
        //    {
        //        Console.Write(b.ToString() + " ");
        //    }
        //    Console.WriteLine();
        //}

        //private static void WriteThread()
        //{
        //    SerialPort sp2 = new SerialPort("COM34", 115200, Parity.None, 8, StopBits.One);
        //    sp2.Open();
        //    byte[] buf = new byte[100];
        //    for (byte i = 0; i < 100; i++)
        //    {
        //        buf[i] = i;
        //    }
        //    sp2.Write(buf, 0, buf.Length);
        //    sp2.Close();
        //}

        private void btnLSaveTime_Click(object sender, EventArgs e)
        {
            //using (ExplicitUnitOfWork euow = new ExplicitUnitOfWork(session1.DataLayer))
            //{
                DragNote.Race rc = new DragNote.Race(session1);
                rc.id_driver = session1.FindObject<DragNote.Driver>(CriteriaOperator.Parse("id =?", Convert.ToInt32(lblL_Id.Text)));
                rc.id_event = session1.FindObject<DragNote.Event>(CriteriaOperator.Parse("id =?", 1)); ;
                rc.race_time = swTime.Elapsed.TotalMilliseconds;

                session1.Save(rc);          
            //    euow.CommitChanges();
            //}
        }
    }
}
