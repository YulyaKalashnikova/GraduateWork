﻿#pragma checksum "..\..\..\PassWindow\NewPassWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6509052E3884A98E7F7BFF9427EED75122BC6626C0F90F610BA1E06DFBCBCCE0"
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
using WpfApp1.PassWindow;


namespace WpfApp1.PassWindow {
    
    
    /// <summary>
    /// NewPassWindow
    /// </summary>
    public partial class NewPassWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 200 "..\..\..\PassWindow\NewPassWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtLogin;
        
        #line default
        #line hidden
        
        
        #line 201 "..\..\..\PassWindow\NewPassWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtConfirmationCode;
        
        #line default
        #line hidden
        
        
        #line 202 "..\..\..\PassWindow\NewPassWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCheckNewPass;
        
        #line default
        #line hidden
        
        
        #line 203 "..\..\..\PassWindow\NewPassWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtNewPassword;
        
        #line default
        #line hidden
        
        
        #line 204 "..\..\..\PassWindow\NewPassWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CheckPass;
        
        #line default
        #line hidden
        
        
        #line 205 "..\..\..\PassWindow\NewPassWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtRepeatNewPassword;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/passwindow/newpasswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PassWindow\NewPassWindow.xaml"
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
            
            #line 187 "..\..\..\PassWindow\NewPassWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Exit_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 188 "..\..\..\PassWindow\NewPassWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Minimize_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtLogin = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtConfirmationCode = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtCheckNewPass = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtNewPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 7:
            this.CheckPass = ((System.Windows.Controls.CheckBox)(target));
            
            #line 204 "..\..\..\PassWindow\NewPassWindow.xaml"
            this.CheckPass.Click += new System.Windows.RoutedEventHandler(this.CheckPassCB_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.txtRepeatNewPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 9:
            
            #line 208 "..\..\..\PassWindow\NewPassWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SendConfirmationCode_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 209 "..\..\..\PassWindow\NewPassWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GeneratePass_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 210 "..\..\..\PassWindow\NewPassWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveNewPass_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 211 "..\..\..\PassWindow\NewPassWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

