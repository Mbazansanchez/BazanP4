using Microsoft.Win32;
using sprocket.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sprockets
{
    /// <summary>
    /// Interaction logic for SprocketOrderForm.xaml
    /// </summary>
    public partial class SprocketOrderForm : Window
    {
        private bool localPickup = false;
        private ObservableCollection<Sprocket> sprockets { get; set; }

        public SprocketOrderForm()
        {
            sprockets = new ObservableCollection<Sprocket>();

            InitializeComponent();

            DataContext = this;
            List_Sprockets.ItemsSource = sprockets;
        }

        private void LocalPickup_Click(object sender, RoutedEventArgs e)
        {
            localPickup = (bool)((CheckBox)sender).IsChecked;
            Visibility visibility = Visibility.Visible;

            if (localPickup)
                visibility = Visibility.Hidden;

            Label_Street.Visibility = visibility;
            Input_Street.Visibility = visibility;
            Grid_Address.Visibility = visibility;
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            SprocketForm sprocketForm = new SprocketForm();
            sprocketForm.ShowDialog();

            if (sprocketForm.Sprocket != null)
                sprockets.Add(sprocketForm.Sprocket);
        }

        private void Button_Remove_Click(object sender, RoutedEventArgs e)
        {
            if (List_Sprockets.SelectedItem == null)
            {
                MessageBox.Show("Select an item to be removed", "Remove item", MessageBoxButton.OK, MessageBoxImage.Warning);
            } else
            {
                MessageBoxResult result = MessageBox.Show("Are you sure?", "Remove item", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    sprockets.Remove((Sprocket)List_Sprockets.SelectedItem);
                }
            }
        }

        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.ShowDialog();

            if (! String.IsNullOrEmpty(fileDialog.FileName))
            {
                SprocketOrder sprocketOrder =
                    new SprocketOrder(
                        localPickup ? null : new Address
                        {
                            City = Input_City.Text,
                            State = Input_State.Text,
                            Street = Input_Street.Text,
                            ZipCode = Input_ZipCode.Text
                        },
                        Input_CustomerName.Text,
                        new List<Sprocket>(sprockets));

                File.WriteAllText(fileDialog.FileName, sprocketOrder.ToString());
            }
        }
    }
}
