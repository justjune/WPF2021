using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
namespace Petzold.DrawCircles
{
    public class DrawCircles : Window
    {
        Canvas canv;
        bool isDrawing;
        Ellipse elips;
        Point ptCenter;
        bool isDragging;
        FrameworkElement elDragging;
        Point ptMouseStart, ptElementStart;

        [STAThread]

        public static void Main()
        {
            Application app = new Application();
            app.Run(new DrawCircles());
        }
        public DrawCircles()
        {
            Title = "Draw Circles";
            Content = canv = new Canvas();  //canv присваивается атрибуту Content       
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs args) //реализация функции OnMouseLeftButtonDown       
        {
            base.OnMouseLeftButtonDown(args);
            if (isDragging)
                return;
            ptCenter = args.GetPosition(canv);
            elips = new Ellipse(); //создание объекта класса Ellipse и его добавление к canv (строки 38 - 45)
            elips.Stroke = SystemColors.WindowTextBrush;
            elips.StrokeThickness = 1;
            elips.Width = 0;
            elips.Height = 0;
            canv.Children.Add(elips);
            Canvas.SetLeft(elips, ptCenter.X);
            Canvas.SetTop(elips, ptCenter.Y);
            CaptureMouse(); //активировать курсор и приготовить к будущим ивентам             
            isDrawing = true; //isDrawing означает, что программа находится в состоянии рисования
        }
        protected override void OnMouseRightButtonDown(MouseButtonEventArgs args) //реализация функции OnMouseRightButtonDown         
        {
            base.OnMouseRightButtonDown(args);
            if (isDrawing)
                return;
            //Получение элемента, на котором был сделан щелчок подготовка к будущим ивентам              
            ptMouseStart = args.GetPosition(canv);
            elDragging = canv.InputHitTest(ptMouseStart) as FrameworkElement;
            if (elDragging != null) //проверка того, что elDragging не ссылается на null и присвоение новых координат              
            {
                ptElementStart = new Point(Canvas.GetLeft(elDragging), Canvas.GetTop(elDragging));
                isDragging = true;
            }
        }
        protected override void OnMouseDown(MouseButtonEventArgs args) //реализация функции OnMouseDown         
        {
            base.OnMouseDown(args);
            if (args.ChangedButton == MouseButton.Middle) //При нажатии средней кнопки мыши внутренняя окружность становится прозрачной (строки 66 - 71)            
            {
                Shape shape = canv.InputHitTest(args.GetPosition(canv)) as Shape;
                if (shape != null)
                    shape.Fill = (shape.Fill == Brushes.Red ? Brushes.Transparent : Brushes.Red);
            }
        }
        protected override void OnMouseMove(MouseEventArgs args) //реализация функции OnMouseMove   
        {
            base.OnMouseMove(args);
            Point ptMouse = args.GetPosition(canv);
            if (isDrawing) // Изменение размеров эллипса (строки 77 - 85)             
            {
                double dRadius = Math.Sqrt(Math.Pow(ptCenter.X - ptMouse.X, 2) + Math.Pow(ptCenter.Y - ptMouse.Y, 2));
                Canvas.SetLeft(elips, ptCenter.X - dRadius);
                Canvas.SetTop(elips, ptCenter.Y - dRadius);
                elips.Width = 2 * dRadius;
                elips.Height = 2 * dRadius;
            }

            else if (isDragging) // Перемещение эллипса (строки 87 - 92)             
            {
                Canvas.SetLeft(elDragging, ptElementStart.X + ptMouse.X - ptMouseStart.X);
                Canvas.SetTop(elDragging, ptElementStart.Y + ptMouse.Y - ptMouseStart.Y);
            }
        }
        protected override void OnMouseUp(MouseButtonEventArgs args) //реализация функции OnMouseUp         
        {
            base.OnMouseUp(args);
            if (isDrawing && args.ChangedButton == MouseButton.Left) /*если в момент рисования отжимается левая кнопка мыши, 
                                                                     режим рисования завершается (строки 95 - 102)*/
            {
                elips.Stroke = Brushes.Blue;
                elips.StrokeThickness = Math.Min(24, elips.Width / 2);
                elips.Fill = Brushes.Red;
                isDrawing = false;
                ReleaseMouseCapture();
            }
            else if (isDragging && args.ChangedButton == MouseButton.Right) /*если в момент перетаскивания отжимается правая кнопка мыши, 
                                                                               режим перетаскивания завершается*/
            {
                isDragging = false;
            }
        }
        protected override void OnTextInput(TextCompositionEventArgs args)
        {
            base.OnTextInput(args);
            if (args.Text.IndexOf('\x1B') != -1) /*выход из режимов рисования и перетаскивания по клавише Esc (в случае перетаскивания при нажатии 
                                                 Esc окружность возвращается к начальным координатам*/
            {
                if (isDrawing)
                    ReleaseMouseCapture();
                else if (isDragging)
                {
                    Canvas.SetLeft(elDragging, ptElementStart.X);
                    Canvas.SetTop(elDragging, ptElementStart.Y);
                    isDragging = false;
                }
            }
        }
        protected override void OnLostMouseCapture(MouseEventArgs args)
        {
            base.OnLostMouseCapture(args); //внештатное завершение рисования              
            if (isDrawing)
            {
                canv.Children.Remove(elips); //удаление дочерних элементов canv                 
                isDrawing = false;
            }
        }
    }
}
