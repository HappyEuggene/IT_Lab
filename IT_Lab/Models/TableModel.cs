using System.Collections.Generic;

namespace IT_Lab.Models
{
    public class TableModel
    {
        public string Name { get; set; }
        public List<ColumnModel> Columns { get; set; } = new List<ColumnModel>();
        public List<RowModel> Rows { get; set; } = new List<RowModel>();
    }
}
