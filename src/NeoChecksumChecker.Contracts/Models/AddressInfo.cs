using Neo.SmartContract.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoChecksumChecker.Contracts.Models
{
  /// <summary>
  /// Holds info about an address, can serialize and deserialize it to/from a string
  /// </summary>
  public class AddressInfo
  {
    public uint FirstChecksum { get; set; }
    public uint LastChecksum { get; set; }
    public uint Total { get; set; }

    public AddressInfo(uint firstChecksum, uint lastChecksum, uint total)
    {
      FirstChecksum = firstChecksum;
      LastChecksum = lastChecksum;
      Total = total;
    }

    public static AddressInfo FromBytes(byte[] data)
    {
      var firstChecksum = data.Range(0, 4).AsUInt();
      var lastChecksum = data.Range(4, 4).AsUInt();
      var total = data.Range(8, 4).AsUInt();

      return new AddressInfo(firstChecksum, lastChecksum, total);
    }

    public static byte[] ToBytes(uint firstChecksum, uint lastChecksum, uint total)
    {
      byte[] result = new byte[0];

      result = result.Concat(firstChecksum.AsByteArray());
      result = result.Concat(lastChecksum.AsByteArray());
      result = result.Concat(total.AsByteArray());

      return result;
    }

  }
}
