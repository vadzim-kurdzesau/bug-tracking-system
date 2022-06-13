using System;
using System.Collections.Generic;
using BugTrackingSystem.Persistence.Models;

namespace BugTrackingSystem.Tests.Comparers
{
    internal class BugComparer : IEqualityComparer<Bug>
    {
        public bool Equals(Bug x, Bug y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Id == y.Id && x.Description == y.Description && x.UpdateDate.Equals(y.UpdateDate) && x.BugTypeId == y.BugTypeId && x.BugStatusId == y.BugStatusId && x.ProjectId == y.ProjectId && x.DeveloperId == y.DeveloperId;
        }

        public int GetHashCode(Bug obj)
        {
            return HashCode.Combine(obj.Id, obj.Description, obj.UpdateDate, obj.BugTypeId, obj.BugStatusId, obj.ProjectId, obj.DeveloperId);
        }
    }
}
