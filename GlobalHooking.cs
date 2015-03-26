using System;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;

namespace JEON_CManager
{
    class GlobalHooking
    {
        [DllImport("user32.dll")]
        public static extern bool CloseWindow(IntPtr hwnd);

        //[DllImport("user32.dll")]
        //public static extern IntPtr FindWindow(string lpclass, string lpname);

        [DllImport("user32", EntryPoint = "SetWindowsHookExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int SetWindowsHookEx(int idHook, LowLevelKeyboardProcDelegate lpfn, int hMod, int dwThreadId);
        [DllImport("user32", EntryPoint = "UnhookWindowsHookEx", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int UnhookWindowsHookEx(int hHook);
        [DllImport("user32", EntryPoint = "CallNextHookEx", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int CallNextHookEx(int hHook, int nCode, int wParam, ref KBDLLHOOKSTRUCT lParam);
        // needed to disable start menu
        [DllImport("user32.dll")]
        private static extern int FindWindow(string className, string windowText);
        [DllImport("user32.dll")]
        private static extern int ShowWindow(int hwnd, int command);
        // needed to get module handle
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);


        public delegate int LowLevelKeyboardProcDelegate(int nCode, int wParam, ref KBDLLHOOKSTRUCT lParam);
        private const int WH_KEYBOARD_LL = 13; // idHook - type of hook procedure
        private static int intLLKey; // hook handle (return value)
        //private static LowLevelKeyboardProcDelegate lpfn; // pointer to the hook procedure
        public void LockKeyboard()
        {
            string lpModuleName = Process.GetCurrentProcess().MainModule.ModuleName;
            int hMod = (int)GetModuleHandle(lpModuleName);
            //lpfn = this.LowLevelKeyboardProc;
            //intLLKey = SetWindowsHookEx(WH_KEYBOARD_LL, lpfn, hMod, 0);
            intLLKey = SetWindowsHookEx(WH_KEYBOARD_LL, LowLevelKeyboardProc, hMod, 0);
        }
        public void UnlockKeyboard()
        {
            UnhookWindowsHookEx(intLLKey);
        }


        public struct KBDLLHOOKSTRUCT
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }
        public int LowLevelKeyboardProc(int nCode, int wParam, ref KBDLLHOOKSTRUCT lParam)
        {
            bool blnEat = false;
            switch (wParam)
            {
                case 256: // WM_KEYDOWN
                case 257: // WM_KEYUP
                case 260: // WM_SYSKEYDOWN
                case 261: // WM_SYSKEYUP
                    blnEat = ((lParam.vkCode == 0x09) && (lParam.flags == 0x20)) | // Alt+Tab
                        ((lParam.vkCode == 0x1B) && (lParam.flags == 0x20)) | // Alt+Esc
                        ((lParam.vkCode == 0x1B) && (lParam.flags == 0x00)) | // Ctrl+Esc
                        ((lParam.vkCode == 0x5B) && (lParam.flags == 0x01)) | // Left Windows Key
                        ((lParam.vkCode == 0x5C) && (lParam.flags == 0x01)) | // Right Windows Key
                        ((lParam.vkCode == 0x73) && (lParam.flags == 0x20)); // Alt+F4
                    break;
            }
            if (blnEat == true)
            {
                return 1;
            }
            else
            {
                // chain to the next hook procedure. allow other applications that
                // have installed hooks to receive hook notification
                return CallNextHookEx(0, nCode, wParam, ref lParam);
            }
        }
    }
}
