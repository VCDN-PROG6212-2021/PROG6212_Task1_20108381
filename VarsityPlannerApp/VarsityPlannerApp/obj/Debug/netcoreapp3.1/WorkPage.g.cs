﻿#pragma checksum "..\..\..\WorkPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CF95CFF0143C4EE37A2B29DD04EC6D5CDF4C28F2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
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
using VarsityPlannerApp;


namespace VarsityPlannerApp {
    
    
    /// <summary>
    /// WorkPage
    /// </summary>
    public partial class WorkPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\WorkPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbModules;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\WorkPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbHours;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\WorkPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas cvHours;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\WorkPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePickerWorkDay;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\WorkPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\WorkPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbDetails;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\WorkPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbHoursDone;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\WorkPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbHoursLeft;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/VarsityPlannerApp;component/workpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WorkPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.cmbModules = ((System.Windows.Controls.ComboBox)(target));
            
            #line 23 "..\..\..\WorkPage.xaml"
            this.cmbModules.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbModules_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txbHours = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\..\WorkPage.xaml"
            this.txbHours.GotFocus += new System.Windows.RoutedEventHandler(this.txbHours_GotFocus);
            
            #line default
            #line hidden
            
            #line 32 "..\..\..\WorkPage.xaml"
            this.txbHours.LostFocus += new System.Windows.RoutedEventHandler(this.txbHours_LostFocus);
            
            #line default
            #line hidden
            
            #line 32 "..\..\..\WorkPage.xaml"
            this.txbHours.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txbHours_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cvHours = ((System.Windows.Controls.Canvas)(target));
            return;
            case 4:
            this.datePickerWorkDay = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.btnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\WorkPage.xaml"
            this.btnAdd.Click += new System.Windows.RoutedEventHandler(this.btnAdd_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txbDetails = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txbHoursDone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txbHoursLeft = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

