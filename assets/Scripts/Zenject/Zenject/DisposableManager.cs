using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using ModestTree.Util;

namespace Zenject;

public class DisposableManager : IDisposable
{
	private struct DisposableInfo(IDisposable disposable, int priority)
	{
		public IDisposable Disposable = disposable;

		public int Priority = priority;
	}

	private class LateDisposableInfo
	{
		public ILateDisposable LateDisposable;

		public int Priority;

		public LateDisposableInfo(ILateDisposable lateDisposable, int priority)
		{
			LateDisposable = lateDisposable;
			Priority = priority;
		}
	}

	private readonly List<DisposableInfo> _disposables = new List<DisposableInfo>();

	private readonly List<LateDisposableInfo> _lateDisposables = new List<LateDisposableInfo>();

	private bool _disposed;

	private bool _lateDisposed;

	[Inject]
	public DisposableManager([Inject(Optional = true, Source = InjectSources.Local)] List<IDisposable> disposables, [Inject(Optional = true, Source = InjectSources.Local)] List<ValuePair<Type, int>> priorities, [Inject(Optional = true, Source = InjectSources.Local)] List<ILateDisposable> lateDisposables, [Inject(Id = "Late", Optional = true, Source = InjectSources.Local)] List<ValuePair<Type, int>> latePriorities)
	{
		foreach (IDisposable disposable in disposables)
		{
			int? num = priorities.Where((ValuePair<Type, int> x) => disposable.GetType().DerivesFromOrEqual(x.First)).Select((Func<ValuePair<Type, int>, int?>)((ValuePair<Type, int> x) => x.Second)).SingleOrDefault();
			int priority = (num.HasValue ? num.Value : 0);
			_disposables.Add(new DisposableInfo(disposable, priority));
		}
		foreach (ILateDisposable lateDisposable in lateDisposables)
		{
			int? num2 = latePriorities.Where((ValuePair<Type, int> x) => lateDisposable.GetType().DerivesFromOrEqual(x.First)).Select((Func<ValuePair<Type, int>, int?>)((ValuePair<Type, int> x) => x.Second)).SingleOrDefault();
			int priority2 = (num2.HasValue ? num2.Value : 0);
			_lateDisposables.Add(new LateDisposableInfo(lateDisposable, priority2));
		}
	}

	public void Add(IDisposable disposable)
	{
		Add(disposable, 0);
	}

	public void Add(IDisposable disposable, int priority)
	{
		_disposables.Add(new DisposableInfo(disposable, priority));
	}

	public void AddLate(ILateDisposable disposable)
	{
		AddLate(disposable, 0);
	}

	public void AddLate(ILateDisposable disposable, int priority)
	{
		_lateDisposables.Add(new LateDisposableInfo(disposable, priority));
	}

	public void Remove(IDisposable disposable)
	{
		_disposables.RemoveWithConfirm(_disposables.Where((DisposableInfo x) => x.Disposable == disposable).Single());
	}

	public void LateDispose()
	{
		Assert.That(!_lateDisposed, "Tried to late dispose DisposableManager twice!");
		_lateDisposed = true;
		foreach (LateDisposableInfo item in _lateDisposables.OrderBy((LateDisposableInfo x) => x.Priority).Reverse().ToList())
		{
			try
			{
				item.LateDisposable.LateDispose();
			}
			catch (Exception innerException)
			{
				throw Assert.CreateException(innerException, "Error occurred while late disposing ILateDisposable with type '{0}'", item.LateDisposable.GetType());
			}
		}
	}

	public void Dispose()
	{
		Assert.That(!_disposed, "Tried to dispose DisposableManager twice!");
		_disposed = true;
		foreach (DisposableInfo item in _disposables.OrderBy((DisposableInfo x) => x.Priority).Reverse().ToList())
		{
			try
			{
				item.Disposable.Dispose();
			}
			catch (Exception innerException)
			{
				throw Assert.CreateException(innerException, "Error occurred while disposing IDisposable with type '{0}'", item.Disposable.GetType());
			}
		}
	}
}
