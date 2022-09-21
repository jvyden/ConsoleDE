using IniParser;
using IniParser.Model;

namespace ConsoleDE.Base.Applications {
    public class DesktopFileParser {
        public string FilePath { get; init; }
        private readonly FileIniDataParser parser;
        private readonly IniData data;
        
        public DesktopFileParser(string filePath) {
            this.FilePath = filePath;
            this.parser = new FileIniDataParser();
            this.parser.Parser.Configuration.CommentString = "#";
            
            this.data = this.parser.ReadFile(filePath);
        }

        public DesktopFile Parse() => new() {
            Name = data["Desktop Entry"]["Name"],
            Comment = data["Desktop Entry"]["Comment"],
            Exec = data["Desktop Entry"]["Exec"],
            IconName = data["Desktop Entry"]["Icon"],
        };
    }
}