namespace TMS_API_Test1.Models
{
    public class WarhouseIndexModel
    {
        public uint Index { get; set; }

        public static bool operator>(WarhouseIndexModel ln1, WarhouseIndexModel ln2)
        {
            return ln1.Index > ln2.Index;
        }

        public static bool operator<(WarhouseIndexModel ln1, WarhouseIndexModel ln2)
        {
            return ln1.Index < ln2.Index;
        }

        public static bool operator >=(WarhouseIndexModel ln1, WarhouseIndexModel ln2)
        {
            return ln1.Index >= ln2.Index;
        }

        public static bool operator <=(WarhouseIndexModel ln1, WarhouseIndexModel ln2)
        {
            return ln1.Index <= ln2.Index;
        }

        public static bool operator ==(WarhouseIndexModel ln1, WarhouseIndexModel ln2)
        {
            return ln1.Index == ln2.Index;
        }

        public static bool operator !=(WarhouseIndexModel ln1, WarhouseIndexModel ln2)
        {
            return ln1.Index != ln2.Index;
        }
    }
}
