using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeoChecksumChecker.Contracts.Models;

namespace NeoChecksumChecker.Website.Models
{
  public class ChecksumViewModel
  {
    public string Checksum { get; set; }
    public ChecksumInfo ChecksumInfo { get; internal set; } = new ChecksumInfo(null, 0, string.Empty);
    public AddressInfo AddressInfo { get; internal set; } = new AddressInfo(0, 0, 0);
  }
}
