namespace Isto.Core.Data;

public class TorchItemData : EquippableItemData
{
	public float lifeRemaining;

	public TorchItemData()
	{
	}

	public TorchItemData(string guid, float lifeRemaining)
		: base(guid)
	{
		this.lifeRemaining = lifeRemaining;
	}
}
