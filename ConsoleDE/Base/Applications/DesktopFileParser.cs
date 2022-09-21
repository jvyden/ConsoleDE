using IniParser;
using IniParser.Model;

namespace ConsoleDE.Base.Applications {
    public class DesktopFileParser {
        private readonly FileIniDataParser parser;

        
        public DesktopFileParser() {
            this.parser = new FileIniDataParser();
            this.parser.Parser.Configuration.CommentString = "#";
        }

        public DesktopFile Parse(string filePath) {
            var data = this.parser.ReadFile(filePath);
            
            return new DesktopFile {
                Name = data["Desktop Entry"]["Name"],
                Comment = data["Desktop Entry"]["Comment"],
                Exec = data["Desktop Entry"]["Exec"],
                IconName = data["Desktop Entry"]["Icon"],
            };
        }
    }
}