﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AD7EB8C402E6CADBE968D39A7315F74124E13348E4BB19B8A53BB42CBDCD809E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Windows.Themes;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
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
using WpfApp1;


namespace WpfApp1 {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 354 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.DataVisualization.Charting.Chart ChartTreatmentResult;
        
        #line default
        #line hidden
        
        
        #line 361 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CmBChartTypes1;
        
        #line default
        #line hidden
        
        
        #line 373 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.DataVisualization.Charting.Chart ChartCountPatientsAtTheDoctor;
        
        #line default
        #line hidden
        
        
        #line 381 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CmBDoctor;
        
        #line default
        #line hidden
        
        
        #line 382 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CmBChartTypes2;
        
        #line default
        #line hidden
        
        
        #line 393 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.Integration.WindowsFormsHost AllChart;
        
        #line default
        #line hidden
        
        
        #line 394 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.DataVisualization.Charting.Chart ChartCountDeadPatients;
        
        #line default
        #line hidden
        
        
        #line 402 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CmBChartTypes3;
        
        #line default
        #line hidden
        
        
        #line 419 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.DataVisualization.Charting.Chart ChartCountPatientsInDepartments;
        
        #line default
        #line hidden
        
        
        #line 427 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CmBDepartments;
        
        #line default
        #line hidden
        
        
        #line 428 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CmBChartTypes4;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            this.ChartTreatmentResult = ((System.Windows.Forms.DataVisualization.Charting.Chart)(target));
            return;
            case 2:
            this.CmBChartTypes1 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 361 "..\..\MainWindow.xaml"
            this.CmBChartTypes1.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.UpdateChartTreatmentResult);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 362 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Logout_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ChartCountPatientsAtTheDoctor = ((System.Windows.Forms.DataVisualization.Charting.Chart)(target));
            return;
            case 5:
            this.CmBDoctor = ((System.Windows.Controls.ComboBox)(target));
            
            #line 381 "..\..\MainWindow.xaml"
            this.CmBDoctor.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.UpdateChartCountPatientsAtTheDoctor);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CmBChartTypes2 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 382 "..\..\MainWindow.xaml"
            this.CmBChartTypes2.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.UpdateChartCountPatientsAtTheDoctor);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 383 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Logout_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.AllChart = ((System.Windows.Forms.Integration.WindowsFormsHost)(target));
            return;
            case 9:
            this.ChartCountDeadPatients = ((System.Windows.Forms.DataVisualization.Charting.Chart)(target));
            return;
            case 10:
            this.CmBChartTypes3 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 402 "..\..\MainWindow.xaml"
            this.CmBChartTypes3.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.UpdateChartCountDeadPatients);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 403 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Logout_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.ChartCountPatientsInDepartments = ((System.Windows.Forms.DataVisualization.Charting.Chart)(target));
            return;
            case 13:
            this.CmBDepartments = ((System.Windows.Controls.ComboBox)(target));
            
            #line 427 "..\..\MainWindow.xaml"
            this.CmBDepartments.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.UpdateChartCountPatientsInDepartments);
            
            #line default
            #line hidden
            return;
            case 14:
            this.CmBChartTypes4 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 428 "..\..\MainWindow.xaml"
            this.CmBChartTypes4.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.UpdateChartCountPatientsInDepartments);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 429 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Logout_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

