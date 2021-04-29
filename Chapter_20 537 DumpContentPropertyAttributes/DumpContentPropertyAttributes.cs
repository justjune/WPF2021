using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Navigation;
public class DumpContentPropertyAttributes
{
    [STAThread]
    public static void Main()
    {
        // Обеспечить загрузку библиотек PresentationCore и PresentationFramework
        UIElement dummy1 = new UIElement(); // создаем элемент пользовательского интерфейса
        FrameworkElement dummy2 = new FrameworkElement();// создаем элемент класса, расширяющего возможности класса UIElement

        // Объект SortedList для хранения классов и свойств содержимого
        SortedList<string, string> listClass = new SortedList<string,
        string>();
        // Форматная строка
        string strFormat = "{0,-35}{1}";

        // Перебор загруженных сборок
        // Объект AssemblyName содержит сведения о сборке, которые можно использовать для привязки к этой сборке
        foreach (AssemblyName asmblyname in
        Assembly.GetExecutingAssembly().GetReferencedAssemblies()) // перебираем объекты класса AssemblyName со всех сборок,
                                                                   // на которые ссылается данная сборка
        {
            // Перебор типов, определённых в каждой из сборок
            foreach (Type type in Assembly.Load(asmblyname).GetTypes())
            {
                // Перебор пользовательских атрибутов для каждого из типов
                // нужно использовать аргумент false, чтобы ограничить поиск ненаследуемыми атрибутами
                foreach (object obj in type.GetCustomAttributes(
                typeof(ContentPropertyAttribute), true))
                {
                    // Если рассматриваемый атрибут - это ContentPropertyAttribute, то включить в список
                    if (type.IsPublic && obj as ContentPropertyAttribute != null)
                        listClass.Add(type.Name,
                        (obj as ContentPropertyAttribute).Name);
                }
            }
        }

        // Вывод результатов
        Console.WriteLine(strFormat, "Class", "Content Property");
        Console.WriteLine(strFormat, "-----", "----------------");
        foreach (string strClass in listClass.Keys)
            Console.WriteLine(strFormat, strClass, listClass[strClass]);
    }
}