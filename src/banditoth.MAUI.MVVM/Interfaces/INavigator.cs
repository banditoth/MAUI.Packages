using System;
using banditoth.MAUI.MVVM.Entities;
using Microsoft.Maui.Controls;

namespace banditoth.MAUI.MVVM.Interfaces
{
	public interface INavigator
	{
		Page GetInstance<TViewmodel>() where TViewmodel : BaseViewModel;

		Page GetInstance<TViewModel>(Action<TViewModel, Page> initialiser, bool initalizeOnDifferentThread = true) where TViewModel : BaseViewModel;

		Page GetInstance<TViewModel, TView>();

		Page GetInstance<TViewModel, TView>(Action<TViewModel, TView> initialiser, bool initalizeOnDifferentThread = true) where TViewModel : BaseViewModel where TView : Page;

	}
}

