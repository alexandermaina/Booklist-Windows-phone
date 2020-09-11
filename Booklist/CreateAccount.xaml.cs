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
    public partial class CreateAccount : PhoneApplicationPage
    {
        public CreateAccount()
        {
            InitializeComponent();
            ApplicationBar = new ApplicationBar();

            //clear button
            ApplicationBarIconButton clear = new ApplicationBarIconButton();
            clear.Text = "Clear";
            clear.IconUri = new Uri("/icons/cancel.png", UriKind.Relative);
            ApplicationBar.Buttons.Add(clear);
            clear.Click += clear_Click;

            //confirm button
            ApplicationBarIconButton confirm = new ApplicationBarIconButton();
            confirm.Text = "Create account";
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
            
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.RelativeOrAbsolute));

        }

        void clear_Click(object sender, EventArgs e)
        {
            txtPasswd.Password = "";
            txtName.Text = "";
            txtUname.Text = "";
        }

        void confirm_Click(object sender, EventArgs e)
        {
            //validate the form
            if (String.IsNullOrEmpty(txtName.Text)){
                MessageBox.Show("Name is required");
                txtName.Focus();
            }
            else if (String.IsNullOrEmpty(txtUname.Text))
            {
                MessageBox.Show("Username is required");
                txtUname.Focus();
            }
            else if (String.IsNullOrEmpty(txtPasswd.Password))
            {
                MessageBox.Show("Password is required");
                txtPasswd.Focus();
            }
            else
            {
                using (BooksDatacontext context = new BooksDatacontext(App.booksconnectionString))
                {
                    
                    try
                    {
                        //Add user information in the database table TblAccounts
                        TblAccounts tb = new TblAccounts() ;
                       
                        tb.name = txtName.Text;
                        tb.username = txtUname.Text;
                        tb.passwd = txtPasswd.Password;
                        context.TblAccounts.InsertOnSubmit(tb);
                        context.SubmitChanges();
                        MessageBox.Show("Account Created Successfully");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("unable to Create an Account");
                        
                    }
                  
                }
            }

        }
    }
}