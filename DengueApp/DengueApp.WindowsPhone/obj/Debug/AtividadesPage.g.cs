﻿

#pragma checksum "C:\Users\Ariadne\Documents\PROJETO APP\ProjetoS2B\DengueApp\DengueApp.WindowsPhone\AtividadesPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "28F6898C36213843C1F524D3FE234A72"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DengueApp
{
    partial class AtividadesPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 15 "..\..\AtividadesPage.xaml"
                ((global::Windows.UI.Xaml.Controls.ListViewBase)(target)).ItemClick += this.LvAtividades_ItemClick;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 39 "..\..\AtividadesPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.LvAtividades_CheckBox_Changed;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


