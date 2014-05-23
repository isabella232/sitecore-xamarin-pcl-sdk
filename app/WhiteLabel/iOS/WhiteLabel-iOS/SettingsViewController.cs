﻿using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace WhiteLabeliOS
{
	public partial class SettingsViewController : UIViewController
	{
		private InstanceSettings instanceSettings;

		public SettingsViewController (IntPtr handle) : base (handle)
		{
			Title = NSBundle.MainBundle.LocalizedString ("Settings", "Settings");
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public InstanceSettings InstanceSettings { 
			get
			{
				return this.instanceSettings;
			} 
			set
			{ 
				this.instanceSettings = value;
			}
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear (animated);

			this.instanceUrlField.Text = this.instanceSettings.InstanceUrl;
			this.passwordField.Text = this.instanceSettings.InstancePassword;
			this.loginField.Text = this.instanceSettings.InstanceLogin;
			this.siteField.Text = this.instanceSettings.InstanceSite;
			this.dbField.Text = this.instanceSettings.InstanceDataBase;
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear (animated);

			InstanceSettings settings = this.instanceSettings;

			settings.InstanceUrl 		= this.instanceUrlField.Text;
			settings.InstancePassword 	= this.passwordField.Text;
			settings.InstanceLogin 		= this.loginField.Text;
			settings.InstanceSite 		= this.siteField.Text;
			settings.InstanceDataBase 	= this.dbField.Text;
		}
	}
}

