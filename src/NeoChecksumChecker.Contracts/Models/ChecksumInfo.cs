using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo.SmartContract.Framework;

namespace NeoChecksumChecker.Contracts.Models
{
  /// <summary>
  /// Holds info about a checksum, can serialize and deserialize it to/from a string
  /// </summary>
  public class ChecksumInfo
  {
    public byte[] Address { get; set; }
    public uint Time { get; set; }
    public string FileName { get; set; }

    public ChecksumInfo(byte[] address, uint time, string filename)
    {
      Address = address;
      Time = time;
      FileName = filename;
    }

    public static ChecksumInfo FromBytes(byte[] data)
    {
      var address = data.Range(0, 4);
      var time = data.Range(4, 4).AsUInt();
      var fileName = data.Range(8, data.Length - 8).AsString();

      return new ChecksumInfo(address, time, fileName);
    }

    public static byte[] ToBytes(byte[] address, uint time, string filename)
    {
      byte[] result = address;
      result = result.Concat(time.AsByteArray());
      result = result.Concat(filename.AsByteArray());

      return result;
    }



  }
}
