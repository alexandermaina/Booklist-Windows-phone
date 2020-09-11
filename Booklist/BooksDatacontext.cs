using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booklist
{
    class BooksDatacontext : DataContext
    {
        public BooksDatacontext(String connectionString)
            : base(connectionString)
        {
             
     }
        public Table<TblBooks> TblBooks
        {
            get
            {
                return this.GetTable<TblBooks>();
            }
        }

        public Table<TblAccounts> TblAccounts
        {
            get
            {
                return this.GetTable<TblAccounts>();
            }
        }
    }
}
