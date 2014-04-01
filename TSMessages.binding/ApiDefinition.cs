using System;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TSMessages
{	
	public delegate void BlockCallback();

	[BaseType (typeof (UIView))]
	public partial interface TSBlurView {

		[Export ("blurTintColor", ArgumentSemantic.Retain)]
		UIColor BlurTintColor { get; set; }
	}

	[BaseType (typeof (NSObject))]
	public partial interface TSMessage {

		[Static, Export ("sharedMessage")]
		TSMessage SharedMessage { get; }

		[Static, Export ("defaultViewController")]
		UIViewController DefaultViewController { get; set; }

		[Static, Export ("showNotificationWithTitle:type:")]
		void ShowNotification (
			[NullAllowed] string message, 
			TSMessageNotificationType type);

		[Static, Export ("showNotificationWithTitle:subtitle:type:")]
		void ShowNotification (
			[NullAllowed] string title, 
			[NullAllowed] string subtitle, 
			TSMessageNotificationType type);

		[Static, Export ("showNotificationInViewController:title:subtitle:type:")]
		void ShowNotification (
			UIViewController viewController, 
			[NullAllowed] string title, 
			[NullAllowed] string subtitle, 
			TSMessageNotificationType type);

		[Static, Export ("showNotificationInViewController:title:subtitle:type:duration:")]
		void ShowNotification (
			UIViewController viewController, 
			[NullAllowed] string title, 
			[NullAllowed] string subtitle, 
			TSMessageNotificationType type, 
			double duration = 1.5f);

		[Static, Export ("showNotificationInViewController:title:subtitle:type:duration:canBeDismissedByUser:")]
		void ShowNotification (
			UIViewController viewController, 
			[NullAllowed] string title, 
			[NullAllowed] string subtitle, 
			TSMessageNotificationType type, 
			double duration = 1.5f, 
			bool dismissingEnabled = true);

		[Static, Export ("showNotificationInViewController:title:subtitle:image:type:duration:callback:buttonTitle:buttonCallback:atPosition:canBeDismissedByUser:")]
		void ShowNotification (
			UIViewController viewController, 
			[NullAllowed] string title, 
			[NullAllowed] string subtitle, 
			[NullAllowed] UIImage image, 
			TSMessageNotificationType type, 
			double duration, 
			[NullAllowed] [BlockCallback] BlockCallback callback, 
			[NullAllowed] string buttonTitle, 
			[NullAllowed] [BlockCallback] BlockCallback buttonCallback, 
			TSMessageNotificationPosition messagePosition, 
			bool dismissingEnabled = true);

		[Static, Export ("dismissActiveNotification")]
		bool DismissActiveNotification ();

		[Static, Export ("addCustomDesignFromFileWithName:")]
		void AddCustomDesignFromFile (string fileName);

		[Static, Export ("isNotificationActive")]
		bool IsNotificationActive { get; }

		[Static, Export ("prepareNotificationToBeShown:")]
		void PrepareNotificationToBeShown (TSMessageView messageView);

		[Static, Export ("iOS7StyleEnabled")]
		bool IOS7StyleEnabled { get; }

		[Static, Export ("isNavigationBarInNavigationControllerHidden:")]
		bool IsNavigationBarInNavigationControllerHidden (UINavigationController navController);
	}

	[BaseType (typeof (NSObject))]
	[Model, Protocol]
	public partial interface TSMessageViewProtocol {

		[Export ("navigationbarBottomOfViewController:")]
		float NavigationbarBottomOfViewController (UIViewController viewController);
	}

	public interface ITSMessageViewProtocol {}

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
		ITSMessageViewProtocol Delegate { get; set; }

		[Export ("initWithTitle:subtitle:image:type:duration:inViewController:callback:buttonTitle:buttonCallback:atPosition:canBeDismissedByUser:")]
		IntPtr Constructor (
			[NullAllowed] string title, 
			[NullAllowed] string subtitle, 
			[NullAllowed] UIImage image, 
			TSMessageNotificationType notificationType, 
			float duration, 
			UIViewController viewController, 
			[NullAllowed] [BlockCallback] BlockCallback callback, 
			[NullAllowed] string buttonTitle, 
			[NullAllowed] [BlockCallback] BlockCallback buttonCallback, 
			TSMessageNotificationPosition position, 
			bool dismissingEnabled = true);

		[Export ("fadeMeOut")]
		void FadeMeOut ();

		[Static, Export ("addNotificationDesignFromFile:")]
		void AddNotificationDesignFromFile (string file);
	}
}

