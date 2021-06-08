using System;
using System.Collections.Generic;
using System.Text;

namespace DataOrganizer.Common
{
    public class SourceHostConnection
    {
        protected SourceHostConnection(SOURCEHOSTTYPE sourceHostType, string locator, string userName, string password, string secretKey)
        {
            SourceHostType = sourceHostType;
            Locator = locator ?? throw new ArgumentNullException(nameof(locator));
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            SecretKey = secretKey ?? throw new ArgumentNullException(nameof(secretKey));
        }

        public SOURCEHOSTTYPE SourceHostType { get; private set; }
        public string Locator { get; private set; }
        public string  UserName { get; private set; }
        public string Password { get; private set; }
        public string SecretKey { get; private set; }


        public static SourceHostConnection ForLocalDrive(string sLocator)
        {
            return new SourceHostConnection(SOURCEHOSTTYPE.Local, sLocator, "", "", "");
        }
        
    }
}
