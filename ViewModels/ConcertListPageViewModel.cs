using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProiectMobileFinal.Models;
using ProiectMobileFinal.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMobileFinal.ViewModels
{
    public partial class ConcertListPageViewModel : ObservableObject
    {
        public static List<ConcertModel> ConcertsListForSearch { get; private set; } = new List<ConcertModel>();
        public ObservableCollection<ConcertModel> Concerts { get; set; } = new ObservableCollection<ConcertModel>();

        private readonly IConcertService _concertService;
        public ConcertListPageViewModel(IConcertService studentService)
        {
            _concertService = studentService;
        }



        [RelayCommand]
        public async void GetConcertList()
        {
            Concerts.Clear();
            var concertList = await _concertService.GetConcertList();
            if (concertList?.Count > 0)
            {
                concertList = concertList.OrderBy(f => f.Name).ToList();
                foreach (var concert in concertList)
                {
                    Concerts.Add(concert);
                }
                ConcertsListForSearch.Clear();
                ConcertsListForSearch.AddRange(concertList);
            }
        }


        [RelayCommand]
        public async void AddUpdateConcert()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateConcert));
        }


        [RelayCommand]
        public async void DisplayAction(ConcertModel concertModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("ConcertDetail", concertModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateConcert), navParam);
            }
            else if (response == "Delete")
            {
                var delResponse = await _concertService.DeleteConcert(concertModel);
                if (delResponse > 0)
                {
                    GetConcertList();
                }
            }
        }
    }
}
