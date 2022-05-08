using System;
using banditoth.MAUI.MVVM.Entities;
using Microsoft.Maui.Controls;

namespace banditoth.MAUI.MVVM.Interfaces
{
	public interface INavigator
	{
		Page GetInstance<TViewmodel>(Action<TViewmodel, Page> initialiser = null, bool initalizeOnDifferentThread = true) where TViewmodel : BaseViewModel;
	}
}

