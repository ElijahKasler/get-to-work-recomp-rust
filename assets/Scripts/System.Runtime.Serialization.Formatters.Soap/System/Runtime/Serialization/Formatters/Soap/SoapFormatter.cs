using System.IO;
using System.Runtime.Remoting.Messaging;

namespace System.Runtime.Serialization.Formatters.Soap;

public sealed class SoapFormatter : IRemotingFormatter, IFormatter
{
	private SerializationBinder _binder;

	private StreamingContext _context;

	private ISurrogateSelector _selector;

	private FormatterAssemblyStyle _assemblyFormat = FormatterAssemblyStyle.Full;

	private FormatterTypeStyle _typeFormat;

	private ISoapMessage _topObject;

	private TypeFilterLevel _filterLevel = TypeFilterLevel.Low;

	public ISurrogateSelector SurrogateSelector
	{
		get
		{
			return _selector;
		}
		set
		{
			_selector = value;
		}
	}

	public SerializationBinder Binder
	{
		get
		{
			return _binder;
		}
		set
		{
			_binder = value;
		}
	}

	public StreamingContext Context
	{
		get
		{
			return _context;
		}
		set
		{
			_context = value;
		}
	}

	public ISoapMessage TopObject
	{
		get
		{
			return _topObject;
		}
		set
		{
			_topObject = value;
		}
	}

	[System.MonoTODO("Interpret this")]
	public TypeFilterLevel FilterLevel
	{
		get
		{
			return _filterLevel;
		}
		set
		{
			_filterLevel = value;
		}
	}

	public FormatterAssemblyStyle AssemblyFormat
	{
		get
		{
			return _assemblyFormat;
		}
		set
		{
			_assemblyFormat = value;
		}
	}

	public FormatterTypeStyle TypeFormat
	{
		get
		{
			return _typeFormat;
		}
		set
		{
			_typeFormat = value;
		}
	}

	public SoapFormatter()
	{
		_selector = null;
		_context = new StreamingContext(StreamingContextStates.All);
	}

	public SoapFormatter(ISurrogateSelector selector, StreamingContext context)
	{
		_selector = selector;
		_context = context;
	}

	public object Deserialize(Stream serializationStream)
	{
		return Deserialize(serializationStream, null);
	}

	public object Deserialize(Stream serializationStream, HeaderHandler handler)
	{
		return new SoapReader(_binder, _selector, _context).Deserialize(serializationStream, _topObject);
	}

	public void Serialize(Stream serializationStream, object graph)
	{
		Serialize(serializationStream, graph, null);
	}

	public void Serialize(Stream serializationStream, object graph, Header[] headers)
	{
		if (serializationStream == null)
		{
			throw new ArgumentNullException("serializationStream");
		}
		if (!serializationStream.CanWrite)
		{
			throw new SerializationException("Can't write in the serialization stream");
		}
		if (graph == null)
		{
			throw new ArgumentNullException("graph");
		}
		new SoapWriter(serializationStream, _selector, _context, _topObject).Serialize(graph, headers, _typeFormat, _assemblyFormat);
	}
}
