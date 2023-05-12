using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppForms
{

    public partial class CumulativeCount : Window
    {
        IDictionary<string, int> cumulativeCount;

        public CumulativeCount(IDictionary<string, int> cumulativecount)
        {
            cumulativeCount = cumulativecount;
            InitializeComponent();
            Loaded += CumulativeCount_Loaded;

        }
        private void CumulativeCount_Loaded(object sender, RoutedEventArgs e)
        {

            PopulateListBox(cumulativeCount);

        }
        private void PopulateListBox(IDictionary<string, int> cumulativeCount)
        {
            listcumulativecount.Items.Clear();

            foreach (KeyValuePair<string, int> item in cumulativeCount)
            {
                ListBoxItem listBoxItem = new ListBoxItem();
                Grid grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(20) }); // Add space between the columns
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });

                TextBlock keyTextBlock = new TextBlock()
                {
                    Text = item.Key
                };
                TextBlock valueTextBlock = new TextBlock()
                {
                    Text = item.Value.ToString()
                };

                Grid.SetColumn(keyTextBlock, 0);
                Grid.SetColumn(valueTextBlock, 2);

                grid.Children.Add(keyTextBlock);
                grid.Children.Add(valueTextBlock);

                listBoxItem.Content = grid;
                listcumulativecount.Items.Add(listBoxItem);
            }
        }
    }
}
