# Checksum Validator

You can use a checksum to check if your downloaded file is valid and not tampered with. But who checks if the checksum is valid? By storing checksums on the NEO blockchain, we can check if a provided checksum is valid.

## How does it work?

When you want to provide a file with a checksum, you can submit the checksum to this NEO Smart Contract. The Smart Contract will store data on the blockchain and assosciate it with the checksum. Data like: filename, submit date, owner and it keeps track of all the activity of an owner, like how many checksums has he provided, when was the first, when was the last. This will give users who want to download a file and check the checksum enough confidence if the provided checksum is real or fake.

## Technology Stack
- NEO Blockchain (testnet)
- C# Smart Contract
- ASP.Net Core MVC website

## Smart Contract

The Smart Contract is written in C# and has only one operation

- New
This operation adds a new checksum to the storage of the smart contract. Checksums can never be overwritten. A duplicate checksum can happen but is highly unlikely.
Parameters: operation name: 'new', owner address, checksum, filename

## Website

The website makes it easy for normal users to check if a checksum is valid. By entering a checksum, the website will retreive all available informatino from the NEO blockchain and present it to the user.  
Checksum info is available on an easy to remember url, so it can be shared or linked from a download page.

Currently there is no way to add new checksums using the website. This functionality is needed in the future.

## Installation

- Open the solution file in Visual Studio 2017
- Restore NuGet packages
- Compile

#### SmartContract
- NeoChecksumChecker.Contracts.cs will be compiled to `src\NeoChecksumChecker.Contracts\bin\Debug\NeoChecksumChecker.Contracts.avm`
- Upload this to your private net or use the contract on the testnet

#### Website
- Modify the `_scriptHash` in `HomeController.cs` to your custom scripthash if you're using a private net.

## Screenshots

TODO: Include Screenshots

## Roadmap

- Website design
- Add new checksums using the website
- Application for Windows / Linux / Mac to easily check checksums of downloaded files
- Administrator functionality, for example: flag checksums of dangerous files
