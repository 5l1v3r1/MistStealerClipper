using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Mist
{
	// Token: 0x0200003D RID: 61
	public class JsonArray : JsonValue, IList<JsonValue>, ICollection<JsonValue>, IEnumerable<JsonValue>, IEnumerable
	{
		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000155 RID: 341 RVA: 0x00004CB5 File Offset: 0x00002EB5
		public override int Count
		{
			get
			{
				return this.list.Count;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000156 RID: 342 RVA: 0x000046D6 File Offset: 0x000028D6
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700003F RID: 63
		public sealed override JsonValue this[int index]
		{
			get
			{
				return this.list[index];
			}
			set
			{
				this.list[index] = value;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000159 RID: 345 RVA: 0x00004CDF File Offset: 0x00002EDF
		public override JsonType JsonType
		{
			get
			{
				return JsonType.Array;
			}
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00004CE2 File Offset: 0x00002EE2
		public JsonArray(params JsonValue[] items)
		{
			this.list = new List<JsonValue>();
			this.AddRange(items);
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00004CFC File Offset: 0x00002EFC
		public JsonArray(IEnumerable<JsonValue> items)
		{
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}
			this.list = new List<JsonValue>(items);
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00004D1E File Offset: 0x00002F1E
		public void Add(JsonValue item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			this.list.Add(item);
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00004D3A File Offset: 0x00002F3A
		public void AddRange(IEnumerable<JsonValue> items)
		{
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}
			this.list.AddRange(items);
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00004D56 File Offset: 0x00002F56
		public void AddRange(params JsonValue[] items)
		{
			if (items != null)
			{
				this.list.AddRange(items);
			}
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00004D67 File Offset: 0x00002F67
		public void Clear()
		{
			this.list.Clear();
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00004D74 File Offset: 0x00002F74
		public bool Contains(JsonValue item)
		{
			return this.list.Contains(item);
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00004D82 File Offset: 0x00002F82
		public void CopyTo(JsonValue[] array, int arrayIndex)
		{
			this.list.CopyTo(array, arrayIndex);
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00004D91 File Offset: 0x00002F91
		public int IndexOf(JsonValue item)
		{
			return this.list.IndexOf(item);
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00004D9F File Offset: 0x00002F9F
		public void Insert(int index, JsonValue item)
		{
			this.list.Insert(index, item);
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00004DAE File Offset: 0x00002FAE
		public bool Remove(JsonValue item)
		{
			return this.list.Remove(item);
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00004DBC File Offset: 0x00002FBC
		public void RemoveAt(int index)
		{
			this.list.RemoveAt(index);
		}

		// Token: 0x06000166 RID: 358 RVA: 0x0000DD78 File Offset: 0x0000BF78
		public override void Save(Stream stream, bool parsing)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			stream.WriteByte(91);
			for (int i = 0; i < this.list.Count; i++)
			{
				JsonValue jsonValue = this.list[i];
				if (jsonValue != null)
				{
					jsonValue.Save(stream, parsing);
				}
				else
				{
					stream.WriteByte(110);
					stream.WriteByte(117);
					stream.WriteByte(108);
					stream.WriteByte(108);
				}
				if (i < this.Count - 1)
				{
					stream.WriteByte(44);
					stream.WriteByte(32);
				}
			}
			stream.WriteByte(93);
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00004DCA File Offset: 0x00002FCA
		IEnumerator<JsonValue> IEnumerable<JsonValue>.GetEnumerator()
		{
			return this.list.GetEnumerator();
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00004DCA File Offset: 0x00002FCA
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.list.GetEnumerator();
		}

		// Token: 0x040000EB RID: 235
		private List<JsonValue> list;
	}
}
