using E470CodeChallenge.Repositories;

namespace E470CodeChallenge.Factories
{
    public interface ITransponderRepositoryFactory
    {
        /// <summary>
        /// This method gets the correct transponder for the given year. I change this to short as the year is limited to 4 digits. 
        /// In addition there are ways I can may this completely open for extension by adding a config that has a value and name
        /// of the class. Then the values are checked in range and the name of the class is created via the Activator class. 
        /// However this has overhead, and the need to add new types of repositories is limited to the factory code. I find this
        /// to be a reasonable solution for the code challenge. 
        /// </summary>
        /// <param name="year">The year to look at.</param>
        /// <returns>The Transponder repository</returns>
        ITransponderRepository GetTransponderRepository(short year);
    }
}
