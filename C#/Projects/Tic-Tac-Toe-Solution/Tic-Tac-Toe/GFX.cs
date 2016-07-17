using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    class GFX
    {
        private static Graphics gObject;

        public GFX(Graphics g)
        {
            gObject = g;
            SetUpCanvas();
        }

        public static void SetUpCanvas()
        {
            Brush background = new SolidBrush(Color.WhiteSmoke);
            Pen lines = new Pen(Color.Black, 5);

            gObject.FillRectangle(background, new Rectangle(0, 0, 500, 600));

            gObject.DrawLine(lines, new Point(167, 0), new Point(167, 500));
            gObject.DrawLine(lines, new Point(334, 0), new Point(334, 500));
            gObject.DrawLine(lines, new Point(0, 0), new Point(0, 500));
            gObject.DrawLine(lines, new Point(500, 0), new Point(500, 500));

            gObject.DrawLine(lines, new Point(0, 167), new Point(500, 167));
            gObject.DrawLine(lines, new Point(0, 334), new Point(500, 334));
            gObject.DrawLine(lines, new Point(0, 0), new Point(500, 0));
            gObject.DrawLine(lines, new Point(0, 500), new Point(500, 500));
        }

        public static void DrawX(Point location)
        {
            Pen xPen = new Pen(Color.Purple, 5);
            int xAbs = location.X * 167;
            int yAbs = location.Y * 167;
            gObject.DrawLine(xPen, xAbs + 10, yAbs + 10, xAbs + 157, yAbs + 157);
            gObject.DrawLine(xPen, xAbs + 157, yAbs + 10, xAbs + 10, yAbs + 157);         
        }

        public static void DrawO(Point location)
        {
            Pen oPen = new Pen(Color.Green, 5);
            int xAbs = location.X * 167;
            int yAbs = location.Y * 167;
            gObject.DrawEllipse(oPen, xAbs + 10, yAbs + 10, 147, 147);
        }
    }
}
