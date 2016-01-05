using System.Collections.Generic;

namespace Model
{
    public class User
    {
        public string Name { get; set; }
        public List<Issue> Issues { get; set; }
    }
}
