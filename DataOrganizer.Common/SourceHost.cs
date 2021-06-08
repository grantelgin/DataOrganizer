using System;
using System.Collections.Generic;
using System.Text;

namespace DataOrganizer.Common
{
    public class SourceHost : Entity
    {
        private SourceHost(SOURCEHOSTTYPE sourceHostType, SourceHostConnection sourceHostConnection, long nID) : base(nID)
        {
            SourceHostType = sourceHostType;
            SourceHostConnection = sourceHostConnection ?? throw new ArgumentNullException(nameof(sourceHostConnection));
        }

        public SOURCEHOSTTYPE SourceHostType { get; private set; }
        public SourceHostConnection SourceHostConnection { get; private set; }
        public static SourceHost LocalDrive(string sLocator)
        {
            SourceHostConnection sourceConn = SourceHostConnection.ForLocalDrive(sLocator);
            long nID = SourceHostEntityService.GetID(sourceConn);
            return new SourceHost(SOURCEHOSTTYPE.Local, sourceConn, nID);
        }
    }
}
