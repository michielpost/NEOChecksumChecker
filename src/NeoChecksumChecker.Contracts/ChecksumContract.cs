using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using NeoChecksumChecker.Contracts.Models;
using System;
using System.Numerics;

namespace NeoChecksumChecker.Contracts
{
  /// <summary>
  /// SmartContract to add checksums to the storage
  /// </summary>
  public class ChecksumContract : SmartContract
  {
    // params: 0710
    // return : 05
    public static object Main(string operation, params object[] args)
    {
      switch (operation)
      {
        case "new":
          return New((byte[])args[0], (string)args[1], (string)args[1]);
        default:
          return "Unknown Operation: " + operation;
      }

    }

    /// <summary>
    /// Add a new checksum
    /// </summary>
    /// <param name="address">Source address</param>
    /// <param name="checksum">New checksum</param>
    /// <param name="fileName">Filename</param>
    /// <returns></returns>
    private static bool New(byte[] address, string checksum, string fileName)
    {
      //Check if there is a checksum given
      if (checksum == null || checksum == "")
        return false;

      //Check if there is a filename given
      if (fileName == null || fileName == "")
        return false;

      //Check if the user using this contract is actually submitting his own address
      if (!Runtime.CheckWitness(address))
        return false;

      //Check if this checksum already exists, overwrite is not possible
      var existing = Storage.Get(Storage.CurrentContext, address);
      if (existing == null)
        return false;

      //Get current date
      Header header = Blockchain.GetHeader(Blockchain.GetHeight());
      var currentTime = header.Timestamp;

      //Save info about checksum: filename, address, date
      var info = new ChecksumInfo(address, currentTime, fileName);
      byte[] checksumInfo = ChecksumInfo.ToBytes(address, currentTime, fileName);
      Storage.Put(Storage.CurrentContext, checksum, checksumInfo);

      //Check if the creator already submitted a checksum before
      var existingInfo = Storage.Get(Storage.CurrentContext, GetFirstDateKey(checksum));
      if (existingInfo == null)
      {
        //Only insert first date if it's empty
        Storage.Put(Storage.CurrentContext, GetFirstDateKey(checksum), currentTime);
      }

      //Always set last updated date
      Storage.Put(Storage.CurrentContext, GetLastDateKey(checksum), currentTime);

      //TODO: Increase count of total number of checksums

      return true;
    }

    private static string GetFirstDateKey(string checksum)
    {
      return "firstdate-" + checksum;
    }
    private static string GetLastDateKey(string checksum)
    {
      return "lastdate-" + checksum;
    }
  }
}
