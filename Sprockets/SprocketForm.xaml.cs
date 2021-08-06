using sprocket.model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
    enum SprocketType
    {
        Steel,
        Aluminum,
        Plastic
    }

    /// <summary>
    /// Interaction logic for SprocketForm.xaml
    /// </summary>
    public partial class SprocketForm : Window
    {
        public Sprocket Sprocket { get; set; }
        public SprocketForm()
        {
            InitializeComponent();

            Input_ItemType.ItemsSource = Enum.GetValues(typeof(SprocketType));
        }

        private void NumberValidationTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = (new Regex("[^0-9]+")).IsMatch(e.Text);
        }

        private void Button_Submit_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(Input_ItemId.Text) ||
                String.IsNullOrEmpty(Input_NoItems.Text) ||
                String.IsNullOrEmpty(Input_NoTeeth.Text) ||
                Input_ItemType.SelectedItem == null)
            {
                MessageBox.Show("All fields are required!");
                return;
            }
            int itemId, noItems, noTeeth;
            if (!int.TryParse(Input_ItemId.Text, out itemId) ||
                !int.TryParse(Input_NoItems.Text, out noItems) ||
                !int.TryParse(Input_NoTeeth.Text, out noTeeth))
            {
                MessageBox.Show("Invalid fields!");
                return;
            }

            SprocketType type = (SprocketType)Input_ItemType.SelectedItem;
            switch (type)
            {
                case SprocketType.Steel:
                    Sprocket = new SteelSprocket(itemId, noItems, noTeeth);
                    break;
                case SprocketType.Aluminum:
                    Sprocket = new AluminumSprocket(itemId, noItems, noTeeth);
                    break;
                case SprocketType.Plastic:
                    Sprocket = new PlasticSprocket(itemId, noItems, noTeeth);
                    break;
            }
            this.Close();
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Sprocket = null;
            this.Close();
        }
    }
}
