using System;
using System.Collections.Generic;

namespace banditoth.MAUI.MVVM.Interfaces
{
	public interface IViewModelConnectionBuilder
	{
        void Register(Type viewModelType, Type viewType);

        void Remove(Type viewModelType);

        bool IsContainsViewModel(Type viewModelType);

        Type GetViewType(Type viewModelType);

        KeyValuePair<Type, Type>[] GetRegisteredTypes();
    }
}

