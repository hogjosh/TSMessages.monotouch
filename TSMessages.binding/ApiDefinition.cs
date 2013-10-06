using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TSMessages
{
	public delegate void BlockCallback();

	[Category, BaseType (typeof (UIColor))]
	public partial interface HexColorAddition_UIColor {

		[Static, Export ("colorWithHexString:")]
		UIColor Color (string hexString);

		[Static, Export ("colorWithHexString:alpha:")]
		UIColor Color (string hexString, float alpha);

		[Static, Export ("colorWith8BitRed:green:blue:")]
		UIColor Color (int red, int green, int blue);

		[Static, Export ("colorWith8BitRed:green:blue:alpha:")]
		UIColor Color (int red, int green, int blue, float alpha);
	}

	[BaseType (typeof (UIView))]
	public partial interface TSBlurView {

		[Export ("blurTintColor", ArgumentSemantic.Retain)]
		UIColor BlurTintColor { get; set; }
	}

	[BaseType (typeof (NSObject))]
	public partial interface TSMessage {

		[Static, Export ("sharedMessage")]
		TSMessage SharedMessage { get; }

		[Static, Export ("showNotificationWithTitle:type:")]
		void ShowNotification (string message, TSMessageNotificationType type);

		[Static, Export ("showNotificationWithTitle:subtitle:type:")]
		void ShowNotification (string title, string subtitle, TSMessageNotificationType type);

		[Static, Export ("showNotificationInViewController:title:subtitle:type:")]
		void ShowNotification (UIViewController viewController, string title, string subtitle, TSMessageNotificationType type);

		[Static, Export ("showNotificationInViewController:title:subtitle:image:type:duration:callback:buttonTitle:buttonCallback:atPosition:canBeDismissedByUser:")]
		void ShowNotification (UIViewController viewController, 
							   string title, 
							   string subtitle, 
							   UIImage image, 
							   TSMessageNotificationType type, 
							   double duration, 
							   [BlockCallback] BlockCallback callback, 
							   string buttonTitle, 
							   [BlockCallback] BlockCallback buttonCallback, 
							   TSMessageNotificationPosition messagePosition, 
							   bool dismissingEnabled);

		[Static, Export ("dismissActiveNotification")]
		bool DismissActiveNotification ();

		[Static, Export ("defaultViewController")]
		UIViewController DefaultViewController { get; set; }

		[Static, Export ("addCustomDesignFromFileWithName:")]
		void AddCustomDesignFromFile (string fileName);

		[Static, Export ("isNotificationActive")]
		bool IsNotificationActive { get; }

		[Static, Export ("prepareNotificationToBeShown:")]
		void PrepareNotificationToBeShown (TSMessageView messageView);

		[Static, Export ("iOS7StyleEnabled")]
		bool IOS7StyleEnabled { get; }
	}

	[Model, BaseType (typeof (NSObject))]
	public partial interface TSMessageViewProtocol {

		[Export ("navigationbarBottomOfViewController:")]
		float NavigationbarBottomOfViewController (UIViewController viewController);
	}

	[BaseType (typeof (UIView))]
	public partial interface TSMessageView {

		[Export ("title")]
		string Title { get; }

		[Export ("subtitle")]
		string Subtitle { get; }

		[Export ("viewController")]
		UIViewController ViewController { get; }

		[Export ("duration")]
		float Duration { get; set; }

		[Export ("messagePosition")]
		TSMessageNotificationPosition MessagePosition { get; set; }

		[Export ("messageIsFullyDisplayed")]
		bool MessageIsFullyDisplayed { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		TSMessageViewProtocol Delegate { get; set; }

		[Export ("initWithTitle:subtitle:image:type:duration:inViewController:callback:buttonTitle:buttonCallback:atPosition:shouldBeDismissed:")]
		IntPtr Constructor (string title, 
							string subtitle, 
							UIImage image, 
							TSMessageNotificationType notificationType, 
							float duration, 
							UIViewController viewController, 
							[BlockCallback] BlockCallback callback, 
							string buttonTitle, 
							[BlockCallback] BlockCallback buttonCallback, 
							TSMessageNotificationPosition position, 
							bool dismissAble);

		[Export ("fadeMeOut")]
		void FadeMeOut ();

		[Static, Export ("addNotificationDesignFromFile:")]
		void AddNotificationDesignFromFile (string file);
	}
}

