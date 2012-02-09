//
// ElementBadge.cs: defines the Badge Element.
//
// Author:
//   Miguel de Icaza (miguel@gnome.org)
//
// Copyright 2010, Novell, Inc.
//
// Code licensed under the MIT X11 license
//
using System;
using System.Collections;
using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using System.Drawing;
using MonoTouch.Foundation;

namespace MWC.iOS.UI.CustomElements {
	/// <summary>
	/// Lifted this code from MT.D source, so it could be customized
	/// </summary>
	public class CustomBadgeElement {
		public CustomBadgeElement ()
		{
		}
		public static UIImage MakeCalendarBadge (UIImage template, string smallText, string bigText)
		{
			using (var cs = CGColorSpace.CreateDeviceRGB ()){
				using (var context = new CGBitmapContext (IntPtr.Zero, 59, 58, 8, 59*4, cs, CGImageAlphaInfo.PremultipliedLast)){
					//context.ScaleCTM (0.5f, -1);
					context.TranslateCTM (0, 0);
					context.DrawImage (new RectangleF (0, 0, 59, 58), template.CGImage);
					context.SetFillColor (0, 0, 0, 1);
					
					// The _small_ string
					context.SelectFont ("Helvetica-Bold", 14f, CGTextEncoding.MacRoman);
					
					// Pretty lame way of measuring strings, as documented:
					var start = context.TextPosition.X;					
					context.SetTextDrawingMode (CGTextDrawingMode.Invisible);
					context.ShowText (smallText);
					var width = context.TextPosition.X - start;
					
					context.SetTextDrawingMode (CGTextDrawingMode.Fill);
					context.ShowTextAtPoint ((59-width)/2, 10, smallText); // was 46
					
					// The BIG string
					context.SelectFont ("Helvetica-Bold", 32, CGTextEncoding.MacRoman);					
					start = context.TextPosition.X;
					context.SetTextDrawingMode (CGTextDrawingMode.Invisible);
					context.ShowText (bigText);
					width = context.TextPosition.X - start;
					
					context.SetFillColor (0, 0, 0, 1);
					context.SetTextDrawingMode (CGTextDrawingMode.Fill);
					context.ShowTextAtPoint ((59-width)/2, 25, bigText);	// was 9
					
					context.StrokePath ();
				
					return UIImage.FromImage (context.ToImage ());
				}
			}
		}
		public static UIImage MakeCalendarBadgeSmall (UIImage template, string smallText, string bigText)
		{
			using (var cs = CGColorSpace.CreateDeviceRGB ()){
				using (var context = new CGBitmapContext (IntPtr.Zero, 30, 29, 8, 30*4, cs, CGImageAlphaInfo.PremultipliedLast)){
					//context.ScaleCTM (0.5f, -1);
					context.TranslateCTM (0, 0);
					context.DrawImage (new RectangleF (0, 0, 30, 29), template.CGImage);
					context.SetFillColor (0, 0, 0, 1);
					
					// The _small_ string
					context.SelectFont ("Helvetica-Bold", 7f, CGTextEncoding.MacRoman);
					
					// Pretty lame way of measuring strings, as documented:
					var start = context.TextPosition.X;					
					context.SetTextDrawingMode (CGTextDrawingMode.Invisible);
					context.ShowText (smallText);
					var width = context.TextPosition.X - start;
					
					context.SetTextDrawingMode (CGTextDrawingMode.Fill);
					context.ShowTextAtPoint ((30-width)/2, 5, smallText); // was 46
					
					// The BIG string
					context.SelectFont ("Helvetica-Bold", 16f, CGTextEncoding.MacRoman);					
					start = context.TextPosition.X;
					context.SetTextDrawingMode (CGTextDrawingMode.Invisible);
					context.ShowText (bigText);
					width = context.TextPosition.X - start;
					
					context.SetFillColor (0, 0, 0, 1);
					context.SetTextDrawingMode (CGTextDrawingMode.Fill);
					context.ShowTextAtPoint ((30-width)/2, 12, bigText);	// was 9
					
					context.StrokePath ();
				
					return UIImage.FromImage (context.ToImage ());
				}
			}
		}
	}
}

