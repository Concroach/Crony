using System.Runtime.InteropServices;

namespace Crony
{
    internal static class KeyboardManager
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern void BlockInput(bool fBlockIt);

        private static bool _isKeyboardBlocked = false;

        public static void ToggleKeyboard()
        {
            _isKeyboardBlocked = !_isKeyboardBlocked;
            BlockInput(_isKeyboardBlocked);
        }

        public static bool IsKeyboardEnabled()
        {
            return !_isKeyboardBlocked;
        }
    }
}