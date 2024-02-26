using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlCenter.BL.Queries.Common;
using ControlCenter.Contracts.Contracts;
using ControlCenter.Entities.Models;

namespace ControlCenter.BL.Queries.Users
{
    public class GetUsersQuery : QueryBase<List<User>>
    {
        #region Constructor

        public GetUsersQuery(IRepository<User> userRepository)
        {
            UserRepository = userRepository;
        }

        #endregion Constructor

        #region Properties

        protected IRepository<User> UserRepository { get; }

        #endregion Properties

        #region Methods

        public override Task<List<User>> ExecuteAsync()
        {
            return UserRepository.AsQueryable()
                .Include(u => u.Department)
                .OrderBy(d => d.Name)
                .AsNoTracking()
                .ToListAsync();
        }

        #endregion Methods
    }
}
