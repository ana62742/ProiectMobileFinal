using ProiectMobileFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMobileFinal.Services
{
    public interface IConcertService
    {
        Task<List<ConcertModel>> GetConcertList();
        Task<int> AddConcert(ConcertModel concertModel);
        Task<int> DeleteConcert(ConcertModel concertModel);
        Task<int> UpdateConcert(ConcertModel concertModel);

    }
}