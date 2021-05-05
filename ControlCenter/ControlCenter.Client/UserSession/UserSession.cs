using System;
using ControlCenter.Client.Managers.Models;

namespace ControlCenter.Client.UserSession
{
    public class UserSession
    {
        #region Events

        public event Action<bool> AuthenticationStateChanged;

        #endregion Events

        #region Properties

        public bool IsSessionStarted { get; private set; }

        public Guid? UserId { get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public Guid? DepartmentId { get; private set; }

        public string DepartmentName { get; private set; }

        #endregion Properties

        #region Methods

        public void StartSession(SignInResult signInResult)
        {
            UserId = signInResult.UserId;
            Name = signInResult.Name;
            Email = signInResult.Email;
            DepartmentId = signInResult.DepartmentId;
            DepartmentName = signInResult.DepartmentName;

            IsSessionStarted = true;

            AuthenticationStateChanged?.Invoke(IsSessionStarted);
        }

        public void EndSession()
        {
            IsSessionStarted = false;

            UserId = DepartmentId = null;
            DepartmentName = Name = Email = null;

            AuthenticationStateChanged?.Invoke(IsSessionStarted);
        }

        #endregion Methods
    }
}
