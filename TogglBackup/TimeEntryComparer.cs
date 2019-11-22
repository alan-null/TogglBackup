using System.Collections.Generic;
using Toggl;

namespace TogglBackup
{
    internal class TimeEntryComparer : IEqualityComparer<TimeEntry>
    {
        public bool Equals(TimeEntry x, TimeEntry y)
        {
            return x.Id.Equals(y.Id);
        }

        public int GetHashCode(TimeEntry obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}