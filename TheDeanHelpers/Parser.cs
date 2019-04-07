using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDeanHelpers.Model;

namespace TheDeanHelpers
{
    public  class Parser
    {
        public CSVFile Download (string filePath )
        {
            if (!File.Exists(filePath))throw new FileNotFoundException();
            using (var reader = new StreamReader(filePath, Encoding.Default))
            {
                string line;
                bool firstLine = true;
                CSVFile doc = new CSVFile();
                int countRow = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    if (firstLine)
                    {
                        int countColumns = 0;
                        foreach (var word in line.Split(';'))
                        {

                            doc.Columns.Add(new Column()
                            {
                                Id = countColumns++,
                                Name = word,
                                IsActive = true
                            });
                        }
                        firstLine = false;
                    }
                    else
                    {
                        Row r = new Row()
                        {
                            Id = countRow
                        };
                        int countWord = 0;                        
                        foreach (var word in line.Split(';'))
                        {

                            r.Cells.Add(new Cell()
                            {
                                ColumnId = countWord,
                                RowId = countRow,
                                Value=word
                            });
                            countWord++;
                        }
                        doc.Rows.Add(r);
                        countRow++;
                    }
                }
                return doc;
            }
            
            
            
        }


        
    }
}
