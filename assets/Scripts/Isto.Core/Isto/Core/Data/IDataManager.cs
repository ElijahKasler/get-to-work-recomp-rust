using System.IO;
using System.Xml.Serialization;

namespace Isto.Core.Data;

public interface IDataManager
{
	void Save(out object saveData);

	bool Load(in TextReader reader);

	bool Validate(in TextReader reader, in object previousDataObject);

	void UpgradeSave(string targetVersion, GameStateSaveData metaData, TextReader reader, out XmlSerializer serializer, out object saveData);
}
