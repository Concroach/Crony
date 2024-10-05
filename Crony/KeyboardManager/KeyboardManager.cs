using System.Runtime.InteropServices;

namespace Crony
{
    class KeyboardManager
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern void BlockInput(bool fBlockIt);

        private static bool _isKeyboardBlocked = false;

        // Метод для переключения состояния клавиатуры
        public static void ToggleKeyboard()
        {
            _isKeyboardBlocked = !_isKeyboardBlocked;
            BlockInput(_isKeyboardBlocked);
        }

        // Метод для проверки состояния клавиатуры
        public static bool IsKeyboardEnabled()
        {
            return !_isKeyboardBlocked; // Если клавиатура не заблокирована, возвращаем true
        }
    }
}