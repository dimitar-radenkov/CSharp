namespace _01.Countries_Towns.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Country
    {
        public Country(string name, 
            string flagSource, 
            string language, 
            int population,
            List<string > towns)
        {
            this.Name = name;
            this.FlagSource = flagSource;
            this.Language = language;
            this.Population = population;
            this.Towns = towns;
        }

        public string Name { get; set; }
        public string FlagSource { get; set; }
        public string Language { get; set; }
        public int Population { get; set; }
        public List<string> Towns { get; set; }
    }
}
