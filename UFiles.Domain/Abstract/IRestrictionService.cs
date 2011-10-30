using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFiles.Domain.Entities;
namespace UFiles.Domain.Abstract
{
    public interface IRestrictionService
    {
        /// <summary>
        /// Adds a user restriction to the specified file
        /// </summary>
        /// <param name="fileId">id of the file to add the user restriction to</param>
        /// <param name="userIds">an array of user ids to restrict access to</param>
        void AddUserRestriction(int fileId, int[] userIds);

        /// <summary>
        /// Adds a group restriction to the specified file
        /// </summary>
        /// <param name="fileId">id of the file to add the group restriction to</param>
        /// <param name="groupIds">an array of group ids to restrict access to</param>
        void AddGroupRestriction(int fileId, int[] groupIds);

        /// <summary>
        /// Adds a time range restriction to the specified file
        /// </summary>
        /// <param name="fileId">id of the file to add the time range restriction to</param>
        /// <param name="timeRanges">an array of time ranges to restrict access to</param>
        void AddTimeRangeRestriction(int fileId, TimeRange[] timeRanges);

        /// <summary>
        /// Adds an ip restriction to the specified file
        /// </summary>
        /// <param name="fileId">id of the file to add the ip restriction to</param>
        /// <param name="ips">an array of ips to restrict access to</param>
        void AddIPRestriction(int fileId, string[] ips);
    }
}
