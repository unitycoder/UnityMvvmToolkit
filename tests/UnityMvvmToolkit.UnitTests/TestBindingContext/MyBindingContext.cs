﻿using UnityMvvmToolkit.Core;
using UnityMvvmToolkit.Core.Interfaces;
using UnityMvvmToolkit.UnitTests.Interfaces;
using UnityMvvmToolkit.UnitTests.TestCommands;

namespace UnityMvvmToolkit.UnitTests.TestBindingContext;

public class MyBindingContext : IBindingContext
{
    private readonly IProperty<int> _count = new ObservableProperty<int>();
    private readonly IProperty<string> m_description = new ObservableProperty<string>();

    public MyBindingContext(string title = "Title")
    {
        Title = new ObservableProperty<string>(title);

        IncrementCommand = new Command(() => Count++);
        DecrementCommand = new MyCommand(() => Count--);

        SetValueCommand = new Command<int>(value => Count = value);
    }

    public IReadOnlyProperty<string> Title { get; }

    public int Count
    {
        get => _count.Value;
        set => _count.Value = value;
    }

    public string Description
    {
        get => m_description.Value;
        set => m_description.Value = value;
    }

    public ICommand IncrementCommand { get; }
    public IMyCommand DecrementCommand { get; }

    public ICommand<int> SetValueCommand { get; }
}