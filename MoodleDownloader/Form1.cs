using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MoodleDownloader
{
    public partial class Form1 : Form
    {

        private AuthenticationForm atForm;
        public Form1()
        {
            InitializeComponent();

            atForm = new AuthenticationForm();
            atForm.Load(this);
            atForm.ShowDialog();
        }
        private WorkWithContent wwc;

        public void authenticate(String username, String password)
        {
            wwc = new WorkWithContent();
            if(wwc.authenticationCheck(username, password))
            {
                atForm.Hide();

                wwc.Load_Course();
                wwc.load_course_files();

                int i = 0;
                foreach (KeyValuePair<Course, List<CourseFile>> entry in wwc.courseFileDict)
                {

                    treeVwCourse.Nodes.Add(entry.Key.getCourseName());
                    if (entry.Value.Count != 0)
                    {
                        foreach (CourseFile cf in entry.Value)
                        {

                            treeVwCourse.Nodes[i].Nodes.Add(cf.getFileName());
                        }
                    }
                    i++;

                }
            } else
            {
                MessageBox.Show("Benutzername oder Passwort falsch", "Login fehlgeschlagen!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
            
        }

        private void treeVwCourse_AfterSelect(object sender, TreeViewEventArgs e)
        {
            foreach (KeyValuePair<Course, List<CourseFile>> entry in wwc.courseFileDict)
            {



                foreach (CourseFile cf in entry.Value)
                {
                    if (treeVwCourse.SelectedNode.Text.Equals(cf.getFileName()))
                    {
                        
                        String pdf_file = wwc.downloadPdfintoTmp("https://moodle.htwg-konstanz.de/moodle/pluginfile.php/154363/mod_resource/content/9/Intro.pdf");

                        acroReaderShowPdf.LoadFile(pdf_file);
                    }

                }
               
            }



                    //
                }
    }
}
