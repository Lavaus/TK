using System.Reflection.Metadata;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TK
{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        // очищает строки
        private void clear_t()
        {
            one_t.Text = "";
            two_t.Text = "";
            tree_t.Text = " ";
            radius_t.Text = " ";
            result.Text = "Hello world!";
        }
        // прячет строки
        private void clear()
        {
            one.Visibility = Visibility.Hidden;
            one_t.Visibility = Visibility.Hidden;
            two.Visibility = Visibility.Hidden;
            two_t.Visibility = Visibility.Hidden;
            tree.Visibility = Visibility.Hidden;
            tree_t.Visibility = Visibility.Hidden;
            radius.Visibility = Visibility.Hidden;
            radius_t.Visibility = Visibility.Hidden;
        }
        // показывает строки для круга
        private void circle_vis()
        {
            radius.Visibility = Visibility.Visible;
            radius_t.Visibility = Visibility.Visible;
        }
        // показывает строки для треугольника
        private void triangle_vis()
        {
            one.Visibility = Visibility.Visible;
            one_t.Visibility = Visibility.Visible;
            two.Visibility = Visibility.Visible;
            two_t.Visibility = Visibility.Visible;
            tree.Visibility = Visibility.Visible;
            tree_t.Visibility = Visibility.Visible;
        }
        // показывает строки для прямоугольника
        private void rectangle_vis()
        {
            one.Visibility = Visibility.Visible;
            one_t.Visibility = Visibility.Visible;
            two.Visibility = Visibility.Visible;
            two_t.Visibility = Visibility.Visible;
        }

       // функция для рассчёта периметра круга
        private void circle()

        {
            // проверка на пустые значения
            if (radius_t.Text == null)
            {
                MessageBox.Show("А данные кто заполнять будет", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // проверка на неподходящие значения
            if (!double.TryParse(radius_t.Text, out double rad))
            {
                MessageBox.Show("Не так не пойдёт", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // проверка на отрицательные и нулевые значения
            if (rad <= 0)
            {
                MessageBox.Show("МЫ В ОТРИЦАТЕЛЬНЫЕ ЧИСЛА НЕ ЛЕЗЕМ", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            double per = 2 * Math.PI * double.Parse(radius_t.Text);
            result.Text = per.ToString();
        }
        // функция для рассчёта периметра треугольника
        private void triangle()
        {
            // проверка на пустые значения
            if (one_t.Text == null || two_t.Text == null || tree_t.Text == null)
            {
                MessageBox.Show("А данные кто заполнять будет", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // проверка на неподходящие значения
            if (!double.TryParse(one_t.Text, out double on))
            {
                MessageBox.Show("Не так не пойдёт", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // проверка на неподходящие значения
            if (!double.TryParse(two_t.Text, out double tw))
            {
                MessageBox.Show("Не так не пойдёт", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // проверка на неподходящие значения
            if (!double.TryParse(tree_t.Text, out double tr))
            {
                MessageBox.Show("Не так не пойдёт", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // проверка на отрицательные и нулевые значения
            if (on <= 0 || tw <= 0 || tr <= 0)
            {
                MessageBox.Show("МЫ В ОТРИЦАТЕЛЬНЫЕ ЧИСЛА НЕ ЛЕЗЕМ", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // у треугольника сумма двух стороне всегда больше третьей строны
            if (on + tw <= tr || on + tr <= tw || tw + tr <= on)
            {
                MessageBox.Show("Треугольник с такими сторонами не существует!\n" +
                    "Я звоню в полицию", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            double per = on + tw + tr;
            result.Text = per.ToString();
        }
        // функция для рассчёта периметра прямоугольника
        private void rectangle()

        {
            // проверка на пустые значения
            if (one_t.Text == null || two_t.Text == null)
            {
                MessageBox.Show("А данные кто заполнять будет", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // проверка на неподходящие значения
            if (!double.TryParse(one_t.Text, out double on))
            {
                MessageBox.Show("Не так не пойдёт", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // проверка на неподходящие значения
            if (!double.TryParse(two_t.Text, out double tw))
            {
                MessageBox.Show("Не так не пойдёт", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // проверка на отрицательные и нулевые значения
            if (on <= 0 || tw <= 0)
            {
                MessageBox.Show("МЫ В ОТРИЦАТЕЛЬНЫЕ ЧИСЛА НЕ ЛЕЗЕМ", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            double per = 2 * on + tw;
            result.Text = per.ToString();
        }
        // обработчик Radiobutton
        private void per(object sender, RoutedEventArgs e)
        {
            RadioButton pe = sender as RadioButton;
            switch (pe.Content)
            {
                case "Круг":
                    clear_t();
                    clear();
                    circle_vis();   
                    break;
                case "Треугольник":
                    clear_t();
                    clear();
                    triangle_vis();
                    break;
                case "Прямоугольник":
                    clear_t();
                    clear();
                    rectangle_vis();
                    break;
            }
        }
        // Вычисление
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (radius.Visibility == Visibility.Visible)
                    {
                    circle();
                    }
                else if(tree.Visibility == Visibility.Visible)
                    {
                    triangle();
                    }
                else
                    {
                    rectangle();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: поля не заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}