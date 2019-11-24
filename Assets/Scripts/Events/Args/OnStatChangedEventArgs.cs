using System;

public class OnStatChangedEventArgs : EventArgs
{
	public readonly int Current = 0;
	public readonly float CurrentAsPercentage = 0f;

	public OnStatChangedEventArgs(int current, float currentAsPercentage)
	{
		Current = current;
		CurrentAsPercentage = currentAsPercentage;
	}
}
