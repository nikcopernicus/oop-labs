namespace Lab4_Bakcup
{
    class PseudoFile
    {
        private string Name;
        private int Size;
        public PseudoFile(string name, int size)
        {
            Name = name;
            Size = size;
        }
        public string GetName()
        {
            return Name;
        }
        public int GetSize()
        {
            return Size;
        }
        public void SetSize(int size)
        {
            Size = size;
        }
    }
}
