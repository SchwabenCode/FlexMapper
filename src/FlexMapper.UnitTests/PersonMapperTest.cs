using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SchwabenCode.FlexMapper.UnitTests
{
    public class PersonMapperTest
    {
        private static Person GetTestPerson()
        {
            return new Person
            {
                Name = "Benjamin Abt",
                DateOfBirth = new DateTime( 1987, 5, 31 )
            };
        }

        private static PersonViewModel GetTestPersonViewModel()
        {
            return new PersonViewModel
            {
                Name = "Benjamin Abt",
                DateOfBirth = "1987-05-31T00:00:00Z"
            };
        }


        [Fact]
        public void Test_ToSingleViewModel()
        {
            // Arrange
            Person person = GetTestPerson();
            IPersonMapper personMapper = new PersonMapper();

            // Act
            PersonViewModel result = personMapper.Map( person );

            // Assert
            PersonViewModel expected = GetTestPersonViewModel();

            Assert.Equal( expected.Name, result.Name );
            Assert.Equal( expected.DateOfBirth, result.DateOfBirth );
        }

        [Fact]
        public void Test_ToSingle()
        {
            // Arrange
            PersonViewModel personViewModel = GetTestPersonViewModel();
            IPersonMapper personMapper = new PersonMapper();

            // Act
            Person result = personMapper.Map( personViewModel );

            // Assert
            Person expected = GetTestPerson();

            Assert.Equal( expected.Name, result.Name );
            Assert.Equal( expected.DateOfBirth, result.DateOfBirth );
        }

        [Fact]
        public void Test_IList()
        {
            // Arrange
            int items = 5;
            IList<PersonViewModel> testModels = new List<PersonViewModel>();
            for( int i = 0 ;i < items ;i++ )
            {
                PersonViewModel personViewModel = GetTestPersonViewModel();
                testModels.Add( personViewModel );
            }

            IPersonMapper personMapper = new PersonMapper();

            // Act
            IList<Person> result = personMapper.Map( testModels );

            // Assert
            int expected = testModels.Count;

            Assert.Equal( expected, result.Count );
        }

        [Fact]
        public void Test_IEnumerable()
        {
            // Arrange
            int items = 5;
            IList<PersonViewModel> testModels = new List<PersonViewModel>();
            for( int i = 0 ;i < items ;i++ )
            {
                PersonViewModel personViewModel = GetTestPersonViewModel();
                testModels.Add( personViewModel );
            }

            IPersonMapper personMapper = new PersonMapper();

            // Act
            IEnumerable<Person> result = personMapper.Map( testModels.AsEnumerable() );

            // Assert
            int expected = testModels.Count;

            Assert.Equal( expected, result.Count() );
        }

        [Fact]
        public void Test_ICollection()
        {
            // Arrange
            int items = 5;
            ICollection<PersonViewModel> testModels = new List<PersonViewModel>();
            for( int i = 0 ;i < items ;i++ )
            {
                PersonViewModel personViewModel = GetTestPersonViewModel();
                testModels.Add( personViewModel );
            }

            IPersonMapper personMapper = new PersonMapper();

            // Act
            ICollection<Person> result = personMapper.Map( testModels );

            // Assert
            int expected = testModels.Count;

            Assert.Equal( expected, result.Count() );
        }

        [Fact]
        public void Test_IReadOnlyCollection()
        {
            // Arrange
            int items = 5;
            List<PersonViewModel> testModels = new List<PersonViewModel>();
            for( int i = 0 ;i < items ;i++ )
            {
                PersonViewModel personViewModel = GetTestPersonViewModel();
                testModels.Add( personViewModel );
            }

            IPersonMapper personMapper = new PersonMapper();

            // Act
            IReadOnlyCollection<Person> result = personMapper.Map( ( IReadOnlyCollection<PersonViewModel> ) testModels.AsReadOnly() );

            // Assert
            int expected = testModels.Count;

            Assert.Equal( expected, result.Count() );
        }
    }
}
