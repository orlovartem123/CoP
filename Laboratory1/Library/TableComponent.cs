using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Xml;

namespace Library
{
    /**
     * 
     * Документ с 
таблицами. 
     * Формат 
документа - Pdf
     
    Не визуальный компонент для создания документа с таблицами. 

    * У компонента должен быть публичный метод, который должен 
принимать на вход имя файла (включая путь до файла), название 
документа (заголовок в документе) и набор таблиц (каждая 
представляет собой двумерный массив строк, где каждая строка –
ячейка таблицы документа). 
    
    Таблицы выделить границами. 
Ширина колонок одинакова у всех. Должна быть проверка на 
заполненность входных данных значениями.
Примеры создания документа в разных форматах (docx, xlsx, 
pdf).
     */
    public class TableComponent
    {
        [Obsolete]
        public void SaveTable(String direction, String documentName, List<String[,]> tables)
        {
            var document = new Document();

            Section section = document.AddSection();
            Paragraph paragraph = section.AddParagraph(documentName);
            paragraph.Format.SpaceAfter = "1cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Style = "NormalTitle";

            foreach (String[,] strings in tables) {
                var table = document.LastSection.AddTable();
                for (int i =0;i< strings.GetLength(1);i++) {
                    table.AddColumn();
                }

                for (int i=0;i<strings.GetLength(0);i++) {
                    var row = table.AddRow();
                    for (int j=0;j<table.Columns.Count;j++) {
                        row.Cells[j].AddParagraph(strings[i, j]);
                    }
                }
            }

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true,
      PdfSharp.Pdf.PdfFontEmbedding.Always)
            {
                Document = document
            };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(direction);
        }
    }
}
