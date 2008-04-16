#region Copyright

/*---------------------------------------------------------------------------
 * The contents of this file are subject to the Mozilla Public License
 * Version 1.1 (the "License"); you may not use this file except in compliance
 * with the License. You may obtain a copy of the License at
 * 
 * http://www.mozilla.org/MPL/
 * 
 * Software distributed under the License is distributed on an "AS IS"
 * basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See the
 * License for the specific language governing rights and limitations under 
 * the License.
 * 
 * The Initial Developer of the Original Code is Robert Smyth.
 * Portions created by Robert Smyth are Copyright (C) 2008.
 * 
 * All Rights Reserved.
 *---------------------------------------------------------------------------*/

#endregion //Copyright

using System;
using System.Collections;
using System.Collections.Generic;
using VicFireReader.CFA.Regions;
using NoeticTools.PlugIns.Persistence;
using NXmlSerializer.XML;


namespace VicFireReader.CFA.Regions
{
	public class CfaRegions : ICfaRegions
	{
		private readonly List<ICfaRegionsChangedListener> listeners = new List<ICfaRegionsChangedListener>();
		private readonly List<ICfaRegion> regions = new List<ICfaRegion>();
		private int selectedIndex;

		public CfaRegions(IPersistenceService persistenceService)
		{
			ICfaRegion defaultSelection = new CfaAllRegions();
			regions.Add(defaultSelection);

			for (int regionNumber = 4; regionNumber <= 24; regionNumber++)
			{
				regions.Add(new CfaRegionItem(regionNumber));
			}

			selectedIndex = regions.IndexOf(persistenceService.RegisterScope<ICfaRegion>("Regions", UpdatePersistence, defaultSelection));
		}

		void ICfaRegions.AddListener(ICfaRegionsChangedListener listener)
		{
			listeners.Add(listener);
		}

		void ICfaRegions.RemoveListener(ICfaRegionsChangedListener listener)
		{
			listeners.Remove(listener);
		}

		private object UpdatePersistence()
		{
			return SelectedRegion;
		}

		public ICfaRegion SelectedRegion
		{
			get { return regions[selectedIndex];  }	
			set
			{
				selectedIndex = regions.IndexOf(value);
				foreach (ICfaRegionsChangedListener listener in listeners)
				{
					listener.OnSelectedRegionChanged();
				}
			}
		}

		public bool IsSelectedRegion(short regionNumber)
		{
			return SelectedRegion.Equals(regionNumber);
		}

		object IList.this[int index]
		{
			get { return regions[index]; }
			set { throw new InvalidOperationException(); }
		}

		int IList.Add(object region)
		{
			throw new InvalidOperationException();
		}

		bool IList.Contains(object region)
		{
			return regions.Contains((ICfaRegion) region);
		}

		void IList.Clear()
		{
			throw new InvalidOperationException();
		}

		int IList.IndexOf(object region)
		{
			return regions.IndexOf((ICfaRegion)region);
		}

		void IList.Insert(int index, object region)
		{
			throw new InvalidOperationException();
		}

		void IList.Remove(object region)
		{
			throw new InvalidOperationException();
		}

		void ICollection.CopyTo(Array array, int index)
		{
			throw new InvalidOperationException();
		}

		public object SyncRoot
		{
			get { throw new InvalidOperationException(); }
		}

		public bool IsSynchronized
		{
			get { return true; }
		}

		public bool IsFixedSize
		{
			get { return true; }
		}

		public int IndexOf(ICfaRegion item)
		{
			return regions.IndexOf(item);
		}

		public void Insert(int index, ICfaRegion item)
		{
			throw new InvalidOperationException();
		}

		public void RemoveAt(int index)
		{
			throw new InvalidOperationException();
		}

		public ICfaRegion this[int index]
		{
			get { return regions[index]; }
			set { throw new InvalidOperationException(); }
		}

		public void Add(ICfaRegion item)
		{
			throw new InvalidOperationException();
		}

		void ICollection<ICfaRegion>.Clear()
		{
			throw new InvalidOperationException();
		}

		public bool Contains(ICfaRegion item)
		{
			return regions.Contains(item);
		}

		public void CopyTo(ICfaRegion[] array, int arrayIndex)
		{
			regions.CopyTo(array, arrayIndex);
		}

		bool ICollection<ICfaRegion>.Remove(ICfaRegion item)
		{
			throw new InvalidOperationException();
		}

		public int Count
		{
			get { return regions.Count; }
		}

		public bool IsReadOnly
		{
			get { return true; }
		}

		IEnumerator<ICfaRegion> IEnumerable<ICfaRegion>.GetEnumerator()
		{
			return regions.GetEnumerator();
		}

		public IEnumerator GetEnumerator()
		{
			return ((IEnumerable<ICfaRegion>)this).GetEnumerator();
		}

		[NXmlSerializable(SerializeOption.Fields)]	// TODO: Smell, ought not expose NXmlSerializable here
		private class CfaRegionItem : ICfaRegion
		{
			private readonly int regionNumber;

			public CfaRegionItem(int regionNumber)
			{
				this.regionNumber = regionNumber;
			}

			public override string ToString()
			{
				return string.Format("Region: {0}", regionNumber);
			}

			public override bool Equals(object obj)
			{
				bool equals;
				if (obj.GetType() == typeof(CfaRegionItem))
				{
					equals = ((CfaRegionItem) obj).regionNumber == regionNumber;
				}
				else if (obj.GetType() == typeof(short))
				{
					equals = ((short)obj) == regionNumber;
				}
				else
				{
					equals = base.Equals(obj);
				}
				return equals;
			}

			public override int GetHashCode()
			{
				return base.GetHashCode();
			}
		}

		private class CfaAllRegions : ICfaRegion
		{
			public override string ToString()
			{
				return string.Format("All regions");
			}

			public override bool Equals(object obj)
			{
				bool equals;
				if (obj.GetType() == GetType() || obj.GetType() == typeof(short))
				{
					equals = true;
				}
				else
				{
					equals = base.Equals(obj);
				}
				return equals;
			}

			public override int GetHashCode()
			{
				return base.GetHashCode();
			}
		}
	}
}