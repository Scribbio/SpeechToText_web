using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Speech.Recognition;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel;
using SpeechToTextPOC;

namespace SpeechToTextPOC
{
    public partial class _Default : Page
    {
        Recognizer r1;
        static string output;


        protected void Page_Load(object sender, EventArgs e)
        {
            Session["output"] = output;
        }


        protected void Button1_Click1(object sender, EventArgs e)
        {
            r1 = new Recognizer(languageEnabled());
            r1.Completed += (sender1, e2) =>
            {
                TextBox1.Text = r1.Result.Text;
                output = r1.Result.Text;
            };

        }

        private string languageEnabled()
        {
            if (CheckBox1.Checked == true)
            {
                return "en-GB";
            }
            else if (CheckBox2.Checked == true)
            {
                return "fr-FR";
            }

            return "en-GB";
        }

        protected void StopButton_Click(object sender, EventArgs e)
        {
            
            TextBox1.Text = (string)Session["output"];
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }



}