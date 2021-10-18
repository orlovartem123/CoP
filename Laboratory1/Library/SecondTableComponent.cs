using Library.HelperModels;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Library
{

    /*У компонента должен быть публичный метод, который должен 
принимать на вход имя файла (включая путь до файла), название 
документа (заголовок в документе), информацию по ширине 
каждого столбца и высоте каждой строки (по строке задается для 
шапки и для остальных строк), заголовки для шапки и данные 
для таблицы. Строки и столбцы таблицы считать с 0 позиции. 
Данные должны передаваться в виде набора объектов какого-то 
класса. 
        
        Таблица должна заполнятся по принципу: каждая строка 
– это запись класса из набора, ячейка строки заполняется из 
свойства/поля объекта класса (в настройках указывать для какого 
столбца какое свойство/поле соответствует) 
        
        Первая ячейка 
строки (относящаяся к шапке) заполняется также из записи 
класса из набора. 
        
        Должна быть проверка на заполненность 
входных данных значениями. 
        
        Должна быть проверка, что все 
ячейки шапки заполнены и для каждого столбца известно 
свойство/поле класса из которого для него следует брать 
значение.
*/

    public class SecondTableComponent
    {

        public void SaveTable(string nameOfFile, string nameOfDocument, List<TableColumnHelper> columns,
            List<TableRowHelper> strings, List<Student> students, bool horisontalAlignment) {

            PdfPTable table = horisontalAlignment ? CreateHorisontalTable(nameOfDocument,
                columns, strings, students) : CreateVerticalTable(nameOfDocument,
                columns, strings, students);
            FileStream fs = new FileStream(nameOfFile, FileMode.Create);
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();
            document.Add(table);
            document.Close();
            writer.Close(); 
            fs.Close();

        }

        private PdfPTable CreateHorisontalTable(string nameOfDocument, List<TableColumnHelper> columns,
            List<TableRowHelper> strings, List<Student> Students) {

            PdfPTable table = new PdfPTable(columns.Count);



            return table;
        }

        private PdfPTable CreateVerticalTable(string nameOfDocument, List<TableColumnHelper> columns,
            List<TableRowHelper> strings, List<Student> students)
        {

            PdfPTable table = new PdfPTable(columns.Count);



            return table;
        }
    }
}
