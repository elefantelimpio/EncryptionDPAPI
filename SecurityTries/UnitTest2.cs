using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.InteropServices;
using System.Security;

namespace SecurityTries
{
    /// <summary>
    /// Summary description for UnitTest2
    /// </summary>
    [TestClass]
    public class UnitTest2
    {
        public UnitTest2 ()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //TODO: http://www.obviex.com/samples/dpapi.aspx

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void TEST3()
        {
            try
            {
                string text = "1234";
                string entropy = null;
                string description;

                Console.WriteLine ( "Plaintext: {0}\r\n", text );

                // Call DPAPI to encrypt data with user-specific key.
                string encrypted = DPAPI.Encrypt ( DPAPI.KeyType.UserKey,
                                                  text,
                                                  entropy,
                                                  "My Data" );
                Console.WriteLine ( "Encrypted: {0}\r\n", encrypted );

                // Call DPAPI to decrypt data.
                string decrypted = DPAPI.Decrypt ( encrypted,
                                                    entropy,
                                                out description );
                Console.WriteLine ( "Decrypted: {0} <<<{1}>>>\r\n",
                                   decrypted, description );
            }
            catch ( Exception ex )
            {
                while ( ex != null )
                {
                    Console.WriteLine ( ex.Message );
                    ex = ex.InnerException;
                }
            }
        }
        
    }
}
