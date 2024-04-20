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
                .ThenBy( n => n.Forename1 )
                .ThenBy( n => n.Forename2 )
                .ThenBy( n => n.Forename3 )
                .Select( n => n.FullName )
                .ToList();
            return sortedNames;
        }

    }

    public class Name
    {
        public string LastName { get; set; }
        public string Forename1 { get; set; }
        public string Forename2 { get; set; }
        public string Forename3 { get; set; }
        public string FullName { get; set; }

        public Name(string nameListLine)
        {
            var nameArr = nameListLine.Split(' ').ToList();
            LastName = nameArr.Last();
            Forename1 = nameArr.First();
            Forename2 = nameArr.Count > 2 ? nameArr[1] : "";
            Forename3 = nameArr.Count == 4 ? nameArr[2] : "";
            FullName = nameListLine;
        }
    }
}

