namespace _01.Countries_Towns.ViewModels
{
    using _01.Countries_Towns.Models;
    using _01.Countries_Towns.ViewModels.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class MainPageViewModel : ViewModelBase
    {
        public List<Country> Countries { get; set; }

        public List<string> CountryNames
        {
            get
            {
                var names =
                    from c in Countries
                    select c.Name;

                return names.ToList();
            }
        }

        private Country country;
        public Country Country 
        {
            get { return country; }
            set 
            {
                this.country = value;
                base.OnPropertyChanged("Country");
            }
        }
        
        public MainPageViewModel(List<Country> countries)
        {
            this.Countries = countries;
            this.Country = countries.FirstOrDefault();
        }
    }
}
