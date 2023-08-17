
using E470CodeChallenge.Controllers;
using E470CodeChallenge.DbContexts;
using E470CodeChallenge.Entities;
using E470CodeChallenge.Events.Vehicular;
using E470CodeChallenge.Factories;
using E470CodeChallenge.Model;
using E470CodeChallenge.Repositories;
using E470CodeChallenge.Services;

using Microsoft.Extensions.Logging;
using Moq;

namespace E470CodeChallenge.Tests.Controllers
{
    public class TransponderFactoryTest
    {
        private readonly Mock<E470DbContext> _context = new();
    
        [Theory]
        [InlineData(2022)]
        [InlineData(2010)]
        [InlineData(1999)]
        public void Get_Class_Repository(short year)
        {
            TransponderRepositoryFactory factory = CreateFactory();
            Assert.IsType<ModernTransponderRepository>(factory.GetTransponderRepository(year));
        }

        [Theory]
        [InlineData(1950)]
        [InlineData(1995)]
        [InlineData(1970)]
        public void Get_Modern_Repository(short year)
        {
            TransponderRepositoryFactory factory = CreateFactory();
            Assert.IsType<ClassicTransponderRepository>(factory.GetTransponderRepository(year));
        }

        private TransponderRepositoryFactory CreateFactory() => 
            new(_context.Object);
    }
}
