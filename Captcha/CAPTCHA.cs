using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace Captcha
{
    public class CAPTCHA
    {
        Bitmap image;
        Random rnd;
        Size size;
        string result;
        public CAPTCHA(Size size)
        {
            rnd = new Random();
            this.size = size;
            image = new Bitmap(size.Width, size.Height);
        }
        public Image Next()
        {
            Graphics gr = Graphics.FromImage(image);
            HatchBrush brush = new HatchBrush((HatchStyle)rnd.Next(0,50),Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)));
            gr.FillRectangle(brush, new Rectangle(new Point(0, 0), size));
            for (int i = 0; i < rnd.Next(4, 10); ++i)
            {
                Pen pen = new Pen(Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)), rnd.Next(0, 5));
                gr.DrawLine(pen,
                    new Point(rnd.Next(0, size.Width/2), rnd.Next(0, size.Height/2)),
                    new Point(rnd.Next(0, size.Width), rnd.Next(size.Height / 2, size.Height)));
            }
            gr.DrawString(GenerateText(), new Font("Arial", size.Height/3), 
                new SolidBrush(Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255))),
                    new PointF(20, 20));
            return image;
        }
        public bool ValidResult(string result)
        {
            result.Trim();
            if (this.result == result)
                return true;
            else
                return false;
        }
        string GenerateText()
        {
            int a = rnd.Next(0, 100);
            int b = rnd.Next(0, 100);
            result = (a + b).ToString();
            return a.ToString() + " + " + b.ToString() + " =";
        }
    }
}
