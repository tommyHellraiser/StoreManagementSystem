using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomButton
{
	public class HellButton : Button
	{
		/// Properties
		public int borderSize = 4;
		public int borderRadius = 40;
		public Color borderColor = Color.MediumBlue;

		//	Getters and setters for properties
		[Category("Custom Properties")]
		public int BorderSize
		{
			get
			{
				return borderSize;
			}
			set
			{
				borderSize = value;
				this.Invalidate();
			}
		}
		[Category("Custom Properties")]
		public int BorderRadius
		{
			get
			{
				return borderRadius;
			}
			set
			{
				borderRadius = value;
				this.Invalidate();
			}
		}
		[Category("Custom Properties")]
		public Color BorderColor
		{
			get
			{
				return borderColor;
			}
			set
			{
				borderColor = value;
				this.Invalidate();
			}
		}
		[Category("Custom Properties")]
		public Color BackgroundColor
		{
			get
			{
				return this.BackColor;
			}
			set
			{
				this.BackColor = value;
			}
		}
		[Category("Custom Properties")]
		public Color TextColor
		{
			get
			{
				return this.ForeColor;
			}
			set
			{
				this.ForeColor = value;
			}
		}

		/// Constructor
		public HellButton()
		{
			this.FlatStyle = FlatStyle.Flat;
			this.FlatAppearance.BorderSize = 0;
			this.Size = new Size(150, 40);
			this.BackColor = Color.RoyalBlue;
			this.ForeColor = Color.WhiteSmoke;
		}

		///	Methods
		private GraphicsPath GetFigurePath(RectangleF rect, float radius)
		{
			GraphicsPath path = new GraphicsPath();
			path.StartFigure();

			path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
			path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
			path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
			path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);

			path.CloseFigure();

			return path;
		}

		protected override void OnPaint(PaintEventArgs ev)
		{
			base.OnPaint(ev);
			ev.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

			RectangleF rSurface = new(0, 0, this.Width, this.Height);
			//	TODO try changing these
			RectangleF rBorder = new(1, 1, this.Width - 0.8F, this.Height - 1F);

			if (this.borderRadius > 2)  //	If > 2 -> rounded button
			{
				using (Pen penSurface = new(this.Parent.BackColor, 2))
				using (Pen penBorder = new(this.borderColor, borderSize))
				using (GraphicsPath pathSurface = GetFigurePath(rSurface, this.borderRadius))
				//	Try with another value for the border down here
				using (GraphicsPath pathBorder = GetFigurePath(rBorder, this.borderRadius - 1F))
				{
					penBorder.Alignment = PenAlignment.Inset;
					this.Region = new(pathSurface);

					//	Draw button
					ev.Graphics.DrawPath(penSurface, pathSurface);

					//	Draw border when it's bigger than 1
					if (this.borderSize > 1)
					{
						ev.Graphics.DrawPath(penBorder, pathBorder);
					}
				}
			}
			else    //	Else, square button
			{
				this.Region = new(rSurface);

				if (borderSize > 1)
				{
					using (Pen penBorder = new(this.borderColor, this.borderSize))
					{
						penBorder.Alignment = PenAlignment.Inset;
						ev.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
					}
				}
			}
		}

		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
		}

		private void Container_BackColorChanged(object sender, EventArgs e)
		{
			if (this.DesignMode)
			{
				this.Invalidate();
			}
		}
	}
}
