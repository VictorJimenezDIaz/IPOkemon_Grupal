using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace juegoPokemon
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.BackStack.Clear();

            // TODO: Use e.Parameter to pass information between pages
        }

        public MainPage()
        {
            this.InitializeComponent();

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += opcionVolver;
        }

        private void opcionVolver(object sender, BackRequestedEventArgs e)
        {
            if (fmMain.BackStack.Any())
            {
                fmMain.GoBack();
            }
        }

        ///////////////////////////////         Navegación entre páginas    ///////////////////////////////////////

        private void btPokedex_Click(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(typeof(PokedexPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void btCombate_Click(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(typeof(CombatePage));
        }

        private void btAcercaDe_Click(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(typeof(AcercaDePage));
        }

        private void btMisPokemon_Click(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(typeof(MisPokemonPage));
        }
    }
}
