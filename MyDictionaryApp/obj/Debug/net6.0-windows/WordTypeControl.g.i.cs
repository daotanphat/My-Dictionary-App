// Updated by XamlIntelliSenseFileGenerator 10/25/2024 3:11:40 AM
#pragma checksum "..\..\..\WordTypeControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "48F5A909CC7C08383D45AE1764C35AB8A72CDA56"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MyDictionaryApp;
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


namespace MyDictionaryApp
{


	/// <summary>
	/// WordTypeControl
	/// </summary>
	public partial class WordTypeControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector
	{


#line 19 "..\..\..\WordTypeControl.xaml"
		[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal System.Windows.Controls.Button btnAddType;

#line default
#line hidden


#line 22 "..\..\..\WordTypeControl.xaml"
		[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal System.Windows.Controls.ListView lvWordType;

#line default
#line hidden

		private bool _contentLoaded;

		/// <summary>
		/// InitializeComponent
		/// </summary>
		[System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
		public void InitializeComponent()
		{
			if (_contentLoaded)
			{
				return;
			}
			_contentLoaded = true;
			System.Uri resourceLocater = new System.Uri("/MyDictionaryApp;component/wordtypecontrol.xaml", System.UriKind.Relative);

#line 1 "..\..\..\WordTypeControl.xaml"
			System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
		[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
		[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
				case 1:
					this.btnAddType = ((System.Windows.Controls.Button)(target));

#line 19 "..\..\..\WordTypeControl.xaml"
					this.btnAddType.Click += new System.Windows.RoutedEventHandler(this.btnAddType_Click);

#line default
#line hidden
					return;
				case 2:
					this.lvWordType = ((System.Windows.Controls.ListView)(target));

#line 22 "..\..\..\WordTypeControl.xaml"
					this.lvWordType.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.lvWordType_MouseDoubleClick);

#line default
#line hidden
					return;
			}
			this._contentLoaded = true;
		}

		internal System.Windows.Controls.Button btnDeleteType;
	}
}

