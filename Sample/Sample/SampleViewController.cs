using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using TSMessages;

namespace Sample
{
	public partial class SampleViewController : UIViewController
	{
		public SampleViewController () : base ("SampleViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.

			// It's recommended to set a default view controller to present the messages.
			TSMessage.DefaultViewController = this;

			showButton.TouchUpInside += (object sender, EventArgs e) => {

				// Show the TSMessage
				TSMessage.ShowNotification ("This is the sample message.", TSMessageNotificationType.Success);

			};
			                            
		}
	}
}

