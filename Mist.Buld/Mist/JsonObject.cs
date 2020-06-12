using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mist
{
	// Token: 0x0200003F RID: 63
	public class JsonObject : JsonValue, IDictionary<string, JsonValue>, ICollection<KeyValuePair<string, JsonValue>>, IEnumerable<KeyValuePair<string, JsonValue>>, IEnumerable
	{
		// Token: 0x17000041 RID: 65
		// (get) Token: 0x0600016B RID: 363 RVA: 0x00004DF6 File Offset: 0x00002FF6
		public override int Count
		{
			get
			{
				return this.map.Count;
			}
		}

		// Token: 0x17000042 RID: 66
		public sealed override JsonValue this[string key]
		{
			get
			{
				return this.map[key];
			}
			set
			{
				this.map[key] = value;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x0600016E RID: 366 RVA: 0x00004E20 File Offset: 0x00003020
		public override JsonType JsonType
		{
			get
			{
				return JsonType.Object;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x0600016F RID: 367 RVA: 0x00004E23 File Offset: 0x00003023
		public ICollection<string> Keys
		{
			get
			{
				return this.map.Keys;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000170 RID: 368 RVA: 0x00004E30 File Offset: 0x00003030
		public ICollection<JsonValue> Values
		{
			get
			{
				return this.map.Values;
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000171 RID: 369 RVA: 0x000046D6 File Offset: 0x000028D6
		bool ICollection<KeyValuePair<string, JsonValue>>.IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00004E3D File Offset: 0x0000303D
		public JsonObject(params KeyValuePair<string, JsonValue>[] items)
		{
			this.map = new SortedDictionary<string, JsonValue>(StringComparer.Ordinal);
			if (items != null)
			{
				this.AddRange(items);
			}
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00004E5F File Offset: 0x0000305F
		public JsonObject(IEnumerable<KeyValuePair<string, JsonValue>> items)
		{
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}
			this.map = new SortedDictionary<string, JsonValue>(StringComparer.Ordinal);
			this.AddRange(items);
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00004E8C File Offset: 0x0000308C
		public IEnumerator<KeyValuePair<string, JsonValue>> GetEnumerator()
		{
			return this.map.GetEnumerator();
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00004E8C File Offset: 0x0000308C
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.map.GetEnumerator();
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00004E9E File Offset: 0x0000309E
		public void Add(string key, JsonValue value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			this.map.Add(key, value);
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00004EBB File Offset: 0x000030BB
		public void Add(KeyValuePair<string, JsonValue> pair)
		{
			this.Add(pair.Key, pair.Value);
		}

		// Token: 0x06000178 RID: 376 RVA: 0x0000DE10 File Offset: 0x0000C010
		public void AddRange(IEnumerable<KeyValuePair<string, JsonValue>> items)
		{
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}
			foreach (KeyValuePair<string, JsonValue> keyValuePair in items)
			{
				this.map.Add(keyValuePair.Key, keyValuePair.Value);
			}
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00004ED1 File Offset: 0x000030D1
		public void AddRange(params KeyValuePair<string, JsonValue>[] items)
		{
			this.AddRange(items);
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00004EDA File Offset: 0x000030DA
		public void Clear()
		{
			this.map.Clear();
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00004EE7 File Offset: 0x000030E7
		bool ICollection<KeyValuePair<string, JsonValue>>.Contains(KeyValuePair<string, JsonValue> item)
		{
			return ((ICollection<KeyValuePair<string, JsonValue>>)this.map).Contains(item);
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00004EF5 File Offset: 0x000030F5
		bool ICollection<KeyValuePair<string, JsonValue>>.Remove(KeyValuePair<string, JsonValue> item)
		{
			return ((ICollection<KeyValuePair<string, JsonValue>>)this.map).Remove(item);
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00004F03 File Offset: 0x00003103
		public override bool ContainsKey(string key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			return this.map.ContainsKey(key);
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00004F1F File Offset: 0x0000311F
		public void CopyTo(KeyValuePair<string, JsonValue>[] array, int arrayIndex)
		{
			((ICollection<KeyValuePair<string, JsonValue>>)this.map).CopyTo(array, arrayIndex);
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00004F2E File Offset: 0x0000312E
		public bool Remove(string key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			return this.map.Remove(key);
		}

		// Token: 0x06000180 RID: 384 RVA: 0x0000DE78 File Offset: 0x0000C078
		public override void Save(Stream stream, bool parsing)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			stream.WriteByte(123);
			foreach (KeyValuePair<string, JsonValue> keyValuePair in this.map)
			{
				stream.WriteByte(34);
				byte[] bytes = Encoding.UTF8.GetBytes(base.EscapeString(keyValuePair.Key));
				stream.Write(bytes, 0, bytes.Length);
				stream.WriteByte(34);
				stream.WriteByte(44);
				stream.WriteByte(32);
				if (keyValuePair.Value == null)
				{
					stream.WriteByte(110);
					stream.WriteByte(117);
					stream.WriteByte(108);
					stream.WriteByte(108);
				}
				else
				{
					keyValuePair.Value.Save(stream, parsing);
				}
			}
			stream.WriteByte(125);
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00004F4A File Offset: 0x0000314A
		public bool TryGetValue(string key, out JsonValue value)
		{
			return this.map.TryGetValue(key, out value);
		}

		// Token: 0x040000EC RID: 236
		private SortedDictionary<string, JsonValue> map;
	}
}
