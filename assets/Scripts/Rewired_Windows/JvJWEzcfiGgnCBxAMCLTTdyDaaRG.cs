using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 4)]
internal struct JvJWEzcfiGgnCBxAMCLTTdyDaaRG
{
	private int tOyfwLKqRCTLxMRixdjgOAPcSGBT;

	private const int uzlLCuYxDuXALohdLbmMSggcnMYA = 65534;

	private const int BbevHmSkOdoSDVQInzhkKsZrGPYc = 16776960;

	public rWezaGflEYhSWijeLCQlsOUkWUZN dWzeuVuwVjDKXbvRMnpDtrvAUWxS => NIRMSGpfjJFEcGuJHZTAaNtlyQRKA();

	public int rPOccANjcrNcvDRDHHQhbBiRwSpX => EqAGnuxtwoKUzXHDQEprdVIGcNmc();

	public JvJWEzcfiGgnCBxAMCLTTdyDaaRG(rWezaGflEYhSWijeLCQlsOUkWUZN P_0, int P_1)
	{
		this = default;
		tOyfwLKqRCTLxMRixdjgOAPcSGBT = (int)(P_0 & ~rWezaGflEYhSWijeLCQlsOUkWUZN.AnyInstance) | ((!((P_1 < 0) | (P_1 > 65534))) ? ((P_1 & 0xFFFF) << 8) : 0);
	}

	public rWezaGflEYhSWijeLCQlsOUkWUZN NIRMSGpfjJFEcGuJHZTAaNtlyQRKA()
	{
		return (rWezaGflEYhSWijeLCQlsOUkWUZN)(tOyfwLKqRCTLxMRixdjgOAPcSGBT & -16776961);
	}

	public int EqAGnuxtwoKUzXHDQEprdVIGcNmc()
	{
		return (tOyfwLKqRCTLxMRixdjgOAPcSGBT >> 8) & 0xFFFF;
	}

	[SpecialName]
	public static int xGjndZkFBWMMDSMdWOYqPHYKLgEX(JvJWEzcfiGgnCBxAMCLTTdyDaaRG P_0)
	{
		return P_0.tOyfwLKqRCTLxMRixdjgOAPcSGBT;
	}

	public bool jQGlvodYwBibUCElXkjuUpQSXsZH(JvJWEzcfiGgnCBxAMCLTTdyDaaRG P_0)
	{
		return P_0.tOyfwLKqRCTLxMRixdjgOAPcSGBT == tOyfwLKqRCTLxMRixdjgOAPcSGBT;
	}

	public bool fPcDDvYEZKvKreQjTCdKCNVATEEX(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(JvJWEzcfiGgnCBxAMCLTTdyDaaRG))
		{
			return false;
		}
		return jQGlvodYwBibUCElXkjuUpQSXsZH((JvJWEzcfiGgnCBxAMCLTTdyDaaRG)P_0);
	}

	public int dBGCCiybtiAPowIGADUfbEkNKRkH()
	{
		return tOyfwLKqRCTLxMRixdjgOAPcSGBT;
	}

	public string bLrxvImZQnpEdphlHsnQZADWaypJ()
	{
		return string.Format(CultureInfo.InvariantCulture, "Flags: {0} InstanceNumber: {1} RawId: 0x{2:X8}", NIRMSGpfjJFEcGuJHZTAaNtlyQRKA(), EqAGnuxtwoKUzXHDQEprdVIGcNmc(), tOyfwLKqRCTLxMRixdjgOAPcSGBT);
	}
}
