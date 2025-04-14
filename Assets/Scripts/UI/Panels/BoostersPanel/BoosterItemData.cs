namespace UI.Panels
{
    public class BoosterItemData
    {
        public bool Empty { get; set; }
        public bool Lock { get; set; }
        public BoosterType BoosterType { get; set; }

        public BoosterItemData()
        {
            Empty = true;
            Lock = true;
            BoosterType = BoosterType.None;
        }
    }
}