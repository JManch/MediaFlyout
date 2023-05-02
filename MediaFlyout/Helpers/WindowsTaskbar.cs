using MediaFlyout.Interop;
using System;
using System.Windows;

namespace MediaFlyout.Helpers
{
    public sealed class WindowsTaskbar
    {
        public struct State
        {
            public Position Side;
            public double Right;
            public double Bottom;

            public bool IsHorizontal
            {
                get
                {
                    return Side == Position.Bottom || Side == Position.Top;
                }
            }
            public bool IsAutoHideEnabled
            {
                get
                {
                    return IsHorizontal ? (SystemParameters.PrimaryScreenHeight == SystemParameters.WorkArea.Height) :
                        (SystemParameters.PrimaryScreenWidth == SystemParameters.WorkArea.Width);
                }
            }
        }

        public enum Position
        {
            Left,
            Top,
            Right,
            Bottom
        }

        public static State Current
        {
            get
            {
                var wk = SystemParameters.WorkArea;

                // Hard code task bar being at top of screen
                return new State
                {
                    Side = Position.Top,
                    Right = wk.Right,
                    Bottom = wk.Top
                };
            }
        }

        public static uint Dpi => User32.GetDpiForWindow(Handle);
        public static IntPtr Handle => User32.FindWindow("Shell_TrayWnd", null);
    }
}
