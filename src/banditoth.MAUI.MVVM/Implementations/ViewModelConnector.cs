﻿using System;
using System.Collections.Generic;
using System.Linq;
using banditoth.MAUI.MVVM.Entities;
using banditoth.MAUI.MVVM.Interfaces;

namespace banditoth.MAUI.MVVM.Implementations
{
    internal class ViewModelConnectorService : IViewModelConnectionBuilder
    {
        private readonly Dictionary<Type, Type> _connections = new Dictionary<Type, Type>();

        public ViewModelConnectorService()
        {

        }

        public void Register(Type viewModelType, Type viewType)
        {
            if (viewType == null)
            {
                throw new Exception($"The {nameof(viewType)} could not be null!");
            }

            if (viewModelType == null)
            {
                throw new Exception($"The {nameof(viewModelType)} could not be null!");
            }

            if (viewModelType.IsSubclassOf(typeof(BaseViewModel)) == false)
            {
                throw new Exception($"The type ({viewModelType.Name}) is not deriving from {nameof(BaseViewModel)}");
            }

            if (viewType.IsSubclassOf(typeof(BaseView)) == false)
            {
                throw new Exception($"The type ({viewType.Name}) is not deriving from {nameof(BaseView)}");
            }

            if (IsContainsViewModel(viewModelType))
            {
                throw new Exception($"The type ({viewType.Name}) is already registered");
            }

            _connections.Add(viewModelType, viewType);
        }

        public void Remove(Type viewModelType)
        {
            if (viewModelType == null)
            {
                throw new Exception($"The {nameof(viewModelType)} could not be null!");
            }

            _connections.Remove(viewModelType);
        }

        public bool IsContainsViewModel(Type viewModelType)
        {
            return _connections.ContainsKey(viewModelType);
        }

        public Type GetViewType(Type viewModelType)
        {
            if (IsContainsViewModel(viewModelType) == false)
            {
                throw new Exception($"The type ({viewModelType.Name}) is not registered");
            }

            return _connections.SingleOrDefault(z=> z.Key == viewModelType).Value;
        }

        public KeyValuePair<Type, Type>[] GetRegisteredTypes()
        {
            return _connections.ToArray();
        }
    }
}

