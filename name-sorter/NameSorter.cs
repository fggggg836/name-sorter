using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    internal class NameSorter
    {
        private List<Name> names;
        public NameSorter(List<string> nameList) 
        {
            names = new List<Name>();
            foreach (var name in nameList)
            {
                if (name != null)
                names.Add(new Name(name));
            }
        }

        public List<string> SortNames()
        {
            var sortedNames = names
                .OrderBy( n => n.lastName )
                .ThenBy( n => n.firstNames )
                .Select( n => n.fullName )
                .ToList();
            return sortedNames;
        }

    }

    internal class Name
    {
        public string lastName;
        public List<string> firstNames;
        public string fullName;

        public Name(string nameListLine)
        {
            var nameArr = nameListLine.Split(' ').ToList();
            lastName = nameArr.Last();
            firstNames = nameArr[..^1];
            fullName = nameListLine;
        }
    }
}

