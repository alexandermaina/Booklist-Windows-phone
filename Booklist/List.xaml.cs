using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Booklist
{
    public partial class List : PhoneApplicationPage
    {
        public List()
        {
            InitializeComponent();
            ApplicationBar = new ApplicationBar();

            //add button
            ApplicationBarIconButton add = new ApplicationBarIconButton();
            add.Text = "Add new";
            add.IconUri = new Uri("/icons/add.png", UriKind.Relative);
            ApplicationBar.Buttons.Add(add);
            add.Click += add_Click;

            //About us... Menu item
            ApplicationBarMenuItem about = new ApplicationBarMenuItem();
            about.Text = "About us";
            ApplicationBar.MenuItems.Add(about);
            about.Click += about_Click;
        }

        void about_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.RelativeOrAbsolute));
        }

        
        //Load books from the database to the list
        private void LoadBooks()
        { 
           
            IList<TblBooks> list = null;
            using (BooksDatacontext context = new BooksDatacontext(App.booksconnectionString))
            {
                IQueryable<TblBooks> query = from c in context.TblBooks select c;
                 list = query.ToList(); 
                bookList.ItemsSource = list;
            }
        }
        void add_Click(object sender, EventArgs e)
        {
            //navigate to the add books page
            NavigationService.Navigate(new Uri("/AddBooks.xaml", UriKind.Relative));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            LoadBooks();
        }

        protected override void OnTap(System.Windows.Input.GestureEventArgs e)
        {
            //enable onTap on the list items
            TblBooks tb = (TblBooks)bookList.SelectedItem;
            if (bookList.SelectedIndex != -1)
            {
                NavigationService.Navigate(new Uri("/ViewBook.xaml?id=" + tb.id, UriKind.RelativeOrAbsolute));

            }
        }

        

        private void bookList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        
    }
}