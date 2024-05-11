using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;


public class ConfigCipher
{
    private readonly string KEY = "全聯實業";
    private readonly byte[] BKEY = new byte[8];
    private readonly byte[] BIV = new byte[8];
    private readonly DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
    
    public ConfigCipher()
    {
        var hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(KEY));
        Array.Copy(hash, 0, BKEY, 0, 8);
        Array.Copy(hash, 8, BIV, 0, 8);
    }

    public string Encrypt(string content)
    {
        if (String.IsNullOrEmpty(content))
        {
            throw new ArgumentNullException("The string which needs to be encrypted can not be null.");
        }

        DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
        MemoryStream memoryStream = new MemoryStream();
        CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(BKEY, BIV), CryptoStreamMode.Write);

        StreamWriter writer = new StreamWriter(cryptoStream);
        writer.Write(content.Trim());
        writer.Flush();
        cryptoStream.FlushFinalBlock();
        writer.Flush();

        string encrypt_string = string.Empty;

        return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length); ;
    }

    public string Decrypt(string content)
    {
        if (String.IsNullOrEmpty(content))
        {
            throw new ArgumentNullException("The string which needs to be encrypted can not be null.");
        }

        DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
        MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(content));
        CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(BKEY, BIV), CryptoStreamMode.Read);
        StreamReader reader = new StreamReader(cryptoStream);

        return reader.ReadToEnd().Trim();
    }

    public string Verify(string app)
    {
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        string appConfig = config.AppSettings.Settings[app].Value;

        if (!appConfig.StartsWith("pxmart"))
        {
            string ciphertext = Encrypt(appConfig);
            config.AppSettings.Settings[app].Value = "pxmart" + ciphertext;
            config.Save();
            System.Configuration.ConfigurationManager.RefreshSection("appSettings");
            return appConfig;       
        }

        return Decrypt(appConfig.Replace("pxmart", ""));
    }



}

