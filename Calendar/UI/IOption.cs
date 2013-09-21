namespace Calendar.UI
{
    internal interface IOption
    {
        bool MatchesString(string chosenOptionAsString);
        void Run();
    }
}