using System;

namespace ConsoleDE.Base.Applications {
    [Serializable]
    public struct DesktopFile {
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Exec { get; set; }
        public string IconName { get; set; }
    }
}