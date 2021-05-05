using System;

namespace ControlCenter.Abstractions
{
    public interface IUserInfoProvider
    {
        Guid CurrentDepartmentId { get; }

        Guid CurrentUserId { get; }

        void SetUserInfo(Guid currentUserId, Guid currentDepartmentId);
    }
}
