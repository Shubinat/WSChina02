﻿#pragma checksum "..\..\..\Pages\ImportVolunteers.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "97B2122C4AC0303DB796A6E337385EF0D296A42661E44B1A875F9EA3778737C8"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
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
using WSChina2020AppComp02.Pages;


namespace WSChina2020AppComp02.Pages {
    
    
    /// <summary>
    /// ImportVolunteers
    /// </summary>
    public partial class ImportVolunteers : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\Pages\ImportVolunteers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBFilePath;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Pages\ImportVolunteers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBrowse;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Pages\ImportVolunteers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnImport;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Pages\ImportVolunteers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnCancel;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Pages\ImportVolunteers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar ProgressBarImporting;
        
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
            System.Uri resourceLocater = new System.Uri("/WSChina2020AppComp02;component/pages/importvolunteers.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\ImportVolunteers.xaml"
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
            this.TBFilePath = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.BtnBrowse = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Pages\ImportVolunteers.xaml"
            this.BtnBrowse.Click += new System.Windows.RoutedEventHandler(this.BtnBrowse_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BtnImport = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\Pages\ImportVolunteers.xaml"
            this.BtnImport.Click += new System.Windows.RoutedEventHandler(this.BtnImport_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BtnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\Pages\ImportVolunteers.xaml"
            this.BtnCancel.Click += new System.Windows.RoutedEventHandler(this.BtnCancel_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ProgressBarImporting = ((System.Windows.Controls.ProgressBar)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

