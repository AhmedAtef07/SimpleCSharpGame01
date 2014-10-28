using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Game_1 
{
    class Fire
    {
        public static int count;

        Shape source;
        Shape shot;
        DispatcherTimer dt;
        int shot_jump = 20;
        public Fire(MovingObject source, int displacment)
        {
            count++;
            shot = new Rectangle();
            shot.Fill = new SolidColorBrush(Colors.Green);
            shot.StrokeThickness = 0;
            shot.Width = 10;
            shot.Height = 10;

            this.source = source.getShape();
            // Placing the fire at the top of the shape and centered.
            Canvas.SetLeft(shot, Canvas.GetLeft(this.source) + (this.source.Width / 2) - (shot.Width / 2) + displacment);
            Canvas.SetTop(shot, Canvas.GetTop(this.source) - (shot.Height));

            Canvas sourceCanvas = (Canvas)this.source.Parent;
            sourceCanvas.Children.Add(shot);

            dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 0, 0, 10);
            dt.Tick += dt_Tick;
            dt.Start();
                
        }
       
       
        private void dt_Tick(object sender, EventArgs e)
        {
            Canvas.SetTop(shot, Canvas.GetTop(shot) - shot_jump);
            if (Canvas.GetTop(shot) + shot.Height < 0)
            {
                dt.Stop();
                ((Canvas)this.source.Parent).Children.Remove(shot);
            }
        }
    }
}
