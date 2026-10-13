using System.Text;

namespace System.Windows.Forms.RTF;

internal static class CharsetToCodepage
{
	public static int Translate(CharsetType charset)
	{
		return charset switch
		{
			CharsetType.ANSI => 1252, 
			CharsetType.Symbol => 42, 
			CharsetType.Shift_Jis => 932, 
			CharsetType.Hangul => 949, 
			CharsetType.Johab => 1361, 
			CharsetType.GB2312 => 936, 
			CharsetType.Big5 => 950, 
			CharsetType.Greek => 1253, 
			CharsetType.Turkish => 1254, 
			CharsetType.Vietnamese => 1258, 
			CharsetType.Hebrew => 1255, 
			CharsetType.Arabic => 1256, 
			CharsetType.Baltic => 1257, 
			CharsetType.Russian => 1251, 
			CharsetType.Thai => 874, 
			CharsetType.Eastern_European => 1250, 
			CharsetType.PC_437 => 437, 
			CharsetType.OEM => 850, 
			_ => Encoding.Default.CodePage, 
		};
	}
}
