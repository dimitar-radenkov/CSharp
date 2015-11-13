namespace _06.PhoneBook
{
    using System;

    class PhoneRecord
    {
        public string Name { get; set; }
        public string Town { get; set; }
        public string Phone { get; set; }

        public PhoneRecord(string name, string town, string phone)
        {
            this.Name = name;
            this.Town = town;
            this.Phone = phone;
        }

        public override string ToString()
        {
            return string.Format("{0} --> {1} --> {2}", 
                this.Name, 
                this.Town, 
                this.Phone);
        }
    }
}
