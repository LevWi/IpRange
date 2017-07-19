using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //maskedTextBox_startIP.ValidatingType = typeof(System.Net.IPAddress);
            //maskedTextBox_endIP.ValidatingType = typeof(System.Net.IPAddress);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] ipStartByteArr = new byte[4];
            byte[] ipEndByteArr = new byte[4];
            try
            {
                 ipStartByteArr= IPAddress.Parse(maskedTextBox_startIP.Text).GetAddressBytes();
                 ipEndByteArr = IPAddress.Parse(maskedTextBox_endIP.Text).GetAddressBytes();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
            Array.Reverse(ipStartByteArr);
            Array.Reverse(ipEndByteArr);

            textBox1.Text = "";
            uint ipstart = BitConverter.ToUInt32(ipStartByteArr, 0);
            uint ipend = BitConverter.ToUInt32(ipEndByteArr, 0);

            for (uint i = ipstart; i <= ipend; i++)
            {
                var arr = BitConverter.GetBytes(i);
                Array.Reverse(arr);
                textBox1.Text = textBox1.Text + new IPAddress(arr).ToString() + Environment.NewLine;
            }
        }
    }
}
