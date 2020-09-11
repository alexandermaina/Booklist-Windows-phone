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
    public partial class EditBook : PhoneApplicationPage
    {
        public EditBook()
        {
            InitializeComponent();
            ApplicationBar = new ApplicationBar();
            

            //confirm button
            ApplicationBarIconButton confirm = new ApplicationBarIconButton();
            confirm.Text = "Confirm";
            confirm.IconUri = new Uri("/icons/save.png", UriKind.Relative);
            ApplicationBar.Buttons.Add(confirm);
            confirm.Click += confirm_Click;

            //About us... Menu item
            ApplicationBarMenuItem about = new ApplicationBarMenuItem();
            about.Text = "About us";
            ApplicationBar.MenuItems.Add(about);
            about.Click += about_Click;
        }

        void about_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.RelativeOrAbsolute));

        }


        private void confirm_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            using (BooksDatacontext context = new BooksDatacontext(App.booksconnectionString))
            {
                var BookLoaded = (from book in context.TblBooks where book.id == Int32.Parse(txtID.Text) select book).FirstOrDefault();
                if (BookLoaded != null)
                {
                    try
                    {
                        //Adding changes into the database
                        String id = NavigationContext.QueryString["id"];
                        BookLoaded.author = txtAuthor.Text;
                        BookLoaded.description = txtDesc.Text;
                        BookLoaded.name = txtName.Text;
                        BookLoaded.version = txtVersion.Text;
                        context.SubmitChanges();  
                        MessageBox.Show("Book Editted successfully");
                        //Move back to the view page
                        NavigationService.Navigate(new Uri("/ViewBook.xaml?id=" + id, UriKind.RelativeOrAbsolute));
                    }
                    catch (Exception)
                    {  
                        MessageBox.Show("Unable to Edit the book");
                    }
                }
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Getting the book id from the former page
            String id = NavigationContext.QueryString["id"];
            using (BooksDatacontext context = new BooksDatacontext(App.booksconnectionString))
            {
                var BookLoaded = (from book in context.TblBooks where book.id == Int32.Parse(id) select book).FirstOrDefault();
                if (BookLoaded != null)
                {
                    //Loading book details in their respective textboxes
                    txtID.Text = BookLoaded.id.ToString();
                    txtAuthor.Text = BookLoaded.author;
                    txtDesc.Text = BookLoaded.description;
                    txtName.Text = BookLoaded.name;
                    txtVersion.Text = BookLoaded.version;
                }
            }
        }
    }
}