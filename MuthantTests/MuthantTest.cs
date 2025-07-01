using FluentAssertions;
using Muthant;
using Muthant.Profile_configuration;
using MystiqueMapperTests.Models;
using MystiqueMapperTests.Utils;

namespace MystiqueMapperTests
{
    public class MuthantTest
    {
        [Fact]
        public void Given_A_Company_Should_Copy_All_Values_To_CompanyDTO()
        {
            //Arrange
            var mapper = new MuthantMapper(new Profile());

            var origin = new Company()
            {
                Id = 1,
                Name = "Test",
                Active = true,
                //Addresses = new List<Address>
                //{
                //    new Address { Id = 1, Name ="Street of dumbs 1" },
                //    new Address { Id = 2, Name = "Street of dumbs 2" }
                //}
            };

            // Act 
            var destiny = mapper.Transmute<CompanyDTO>(origin);

            var res = UtilsService.CompareObjects(destiny, origin);

            //Assert
            res.Should().BeTrue();
        }

        [Fact]
        public void Given_A_CompanyDTO_Should_Copy_All_Values_To_Company()
        {
            //Arrange
            var mapper = new MuthantMapper(new Profile());

            var origin = new CompanyDTO()
            {
                Id = 1,
                Name = "Test",
                Active = true,
                Addresses = new List<Address>
                {
                    new Address { Id = 1, Name ="Street of dumbs 1" },
                    new Address { Id = 2, Name = "Street of dumbs 2" }
                }
            };

            // Act 
            var destiny = mapper.Transmute<Company>(origin);
            var res = UtilsService.CompareObjects(destiny, origin);

            //Assert
            res.Should().BeTrue();
        }

        //[Fact]
        //public void Given_A_List__Companies_Should_Copy_All_Values_To_CompanyDTO()
        //{
        //    //Arrange
        //    var mapper = new Mystique();

        //    var listOfOrigins = new List<Company>()
        //    {
        //        new Company()
        //        {
        //            Id = 1,
        //            Name = "Test",
        //            Active = true,
        //            Addresses = new List<Address>{
        //                new Address { Id = 1, Name ="Street of dumbs 1" },
        //                new Address { Id = 1, Name = "Street of dumbs 2" }
        //            }
        //        },

        //        new Company()
        //        {
        //            Id = 2,
        //            Name = "Test 2",
        //            Active = false,
        //            Addresses = new List<Address>{
        //                new Address { Id = 1, Name ="Street of dumbs 1" }, 
        //                new Address { Id = 1, Name = "Street of dumbs 2" }
        //            }  
        //        }
        //    };

        //    // Act 
        //    var destiny = mapper.Transmute<IEnumerable<CompanyDTO>>(listOfOrigins);
        //    var res = UtilsService.CompareObjects(destiny, listOfOrigins);

        //    //Assert
        //    res.Should().BeTrue();
        //}
    }
}