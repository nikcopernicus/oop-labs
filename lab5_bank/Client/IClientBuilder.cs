namespace lab5_bank
{
    interface IClientBuilder
    {
        public IClientBuilder SetFirstName(string firstName);
        public IClientBuilder SetSecondName(string secondName);
        public IClientBuilder SetAdress(string adress);
        public IClientBuilder SetPassportNumber(string passportNumber);
        public Client ClientBuild();
    }
}
