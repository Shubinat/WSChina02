﻿#pragma checksum "..\..\..\Pages\AboutWorldskillsPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6939908FD9BC5B96A528C0D29C93CAD6F45B2CC59C0C7FC1820FF8972248BFFA"
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
    /// AboutWorldskillsPage
    /// </summary>
    public partial class AboutWorldskillsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\Pages\AboutWorldskillsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnHistory;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Pages\AboutWorldskillsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnCompetention;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Pages\AboutWorldskillsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnPrevios;
        
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
            System.Uri resourceLocater = new System.Uri("/WSChina2020AppComp02;component/pages/aboutworldskillspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\AboutWorldskillsPage.xaml"
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
            this.BtnHistory = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\Pages\AboutWorldskillsPage.xaml"
            this.BtnHistory.Click += new System.Windows.RoutedEventHandler(this.BtnHistory_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BtnCompetention = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\Pages\AboutWorldskillsPage.xaml"
            this.BtnCompetention.Click += new System.Windows.RoutedEventHandler(this.BtnCompetention_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BtnPrevios = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\Pages\AboutWorldskillsPage.xaml"
            this.BtnPrevios.Click += new System.Windows.RoutedEventHandler(this.BtnPrevios_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

