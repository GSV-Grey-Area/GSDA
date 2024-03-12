using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
	public class Point
	// "Point" class for the rendering engine: equivalent to a pixel with some properties.
	{
		// Two characters are used for the purpose of drawing a square: two dotted rectangles.
		char contentA = (char)9618; // Left character.
		char contentB = (char)9618; // Right character.
									// Both the character and the background have color, and it is possible to combine them.
									// Both characters have the same colors.
		int color1 = 1; // Background or main color.
		int color2 = 1; // Foreground or secondary color.
		bool render = false; // Determines whether a "pixel" is rendered or not. Initially, points are not visible.

		public Point() // I believe this to be a constructor. However, it is not used anywhere.
					   // The values are the same as the default, can any of the two functions be simplified?
		{
			contentA = (char)9618;
			contentB = (char)9618;
			color1 = 1;
			color2 = 1;
			render = false;
		}

		public Point(int n_color, int n_color2, bool n_render)
		// Creates points. Constructor?
		{
			color1 = n_color;
			color2 = n_color2;
			render = n_render;
		}

		public void Fill(int n_color, int n_color2, bool n_render)
		// This function is quite similar to the other, perhaps they could be fused.
		{
			color1 = n_color;
			color2 = n_color2;
			render = n_render;
		}

		public char GetContentA()
		// Outputs the left character.
		{
			return contentA;
		}

		public void SetContentA(char new_contentA)
		// Inputs the right character.
		{
			contentA = new_contentA;
		}

		public char GetContentB()
		// Outputs the right character.
		{
			return contentB;
		}

		public void SetContentB(char new_contentB)
		// Inputs the left character.
		{
			contentB = new_contentB;
		}

		public int GetColor()
		// Outputs the main or background color.
		{
			return color1;
		}

		public int GetColor2()
		// Outputs the secondary or foreground color.
		{
			return color2;
		}

		public void SetColor(int newColor)
		// Sets a point's new (background) color.
		{
			color1 = newColor;
		}

		public void SetRender(bool new_render)
		// Changes a point's visibility.
		{
			render = new_render;
		}

		public bool GetRender()
		// Reports the visibility of a point.
		{
			return render;
		}
	}
}
