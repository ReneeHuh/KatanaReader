using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;

namespace KatanaReader
{
    public class ScrollByPixel
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetScrollInfo(IntPtr hwnd, int fnBar, ref SCROLLINFO lpsi);

        [DllImport("user32.dll")]
        static extern int SetScrollInfo(IntPtr hwnd, int fnBar, [In] ref SCROLLINFO lpsi, bool fRedraw);

        [DllImport("User32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern int FindWindow(string className, string windowText);

        [DllImport("user32.dll")]
        private static extern int ShowWindow(int hwnd, int command);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 1;

        struct SCROLLINFO
        {
            public uint cbSize;
            public uint fMask;
            public int nMin;
            public int nMax;
            public uint nPage;
            public int nPos;
            public int nTrackPos;
        }

        enum ScrollBarDirection
        {
            SB_HORZ = 0,
            SB_VERT = 1,
            SB_CTL = 2,
            SB_BOTH = 3
        }

        enum ScrollInfoMask
        {
            SIF_RANGE = 0x1,
            SIF_PAGE = 0x2,
            SIF_POS = 0x4,
            SIF_DISABLENOSCROLL = 0x8,
            SIF_TRACKPOS = 0x10,
            SIF_ALL = SIF_RANGE + SIF_PAGE + SIF_POS + SIF_TRACKPOS
        }

        const int WM_VSCROLL = 277;
        const int SB_LINEUP = 0;
        const int SB_LINEDOWN = 1;
        const int SB_THUMBPOSITION = 4;
        const int SB_THUMBTRACK = 5;
        const int SB_TOP = 6;
        const int SB_BOTTOM = 7;
        const int SB_ENDSCROLL = 8;

        public void scroll(IntPtr handle, int pixles)
        {

            {
                // Get current scroller position

                SCROLLINFO si = new SCROLLINFO();
                si.cbSize = (uint)Marshal.SizeOf(si);
                si.fMask = (uint)ScrollInfoMask.SIF_ALL;
                GetScrollInfo(handle, (int)ScrollBarDirection.SB_VERT, ref si);

                // Increase position by pixles
                si.nPos += pixles;

                // Reposition scroller
                SetScrollInfo(handle, (int)ScrollBarDirection.SB_VERT, ref si, true);

                // Send a WM_VSCROLL scroll message using SB_THUMBTRACK as wParam
                // SB_THUMBTRACK: low-order word of wParam, si.nPos high-order word of  wParam

                //IntPtr ptrWparam = new IntPtr(SB_THUMBTRACK + 0x10000 * si.nPos);
                IntPtr ptrWparam = new IntPtr(SB_THUMBPOSITION + 0x10000 * si.nPos);
                IntPtr ptrLparam = new IntPtr(0);
                SendMessage(handle, WM_VSCROLL, ptrWparam, ptrLparam); 
            }
        }

    }
}
