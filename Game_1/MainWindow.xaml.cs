using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Game_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isLeftClicked, isRightClicked, isUpClicked, isDownClicked, isSpaceClicked;

        MovingObject mario;
        public MainWindow()
        {
            InitializeComponent();
            isLeftClicked = false;
            isRightClicked = false;
            isUpClicked = false;
            isDownClicked = false;
            isSpaceClicked = false;
            
            mario = new MovingObject(rec);

            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 0, 0, 10);
            dt.Tick += dt_Tick;
            dt.Start();
        }

        void dt_Tick(object sender, EventArgs e)
        {
            if (isLeftClicked)
            {
                mario.Move(MovingObject.MoveDir.Left);
            }
            if (isRightClicked)
            {
                mario.Move(MovingObject.MoveDir.Right);
            }
            if (isUpClicked)
            {
                mario.Move(MovingObject.MoveDir.Up);
            }
            if (isDownClicked)
            {
                mario.Move(MovingObject.MoveDir.Down);
            }
            if (isSpaceClicked)
            {
                new Fire(mario, -20);
                new Fire(mario, 20);
                fire_count_txt.Text = Fire.count.ToString();
            }
        }

        private void canvas_keydown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.Key + "");
            //if (e.Key == Key.Left) Canvas.SetLeft(rec, Canvas.GetLeft(rec) - 5);
            //else if (e.Key == Key.Right) Canvas.SetLeft(rec, Canvas.GetLeft(rec) + 5);
            //else if (e.Key == Key.Space || e.Key == Key.Up) Canvas.SetTop(rec, Canvas.GetTop(rec) - 5);

            if (e.Key == Key.Left) isLeftClicked = true;
            if (e.Key == Key.Right) isRightClicked = true;
            if (e.Key == Key.Down) isDownClicked = true;            
            if (e.Key == Key.Up) isUpClicked = true;
            if (e.Key == Key.Space) isSpaceClicked = true;
            
        }

        private void canvas_keyup(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left) isLeftClicked = false;
            if (e.Key == Key.Right) isRightClicked = false;
            if (e.Key == Key.Down) isDownClicked = false;  
            if (e.Key == Key.Up) isUpClicked = false;
            if (e.Key == Key.Space) isSpaceClicked = false;
        }
    }
}
