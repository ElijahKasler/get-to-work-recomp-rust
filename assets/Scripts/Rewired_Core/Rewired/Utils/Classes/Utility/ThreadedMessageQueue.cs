using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
internal class ThreadedMessageQueue<T> : IDisposable
{
	private readonly int fcJzYyFBoAbLkteniNPZzzmzqDPX;

	private readonly int dESytEbGOvpqbKseRTYaXgQySMLl;

	private readonly int LtAewykugfuyAEMMFNTzErUmFuWC;

	private readonly bool zJQDrCvzJdJTxPTrWbKwPioJllNn;

	private ThreadHelper dpsHIrvJiQldvTGNUiPqofIMBFJV;

	private Queue<T> rEudGBzOebGDtjwIgGIyhgIYJihaA;

	private Queue<T> vsERDLkIIgJgNKycDvVqUnAvtzMJ;

	private bool xKeEiSGlUnwVoismWVZRsrMBWBZO;

	private bool jutfvVjtiTDshQuSWURgDThkquYp;

	private Action<T> CCIvLdCawKTMZFWgNKSkBFuKrdUO;

	private bool JffXnNxIZZMtgnHYUwWTZSnoJlEe;

	public ThreadedMessageQueue(int P_0, int P_1, int P_2, bool P_3, Action<T> P_4)
	{
		if (P_4 == null)
		{
			throw new ArgumentNullException("messageReceiverDelegate");
		}
		if (P_0 < 0)
		{
			P_0 = 0;
		}
		if (P_1 < 0)
		{
			P_1 = 0;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		fcJzYyFBoAbLkteniNPZzzmzqDPX = P_0;
		dESytEbGOvpqbKseRTYaXgQySMLl = P_1;
		LtAewykugfuyAEMMFNTzErUmFuWC = P_2;
		zJQDrCvzJdJTxPTrWbKwPioJllNn = P_3;
		CCIvLdCawKTMZFWgNKSkBFuKrdUO = P_4;
		rEudGBzOebGDtjwIgGIyhgIYJihaA = new Queue<T>(P_0);
		vsERDLkIIgJgNKycDvVqUnAvtzMJ = new Queue<T>(P_0);
	}

	public void Enqueue(T message)
	{
		if (!GVEesrohyyhrsJiItdUgwKZbpUWn())
		{
			return;
		}
		lock (rEudGBzOebGDtjwIgGIyhgIYJihaA)
		{
			if (fcJzYyFBoAbLkteniNPZzzmzqDPX > 0)
			{
				while (rEudGBzOebGDtjwIgGIyhgIYJihaA.Count >= fcJzYyFBoAbLkteniNPZzzmzqDPX)
				{
					rEudGBzOebGDtjwIgGIyhgIYJihaA.Dequeue();
				}
			}
			rEudGBzOebGDtjwIgGIyhgIYJihaA.Enqueue(message);
		}
	}

	private bool GVEesrohyyhrsJiItdUgwKZbpUWn()
	{
		if (xKeEiSGlUnwVoismWVZRsrMBWBZO)
		{
			return false;
		}
		if (!aXmLlEdtpoERNPzjtaiNTVzzaejj())
		{
			return false;
		}
		if (jutfvVjtiTDshQuSWURgDThkquYp)
		{
			return true;
		}
		jutfvVjtiTDshQuSWURgDThkquYp = true;
		return true;
	}

	private bool aXmLlEdtpoERNPzjtaiNTVzzaejj()
	{
		if (xKeEiSGlUnwVoismWVZRsrMBWBZO)
		{
			return false;
		}
		if (dpsHIrvJiQldvTGNUiPqofIMBFJV == null)
		{
			try
			{
				dpsHIrvJiQldvTGNUiPqofIMBFJV = ThreadHelper.CreateFixedTimeStep(dESytEbGOvpqbKseRTYaXgQySMLl, LtAewykugfuyAEMMFNTzErUmFuWC);
				dpsHIrvJiQldvTGNUiPqofIMBFJV.ThreadUpdateEvent += eGNXGtBbYKBaUOQZllhpxChtNMQf;
				dpsHIrvJiQldvTGNUiPqofIMBFJV.Start(zJQDrCvzJdJTxPTrWbKwPioJllNn);
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Exception occurred while creating thread!\n" + ex, requiredThreadSafety: true);
				if (dpsHIrvJiQldvTGNUiPqofIMBFJV != null)
				{
					dpsHIrvJiQldvTGNUiPqofIMBFJV.Stop(zJQDrCvzJdJTxPTrWbKwPioJllNn);
				}
				xKeEiSGlUnwVoismWVZRsrMBWBZO = true;
				return false;
			}
		}
		if (!dpsHIrvJiQldvTGNUiPqofIMBFJV.isRunning)
		{
			dpsHIrvJiQldvTGNUiPqofIMBFJV.Start(zJQDrCvzJdJTxPTrWbKwPioJllNn);
		}
		else if (LtAewykugfuyAEMMFNTzErUmFuWC > 0)
		{
			dpsHIrvJiQldvTGNUiPqofIMBFJV.ResetTimeout();
		}
		return true;
	}

	private void cORjbmXpHwPskQxfBbGBuFOCcSku()
	{
		lock (rEudGBzOebGDtjwIgGIyhgIYJihaA)
		{
			lock (vsERDLkIIgJgNKycDvVqUnAvtzMJ)
			{
				MiscTools.Swap(ref rEudGBzOebGDtjwIgGIyhgIYJihaA, ref vsERDLkIIgJgNKycDvVqUnAvtzMJ);
			}
		}
	}

	private void eGNXGtBbYKBaUOQZllhpxChtNMQf()
	{
		cORjbmXpHwPskQxfBbGBuFOCcSku();
		lock (vsERDLkIIgJgNKycDvVqUnAvtzMJ)
		{
			while (vsERDLkIIgJgNKycDvVqUnAvtzMJ.Count > 0)
			{
				try
				{
					CCIvLdCawKTMZFWgNKSkBFuKrdUO(vsERDLkIIgJgNKycDvVqUnAvtzMJ.Dequeue());
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred while sending message.\nMessage: " + ex.Message, requiredThreadSafety: true);
				}
			}
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	~ThreadedMessageQueue()
	{
		Dispose(disposing: false);
	}

	protected void Dispose(bool disposing)
	{
		if (JffXnNxIZZMtgnHYUwWTZSnoJlEe)
		{
			return;
		}
		if (disposing)
		{
			if (rEudGBzOebGDtjwIgGIyhgIYJihaA != null)
			{
				if (vsERDLkIIgJgNKycDvVqUnAvtzMJ != null)
				{
					lock (rEudGBzOebGDtjwIgGIyhgIYJihaA)
					{
						lock (vsERDLkIIgJgNKycDvVqUnAvtzMJ)
						{
							rEudGBzOebGDtjwIgGIyhgIYJihaA.Clear();
							vsERDLkIIgJgNKycDvVqUnAvtzMJ.Clear();
						}
					}
				}
				else
				{
					lock (rEudGBzOebGDtjwIgGIyhgIYJihaA)
					{
						rEudGBzOebGDtjwIgGIyhgIYJihaA.Clear();
					}
				}
			}
			else if (vsERDLkIIgJgNKycDvVqUnAvtzMJ != null)
			{
				lock (vsERDLkIIgJgNKycDvVqUnAvtzMJ)
				{
					vsERDLkIIgJgNKycDvVqUnAvtzMJ.Clear();
				}
			}
			if (dpsHIrvJiQldvTGNUiPqofIMBFJV != null)
			{
				dpsHIrvJiQldvTGNUiPqofIMBFJV.Dispose();
			}
		}
		JffXnNxIZZMtgnHYUwWTZSnoJlEe = true;
	}
}
