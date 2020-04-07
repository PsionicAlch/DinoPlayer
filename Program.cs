using System;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace Challenge01
{
    class Program
    {
        static Color GetPixel(Point position)
        {
            using (var bitmap = new Bitmap(1, 1))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(position, new Point(0, 0), new Size(1, 1));
                }

                return bitmap.GetPixel(0, 0);
            }
        }

        static void Main()
        {
            Color color = Color.FromArgb(255, 32, 33, 36);
            InputSimulator sim = new InputSimulator();

            Console.WriteLine("Game starting in 5...");
            Thread.Sleep(1000);
            Console.WriteLine("Game starting in 4...");
            Thread.Sleep(1000);
            Console.WriteLine("Game starting in 3...");
            Thread.Sleep(1000);
            Console.WriteLine("Game starting in 2...");
            Thread.Sleep(1000);
            Console.WriteLine("Game starting in 1...");
            Thread.Sleep(1000);

            sim.Keyboard.KeyPress(VirtualKeyCode.SPACE);

            while(true)
            {
                if(GetPixel(Cursor.Position) != color)
                {
                    sim.Keyboard.KeyPress(VirtualKeyCode.SPACE);
                    Console.WriteLine("JUMP!");
                }
            }
        }
    }
}
