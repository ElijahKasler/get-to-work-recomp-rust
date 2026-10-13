namespace Isto.GTW.SectionLoading;

public interface ISectionLoadStrategy
{
	bool IsLoaded { get; }

	bool IsLoading { get; }

	bool IsUnloading { get; }

	float Progress { get; }

	void StartLoading();

	void StartUnloading();
}
