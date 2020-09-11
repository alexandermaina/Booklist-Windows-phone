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
    public partial class AddBooks : PhoneApplicationPage
    {
        public AddBooks()
        {
            InitializeComponent();
            ApplicationBar = new ApplicationBar();
            
            //button to clear the textboxes
            ApplicationBarIconButton clear = new ApplicationBarIconButton();
            clear.Text = "Clear";
            clear.IconUri = new Uri("/icons/cancel.png", UriKind.Relative);
            ApplicationBar.Buttons.Add(clear);
            clear.Click += clear_Click;

            //confirm button
            ApplicationBarIconButton confirm = new ApplicationBarIconButton();
            confirm.Text = "Confirm";
            confirm.IconUri = new Uri("/icons/check.png", UriKind.Relative);
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

        void confirm_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text)){
                MessageBox.Show("Name of the book is required");
                txtName.Focus();
            }
            else if (String.IsNullOrEmpty(txtAuthor.Text))
            {
                MessageBox.Show("Name of the Author is required");
                txtAuthor.Focus();
            }
            else
            {
                using (BooksDatacontext context = new BooksDatacontext(App.booksconnectionString))
                {
                    
                    try
                    {
                        //Add the details to the Tables
                        TblBooks st = new TblBooks() { name = txtName.Text, author = txtAuthor.Text, description = txtDesc.Text, version = txtVersion.Text };
                        context.TblBooks.InsertOnSubmit(st);
                        context.SubmitChanges();
                        MessageBox.Show("Book has been Added Successfully");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Unable to add book");
                    }
                }

            }

        }

        void clear_Click(object sender, EventArgs e)
        {
            //clear the textboxes
            txtAuthor.Text = "";
            txtDesc.Text = "";
            txtName.Text = "";
            txtVersion.Text = "";
        }
    }
}