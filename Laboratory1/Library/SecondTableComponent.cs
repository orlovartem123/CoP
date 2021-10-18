﻿using Library.HelperModels;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Reflection;
using System;

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
            TableRowHelper[] rows, List<Student> students)
        {
            IsDataNotEmpty(students);
            AreColumnsFull(columns);

            PdfPTable table = CreateTable(columns, rows, students);
            FileStream fs = new FileStream(nameOfFile, FileMode.Create);
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();
            document.Add(new Paragraph(nameOfDocument));
            document.Add(table);
            document.Close();
            writer.Close();
            fs.Close();

        }

        private PdfPTable CreateTable(List<TableColumnHelper> columns,
            TableRowHelper[] rows, List<Student> students)
        {

            //Здесь получаем массив ширины колонок для таблицы и проверяем заполненность ширины 
            float[] widths = new float[columns.Count];
            bool widthsExist = true;
            foreach (TableColumnHelper column in columns)
            {
                if (column.Width == null)
                {
                    widthsExist = false;
                }
            }
            if (widthsExist)
            {
                int index = 0;
                int sum = 0;
                foreach (TableColumnHelper column in columns)
                {
                    widths[index] = (float)column.Width;
                    sum += (int)column.Width;
                    index++;
                }
            }

            //Здесь мы проверяем наличие данных о высоте колонок
            bool heightsExist;
            heightsExist = rows.Length == 2 ? true : false;
            foreach (TableRowHelper row in rows)
            {
                if (row.Height == null)
                {
                    heightsExist = false;
                }
            }

            //Если есть ширина, то добавляем параметры
            PdfPTable table = new PdfPTable(columns.Count);
            if (widthsExist) {
                table.LockedWidth = true;
                table.SetTotalWidth(widths);
            }

            //Добавляем столбцы по данным
            foreach (TableColumnHelper column in columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.Name));
                if (heightsExist) cell.MinimumHeight = (float)rows[0].Height;
                table.AddCell(cell);
            }

            //Добавляем ячейки по данным
            foreach (Student student in students)
            {
                foreach (TableColumnHelper column in columns)
                {
                    PropertyInfo propertyInfo = student.GetType().GetProperty(column.PropertyName);
                    string value = propertyInfo.GetValue(student).ToString();
                    PdfPCell cell = new PdfPCell(new Phrase(value));
                    if (heightsExist) cell.MinimumHeight = (float)rows[1].Height;
                    table.AddCell(cell);
                }
            }

            return table;
        }

        private void IsDataNotEmpty(List<Student> students) {
            if (students.Count == 0) throw new Exception("list is empty");
        }

        private void AreColumnsFull(List<TableColumnHelper> columnHelpers) {
            foreach (TableColumnHelper column in columnHelpers) {
                if (column.Name == null || column.PropertyName==null) {
                    throw new Exception("fullfill the columnHelpers");
                }
            }
        }
    }
}
