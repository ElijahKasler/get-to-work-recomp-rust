namespace System.Windows.Forms;

internal abstract class TabStop : IComparable<TabStop>
{
	private float _pos = -1f;

	internal float Position
	{
		get
		{
			return _pos;
		}
		set
		{
			if (_pos >= 0f)
			{
				throw new InvalidOperationException("Can't change Position once it has been set!");
			}
			_pos = value;
		}
	}

	internal virtual float GetInitialWidth(Line line, int pos)
	{
		return 0f;
	}

	internal abstract float CalculateRight(Line line, int pos);

	public override bool Equals(object obj)
	{
		if (obj.GetType() == GetType())
		{
			return (double)Math.Abs(((TabStop)obj).Position - Position) < 0.01;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return GetType().GetHashCode() ^ Position.GetHashCode();
	}

	public override string ToString()
	{
		return $"[{GetType().Name}: Position {Position}]";
	}

	public int CompareTo(TabStop other)
	{
		return Position.CompareTo(other.Position);
	}
}
