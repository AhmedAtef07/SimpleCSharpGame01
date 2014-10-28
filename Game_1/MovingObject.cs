using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Game_1
{
   
    class MovingObject
    {
        public enum MoveDir
        {
            Left = 0,
            Up = 1,
            Right = 2,
            Down = 3
        }
        
        Shape ui_element;   

        public MovingObject (Shape ui_element) {
            this.ui_element = ui_element;
        }
        int step = 7;
        public void Move(MoveDir move_dir)
        {
            double top = Canvas.GetTop(ui_element), left = Canvas.GetLeft(ui_element);
            switch (move_dir)
            {
                case MoveDir.Left:
                    if(isInCanvas(top, left - step)) Canvas.SetLeft(ui_element, left - step);
                    break;
                case MoveDir.Up:
                    if (isInCanvas(top - step, left)) Canvas.SetTop(ui_element, top - step);
                    break;
                case MoveDir.Right:
                    if (isInCanvas(top, left + step + ui_element.Width)) Canvas.SetLeft(ui_element, left + step);
                    break;
                case MoveDir.Down:
                    if (isInCanvas(top + step + ui_element.Height, left)) Canvas.SetTop(ui_element, top + step);
                    break;
                default:
                     break;
            }
        }

        bool isInCanvas(double top, double left)
        {
            Canvas canvas = (Canvas)ui_element.Parent;
            if (top > canvas.RenderSize.Height || top < 0 || 
                left > canvas.RenderSize.Width || left < 0) return false;
            return true;
            

            
        }

        public Shape getShape()
        {
            return ui_element;
        }
    }
}
