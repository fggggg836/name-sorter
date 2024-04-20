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
            var nameString = "Forename Lastname";
            var name = new Name( nameString );

            Assert.IsNotNull( name );
            Assert.AreEqual( name.LastName, "Lastname" );
            Assert.AreEqual( name.Forename1, "Forename" );
            Assert.AreEqual( name.FullName, "Forename Lastname" );
        }

        [TestMethod]
        public void Name_Constructor_CreateNameObjectWithMultipleForenames()
        {
            var nameString = "Forename1 Forename2 Forename3 Lastname";
            var name = new Name( nameString );

            Assert.AreEqual( name.Forename1, "Forename1" );
            Assert.AreEqual( name.Forename2, "Forename2" );
            Assert.AreEqual( name.Forename3, "Forename3" );
        }

        [TestMethod]
        public void NameSorter_Constructor_CreateNameList()
        {
            var nameList = new List<string>
            {
                "Forename1 Lastname1",
                "Forename2 Lastname2"
            };
            var nameSorter = new NameSorter(nameList);

            Assert.AreEqual( nameSorter.Names.ElementAt( 0 ).LastName, "Lastname1" );
            Assert.AreEqual( nameSorter.Names.ElementAt( 0 ).Forename1, "Forename1" );
            Assert.AreEqual( nameSorter.Names.ElementAt( 0 ).FullName, "Forename1 Lastname1" );

            Assert.AreEqual( nameSorter.Names.ElementAt( 1 ).LastName, "Lastname2" );
            Assert.AreEqual( nameSorter.Names.ElementAt( 1 ).Forename1, "Forename2" );
            Assert.AreEqual( nameSorter.Names.ElementAt( 1 ).FullName, "Forename2 Lastname2" );

            Assert.AreEqual( nameSorter.Names.Count, 2 );

            Assert.IsNotNull( nameSorter );
            Assert.IsInstanceOfType( nameSorter, typeof( NameSorter ) );
        }

        [TestMethod]
        public void NameSorter_SortNames_SortNameList()
        {
            var nameList = new List<string>
            {
                "Forename3 Lastname3",
                "Forename2 Lastname2",
                "Forename1 Lastname1"
            };
            var nameSorter = new NameSorter( nameList );
            var sortedNames = nameSorter.SortNames();

            Assert.AreEqual( sortedNames.ElementAt( 0 ), "Forename1 Lastname1" );
            Assert.AreEqual( sortedNames.ElementAt( 1 ), "Forename2 Lastname2" );
            Assert.AreEqual( sortedNames.ElementAt( 2 ), "Forename3 Lastname3" );

            Assert.AreEqual( sortedNames.Count, 3 );
        }

        [TestMethod]
        public void NameSorter_SortNames_FilterOutEmpty()
        {
            var nameList = new List<string>
            {
                "Forename2 Lastname2",
                "",
                "Forename1 Lastname1"
            };
            var nameSorter = new NameSorter( nameList );
            var sortedNames = nameSorter.SortNames();

            Assert.AreEqual( sortedNames.ElementAt( 0 ), "Forename1 Lastname1" );
            Assert.AreEqual( sortedNames.ElementAt( 1 ), "Forename2 Lastname2" );

            Assert.AreEqual( sortedNames.Count, 2 );
        }

        [TestMethod]
        public void NameSorter_SortNames_HandlesDoubleSpace()
        {
            var nameList = new List<string>
            {
                "Forename2  Lastname2",
                "Forename1 Lastname1"
            };
            var nameSorter = new NameSorter( nameList );
            var sortedNames = nameSorter.SortNames();

            Assert.AreEqual( sortedNames.ElementAt( 0 ), "Forename1 Lastname1" );
            Assert.AreEqual( sortedNames.ElementAt( 1 ), "Forename2  Lastname2" );

            Assert.AreEqual( sortedNames.Count, 2 );
        }

        [TestMethod]
        public void NameSorter_SortNames_HandlesMultipleForenames()
        {
            var nameList = new List<string>
            {
                "Forename1 Secondname1 Thirdname2 Lastname1",
                "Forename1 Secondname1 Thirdname1 Lastname1"
            };
            var nameSorter = new NameSorter( nameList );
            var sortedNames = nameSorter.SortNames();

            Assert.AreEqual( sortedNames.ElementAt( 0 ), "Forename1 Secondname1 Thirdname1 Lastname1" );
            Assert.AreEqual( sortedNames.ElementAt( 1 ), "Forename1 Secondname1 Thirdname2 Lastname1" );

            Assert.AreEqual( sortedNames.Count, 2 );
        }

        [TestMethod]
        public void NameSorter_SortNames_HandlesNamesWithDifferentNumbersOfForenames()
        {
            var nameList = new List<string>
            {
                "Forename1 Secondname1 Thirdname1 Lastname1",
                "Forename1 Secondname1 Lastname1"
            };
            var nameSorter = new NameSorter( nameList );
            var sortedNames = nameSorter.SortNames();

            Assert.AreEqual( sortedNames.ElementAt( 0 ), "Forename1 Secondname1 Lastname1" );
            Assert.AreEqual( sortedNames.ElementAt( 1 ), "Forename1 Secondname1 Thirdname1 Lastname1" );

            Assert.AreEqual( sortedNames.Count, 2 );
        }


        [TestMethod]
        public void NameSorter_SortNames_HandlesEmptyList()
        {
            var nameList = new List<string>();
            var nameSorter = new NameSorter( nameList );
            var sortedNames = nameSorter.SortNames();

            Assert.AreEqual( sortedNames.Count, 0 );
        }
    }
}