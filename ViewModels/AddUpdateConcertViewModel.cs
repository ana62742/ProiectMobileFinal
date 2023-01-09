using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProiectMobileFinal.Models;
using ProiectMobileFinal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMobileFinal.ViewModels
{
    [QueryProperty(nameof(ConcertDetail), "ConcertDetail")]
    public partial class AddUpdateConcertViewModel : ObservableObject
    {
        [ObservableProperty]
        private ConcertModel _concertDetail = new ConcertModel();

        private readonly IConcertService _concertService;
        public AddUpdateConcertViewModel(IConcertService concertService)
        {
            _concertService = concertService;
        }

        [RelayCommand]
        public async void AddUpdateConcert()
        {
            int response = -1;
            if (ConcertDetail.ID > 0)
            {
                response = await _concertService.UpdateConcert(ConcertDetail);
            }
            else
            {
                response = await _concertService.AddConcert(new Models.ConcertModel
                {
                    Name = ConcertDetail.Name,
                    Description = ConcertDetail.Description,
                    Date = ConcertDetail.Date,
                    Image = ConcertDetail.Image,
                });
            }



            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Concert Info Saved", "Record Saved", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Heads Up!", "Something went wrong while adding record", "OK");
            }
        }

    }
}

