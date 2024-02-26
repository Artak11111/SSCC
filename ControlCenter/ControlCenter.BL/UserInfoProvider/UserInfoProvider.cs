using ControlCenter.Contracts.Contracts;

using System;

namespace ControlCenter.BL.UserInfoProvider
{
    public class UserInfoProvider : IUserInfoProvider
    {
        public Guid CurrentDepartmentId { get; private set; }

        public Guid CurrentUserId { get; private set; }

        public void SetUserInfo(Guid currentUserId, Guid currentDepartmentId)
        {
            CurrentDepartmentId = currentDepartmentId;
            CurrentUserId = currentUserId;
        }
    }
}
