using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using KM;
namespace key
{
    public partial class UserControl1: UserControl
    {
        int a = 10;
        public UserControl1()
        {
            InitializeComponent();
        }
 
        
        private void button1_Click(object sender, EventArgs e)
        {
            WindowsKM.moveMouse(100, 100);
            WindowsKM.clickLeft(1);
            WindowsKM.downKey(Keys.A);
            WindowsKM.sleepRandTime();
            WindowsKM.upKey(Keys.A);
        }
    }
}
