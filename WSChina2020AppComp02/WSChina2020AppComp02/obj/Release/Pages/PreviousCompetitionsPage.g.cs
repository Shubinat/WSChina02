﻿#pragma checksum "..\..\..\Pages\PreviousCompetitionsPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5C3DF83FC6FD1F414690657922C5B1132DF516BEF3E1ACCB55DD6E5F378B35B3"
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
    /// PreviosCompetitionsPage
    /// </summary>
    public partial class PreviosCompetitionsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\Pages\PreviousCompetitionsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtBoxOrdinal;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Pages\PreviousCompetitionsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtBoxCity;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Pages\PreviousCompetitionsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SearchBtn;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Pages\PreviousCompetitionsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TBTotalRec;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Pages\PreviousCompetitionsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid CompetitionsGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/WSChina2020AppComp02;component/pages/previouscompetitionspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\PreviousCompetitionsPage.xaml"
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
            this.TxtBoxOrdinal = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TxtBoxCity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.SearchBtn = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\Pages\PreviousCompetitionsPage.xaml"
            this.SearchBtn.Click += new System.Windows.RoutedEventHandler(this.SearchBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TBTotalRec = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.CompetitionsGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

