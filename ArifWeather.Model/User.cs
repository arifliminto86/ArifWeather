using System;
using System.Security.Cryptography;
using System.Text;

namespace ArifWeather.Model
{
    public class User
    {
        private static readonly string _key = "fksldkdsfkjlajlk;jklfasdkjlafsd;";
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsMock { get; set; } //indicate if we are using the real data or not
        public string Version { get; set; }

        /// <summary>
        /// Encrypt word by using key value
        /// </summary>
        /// <param name="word">uncrypted word</param>
        /// <returns></returns>
        public static string EncryptedWord(string word)
        {
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(word);
            
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            var keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(_key));
            //Always release the resources and flush data
            // of the Cryptographic service provide. Best Practice
            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);            
        }

        /// <summary>
        /// Decrypt word
        /// </summary>
        /// <param name="encryptedWord">the encrypted word</param>
        /// <returns></returns>
        public static string DecryptWord(string encryptedWord)
        {
            byte[] toEncryptArray = Convert.FromBase64String(encryptedWord);
                   
            //if hashing was used get the hash code with regards to your key
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            var keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(_key));
            //release any resource held by the MD5CryptoServiceProvider
            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor                
            tdes.Clear();
            //return the Clear decrypted TEXT
            return Encoding.UTF8.GetString(resultArray);            
        }
    }
}
