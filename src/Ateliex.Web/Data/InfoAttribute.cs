namespace Ateliex.Data
{
    public class InfoAttribute : Attribute
    {
        public string AreaName { get; set; }

        public string MetaName { get; set; }

        public string SingleName { get; set; }

        public string PluralName { get; set; }
    }
}
