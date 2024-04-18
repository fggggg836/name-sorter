using name_sorter;
using System.Linq;
using Xunit.Sdk;

namespace name_sorter_tests
{
    [TestClass]
    public class NameSorterTests
    {
        [TestMethod]
        public void Name_Constructor_CreateNameObject()
        {
            var nameString = "Firstname Lastname";
            var name = new Name( nameString );

            Assert.IsNotNull( name );
            Assert.AreEqual( name.LastName, "Lastname" );
            Assert.AreEqual( name.FirstNames.First(), "Firstname" );
            Assert.AreEqual( name.FullName, "Firstname Lastname" );
        }

        [TestMethod]
        public void Name_Constructor_CreateNameObjectWithMultipleFirstnames()
        {
            var nameString = "Firstname1 Firstname2 Firstname3 Lastname";
            var name = new Name( nameString );

            Assert.AreEqual( name.FirstNames.ElementAt( 0 ), "Firstname1" );
            Assert.AreEqual( name.FirstNames.ElementAt( 1 ), "Firstname2" );
            Assert.AreEqual( name.FirstNames.ElementAt( 2 ), "Firstname3" );
            Assert.AreEqual( name.FirstNames.Count, 3 );
        }

        [TestMethod]
        public void NameSorter_Constructor_CreateNameList()
        {
            var nameList = new List<string>
            {
                "Firstname1 Lastname1",
                "Firstname2 Lastname2"
            };
            var nameSorter = new NameSorter(nameList);

            Assert.AreEqual( nameSorter.Names.ElementAt( 0 ).LastName, "Lastname1" );
            Assert.AreEqual( nameSorter.Names.ElementAt( 0 ).FirstNames.First(), "Firstname1" );
            Assert.AreEqual( nameSorter.Names.ElementAt( 0 ).FullName, "Firstname1 Lastname1" );

            Assert.AreEqual( nameSorter.Names.ElementAt( 1 ).LastName, "Lastname2" );
            Assert.AreEqual( nameSorter.Names.ElementAt( 1 ).FirstNames.First(), "Firstname2" );
            Assert.AreEqual( nameSorter.Names.ElementAt( 1 ).FullName, "Firstname2 Lastname2" );

            Assert.AreEqual( nameSorter.Names.Count, 2 );

            Assert.IsNotNull( nameSorter );
            Assert.IsInstanceOfType( nameSorter, typeof( NameSorter ) );
        }

        [TestMethod]
        public void NameSorter_SortNames_SortNameList()
        {
            var nameList = new List<string>
            {
                "Firstname3 Lastname3",
                "Firstname2 Lastname2",
                "Firstname1 Lastname1"
            };
            var nameSorter = new NameSorter( nameList );
            var sortedNames = nameSorter.SortNames();

            Assert.AreEqual( sortedNames.ElementAt( 0 ), "Firstname1 Lastname1" );
            Assert.AreEqual( sortedNames.ElementAt( 1 ), "Firstname2 Lastname2" );
            Assert.AreEqual( sortedNames.ElementAt( 2 ), "Firstname3 Lastname3" );

            Assert.AreEqual( sortedNames.Count, 3 );
        }

        [TestMethod]
        public void NameSorter_SortNames_FilterOutEmpty()
        {
            var nameList = new List<string>
            {
                "Firstname2 Lastname2",
                "",
                "Firstname1 Lastname1"
            };
            var nameSorter = new NameSorter( nameList );
            var sortedNames = nameSorter.SortNames();

            Assert.AreEqual( sortedNames.ElementAt( 0 ), "Firstname1 Lastname1" );
            Assert.AreEqual( sortedNames.ElementAt( 1 ), "Firstname2 Lastname2" );

            Assert.AreEqual( sortedNames.Count, 2 );
        }

    }
}