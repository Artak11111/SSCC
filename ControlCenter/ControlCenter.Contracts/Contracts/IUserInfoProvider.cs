﻿using System;

namespace ControlCenter.Contracts.Contracts
{
    public interface IUserInfoProvider
    {
        Guid CurrentDepartmentId { get; }

        Guid CurrentUserId { get; }

        void SetUserInfo(Guid currentUserId, Guid currentDepartmentId);
    }
}
