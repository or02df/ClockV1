using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace ClockV1
{
    public partial class ClockForm : Form
    {
        private readonly System.Timers.Timer timer;

        public ClockForm()
        {
            InitializeComponent();

            // Enable double buffering to avoid flicker
            Panel_Clock.GetType()
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .SetValue(Panel_Clock, true, null);

            // Set up the timer for clock updates
            timer = new System.Timers.Timer(1000); // 1-second interval
            timer.Elapsed += (s, e) => UpdateClock();
            timer.Start();
        }

        private void UpdateClock()
        {
            Invoke(new Action(() => Panel_Clock.Invalidate())); // Ensure UI updates are on the main thread
        }

        private void Panel_Clock_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            int width = Panel_Clock.Width;
            int height = Panel_Clock.Height;
            int centerX = width / 2;
            int centerY = height / 2;
            int radius = Math.Min(centerX, centerY) - 10;

            // Draw clock face
            g.DrawEllipse(Pens.Black, centerX - radius, centerY - radius, radius * 2, radius * 2);

            // Draw hour and minute marks
            for (int i = 0; i < 60; i++)
            {
                float angle = i * 6; // 360 / 60 = 6 degrees for each minute
                var outer = GetPoint(angle, radius, centerX, centerY);
                var inner = GetPoint(angle, i % 5 == 0 ? radius - 20 : radius - 10, centerX, centerY);
                g.DrawLine(i % 5 == 0 ? Pens.Black : Pens.Gray, outer.X, outer.Y, inner.X, inner.Y);
            }

            // Draw numbers around the perimeter
            for (int i = 1; i <= 12; i++)
            {
                float angle = i * 30; // 360 / 12 = 30 degrees per hour
                var position = GetPoint(angle, radius - 30, centerX, centerY);
                var font = new Font("Arial", 12, FontStyle.Bold);
                var size = g.MeasureString(i.ToString(), font);
                g.DrawString(i.ToString(), font, Brushes.Black, position.X - size.Width / 2, position.Y - size.Height / 2);
            }

            // Get current time
            DateTime currentTime = DateTime.Now;

            // Draw clock hands
            DrawHand(g, currentTime.Hour % 12 * 30 + currentTime.Minute / 2, radius * 0.5f, centerX, centerY, Pens.Black, 4); // Hour hand
            DrawHand(g, currentTime.Minute * 6, radius * 0.8f, centerX, centerY, Pens.Black, 2);                             // Minute hand
            DrawHand(g, currentTime.Second * 6, radius * 0.9f, centerX, centerY, Pens.Red, 1);                              // Second hand
        }

        private (float X, float Y) GetPoint(float angle, float radius, float centerX, float centerY)
        {
            float radians = (float)(Math.PI / 180 * (angle - 90)); // Adjust orientation
            float x = centerX + radius * (float)Math.Cos(radians);
            float y = centerY + radius * (float)Math.Sin(radians);
            return (x, y);
        }

        private void DrawHand(Graphics g, float angle, float length, int centerX, int centerY, Pen pen, int thickness)
        {
            float radians = (float)(Math.PI / 180 * (angle - 90)); // Adjust angle orientation
            float x = centerX + length * (float)Math.Cos(radians);
            float y = centerY + length * (float)Math.Sin(radians);
            g.DrawLine(new Pen(pen.Color, thickness), centerX, centerY, x, y);
        }
    }
}
