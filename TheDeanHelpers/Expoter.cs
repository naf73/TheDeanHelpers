using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TheDeanHelpers
{
    public class Expoter
    {
        public void ExportToFileXLSX(string pathFile, System.Data.DataTable doc)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(pathFile, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet();

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());

                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet_1" };

                sheets.Append(sheet);

                SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                worksheetPart.Worksheet.Save();
                
                #region Columns

                Row Headers = new Row();

                foreach (DataColumn column in doc.Columns)
                {
                    Headers.Append(ConstructCell(column.ColumnName, CellValues.String));
                }
                sheetData.AppendChild(Headers);               

                #endregion

                #region Rows

                foreach (DataRow row in doc.Rows)
                {
                    Row sheetRow = new Row();

                    foreach(string value in row.ItemArray)
                    {
                        if (!string.IsNullOrEmpty(value))
                        {
                            sheetRow.Append(ConstructCell(value, CellValues.String));
                        }
                    }

                    if (sheetRow.Count() > 0)
                    {
                        sheetData.Append(sheetRow);
                    }
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
