using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    internal class TextFileManager
    {
        public static List<string> ReadNamesFromFile(string path)
        {
            List<string> nameList = [];
            string line;
            try
            {
                StreamReader sr = new( path );

                line = sr.ReadLine();
                nameList.Add( line );

                while(line != null)
                {
                    line = sr.ReadLine();
                    nameList.Add( line );
                }
                sr.Close();
                return nameList;
            }
            catch(Exception e)
            {
                Console.WriteLine( "Error reading file: " + e.Message );
                return nameList;
            }
        }

        public static void WriteNamesToFile( List<string> names, string path )
        {
            try
            {
                StreamWriter sw = new( path );
                foreach( string name in names )
                {
                    sw.WriteLine( name );
                    Console.WriteLine(name);
                }
                sw.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine( "Error writing to file: " + e.Message );
            }
        }

    }
}
