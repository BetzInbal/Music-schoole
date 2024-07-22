using static MiusucScule2.Service.MiusicSchooleService;
using  MiusucScule2.Models;

namespace MiusucScule2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //CriateXSMLifNotExistsCars();
            //AddNewCllas("guitara gaz");
            //AddNewTeacher("yossi", "guitara gaz");
            AddNewStudent("guitara gaz", "fe", "guitara");
            /*AddNewXMLStudent("guitara gaz",
                new Student("ben", new Instrumet("guitara")),
                new Student("ron", new Instrumet("guitara")),
                new Student("gon", new Instrumet("guitara")),
                new Student("fe", new Instrumet("guitara")));*/
            //Updateinstro("gon", "chalil");
            //Updatteacher("yossi", "yossef");
            UpdatStudent(new Student("gon", new Instrumet("guitara")), "geny");



        }
    }
}
