namespace _06.PhoneBook
{
    using System;
    using System.IO;
    using Wintellect.PowerCollections;
    public class Phonebook
    {
        private const int NAME = 0;
        private const int TOWN = 1;
        private const int PHONE = 2;

        private const string FilePath = "../../files/phones.txt";

        private MultiDictionary<string, PhoneRecord> names =
                new MultiDictionary<string, PhoneRecord>(true);

        private MultiDictionary<Tuple<string, string>, PhoneRecord> namesAndTowns =
                new MultiDictionary<Tuple<string, string>, PhoneRecord>(true);

        private void LoadPhonebook()
        {
            var reader = new StreamReader(FilePath);
            using (reader)
            {
                string line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    var parsedLine = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    PhoneRecord record =
                        new PhoneRecord(parsedLine[NAME].Trim(),
                            parsedLine[TOWN].Trim(),
                            parsedLine[PHONE].Trim());

                    this.names.Add(record.Name, record);
                    this.namesAndTowns.Add(new Tuple<string, string>(record.Name, record.Town), record);
                }
            }
        }

        public Phonebook()
        {
            this.names = new MultiDictionary<string, PhoneRecord>(true);
            this.namesAndTowns = new MultiDictionary<Tuple<string, string>, PhoneRecord>(true);
            this.LoadPhonebook();
        }

        public void Find(string name)
        {
            var records = this.names[name];

            foreach (var item in records)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void Find(string name, string town)
        {           
            var records = this.namesAndTowns[new Tuple<string, string>(name, town)];

            foreach (var item in records)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
