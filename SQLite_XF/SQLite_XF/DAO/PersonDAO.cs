using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLite_XF.Model;

namespace SQLite_XF.DAO
{
    public class PersonDao
    {
        private static PersonDao _instance;

        public static PersonDao Instance
        {
            get
            {
                if (_instance == null)
                    throw new Exception(
                        "You must call Initialize before retrieving the singleton for the PersonRepository.");

                return _instance;
            }
        }

        public static void Initialize(string filename)
        {
            if (filename == null)
                throw new ArgumentNullException(nameof(filename));

            // TODO: dispose any existing connection
            _instance?._conn.GetConnection().Dispose();

            _instance = new PersonDao(filename);
        }

        public string StatusMessage { get; set; }

        private readonly SQLiteAsyncConnection _conn;

        private PersonDao(string dbPath)
        {
            // TODO: Initialize a new SQLiteConnection
            _conn = new SQLiteAsyncConnection(dbPath);
            // TODO: Create the Person table
            _conn.CreateTableAsync<Person>().Wait();
        }

        public async Task AddNewPersonAsync(string name)
        {
            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                // TODO: insert a new person into the Person table
                var result = await _conn.InsertAsync(new Person {Name = name});

                StatusMessage = $"{result} record(s) added [Name: {name})";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to add {name}. Error: {ex.Message}";
            }
        }

        public async Task<IEnumerable<Person>> GetAllPeopleAsync()
        {
            try
            {
                // TODO: return the Person table in the database
                return await _conn.Table<Person>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to retrieve data. {ex.Message}";
            }

            return Enumerable.Empty<Person>();
        }
    

        /*
        public CodeDatabase()
        {
            //_database = new SQLiteAsyncConnection(dbPath);
            _dbConn.CreateTableAsync<Code>().Wait();
        }
        public Task<List<Code>> GetAllCode()
        {
            return _dbConn.Table<Code>().ToListAsync();  
        }

        public Task<int> SaveCode(Code aCode)
        {
            return _dbConn.InsertAsync(aCode);
        }
        public Task<int> DeleteCode(Code aCode)
        {
      
            return _dbConn.DeleteAsync(aCode);        
            
        }
        public Task<int> EditCode(Code aCode)
        {
            return _dbConn.UpdateAsync(aCode);       
        }
        */

    }
}
