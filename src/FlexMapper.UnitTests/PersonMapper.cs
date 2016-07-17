using System;

namespace SchwabenCode.FlexMapper.UnitTests
{
    /// <summary>
    /// Test Mapper
    /// </summary>
    internal class PersonMapper : FlexMapper<Person, PersonViewModel>, IPersonMapper
    {
        const string ISO8601DateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ";

        /// <summary>
        /// Map from <see cref="Person"/> to <see cref="PersonViewModel"/>
        /// </summary>
        public override PersonViewModel Map( Person t1, PersonViewModel t2 )
        {
            t2.Name = t1.Name;
            t2.DateOfBirth = t1.DateOfBirth.ToString( ISO8601DateTimeFormat ); // Json -> ISO 8601

            return t2;
        }

        /// <summary>
        /// Map from <see cref="PersonViewModel"/> to <see cref="Person"/>
        /// </summary>
        public override Person Map( PersonViewModel t1, Person t2 )
        {
            t2.Name = t1.Name;
            t2.DateOfBirth = DateTime.ParseExact( t1.DateOfBirth, ISO8601DateTimeFormat, null ).ToUniversalTime(); // Json -> ISO 8601

            return t2;
        }
    }
}
