using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Crony
{
    public class KeyboardHook : IDisposable
    {
        private IntPtr _hookID = IntPtr.Zero;
        private const int WH_KEYBOARD_LL = 13;
        private LowLevelKeyboardProc _proc;

        private bool _leftShiftPressed = false;
        private bool _rightShiftPressed = false;

        public event Action OnHotkeyPressed;

        public KeyboardHook()
        {
            _proc = HookCallback;
            _hookID = SetHook(_proc);
        }

        public void Dispose()
        {
            UnhookWindowsHookEx(_hookID);
        }

        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                Keys key = (Keys)vkCode;

                if (wParam == (IntPtr)0x100 || wParam == (IntPtr)0x104)
                {
                    if (key == Keys.LShiftKey)
                    {
                        _leftShiftPressed = true;
                    }
                    else if (key == Keys.RShiftKey)
                    {
                        _rightShiftPressed = true;
                    }

                    if (_leftShiftPressed && _rightShiftPressed)
                    {
                        OnHotkeyPressed?.Invoke();
                    }
                }
                else if (wParam == (IntPtr)0x101 || wParam == (IntPtr)0x105)
                {
                    if (key == Keys.LShiftKey)
                    {
                        _leftShiftPressed = false;
                    }
                    else if (key == Keys.RShiftKey)
                    {
                        _rightShiftPressed = false;
                    }
                }
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
    }
}