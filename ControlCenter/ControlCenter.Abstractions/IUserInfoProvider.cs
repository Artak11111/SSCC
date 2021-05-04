using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter.Abstractions
{
    public interface IUserInfoProvider
    {
        Guid CurrentDepartmentId { get; }

        Guid CurrentUserId { get; }

        void SetUserInfo(Guid currentUserId, Guid currentDepartmentId);
    }
}
