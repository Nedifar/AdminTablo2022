﻿#pragma checksum "..\..\..\..\Pages\ScreenSaverSettingsPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A5D15594305BCD9DEB025D833E13ACC3A181A643"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AdminTabloNetCore.Pages;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace AdminTabloNetCore.Pages {
    
    
    /// <summary>
    /// ScreenSaverSettingsPage
    /// </summary>
    public partial class ScreenSaverSettingsPage : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\Pages\ScreenSaverSettingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gr;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Pages\ScreenSaverSettingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbBackgroundType;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Pages\ScreenSaverSettingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpBack;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Pages\ScreenSaverSettingsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement meBackPlayer;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AdminTabloNetCore;component/pages/screensaversettingspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\ScreenSaverSettingsPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\..\Pages\ScreenSaverSettingsPage.xaml"
            ((AdminTabloNetCore.Pages.ScreenSaverSettingsPage)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.ScreenSizeChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.gr = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.cbBackgroundType = ((System.Windows.Controls.ComboBox)(target));
            
            #line 15 "..\..\..\..\Pages\ScreenSaverSettingsPage.xaml"
            this.cbBackgroundType.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TypeChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dpBack = ((System.Windows.Controls.DatePicker)(target));
            
            #line 16 "..\..\..\..\Pages\ScreenSaverSettingsPage.xaml"
            this.dpBack.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.CurrentDateChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.meBackPlayer = ((System.Windows.Controls.MediaElement)(target));
            
            #line 18 "..\..\..\..\Pages\ScreenSaverSettingsPage.xaml"
            this.meBackPlayer.MediaEnded += new System.Windows.RoutedEventHandler(this.MediaEnded);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 22 "..\..\..\..\Pages\ScreenSaverSettingsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ClSelectMediaFile);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

