namespace lab5_bank
{
    class CurrentClientBuilder : IClientBuilder
    {
        public string FirstName { get; set; } = null;
        public string SecondName { get; set; } = null;
        public string Adress { get; set; } = null;
        public string PassportNumber { get; set; } = null;

        public Client ClientBuild()
        {
            return new Client(FirstName, SecondName, Adress, PassportNumber);
        }
        public IClientBuilder SetAdress(string adress)
        {
            Adress = adress;
            return this;
        }
        public IClientBuilder SetFirstName(string firstName)
        {
            FirstName = firstName;
            return this;
        }
        public IClientBuilder SetPassportNumber(string passportNumber)
        {
            PassportNumber = passportNumber;
            return this;
        }
        public IClientBuilder SetSecondName(string secondName)
        {
            SecondName = secondName;
            return this;
        }
    }
}
