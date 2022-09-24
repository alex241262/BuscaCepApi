using BuscaCepApi.Entities;
using BuscaCepApi.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace BuscaCepApi
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private BuscaCepApic buscaCepapic;
        public BuscaCepApic BuscaCepApic
        {
            get { return buscaCepapic; }
            set { buscaCepapic = value; NotifyPropertyChanged(); }
        }
        public async void ConsultaBuscaCepApic()
        {
            
            string Cep = txtbox1.Text;
            try
            {
                var service = new BuscaCepApiService();
                var buscaCepapic = await service.GetBuscaCepApicRandom(Cep);

                if (buscaCepapic == null) return;
                BuscaCepApic = buscaCepapic;
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConsultaBuscaCepApic();
        }
    }
}
