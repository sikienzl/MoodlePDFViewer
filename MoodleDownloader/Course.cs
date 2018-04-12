using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodleDownloader
{
    public class Course
    {
        //public List<String> listOfCourses;


        private String courseName;
        private String courseHtmlTitle;
        private String courseHref;
        public Course()
        {
           // listOfCourses = new List<string>();

        }

        public void setCourseName(String courseName)
        {
            this.courseName = courseName;
        }
        public void setCourseHtmlTitle(String courseHtmlTitle)
        {
            this.courseHtmlTitle = courseHtmlTitle;
        }
        public void setCourseHref(String courseHref)
        {
            this.courseHref = courseHref;
        }

        public String getCourseName()
        {
            return courseName;
        }

        public String getCourseHtmlTitle()
        {
            return courseHtmlTitle;
        }

        public String getCourseHref()
        {
            return courseHref;
        }
    }
}
