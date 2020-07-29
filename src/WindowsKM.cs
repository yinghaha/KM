using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KM
{
    static class WindowsKM
    {
        const int MOUSEEVENTF_MOVE = 0x0001;                //移动鼠标
        const int MOUSEEVENTF_LEFTDOWN = 0x0002;            //模拟鼠标左键按下
        const int MOUSEEVENTF_LEFTUP = 0x0004;              //模拟鼠标左键抬起
        const int MOUSEEVENTF_RIGHTDOWN = 0x0008;           //模拟鼠标右键按下
        const int MOUSEEVENTF_RIGHTUP = 0x0010;             //模拟鼠标右键抬起
        const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;          //模拟鼠标中键按下
        const int MOUSEEVENTF_MIDDLEUP = 0x0040;            //模拟鼠标中键抬起
        const int MOUSEEVENTF_ABSOLUTE = 0x8000;            //标示是否采用绝对坐标

        [System.Runtime.InteropServices.DllImport("user32")]
        public static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        [System.Runtime.InteropServices.DllImport("user32")]
        public static extern void keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        private static Random ran;

        static WindowsKM()
        {
            int nowTime = DateTime.Now.Millisecond;
            ran = new Random(nowTime);
        }
        public static void sleepTime(int time)
        {
            Thread.Sleep(time);
        }
        //随机睡眠
        public static void sleepRandTime()
        {
            int sleepTime = ran.Next(100, 300);
            Thread.Sleep(sleepTime);
        }
        //移动鼠标（相对坐标）
        public static void moveMouse(int x, int y)
        {
            mouse_event(MOUSEEVENTF_MOVE, x, y, 0, 0);
        }
        //移动鼠标（绝对坐标）
        public static void moveMouseToPint(int x, int y)
        {
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, x, y, 0, 0);
        }
        //点击左键
        public static void clickLeft(int times)
        {
            if (times <= 0)
                return;
            while(times > 0)
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                --times;
                sleepRandTime();
            }
        }
        //点击右键
        public static void clickRignt(int times)
        {
            if (times <= 0)
                return;
            while (times > 0)
            {
                mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
                --times;
                sleepRandTime();
            }
        }
        //按下左键
        public static void downLeft()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
        }
        //抬起左键
        public static void upLeft()
        {
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
        //按下右键
        public static void downRight()
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
        }
        //抬起右键
        public static void upRight()
        {
            mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
        }

        public static void downKey(Keys keys)
        {
            keybd_event(keys, 0, 0, 0);
        }

        public static void upKey(Keys keys)
        {
            keybd_event(keys, 0, 2, 0);
        }

    }


}
