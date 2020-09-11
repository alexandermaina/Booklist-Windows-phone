using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booklist
{
    //Table to store the books
    [Table]
    class TblBooks
    {
        //columns
        [Column(IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int id { get; set; }
        [Column(CanBeNull = false)]
        public string name { get; set; }
        [Column(CanBeNull = false)]
        public string author { get; set; }
        [Column(CanBeNull = false)]
        public string version { get; set; }
        [Column(CanBeNull = true)]
        public string description { get; set; }
    }
}
