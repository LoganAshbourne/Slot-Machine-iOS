using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SlotMachine
{
	public partial class SlotMachine : ContentPage
	{
		// Global variables
		int coins = 25;
		int coinsWon = 0;
		int multiplier = 1;

		public SlotMachine()
		{
			InitializeComponent();
		}

		// Spin button
	    async void SlotMachineSpin(object s, EventArgs e)
		{
			if (coins > 0)
			{
				// Play sound
				DependencyService.Get<IAudio>().PlayAudioFile("casino.mp3");
				await Task.Delay(250);

				// Cost of playing slot machine
				coins -= 1 * multiplier;

				// Random variables
				var rnd = new System.Random();
				var rnd1 = rnd.Next(1, 4);
				var rnd2 = rnd.Next(1, 4);
				var rnd3 = rnd.Next(1, 4);

				// Change one slot picture
				switch (rnd1)
				{
					case 1:
						slotImage1.Source = "numberOne.jpg";
						break;

					case 2:
						slotImage1.Source = "numberTwo.jpg";
						break;

					case 3:
						slotImage1.Source = "numberThree.jpg";
						break;
				}

				// Change second slot picture
				switch (rnd2)
				{
					case 1:
						slotImage2.Source = "numberOne.jpg";
						break;

					case 2:
						slotImage2.Source = "numberTwo.jpg";
						break;

					case 3:
						slotImage2.Source = "numberThree.jpg";
						break;
				}

				// Change third slot picture
				switch (rnd3)
				{
					case 1:
						slotImage3.Source = "numberOne.jpg";
						break;

					case 2:
						slotImage3.Source = "numberTwo.jpg";
						break;

					case 3:
						slotImage3.Source = "numberThree.jpg";
						break;
				}

				// 3/3 Matching
				// If they all match (1)
				if (rnd1 == 1 && rnd2 == 1 && rnd3 == 1)
				{
					coins += 10 * multiplier;
					coinsWon += 10 * multiplier;
				}
				// If they all match (2)
				else if (rnd1 == 2 && rnd2 == 2 && rnd3 == 2)
				{
					coins += 20 * multiplier;
					coinsWon += 20 * multiplier;
				}
				// If they all match (3)
				else if (rnd1 == 3 && rnd2 == 3 && rnd3 == 3)
				{
					coins += 30 * multiplier;
					coinsWon += 30 * multiplier;
				}

				// Display new coins
				coinsLabel.Text = "Coins: " + coins;
				coinsWonLabel.Text = "Coins Won: " + coinsWon;

				// Reset to 0
				coinsWon = 0;
			}
		}

		async void multiplier1Button(object s, EventArgs e)
		{
			await Task.Delay(5);

			multiplier = 1;
			borderWidth();
		}

		async void multiplier2Button(object s, EventArgs e)
		{
			await Task.Delay(5);

			multiplier = 2;
			borderWidth();
		}

		async void multiplier3Button(object s, EventArgs e)
		{
			await Task.Delay(5);

			multiplier = 3;
			borderWidth();
		}

		public void borderWidth()
		{
			switch (multiplier)
			{
				case 1:
					multiplier1.BorderWidth = 2;
					multiplier2.BorderWidth = 0;
					multiplier3.BorderWidth = 0;
					break;

				case 2:
					multiplier1.BorderWidth = 0;
					multiplier2.BorderWidth = 2;
					multiplier3.BorderWidth = 0;
					break;

				case 3:
					multiplier1.BorderWidth = 0;
					multiplier2.BorderWidth = 0;
					multiplier3.BorderWidth = 2;
					break;
			}
		}
	}
}