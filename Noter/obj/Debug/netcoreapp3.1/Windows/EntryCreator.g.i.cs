﻿#pragma checksum "..\..\..\..\Windows\EntryCreator.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23589FEFD780B90A981D8EFEAD5C4312C1EC9504"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Noter.Models.Attachments;
using Noter.Windows;
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


namespace Noter.Windows {
    
    
    /// <summary>
    /// EntryCreator
    /// </summary>
    public partial class EntryCreator : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\..\Windows\EntryCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Noter.Windows.EntryCreator @this;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Windows\EntryCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox objName;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Windows\EntryCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label l1;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Windows\EntryCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chbCopy;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.17.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Noter;component/windows/entrycreator.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\EntryCreator.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.17.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.@this = ((Noter.Windows.EntryCreator)(target));
            return;
            case 2:
            this.objName = ((System.Windows.Controls.TextBox)(target));
            
            #line 23 "..\..\..\..\Windows\EntryCreator.xaml"
            this.objName.KeyDown += new System.Windows.Input.KeyEventHandler(this.objName_KeyDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.l1 = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.chbCopy = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            
            #line 35 "..\..\..\..\Windows\EntryCreator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Create_Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 36 "..\..\..\..\Windows\EntryCreator.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cancel_Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

