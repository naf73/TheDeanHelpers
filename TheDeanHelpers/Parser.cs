using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace TheDeanHelpers
{
    public  class Parser
    {
        public DataTable Download(string filePath)
        {
            if (!File.Exists(filePath))throw new FileNotFoundException();
            using (var reader = new StreamReader(filePath, Encoding.Default))
            {
                string line;
                bool firstLine = true;
                DataTable doc = new DataTable();
                while ((line = reader.ReadLine()) != null)
                {
                    if (firstLine)
                    {
                        int index = 0;
                        foreach (var word in line.Split(';'))
                        {
                            doc.Columns.Add(new DataColumn
                            {
                                ColumnName = string.Format("Column_{0}", index),
                                Caption = word
                            });
                            index++;
                        }
                        firstLine = false;
                    }
                    else
                    {
                        List<string> words = new List<string>();
                        foreach (var word in line.Split(';'))
                        {
                            words.Add(word);
                        }
                        doc.Rows.Add(words.ToArray());
                    }
                }
                return doc;
            }         
        } 
    }
}
