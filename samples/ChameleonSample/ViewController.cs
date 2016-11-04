using System;
using UIKit;

using ChameleonFramework;
using CoreGraphics;
using AssetsLibrary;
using Foundation;
using System.Runtime.InteropServices;
using ObjCRuntime;

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

			var picture = UIImage.FromBundle ("africa-blue.jpg");
			var colors = ChameleonColorArray.GetColors(picture, false);
			var average = ChameleonColor.GetImageAverageColor (picture);
			var complement = ChameleonColor.GetComplementaryColor(average);
			//View.BackgroundColor = average;
			var colorArray = new UIColor[] { colors[0], average, complement};
			var gradient = ChameleonColor.GetGradientColor(GradientStyle.Radial, View.Bounds, colorArray);
			View.BackgroundColor = gradient;

			nfloat y = NavigationController.NavigationBar.Bounds.Height + UIApplication.SharedApplication.StatusBarFrame.Height + 4;
			nfloat size = 12;
			nfloat left = 4;
			// Show the colors in the image color scheme
			ShowColorArray(left, y, size, colorArray);

			// show colors from the color scheme methods
			var baseColor = colorArray[1];
			left += size + 4;
			// analogous color scheme based on the middle color
			ShowColorArray(left, y, size, ChameleonColorArray.GetColors(ColorScheme.Analogous, baseColor, true));
			left += size + 4;
			// complementary color scheme based on the middle color
			ShowColorArray(left, y, size, ChameleonColorArray.GetColors(ColorScheme.Complementary, baseColor, true));
			left += size + 4;
			// triadic color scheme based on the middle color
			ShowColorArray(left, y, size, ChameleonColorArray.GetColors(ColorScheme.Triadic, baseColor, true));

			// Let's create a snapshot to use as a splashscreen...
			string key = "SavedScreenShot";
			if (!NSUserDefaults.StandardUserDefaults.BoolForKey(key))
			{
				SaveLaunchScreen(View.Bounds.Width, View.Bounds.Height, colorArray);
				NSUserDefaults.StandardUserDefaults.SetBool(true, key);
			}
			else
			{
				Console.WriteLine("already saved screenshots to photos");
			}

		}

		void ShowColorArray(nfloat left, nfloat top, nfloat size, UIColor[] colorArray)
		{
			Console.WriteLine("{0} colors in scheme", colorArray.Length);
			nfloat y = top;
			for (int i = 0; i < colorArray.Length; i++)
			{
				UIView view = new UIView(new CGRect(left, y, size, size));
				view.BackgroundColor = colorArray[i];
				View.AddSubview(view);
				y += size + 4;
			}
		}

		// Get the luminance of a color
		nfloat GetLuminance(UIColor color)
		{
			nfloat luminance = 0;
			nfloat r, g, b, a;
			color.GetRGBA(out r, out g, out b, out a);
			if (a != 0)
			{
				// Relative luminance in colorimetric spaces
				// http://en.wikipedia.org/wiki/Luminance_(relative)
				r *= 0.2126f; g *= 0.7152f; b *= 0.0722f;
				luminance = r + g + b;
			}
			return luminance;
		}

		// Useful for changing the color from GetContrastingBlackOrWhiteColor
		UIColor ChangeByPercentage(UIColor color, nfloat percentage)
		{
			nfloat luminance = GetLuminance(color);
			nfloat h, s, b, a;
			color.GetHSBA(out h, out s, out b, out a);
			if (luminance > 0.6f)
			{
				// we are going to darken
				if (percentage > 0)
				{
					nfloat v = b - percentage;
					b = (v < 1.0f) ? v : 1.0f;
				}
			}
			else
			{
				// we are going to lighten
				if (percentage > 0)
				{
					nfloat v = b + percentage;
					b = (v < 1.0f) ? v : 1.0f;
				}
			}
			return UIColor.FromHSBA(h, s, b, a);
		}

		// Save an image to the photo album
		void SaveLaunchScreen(nfloat width, nfloat height, UIColor[] colorArray)
		{
			var gradient = ChameleonColor.GetGradientColor(GradientStyle.Radial, View.Bounds, colorArray);
			CGRect rect = new CGRect(0, 0, width, height);
			UIView view = new UIView(rect);
			view.BackgroundColor = gradient;

			UIGraphics.BeginImageContext(new CGSize(width, height));
			var context = UIGraphics.GetCurrentContext();
			view.Layer.RenderInContext(context);
			UIImage photo = UIGraphics.GetImageFromCurrentImageContext();
			UIGraphics.EndImageContext();

			photo.SaveToPhotosAlbum((image, error) =>
			{
				if (error != null)
				{
					Console.WriteLine("error:" + error);
				}
				else {
					Console.WriteLine("wrote {0}x{1} to photos", width, height);
				}
			});
		}

	}

}
