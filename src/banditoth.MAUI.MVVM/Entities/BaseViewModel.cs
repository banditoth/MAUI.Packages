﻿using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;

namespace banditoth.MAUI.MVVM.Entities
{
	public partial class BaseViewModel : ObservableObject
	{
		public INavigation Navigation { get; private set; }

		public BaseViewModel()
		{

		}

		internal void SetNavigation(INavigation navigation)
        {
			Navigation = navigation;
        }

		public virtual void OnViewAppearing()
        {

        }

		public virtual void OnViewDisapearing()
        {

        }

		[RelayCommand]
		public virtual void OnBackButtonPressed()
        {

        }
	}
}

