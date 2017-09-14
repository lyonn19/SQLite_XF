using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite_XF.Model;

namespace SQLite_XF.DAO
{
    public class PersonDao: BaseDatabase
    {
        private static PersonDao _instance;
        public static PersonDao Instance => _instance ?? (_instance = new PersonDao());
        private PersonDao()
        {
            DbConn.CreateTableAsync<Person>().Wait();
        }
        public async Task<IEnumerable<Person>> GetAllPeopleAsync()
        {
            try
            {
                return await DbConn.Table<Person>().ToListAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed to retrieve data. {0}", ex.Message);
            }
            return Enumerable.Empty<Person>();
        }
        public async Task AddNewPersonAsync(Person person)
        {
            try
            {
                var result = await DbConn.InsertAsync(person);
                System.Diagnostics.Debug.WriteLine("{0} record(s) added [Name: {1})", result, person.Name);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed to add {0}. Error: {1}", person.Name, ex.Message);
            }
        }
    }
}
