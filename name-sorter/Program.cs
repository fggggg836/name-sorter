using name_sorter;

Console.WriteLine( "Hello, World!" );
Console.WriteLine( args[0] );

var nameList = TextFileManager.ReadFile( args[0] );
        var nameSorter = new NameSorter( nameList );
        var sortedNames = nameSorter.SortNames();
        TextFileManager.WriteFile( sortedNames, "./sorted-names-list.txt" );

