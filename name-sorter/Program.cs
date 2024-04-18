using name_sorter;

var nameList = TextFileManager.ReadNamesFromFile( args[0] );
var nameSorter = new NameSorter( nameList );
var sortedNames = nameSorter.SortNames();
TextFileManager.WriteNamesToFile( sortedNames, "./sorted-names-list.txt" );