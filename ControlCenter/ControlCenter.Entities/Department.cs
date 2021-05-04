using System.Collections.Generic;

namespace ControlCenter.Entities
{
    public class Department : EntityBase
    {
        public string Name { get; set; }

        public List<User> Users { get; set; }
    }
}