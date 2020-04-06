using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    class Dog
    {
        public string Name { private set; get; }

        public string categories { private set; get; }

        public Dog(string name, string categories)
        {
            this.Name = name;
            this.categories = categories;
        }
    }
}
