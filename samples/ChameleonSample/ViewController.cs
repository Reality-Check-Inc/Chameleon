using System;
using UIKit;

using ChameleonFramework;

namespace ChameleonSample
{
	partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle)
			: base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			NavigationController.HideNavigationBarHairline (true);

			var image = UIImage.FromBundle ("africa-blue.jpg");
			var colors = ChameleonColorArray.GetColors(image, true);
			var average = ChameleonColor.GetImageAverageColor (image);
			var complement = ChameleonColor.GetComplementaryColor(average);
			//View.BackgroundColor = average;
			var colorArray = new UIColor[] { colors[0], average, complement};
			var gradient = ChameleonColor.GetGradientColor(GradientStyle.Radial, View.Bounds, colorArray);
			View.BackgroundColor = gradient;
		}
	}
}
