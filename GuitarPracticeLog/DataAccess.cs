using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;

namespace GuitarPracticeLog
{
    public class DataAccess
    {
        public static void SaveData(object obj, string filename)
        {
            try
            {
                using (TextWriter writer = new StreamWriter(filename))
                {
                    XmlSerializer sr = new XmlSerializer(obj.GetType());
                    sr.Serialize(writer, obj);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "IOException");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }
        
    }
}
