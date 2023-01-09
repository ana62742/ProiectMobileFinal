using ProiectMobileFinal.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMobileFinal.Services
{
    public class ConcertService : IConcertService
    {
        private SQLiteAsyncConnection _dbConnection;
        public ConcertService()
        {
            SetUpDb();
        }

        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Concert.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<ConcertModel>();
            }
        }
        public async Task<int> AddConcert(ConcertModel concertModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(concertModel);
        }

        public async Task<int> DeleteConcert(ConcertModel concertModel)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(concertModel);
        }

        public async Task<List<ConcertModel>> GetConcertList()
        {
            await SetUpDb();
            var concertList = await _dbConnection.Table<ConcertModel>().ToListAsync();
            return concertList;
        }

        public async Task<int> UpdateConcert(ConcertModel concertModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(concertModel);
        }
    }
}
