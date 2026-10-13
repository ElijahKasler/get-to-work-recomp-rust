namespace System.Windows.Forms.PropertyGridInternal;

[System.MonoInternalNote("needs to implement IRootGridEntry")]
internal class RootGridEntry : GridEntry
{
	private object[] val;

	public override bool Expandable => true;

	public override GridItemType GridItemType => GridItemType.Root;

	public override string Label
	{
		get
		{
			if (val.Length <= 1)
			{
				return val[0].GetType().ToString();
			}
			return val.GetType().ToString();
		}
	}

	public override object Value
	{
		get
		{
			if (val.Length <= 1)
			{
				return val[0];
			}
			return val;
		}
	}

	public override object[] Values => val;

	public override bool IsReadOnly => true;

	public override bool IsEditable => false;

	public override bool IsResetable => false;

	public override bool IsMerged => val.Length > 1;

	public RootGridEntry(PropertyGrid owner, object[] obj)
		: base(owner, null)
	{
		if (obj == null || obj.Length == 0)
		{
			throw new ArgumentNullException("obj");
		}
		val = obj;
	}

	public override bool Select()
	{
		return false;
	}
}
