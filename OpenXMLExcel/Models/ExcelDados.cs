using System.Collections.Generic;
using DocumentFormat.OpenXml.Spreadsheet;

namespace OpenXMLExcel.Models
{
    public class ExcelStatus
    {
        public string Message { get; set; }
        public bool Success
        {
            get { return string.IsNullOrWhiteSpace(Message); }
        }
    }
	
    public class ExcelDados
    {
        public ExcelStatus Status { get; set; }
        public Columns ColumnConfigurations { get; set; }
        public List<string> Headers { get; set; }
        public List<List<string>> DataRows { get; set; }
        public string SheetName { get; set; }

        public ExcelDados()
        {
            Status = new ExcelStatus();
            Headers = new List<string>();
            DataRows = new List<List<string>>();
        }
    }
} 