/*
 * 由SharpDevelop创建。
 * 用户： admin
 * 日期: 2019/4/11
 * 时间: 18:26
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.IO;

namespace ShowAllSRC
{
	class Program
	{
		/// <summary>
		/// 指定扩展名
		/// </summary>
		public static string SRC_EXT = "java";
		/// <summary>
		/// 指定导出的文本文件
		/// </summary>
		public static string SRC_FILE = @"d:\src.txt";

		/// <summary>
		/// 判断文件名是否符合扩展名
		/// </summary>
		/// <param name="path"></param>
		/// <param name="ext"></param>
		/// <returns></returns>
		public static bool isExtFile(string path, string ext) {
			int index = path.LastIndexOf(".");
			string pext = "";
			if (index >= 0) {
				pext = path.Substring(index + 1);
			}
			return pext.Equals(ext);
		}
		
		/// <summary>
		/// 写入指定信息
		/// </summary>
		/// <param name="path">文件夹路径</param>
		/// <param name="ext">扩展名</param>
		public static void writeAllSrcTxt(string path) {
			string[] phs = Directory.GetDirectories(path);
			string[] fls = Directory.GetFiles(path);
			foreach (string fi in fls) {
				if (isExtFile(fi, SRC_EXT)) {
					File.AppendAllText(SRC_FILE, "\n" + fi + "\n");
					File.AppendAllText(SRC_FILE, File.ReadAllText(fi));
				}
			}
			foreach (string di in phs) {
				writeAllSrcTxt(di);
			}
		}

		
		public static void Main(string[] args)
		{
			Console.WriteLine("读取当前目录信息，请稍候。。。");
			string path = ".";
			if (args.Length < 3) {
				Console.WriteLine("参数不全，将采用默认方式。");
			} else {
				path = args[0];
				SRC_EXT = args[1];
				SRC_FILE = args[2];
			}
			Console.WriteLine("收集目录：" + path + "\n扩展名：" + SRC_EXT + "\n输出目标文件：" + SRC_FILE);
			Console.WriteLine("请等待 . . . ");
			writeAllSrcTxt(path);
			Console.Write("已完成，任意键退出...");
			Console.ReadKey(true);
		}
	}
}