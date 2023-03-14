using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace L8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Students> students = new List<Students>();
        Students selectedstudent = null;
        public MainWindow()
        {//makes everthing happen
            InitializeComponent();
            preload();
            DisplayToListBox();
            DisplaytocbDisplay();
            PreviewKeyDown += MainWindow_PreviewKeyDown;
            //start from zero
            lbDisplayInfo.SelectedIndex = 0;
            cbDisplayinfo.SelectedIndex = 0;
        }
        private void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {//closes the program
            if (e.Key == Key.K)
            {//when I press K
                Close();//close
            }
        }

        public void preload()
        {//greades for the students classes
            Students student = new Students("abdul", "joe", 100, 90);
            students.Add(student);//their names and grades
            //all students
            students.Add(new Students("john", "key", 100, 100));
            students.Add(new Students("jostin", "tom", 80, 90));
            students.Add(new Students("jace", "maro", 70, 96));
            students.Add(new Students("jeff", "Abdil", 88, 90));
            students.Add(new Students("jack", "jake", 89, 79));
            students.Add(new Students("fall", "deek", 90, 70));
            students.Add(new Students("cartman", "toy", 96, 89));


        }
        public void DisplayToListBox()
        {//display box to display these
            lbDisplayInfo.Items.Clear();
            for (int i = 0; i < students.Count; i++)
            {
                string firstName = students[i].FName;
                string lastName = students[i].LName;
                string FullName = firstName + " " + lastName;
                lbDisplayInfo.Items.Add(FullName);
                //added
            }


        }

        public void DisplaytocbDisplay()
        {
            cbDisplayinfo.Items.Clear();
            for (int i = 0; i < students.Count; i++)
            {//for it to display these things
                string firstName = students[i].FName;
                string lastName = students[i].LName;
                string FullName = firstName + " " + lastName;
                cbDisplayinfo.Items.Add(FullName);

            }


        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {//click button 
            int selectedIndex = lbDisplayInfo.SelectedIndex;

            if(selectedIndex < 0)
            {//do this
                MessageBox.Show("Select a name from the list box ");
            }
            else
            {
                DisplayStudentsInformation(selectedstudent);
            }
        }

        public void DisplayStudentsInformation(Students student)
        {//display play these information
            txtFirstName.Text = student.FName;
            txtLastName.Text = student.LName;
            txtCsiGrade.Text = student.egrade.ToString();
            txtGenEdGrade.Text = student.othergrade.ToString();
        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {//button to add new students in the list
                string fName = txtFirstName.Text;
                string lName = txtLastName.Text;
                string csi = txtCsiGrade.Text;
                string genEd = txtGenEdGrade.Text;

            int CSIGrade = int.Parse(csi);
            int GenEdGrade = int.Parse(genEd);

             students.Add(new Students(fName,lName, CSIGrade, GenEdGrade));
            //display them
            DisplayToListBox();
        }

        private void btnRemovestd_Click(object sender, RoutedEventArgs e)
        {//button for the students to be removed from the list
            int selectedIndex = lbDisplayInfo.SelectedIndex;
            students.Remove(selectedstudent);
            DisplayToListBox ();
        }
        private void DisplayUpdatedInformation(int SelectedIndex)
        {//for the students to be updated their grades
            selectedstudent = students[SelectedIndex];
            DisplayStudentsInformation(selectedstudent);
        }

        private void cbDisplayinfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//with this button the changes happen
            DisplayUpdatedInformation(cbDisplayinfo.SelectedIndex);
            DisplayStudentsInformation(selectedstudent);
        }

        private void lbDisplayInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//changed the things
            DisplayUpdatedInformation(lbDisplayInfo.SelectedIndex);
            DisplayStudentsInformation(selectedstudent);
        }
    }



    
}
