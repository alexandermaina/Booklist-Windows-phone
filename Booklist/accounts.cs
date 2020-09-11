using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booklist
{
        [Table]
        //Table for user acccounts
        class TblAccounts
        {
            [Column(IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false, AutoSync = AutoSync.OnInsert)]
            public int id { get; set; }
            [Column(CanBeNull = false)] 
            public string name { get; set; }
            [Column(CanBeNull = false)]
            public string username { get; set; }
            [Column(CanBeNull = false)]
            public string passwd { get; set; }
        }
}
