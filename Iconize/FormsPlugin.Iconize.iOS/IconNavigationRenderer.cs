﻿using System;
using FormsPlugin.Iconize;
using FormsPlugin.Iconize.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(IconNavigationPage), typeof(IconNavigationRenderer))]
namespace FormsPlugin.Iconize.iOS
{
    /// <summary>
    /// Defines the <see cref="IconNavigationRenderer" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.iOS.NavigationRenderer" />
    public class IconNavigationRenderer : NavigationRenderer
    {
        /// <summary>
        /// Views the did appear.
        /// </summary>
        /// <param name="animated">if set to <c>true</c> [animated].</param>
        public override void ViewDidAppear(Boolean animated)
        {
            base.ViewDidAppear(animated);

            OnUpdateToolbarItems(this);
            MessagingCenter.Subscribe<Object>(this, "Iconize.UpdateToolbarItems", OnUpdateToolbarItems);
        }

        /// <summary>
        /// Views the did disappear.
        /// </summary>
        /// <param name="animated">if set to <c>true</c> [animated].</param>
        public override void ViewDidDisappear(Boolean animated)
        {
            base.ViewDidDisappear(animated);

            MessagingCenter.Unsubscribe<Object>(this, "Iconize.UpdateToolbarItems");
        }

        /// <summary>
        /// Called when [update toolbar items].
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void OnUpdateToolbarItems(Object sender)
        {
            (Element as NavigationPage)?.UpdateToolbarItems(this);
        }
    }
}