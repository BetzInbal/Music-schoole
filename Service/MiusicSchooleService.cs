using MiusucScule2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MiusucScule2.Models;
using static MiusucScule2.Configuration.AppConfiguration;

namespace MiusucScule2.Service
{
    internal static class MiusicSchooleService
    {
        public static void CriateXSMLifNotExistsCars()
        {
            if (!File.Exists(MiusicSchoolePath))
            {
                XDocument document = new(); //XDocument.Parse
                XElement root = new XElement("MusicSchoole");
                document.Add(root);
                document.Save(MiusicSchoolePath);
            }
        }

        public static void AddNewCllas(string className)
        {
            XDocument document = XDocument.Load(MiusicSchoolePath);
            XElement schoole = document.Descendants("MusicSchoole").FirstOrDefault();
            if (schoole == null)
            {
                return;
            }
            //<class-room name = className/>
            XElement newCllas = new XElement("Clls-room", new XAttribute("name", className));
            schoole.Add(newCllas);
            document.Save(MiusicSchoolePath);
        }

        public static void AddNewTeacher(string teacherName, string className)
        {
            XDocument document = XDocument.Load(MiusicSchoolePath);
            XElement? clas = document.Descendants("Clls-room").FirstOrDefault
                (r => r.Attribute("name")?.Value == className) ;
            if (clas == null)
            {
                return;
            }
            //List<XElement> classes = new List<XElement>();
            //XElement class = schoole.Attribute("name").ToString() == className);
            //<class-room name = className/>
            XElement newteach = new XElement("Teacher", new XAttribute("name", teacherName));
            clas.Add(newteach);
            document.Save(MiusicSchoolePath);
        }

        public static void AddNewStudent(string className, string studentName, string instrument)
        {
            XDocument document = XDocument.Load(MiusicSchoolePath);
            XElement? clases = ( from room in document.Descendants("Clls-room")
                                 where room.Attribute("name")?.Value == className
                                 select room).FirstOrDefault();
            XElement? clas = document.Descendants("Clls-room").FirstOrDefault
                (r => r.Attribute("name")?.Value == className);
            if (clas == null)
            {
                return;
            }
            XElement newStudent = new XElement("Student", new XAttribute("name", studentName),new XElement("instrument", instrument));
            clas.Add(newStudent);
            document.Save(MiusicSchoolePath);
        }

        static XElement ConvertToXelment(Student studentName)
        {
            return new XElement("Student", new XAttribute("name", studentName.Name), 
                new XElement("instrument", studentName.instrumet.Name));
        }

        public static void AddNewXMLStudent(string className, params Student[] students)
        {
            XDocument document = XDocument.Load(MiusicSchoolePath);
            XElement? clases = (from room in document.Descendants("Clls-room")
                                where room.Attribute("name")?.Value == className
                                select room).FirstOrDefault();
            if (clases == null) return;
            List<XElement> xlstu = students.Select(ConvertToXelment).ToList();    
            clases.Add(xlstu);
            document.Save(MiusicSchoolePath);
           
        }

        public static void Updateinstro(string studentName, string instrNname )
        {
            XDocument document = XDocument.Load(MiusicSchoolePath);
            XElement? stu = document.Descendants("Student").FirstOrDefault
                (r => r.Attribute("name")?.Value == studentName);
            if (stu == null) return;

            stu = stu.Descendants("instrument").FirstOrDefault();
            stu.Value = instrNname;
            document.Save(MiusicSchoolePath);
        }


        public static void Updatteacher(string oldTeacher, string newTeacher)
        {
            XDocument document = XDocument.Load(MiusicSchoolePath);
            XElement? teach = document.Descendants("Teacher").FirstOrDefault
                (r => r.Attribute("name")?.Value == oldTeacher);
            if (teach == null) return;

            teach.SetAttributeValue("name", newTeacher);
            document.Save(MiusicSchoolePath);
        }
        public static void UpdatStudent(Student newStudent, string studentName)
        {
            XElement newStudentXML = ConvertToXelment(newStudent);
            XDocument document = XDocument.Load(MiusicSchoolePath);
            XElement? oldStu = document.Descendants("Student").FirstOrDefault
                (s => s.Attribute("name")?.Value == studentName);
            if (oldStu == null) return;

            oldStu.ReplaceWith(newStudentXML);
            document.Save(MiusicSchoolePath);
        }
    }
}

