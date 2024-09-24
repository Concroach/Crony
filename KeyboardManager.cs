using System.Runtime.InteropServices;

namespace Crony
{
    class KeyboardManager
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern void BlockInput(bool fBlockIt);

        private static bool _isKeyboardBlocked = false;

        public static void ToggleKeyboard()
        {
            _isKeyboardBlocked = !_isKeyboardBlocked;
            BlockInput(_isKeyboardBlocked);
        }
    }
}