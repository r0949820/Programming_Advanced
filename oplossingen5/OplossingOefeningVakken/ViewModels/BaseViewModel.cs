﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace VakkenOefening.ViewModels
{
	public partial class BaseViewModel : ObservableObject
	{
		[ObservableProperty]
		string title;

		[ObservableProperty]
		[NotifyPropertyChangedFor(nameof(IsNotBusy))]
		bool isBusy;

		public bool IsNotBusy => !isBusy;
	}
}
