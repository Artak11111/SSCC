using ControlCenter.Abstractions;
using ControlCenter.BL.Exceptions;
using ControlCenter.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlCenter.BL.Queries.Users
{
    public class GetUsersQuery
    {
        #region Fields

        private readonly IRepository<User> userRepository;
        private readonly IUserInfoProvider userInfoProvider;

        #endregion Fields

        #region Constructor

        public GetUsersQuery(IUserInfoProvider userInfoProvider, IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
            this.userInfoProvider = userInfoProvider;
        }

        #endregion Constructor

        #region Methods

        public async Task<List<User>> Execute()
        {
            // validations
            await ValidateInput();

            return await userRepository.AsQueryable()
                .Include(u=>u.Department)
                .OrderBy(d=> d.Name)
                .AsNoTracking()
                .ToListAsync();
        }

        private async Task ValidateInput()
        {
            if (!await userRepository.AnyAsync(u => u.Id == userInfoProvider.CurrentUserId))
                throw new BusinessException("User not found");
        }

        #endregion Methods
    }
}
