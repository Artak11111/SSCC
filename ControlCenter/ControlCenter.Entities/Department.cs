using System.Collections.Generic;

namespace ControlCenter.Entities
{
    public class Department : EntityWithId
    {
        public string Name { get; set; }

        public List<User> Users { get; set; }
    }
}