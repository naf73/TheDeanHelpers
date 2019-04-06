using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDeanHelpers.Model;
using SheetRow = DocumentFormat.OpenXml.Spreadsheet.Row;
using CSVRow = TheDeanHelpers.Model.Row;

namespace TheDeanHelpers
{
    public class Expoter
    {
        public void ExportToFileXLSX(string pathFile, CSVFile doc)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(pathFile, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet();

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());

                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet" };

                sheets.Append(sheet);

                SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                worksheetPart.Worksheet.Save();

                #region Заголовок

                SheetRow rangeDates = new SheetRow();

                foreach (var column in doc.Columns)
                {
                    rangeDates.Append(ConstructCell(column.Name, CellValues.String));
                }
                sheetData.AppendChild(rangeDates);               

                #endregion

                #region Customers

                foreach (var row in doc.Rows)
                {
                    SheetRow sheetRow = new SheetRow();

                    //sheetRow.Append(ConstructCell(row.Cells[], CellValues.Number));

                    sheetData.Append(sheetRow);
                }

                #endregion

                workbookPart.Workbook.Save();
            }
        }

        #region Methods

        private DocumentFormat.OpenXml.Spreadsheet.Cell ConstructCell(string value, CellValues dataType)
        {
            return new DocumentFormat.OpenXml.Spreadsheet.Cell()
            {
                CellValue = new CellValue(value),
                DataType = new EnumValue<CellValues>(dataType)
            };
        }

        #endregion
    }
}
