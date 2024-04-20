using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    public class NameSorter
    {
        public List<Name> Names { get; set; }
        public NameSorter(List<string> nameList) 
        {
            Names = [];
            foreach (var name in nameList)
            {
                if(name != "" && name != null)
                {
                    Names.Add( new Name( name ) );
                }
            }
        }

        public List<string> SortNames()
        {
            var sortedNames = Names
                .OrderBy( n => n.LastName )
                .ThenBy( n => n.FirstNames )
                .Select( n => n.FullName )
                .ToList();
            return sortedNames;
        }

    }

    public class Name
    {
        public string LastName { get; set; }
        public List<string> FirstNames { get; set; }
        public string FullName { get; set; }

        public Name(string nameListLine)
        {
            var nameArr = nameListLine.Split(' ').ToList();
            LastName = nameArr.Last();
            FirstNames = nameArr[..^1];
            FullName = nameListLine;
        }
    }
}

