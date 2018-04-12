using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodleDownloader
{
    public class CourseFile
    {

        private String filename;
        private String filelink;
        

        public void setFileName(String filename)
        {
            this.filename = filename;
        }

        public void setFileLink(String filelink)
        {
            this.filelink = filelink;
        }

        public String getFileName()
        {
            return filename;
        }

        public String getFileLink()
        {
            return filelink;
        }
    }
}
