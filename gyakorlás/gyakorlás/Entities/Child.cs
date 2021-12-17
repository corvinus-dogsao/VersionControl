using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gyakorlás.Entities
{
    public class Child
    {
        public string Name { get; set; }
        public Behaviour Behaviour { get; set; }

        public bool CheckBehaviour(int number)
        {
            if (number > 0 && number < 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Gift> gifts;
    }
}
