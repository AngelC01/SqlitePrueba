﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqlitePrueba.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaPage : ContentPage
    {
        public ConsultaPage()
        {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.Red;
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.OrangeRed;
        }
    }
}