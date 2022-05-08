using System;
using System.Collections.Generic;

namespace banditoth.MAUI.MVVM.Interfaces
{
	public interface IViewModelConnector
	{
        public void Register(Type viewModelType, Type viewType);

        public void Remove(Type viewModelType);

        public bool IsContainsViewModel(Type viewModelType);

        public Type GetViewType(Type viewModelType);

        public KeyValuePair<Type, Type>[] GetRegisteredTypes();
    }
}

