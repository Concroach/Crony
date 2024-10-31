using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Crony
{
    internal static class KeyboardManager
    {
        private static bool _isKeyboardBlocked = false;
        private static bool _leftShiftPressed = false;
        private static bool _rightShiftPressed = false;
        private static IntPtr _hookId = IntPtr.Zero;
        private static LowLevelKeyboardProc _proc = HookCallback;

        public static void ToggleKeyboard()
        {
            if (_isKeyboardBlocked)
            {
                UnhookWindowsHookEx(_hookId);
                _isKeyboardBlocked = false;
            }
            else
            {
                _hookId = SetHook(_proc);
                _isKeyboardBlocked = true;
            }
        }

        public static bool IsKeyboardEnabled()
        {
            return !_isKeyboardBlocked;
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using var curProcess = Process.GetCurrentProcess();
            using var curModule = curProcess.MainModule;
            return SetWindowsHookEx(13, proc, GetModuleHandle(curModule.ModuleName), 0);
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                Keys key = (Keys)vkCode;

                if (wParam == (IntPtr)0x100 || wParam == (IntPtr)0x104)
                {
                    if (key == Keys.LShiftKey)
                        _leftShiftPressed = true;
                    else if (key == Keys.RShiftKey)
                        _rightShiftPressed = true;

                    if (_leftShiftPressed && _rightShiftPressed)
                    {
                        ToggleKeyboard();
                        return (IntPtr)1;
                    }
                }
                else if (wParam == (IntPtr)0x101 || wParam == (IntPtr)0x105)
                {
                    if (key == Keys.LShiftKey)
                        _leftShiftPressed = false;
                    else if (key == Keys.RShiftKey)
                        _rightShiftPressed = false;
                }

                if (_isKeyboardBlocked && key != Keys.LShiftKey && key != Keys.RShiftKey)
                {
                    return (IntPtr)1;
                }
            }

            return CallNextHookEx(_hookId, nCode, wParam, lParam);
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
    }
}
