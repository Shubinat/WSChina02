﻿#pragma checksum "..\..\..\Pages\SponsorshipManagementPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F1B58575653DBB166F427074F364B8F26BE4E3C2419D442C97FD467692C272FA"
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
    /// SponsorshipManagementPage
    /// </summary>
    public partial class SponsorshipManagementPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\Pages\SponsorshipManagementPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TBHello;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Pages\SponsorshipManagementPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSponsorStat;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Pages\SponsorshipManagementPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSponsorView;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Pages\SponsorshipManagementPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSponsorChart;
        
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
            System.Uri resourceLocater = new System.Uri("/WSChina2020AppComp02;component/pages/sponsorshipmanagementpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\SponsorshipManagementPage.xaml"
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
            this.TBHello = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.BtnSponsorStat = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\Pages\SponsorshipManagementPage.xaml"
            this.BtnSponsorStat.Click += new System.Windows.RoutedEventHandler(this.BtnSponsorStat_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BtnSponsorView = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Pages\SponsorshipManagementPage.xaml"
            this.BtnSponsorView.Click += new System.Windows.RoutedEventHandler(this.BtnSponsorView_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BtnSponsorChart = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\Pages\SponsorshipManagementPage.xaml"
            this.BtnSponsorChart.Click += new System.Windows.RoutedEventHandler(this.BtnSponsorChart_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

