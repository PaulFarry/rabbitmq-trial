using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendMessages
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rnd = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            var i = new Outside.GatewayServiceClient();


            var m = new Outside.LocationRequest() { Latitude = rnd.Next(0, 360), Longitude = rnd.Next(0, 360) };
            i.LocationUpdate(m);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            var i = new Outside.GatewayServiceClient();

            for (var ci = 1; ci < 1000; ci++)
            {

                var m = new Outside.AlertRequest() { Arrived = DateTime.Now, Id = DateTime.Now.Second + ci };
                i.Alert(m);
            }
        }
    }
}
