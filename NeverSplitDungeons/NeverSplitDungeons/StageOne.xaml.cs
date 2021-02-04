using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace NeverSplitDungeons
{
    /// <summary>
    /// Interaktionslogik für StageOne.xaml
    /// </summary>
    public partial class StageOne : Window
    {
        public StageOne()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Button DungeonField = new Button();

            for(int i = 1; i < 50; i++)
            {
                DungeonField = new Button();
                DungeonField.Width = 70;
                DungeonField.Height = 50;
                DungeonField.Click += BtnDungeonField_Click;
                DungeonField.Background = Brushes.DarkGray;
                string DungeonFieldname = "BtnDungeonField";
                DungeonField.Name = DungeonFieldname + i.ToString();
                WpDungeon.Children.Add(DungeonField);
            }
        }

        public void BtnDungeonField_Click(object sender, RoutedEventArgs e)
        {
            Button clicked = e.Source as Button;

            if(clicked.Background == Brushes.DarkGray)
            { 
                clicked.Background = Brushes.SkyBlue; 
            }
            else if(clicked.Background == Brushes.SkyBlue)
            {
                clicked.Background = Brushes.Yellow;
            }
            else if (clicked.Background == Brushes.Yellow)
            {
                clicked.Background = Brushes.Red;
            }
            else if (clicked.Background == Brushes.Red)
            {
                clicked.Background = Brushes.MediumPurple;
            }
            else if (clicked.Background == Brushes.MediumPurple)
            {
                clicked.Background = Brushes.DarkGray;
            }
        }

        private void BtnSaveDungeonOne_Click(object sender, RoutedEventArgs e)
        {
            string DungeonInString = " ";
            int counter = 1;
            string filename = "Dungeon" + counter.ToString();

            while (File.Exists("Dungeons/" + filename + ".txt"))
            {
                counter++;
                filename = "Dungeon" + counter.ToString();
            }

            counter = 1;
            string filepath = "Dungeons/" + filename + ".txt";

            foreach(Button Field in WpDungeon.Children)
            {
                if (Field.Background == Brushes.DarkGray)
                {
                    DungeonInString += "0";
                }
                else if (Field.Background == Brushes.SkyBlue)
                {
                    DungeonInString += "1";
                }
                else if (Field.Background == Brushes.Yellow)
                {
                    DungeonInString += "Y";
                }
                else if (Field.Background == Brushes.Red)
                {
                    DungeonInString += "R";
                }
                else if (Field.Background == Brushes.MediumPurple)
                {
                    DungeonInString += "P";
                }

                if(counter % 7 == 0) { DungeonInString += "\n"; }
                DungeonInString += " ";
                counter++;
            }

            File.WriteAllText(filepath, DungeonInString);
            MessageBox.Show("Dungeon Sucessfully saved!", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
