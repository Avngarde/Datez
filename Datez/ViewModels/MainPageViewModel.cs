using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Datez.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty] private string _testText = "Test";
}
