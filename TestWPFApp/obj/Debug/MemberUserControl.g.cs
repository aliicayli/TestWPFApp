﻿#pragma checksum "..\..\MemberUserControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4548C430FBCBF7C63AD0E23FFE0F94A258910D796C1C9CA1F166D4DFBFEB3723"
//------------------------------------------------------------------------------
// <auto-generated>
//     Bu kod araç tarafından oluşturuldu.
//     Çalışma Zamanı Sürümü:4.0.30319.42000
//
//     Bu dosyada yapılacak değişiklikler yanlış davranışa neden olabilir ve
//     kod yeniden oluşturulursa kaybolur.
// </auto-generated>
//------------------------------------------------------------------------------

using Aspose.Cells.GridDesktop;
using MahApps.Metro.IconPacks;
using MahApps.Metro.IconPacks.Converter;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using TestWPFApp;


namespace TestWPFApp {
    
    
    /// <summary>
    /// MembersUserControl
    /// </summary>
    public partial class MembersUserControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 49 "..\..\MemberUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExcel;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\MemberUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOpenExcelLibreOffice;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\MemberUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxFilter;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\MemberUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid membersDataGrid;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\MemberUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtName;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\MemberUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtMail;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\MemberUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPhoneNumber;
        
        #line default
        #line hidden
        
        
        #line 142 "..\..\MemberUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSetAdmin;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\MemberUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUpdate;
        
        #line default
        #line hidden
        
        
        #line 154 "..\..\MemberUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelete;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TestWPFApp;component/memberusercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MemberUserControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnExcel = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\MemberUserControl.xaml"
            this.btnExcel.Click += new System.Windows.RoutedEventHandler(this.btnExcel_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnOpenExcelLibreOffice = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\MemberUserControl.xaml"
            this.btnOpenExcelLibreOffice.Click += new System.Windows.RoutedEventHandler(this.btnOpenExcelLibreOffice_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.textBoxFilter = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.membersDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 89 "..\..\MemberUserControl.xaml"
            this.membersDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.membersDataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtMail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtPhoneNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btnSetAdmin = ((System.Windows.Controls.Button)(target));
            
            #line 142 "..\..\MemberUserControl.xaml"
            this.btnSetAdmin.Click += new System.Windows.RoutedEventHandler(this.btnSetAdmin_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnUpdate = ((System.Windows.Controls.Button)(target));
            
            #line 148 "..\..\MemberUserControl.xaml"
            this.btnUpdate.Click += new System.Windows.RoutedEventHandler(this.btnUpdate_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnDelete = ((System.Windows.Controls.Button)(target));
            
            #line 154 "..\..\MemberUserControl.xaml"
            this.btnDelete.Click += new System.Windows.RoutedEventHandler(this.btnDelete_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

