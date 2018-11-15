using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Andrew_s_MahJong
{
    public class Tile
    {
        private static int gap = 2; //paint gap between for the outline
        private static int offSet = 8; // 3D offset
        private static int width = 80;
        private static int height = 100;

        private int x, y;
        private string text; //only uses a char, -1 if inactive
        private int[] outlineColor = new int[3];

        public static int Width
        {
            get { return width; }
        }
        public static int Height
        {
            get { return height; }
        }
        public static int OffSet
        {
            get { return offSet; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public Tile(int x, int y, char text)
        {
            this.x = x;
            this.y = y;
            this.text += text;
        }

        public bool Click(int mouseX, int mouseY)
        {
            bool clicked = false;
            SetOutlineColor(0, 0, 0);

            if (text != "-1" && mouseX >= x && mouseX <= x + width)
            {
                if (mouseY >= y && mouseY <= y + height)
                {
                    clicked = true;
                    SetOutlineColor(255, 0, 0);
                }
            }

            return clicked;
        }

        private void SetOutlineColor(int r, int g, int b)
        {
            outlineColor[0] = r;
            outlineColor[1] = g;
            outlineColor[2] = b;
        }
        public void Paint(PaintEventArgs e)
        {
            if (text != "-1")
            {
                Brush outline = new SolidBrush(Color.FromArgb(outlineColor[0], outlineColor[1], outlineColor[2]));
                Brush fill = new SolidBrush(Color.FromArgb(200, 200, 200));
                Brush fillShaded = new SolidBrush(Color.FromArgb(150, 150, 150));

                PaintRectangle3D(e, outline, fill, fillShaded, x, y, width, height); //front

                PaintText(e, outline);

                outline.Dispose();
                fill.Dispose();
                fillShaded.Dispose();
            }
        }
        private void PaintRectangle3D(PaintEventArgs e, Brush outline, Brush fill, Brush fillShaded, int x, int y, int width, int height)
        {
            Pen outlinePen = new Pen(Color.FromArgb(outlineColor[0], outlineColor[1], outlineColor[2]));
            outlinePen.Width = gap;

            Point[] pointsO = new Point[6]; //Outline, starts bottom right corner, goes clockwise connecting the dots
            pointsO[0] = new Point(x + width, y + height);
            pointsO[1] = new Point(x, y + height);
            pointsO[2] = new Point(x - offSet, y + height - offSet);
            pointsO[3] = new Point(x - offSet, y - offSet);
            pointsO[4] = new Point(x + width - offSet, y - offSet);
            pointsO[5] = new Point(x + width, y);

            Point[] pointsF = new Point[6]; //Fill
            pointsF[0] = new Point(x + width - gap, y + height - gap);
            pointsF[1] = new Point(x + gap, y + height - gap / 2);
            pointsF[2] = new Point(x - offSet + gap, y + height - offSet - gap / 2);
            pointsF[3] = new Point(x - offSet + gap, y - offSet + gap);
            pointsF[4] = new Point(x + width - offSet - gap / 2, y - offSet + gap);
            pointsF[5] = new Point(x + width - gap / 2, y + gap);

            e.Graphics.FillPolygon(outline, pointsO); //outline
            e.Graphics.FillPolygon(fillShaded, pointsF); //fillShaded
            e.Graphics.DrawLine(outlinePen, x - offSet, y - offSet, x, y); //connector 
            PaintRectangle(e, outline, fill, x, y, width, height); //main face

            outlinePen.Dispose();
        }
        private void PaintRectangle(PaintEventArgs e, Brush outline, Brush fill, int x, int y, int width, int height)
        {
            e.Graphics.FillRectangle(outline, x, y, width, height);
            e.Graphics.FillRectangle(fill, x + gap, y + gap, width - gap * 2, height - gap * 2);
        }

        private Font SetFont()
        {
            Font font;

            if (width < height)
            {
                font = new Font("Ariel", width / 3 * 2);
            }
            else
            {
                font = new Font("Ariel", height / 3 * 2);
            }

            return font;
        }
        private StringFormat SetFormat()
        {
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            return sf;
        }
        private void PaintText(PaintEventArgs e, Brush outline)
        {
            Font font = SetFont();
            StringFormat sf = SetFormat();

            Rectangle rect = new Rectangle(x, y, width, height);

            e.Graphics.DrawString(text, font, outline, rect, sf); //text

            font.Dispose();
        }
    }
}
