using System;
using System.Reflection;

namespace DPAPI
{
    public sealed class Encryption
    {
        private static readonly string product = ( ( AssemblyProductAttribute ) Attribute.GetCustomAttribute ( Assembly.GetExecutingAssembly (), typeof ( AssemblyProductAttribute ), false ) ).Product;

        public static string DecryptValue (string textToDecrypt, string description)
        {
            try
            {
                var newProduct = PwC.Framework.Encrypt.Md5.EncryptMd5 ( product );
                var deCrypted = EncryptionDPAPI.DecryptValue ( textToDecrypt, newProduct, out description );

                return deCrypted;
            }
            catch ( Exception ex )
            {
                throw new Exception( "Couldn't decrypt the text inputed..."  + ex.Message);
            }

            throw new Exception ( "Error DecryptValue" );
        }

        public static string EncryptValue (string textToEncrypt, string description, EncryptionDPAPI.KeyType encryptType)
        {
            try
            {
               
                var newProduct = PwC.Framework.Encrypt.Md5.EncryptMd5 ( product );

                var encrypted = EncryptionDPAPI.EncryptValue (  encryptType, textToEncrypt, newProduct, description );

                return encrypted;
            }
            catch ( Exception ex )
            {
               throw new Exception ( "Couln't encrypt the text readed..." + ex.Message);
            }

            throw new Exception ( "Error EncryptValue" );
        }

    }
}
