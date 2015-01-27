﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Sweet.LoveWinne.Utility
{
	/// <summary>
	/// Encryption / Decryption wrapper using AesManaged.
	/// <para></para>
	/// Encryption format: [IV]-[DATA]
	/// Encoding: utf-8
	/// </summary>
	/// <remarks>link: http://codereview.stackexchange.com/questions/13714/symmetric-encryption-decryption-routine-using-aes </remarks>
	public static class AesManagedHelper
	{
		#region properties

		public readonly static Encoding Encoding = Encoding.UTF8;

		/// <summary>
		/// Secret key size in bits.
		/// </summary>
		private const int _keySize = 256;
		/// <summary>
		/// Initialization Vector length in bytes.
		/// </summary>
		private const int _ivLength = 16;
		/// <summary>
		/// Padding for rounding byte count before encryption.
		/// </summary>
		/// <remarks>PaddingModes Zeros and None does not work.</remarks>
		private const PaddingMode _paddingMode = PaddingMode.PKCS7;
		/// <summary>
		/// Some const string randomly generated as passphrase for testing. 
		/// Used to create byte[] key.
		/// </summary>
		/// <remarks>Do NOT use this. Change it!</remarks>
		/// <remarks>using http://www.random.org/strings/?num=1&len=20&loweralpha=on&unique=on&format=html&rnd=new </remarks>
		private const string _salt = @"
uxxbmipxvj
dbskrlzjff
scehvltzzh
jipckljeoe
mqoecrjgrm
kxrsaoiolw
jttzttkxhj
httjuwxxkk
tiuwjtlweg
bskcvvscao";


		#endregion

		#region methods

		/// <summary>
		/// Encrypts utf-8 text to get base64 string of format [IV]-[DATA].
		/// </summary>
		public static string EncryptString(string data, string key)
		{
			byte[] textBytesEncryptedCombined;
			using (var aes = new AesManaged())
			{
				// Convert to bytes
				byte[] textBytes = Encoding.GetBytes(data);
				aes.Padding = _paddingMode;
				aes.KeySize = _keySize;

				// Generate nonce
				aes.IV = GenerateIv();

				// Key
				aes.Key = GetEncryptionKey(key);

				using (var ms = new MemoryStream())
				using (var encryptor = aes.CreateEncryptor())
				{
					using (var cryptoStream = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
					{
						cryptoStream.Write(textBytes, 0, textBytes.Length);
					}
					byte[] textBytesEncrypted = ms.ToArray();

					// Combine IV and DATA
					textBytesEncryptedCombined = CombineIvData(aes.IV, textBytesEncrypted);
				}
			}
			var textEncrypted = Convert.ToBase64String(textBytesEncryptedCombined);
			return textEncrypted;
		}

		/// <summary>
		/// Decrypts base64 string in [IV]-[DATA] format to get utf-8 text.
		/// </summary>
		public static string DecryptString(string textEncrypted, string key)
		{

			byte[] textBytesDecrypted;
			using (var aes = new AesManaged())
			{
				// Convert string to bytes
				byte[] textBytesEncryptedCombined = Convert.FromBase64String(textEncrypted);
				aes.Padding = _paddingMode;
				aes.KeySize = _keySize;

				// Parse IV from encrypted bytes
				aes.IV = GetIv(textBytesEncryptedCombined);
				// Key
				aes.Key = GetEncryptionKey(key);

				// Remove IV before decryption
				var textBytesEncrypted = RemoveIv(textBytesEncryptedCombined);

				using (var ms = new MemoryStream())
				using (var decryptor = aes.CreateDecryptor())
				{
					using (var cryptoStream = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
					{
						cryptoStream.Write(textBytesEncrypted, 0, textBytesEncrypted.Length);
					}
					textBytesDecrypted = ms.ToArray();
				}
			}
			var textDecrypted = Encoding.GetString(textBytesDecrypted);
			return textDecrypted;
		}

		/// <summary>
		/// Generates encryption key using passphrase.
		/// </summary>
		/// <remarks>link: http://stackoverflow.com/questions/667887/aes-in-asp-net-with-vb-net/668008#668008 </remarks>
		private static byte[] GetEncryptionKey(string key)
		{
			var pdb = new PasswordDeriveBytes(
				strPassword: key,
				rgbSalt: Encoding.GetBytes(_salt), // use const byte[] as salt
				strHashName: "SHA512", iterations: 129
			);
			var key_g = pdb.GetBytes(_keySize / 8);
			//Console.WriteLine("key:" + string.Join(",", key_g.ToArray()));
			return key_g;
		}

		/// <summary>
		/// Generates a random IV.
		/// </summary>
		/// <returns>Random nonce.</returns>
		private static byte[] GenerateIv()
		{
			using (var rng = new RNGCryptoServiceProvider())
			{
				byte[] nonce = new byte[_ivLength];
				rng.GetBytes(nonce);
				return nonce;
			}
		}

		/// <summary>
		/// Parses IV from [IV-DATA] byte array.
		/// </summary>
		/// <param name="ivdata">[IV]-[DATA] byte array.</param>
		/// <returns>IV byte array.</returns>
		private static byte[] GetIv(byte[] ivdata)
		{
			byte[] iv = new byte[_ivLength];
			Array.Copy(sourceArray: ivdata, sourceIndex: 0,
				destinationArray: iv, destinationIndex: 0,
				length: _ivLength);
			return iv;
		}

		/// <summary>
		/// Removes IV from [IV]-[DATA] byte array.
		/// </summary>
		/// <param name="ivdata">[IV]-[DATA] byte array.</param>
		/// <returns>[DATA] byte array.</returns>
		private static byte[] RemoveIv(byte[] ivdata)
		{
			byte[] data = new byte[ivdata.Length - _ivLength];
			Array.Copy(sourceArray: ivdata, sourceIndex: _ivLength,
				destinationArray: data, destinationIndex: 0,
				length: ivdata.Length - _ivLength);
			return data;
		}

		/// <summary>
		/// Combine IV with encrypted [DATA] to get [IV]-[DATA] byte array.
		/// </summary>
		private static byte[] CombineIvData(byte[] iv, byte[] data)
		{
			byte[] ivdata = new byte[data.Length + iv.Length];
			iv.CopyTo(array: ivdata, index: 0);
			data.CopyTo(array: ivdata, index: _ivLength);
			return ivdata;
		}

		#endregion
	}
}

