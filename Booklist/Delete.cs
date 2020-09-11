using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booklist
{
    class Delete
    {
        //delete book by id
        public void DeleteUser(String id)
        {
            using (BooksDatacontext context = new BooksDatacontext(App.booksconnectionString))
            {
                IQueryable<TblBooks> entityQuery = from c in context.TblBooks where c.id.Equals(id) select c;
                TblBooks entityToDelete = entityQuery.FirstOrDefault();
                context.TblBooks.DeleteOnSubmit(entityToDelete);
                context.SubmitChanges();
            }
        }
    }
}
