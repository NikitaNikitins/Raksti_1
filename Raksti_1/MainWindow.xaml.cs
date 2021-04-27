using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KeyEventArgs = System.Windows.Forms.KeyEventArgs;
using RadioButton = System.Windows.Controls.RadioButton;

namespace Raksti_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _selectedRadioButtonTag { get; set; }
        private GeometryInitializer geometryInitializer { get; set; }
        private Pen _pen { get; set; }
        private Brush _brush { get; set; }
        private Brush _canvasBackground { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            geometryInitializer = new GeometryInitializer();

            _selectedRadioButtonTag = 1;

            _pen = new Pen(Brushes.Red, 1);

            _brush = Brushes.Green;

            _canvasBackground = Brushes.White;

            PenColorBtn.BorderBrush = _pen.Brush;
            BrushColorBtn.BorderBrush = _brush;
            BackgroundColorBtn.BorderBrush = _canvasBackground;

            SetUpRadioButtonImages();
        }

        private void onPaint(object sender, RoutedEventArgs e)
        {
            var geometryGroup = geometryInitializer.GetSelectedGeometry(_selectedRadioButtonTag);
            int scaleFactor = 1;

            try
            {
                scaleFactor= int.Parse(scaleFactorField.Text);
            }
            catch
            {
            }

            fillCanvas(drawingCanvasField, geometryGroup, scaleFactor);

            SetUpRadioButtonImages();
        }

        private void fillCanvas(Canvas canvas, Geometry geometry, int scaleFactor = 1)
        {

            GeometryDrawing geometryDrawing = new GeometryDrawing();
            geometryDrawing.Geometry = geometry;
            geometryDrawing.Brush = _brush;
            geometryDrawing.Pen = _pen;

            DrawingBrush drawingBrush = new DrawingBrush();
            drawingBrush.Drawing = geometryDrawing;

            drawingBrush.Viewport = new Rect(0, 0, 1.0 / scaleFactor, 1.0 / scaleFactor);
            drawingBrush.ViewportUnits = BrushMappingMode.RelativeToBoundingBox;
            drawingBrush.TileMode = TileMode.Tile;

            canvas.Background = drawingBrush;

            canvasBackground.Background = _canvasBackground;
        }

        private void SetUpRadioButtonImages()
        {
            fillCanvas(firstImg, geometryInitializer.GetSelectedGeometry(1));
            fillCanvas(secondImg, geometryInitializer.GetSelectedGeometry(2));
            fillCanvas(thirdImg, geometryInitializer.GetSelectedGeometry(3));
            fillCanvas(fourthImg, geometryInitializer.GetSelectedGeometry(4));
            fillCanvas(fifthImg, geometryInitializer.GetSelectedGeometry(5));
        }

        private void graphicsSelected(object sender, RoutedEventArgs e)
        {
            _selectedRadioButtonTag = int.Parse((sender as RadioButton).Tag.ToString());

            onPaint(sender, e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _pen = new Pen(new SolidColorBrush(GetColorFromDialog()), 1);

            PenColorBtn.BorderBrush = _pen.Brush;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _brush = new SolidColorBrush(GetColorFromDialog());

            BrushColorBtn.BorderBrush = _brush;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _canvasBackground = new SolidColorBrush(GetColorFromDialog());

            BackgroundColorBtn.BorderBrush = _canvasBackground;
        }

        private Color GetColorFromDialog()
        {
            var c = new Color();

            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                c = Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);

            return c;
        }

        private void F1_Key_Down(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                System.Windows.MessageBox.Show(@"
                              Author: Nikita Nikitins
                              E-mail: nikitinsn6@gmail.com
                              Github: https://github.com/NikitaNikitins
                              Project name: Grafikas Attēlošana ar WPF");
            }
        }
    }
}
