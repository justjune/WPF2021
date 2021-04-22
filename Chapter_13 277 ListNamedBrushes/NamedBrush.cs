using System;
using System.Reflection;
using System.Windows.Media;

namespace Petzold.ListNamedBrushes
{
    public class NamedBrush //класс идентичен NamedColor, если не считать что все ссылки на Color и Colors заменяются на Brush, Brushes
    {
        static NamedBrush[] nbrushes;
        Brush brush;
        string str;

        // Статический конструктор
        static NamedBrush()
        {
            PropertyInfo[] props = typeof(Brushes).GetProperties(); // Выявляет атрибуты свойства и обеспечивает доступ к его метаданным
            nbrushes = new NamedBrush[props.Length];

            for (int i = 0; i < props.Length; i++)
                nbrushes[i] = new NamedBrush(props[i].Name,
                                        (Brush)props[i].GetValue(null, null)); // Возвращает значение свойства заданного объекта с дополнительными значениями индекса для индексированных свойств
        }

        // Приватный конструктор
        private NamedBrush(string str, Brush brush)
        {
            this.str = str;
            this.brush = brush;
        }

        // Статическое свойство доступное только для чтения
        public static NamedBrush[] All
        {
            get { return nbrushes; }
        }

        // Свойства доступные только для чтения
        public Brush Brush
        {
            get { return brush; }
        }
        public string Name
        {
            get
            {
                string strSpaced = str[0].ToString();

                for (int i = 1; i < str.Length; i++)
                    strSpaced += (char.IsUpper(str[i]) ? " " : "") +
                                            str[i].ToString();
                return strSpaced;
            }
        }

        // Переопределение метода ToString
        public override string ToString()
        {
            return str;
            //при занесении в ListBox обьектов NamedBrush свойство SelectedValuePath задается равным "Brush"
            //Привязка показывает, что свойство SelectedValue обьекта ListBox связывается с со свойством Background окна this
        }
    }
}
