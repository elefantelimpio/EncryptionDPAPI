using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DPAPI
{
    class Program
    {
        private static readonly string product = ( ( AssemblyProductAttribute ) Attribute.GetCustomAttribute ( Assembly.GetExecutingAssembly (), typeof ( AssemblyProductAttribute ), false ) ).Product;

        static void Main (string [] args)
        {

            ConsoleKernel32.EnableQuickEditMode ();

            int encryptDecrypt = 0;
            int encryptType = 0;

            Console.WriteLine ( "Select option: 1 decrypt, 2 encrypt: " );
            encryptDecrypt = int.Parse ( Console.ReadLine () );

            Console.WriteLine ( " Select keyTipe: 1 UserKey, 2 MachineKey" );
            encryptType = int.Parse ( Console.ReadLine () );

            switch ( encryptDecrypt )
            {
                case 1:
                    DecryptValue ();
                    break;
                case 2:
                    EncryptValue ( encryptType );
                    break;
                default:
                    Console.WriteLine ( "ERR=R" );
                    break;
            }

            Console.ReadKey ();
        }


        private static void DecryptValue ()
        {
            try
            {
                Console.WriteLine ( "Text to Decrypt: " );

                var desc = "Description";
                string toDecrypt = Console.ReadLine ();

                var newProduct = PwC.Framework.Encrypt.Md5.EncryptMd5 ( product );
                var deCrypted = EncryptionDPAPI.DecryptValue ( toDecrypt, newProduct, out desc );


                Console.WriteLine ( deCrypted );
            }
            catch ( Exception ex )
            {
                Console.WriteLine ( "Couldn't decrypt the text inputed..." );
            }

            Console.ReadKey ();
        }

        private static void EncryptValue (int encryptType)
        {
            try
            {
                Console.WriteLine ( "Text to Encrypt: " );
                string toEncrypt = Console.ReadLine ();
                var newProduct = PwC.Framework.Encrypt.Md5.EncryptMd5 ( product );

                var encrypted = EncryptionDPAPI.EncryptValue ( ( EncryptionDPAPI.KeyType ) encryptType, toEncrypt, newProduct, "Description" );

                Console.WriteLine ( encrypted );
            }
            catch ( Exception ex )
            {
                Console.WriteLine ( "Couln't encrypt the text readed..." );
            }

            Console.ReadKey ();
        }

    }
}
