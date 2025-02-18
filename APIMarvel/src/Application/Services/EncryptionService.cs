using System.Security.Cryptography;
using System.Text;

namespace APIMarvel.src.Application.Services
{
    public class EncryptionService
    {
        private readonly string _key;

        public EncryptionService(string key)
        {
            _key = key;
        }

        public string Encrypt(string plainText)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(_key);
            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes.Take(32).ToArray(); // Asegurar que la clave es de 256 bits
                aes.GenerateIV();

                using (var encryptor = aes.CreateEncryptor())
                {
                    byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                    byte[] encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

                    // Concatenar IV + Data Encriptada
                    byte[] result = new byte[aes.IV.Length + encryptedBytes.Length];
                    Buffer.BlockCopy(aes.IV, 0, result, 0, aes.IV.Length);
                    Buffer.BlockCopy(encryptedBytes, 0, result, aes.IV.Length, encryptedBytes.Length);

                    return Convert.ToBase64String(result);
                }
            }
        }

        public string Decrypt(string encryptedText)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(_key);
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes.Take(32).ToArray();

                // Extraer IV
                byte[] iv = new byte[aes.BlockSize / 8];
                byte[] cipherBytes = new byte[encryptedBytes.Length - iv.Length];

                Buffer.BlockCopy(encryptedBytes, 0, iv, 0, iv.Length);
                Buffer.BlockCopy(encryptedBytes, iv.Length, cipherBytes, 0, cipherBytes.Length);

                aes.IV = iv;

                using (var decryptor = aes.CreateDecryptor())
                {
                    byte[] decryptedBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                    return Encoding.UTF8.GetString(decryptedBytes);
                }
            }
        }
    }
}
