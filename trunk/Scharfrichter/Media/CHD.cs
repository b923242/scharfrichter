﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Scharfrichter.Codec.Media
{
	public class CHD : Stream
	{
		public static CHD Load(Stream source)
		{
			CHD result = new CHD();
			BinaryReaderEx reader = new BinaryReaderEx(source);

			if (new string(reader.ReadChars(8)) != "MComprHD")
				return null;

			UInt32 headerLength = reader.ReadUInt32();
			UInt32 version = reader.ReadUInt32();

			switch (version)
			{
				case 1:
					result.ReadHeaderV1(reader);
					break;
				case 2:
					break;
				case 3:
					break;
				case 4:
					break;
				case 5:
					break;
			}
		}

		private void ReadHeaderV1(BinaryReaderEx reader)
		{
			UInt32 flags = reader.ReadUInt32();
			UInt32 compression = reader.ReadUInt32();
			UInt32 hunkSize = reader.ReadUInt32();
			UInt32 totalHunks = reader.ReadUInt32();
			UInt32 cylinders = reader.ReadUInt32();
			UInt32 heads = reader.ReadUInt32();
			UInt32 sectors = reader.ReadUInt32();
			byte[] md5 = reader.ReadBytes(16);
			byte[] parentmd5 = reader.ReadBytes(16);
		}

		private void ReadHeaderV2(BinaryReaderEx reader)
		{
			UInt32 flags = reader.ReadUInt32();
			UInt32 compression = reader.ReadUInt32();
			UInt32 hunkSize = reader.ReadUInt32();
			UInt32 totalHunks = reader.ReadUInt32();
			UInt32 cylinders = reader.ReadUInt32();
			UInt32 heads = reader.ReadUInt32();
			UInt32 sectors = reader.ReadUInt32();
			byte[] md5 = reader.ReadBytes(16);
			byte[] parentmd5 = reader.ReadBytes(16);
			UInt32 seclen = reader.ReadUInt32();
		}

		private void ReadHeaderV3(BinaryReaderEx reader)
		{
			UInt32 flags = reader.ReadUInt32();
			UInt32 compression = reader.ReadUInt32();
			UInt32 totalHunks = reader.ReadUInt32();
			UInt64 logicalBytes = reader.ReadUInt64();
			
		}

		private void ReadHeaderV4(BinaryReaderEx reader)
		{
		}

		private void ReadHeaderV5(BinaryReaderEx reader)
		{
		}
	}
}
