﻿#pragma checksum "C:\Users\Homcom Computers\Desktop\Notes & tutorials\Windows phone app\kiokos.net\Project\Booklist\Booklist\EditBook.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "40557B592EBD1FA8AA85A911D60658A3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Booklist {
    
    
    public partial class EditBook : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBox txtName;
        
        internal System.Windows.Controls.TextBox txtAuthor;
        
        internal System.Windows.Controls.TextBox txtVersion;
        
        internal System.Windows.Controls.TextBox txtDesc;
        
        internal System.Windows.Controls.TextBox txtID;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Booklist;component/EditBook.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.txtName = ((System.Windows.Controls.TextBox)(this.FindName("txtName")));
            this.txtAuthor = ((System.Windows.Controls.TextBox)(this.FindName("txtAuthor")));
            this.txtVersion = ((System.Windows.Controls.TextBox)(this.FindName("txtVersion")));
            this.txtDesc = ((System.Windows.Controls.TextBox)(this.FindName("txtDesc")));
            this.txtID = ((System.Windows.Controls.TextBox)(this.FindName("txtID")));
        }
    }
}
