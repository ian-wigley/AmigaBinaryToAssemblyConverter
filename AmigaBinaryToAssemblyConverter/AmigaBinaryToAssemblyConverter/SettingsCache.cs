namespace BinToAssembly
{
    public class SettingsCache
    {
        public SettingsCache(
            string vasmLocation,
            string processor,
            string kickhunk,
            string fhunk,
            string flag,
            string folder,
            string filename
            )
        {
            VasmLocation = vasmLocation;
            Processor = processor;
            Kickhunk = kickhunk;
            Fhunk = fhunk;
            Flag = flag;
            Folder = folder;
            Filename = filename;
        }
        public string VasmLocation { get; private set; }
        public string Processor { get; private set; }
        public string Kickhunk { get; private set; }
        public string Fhunk { get; private set; }
        public string Flag { get; private set; }
        public string Folder { get; private set; }
        public string Filename { get; private set; }
        }
}
