using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoChecksumChecker.Contracts
{
  /// <summary>
  /// https://github.com/jlgaffney/Surveys-Smart-Contract/blob/f934d5ed58cac7ad4d402d372393e330724d4bf7/Survey.Contract/EncodingHelper.cs
  /// </summary>
  public static class Converters
  {
    /// <summary>
    /// Little-endian
    /// </summary>
    public static uint AsUInt(this byte[] source)
    {
      uint value = 0;

      if (source.Length != 4) return value;

      value |= ((uint)source[0]);
      value |= (((uint)source[1]) << 8);
      value |= (((uint)source[2]) << 16);
      value |= (((uint)source[3]) << 24);

      return value;
    }

    /// <summary>
    /// Little-endian
    /// </summary>
    public static byte[] AsByteArray(this uint source)
    {
      byte firstByte = (byte)(source & 0xFF);
      byte secondByte = (byte)((source >> 8) & 0xFF);
      byte thirdByte = (byte)((source >> 16) & 0xFF);
      byte fourthByte = (byte)((source >> 24) & 0xFF);

      byte[] result = new byte[4];
      result[0] = firstByte;
      result[1] = secondByte;
      result[2] = thirdByte;
      result[3] = fourthByte;
      return result;
    }
  }
}
