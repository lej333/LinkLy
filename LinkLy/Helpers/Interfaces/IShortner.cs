namespace LinkLy.Interfaces
{
    public interface IShortner
    {
        public string GenerateGuid(int id);

        public int RestoreGuid(string guid);
    }
}
