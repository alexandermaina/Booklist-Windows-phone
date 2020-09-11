using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Booklist.Resources;

namespace Booklist
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            //Check if the database exists
            using (BooksDatacontext context = new BooksDatacontext(App.booksconnectionString))
            {
                if (!context.DatabaseExists())
                {
                    context.CreateDatabase();
                    MessageBox.Show("You're  Welcome to add new Books");
                }
                else
                {
                    MessageBox.Show("List of books already Exists");
                }
            }

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
            ApplicationBar = new ApplicationBar();

            //add button
            ApplicationBarIconButton add = new ApplicationBarIconButton();
            add.Text = "Add new";
            add.IconUri = new Uri("/icons/add.png", UriKind.Relative);
            ApplicationBar.Buttons.Add(add);
            add.Click += add_Click;  

            //clear button
            ApplicationBarIconButton clear = new ApplicationBarIconButton();
            clear.Text = "Clear";
            clear.IconUri = new Uri("/icons/cancel.png", UriKind.Relative);
            ApplicationBar.Buttons.Add(clear);
            clear.Click += clear_Click;

            //confirm button
            ApplicationBarIconButton confirm = new ApplicationBarIconButton();
            confirm.Text = "Login";
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

        void add_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            NavigationService.Navigate(new Uri("/CreateAccount.xaml", UriKind.Relative));

        }

        void confirm_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (String.IsNullOrEmpty(txtUname.Text)) {
                MessageBox.Show("Username is required");
                txtUname.Focus();
            }
            else if (String.IsNullOrEmpty(txtpasswd.Password))
            {
                MessageBox.Show("Password is required");
                txtUname.Focus();
            }
            else
            {
                
                NavigationService.Navigate(new Uri("/List.xaml", UriKind.Relative));
            }
        }

        void clear_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //Clear the textBoxes
             txtpasswd.Password = "";
            txtUname.Text = "";
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}