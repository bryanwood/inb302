using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFiles.Domain.Entities;
namespace UFiles.Domain.Abstract
{
    public interface IRestrictionService
    {
        void AddUserRestriction(int fileId, int[] userIds);
        void AddGroupRestriction(int fileId, int[] groupIds);
        void AddTimeRangeRestriction(int fileId, TimeRange[] timeRanges);
        void AddIPRestriction(int fileId, string[] ips);
    }
}
