using ClassLibrary1_Prueba;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace GliscorJCZ{
    public sealed partial class GliscorJCZ : UserControl, iPokemon{
        DispatcherTimer dtTime;
        DispatcherTimer dtTime2;

        public double Vida{
            get => this.pbSALUD.Value;
            set => this.pbSALUD.Value = value;
        }
        public double Energia{
            get => this.pbCOMBATE.Value;
            set => this.pbCOMBATE.Value = value;
        }
        public string Nombre{
            get => "Gliscor";
            set => throw new NotImplementedException();
        }
        public string Categoría{
            get => "Murciélago";
            set => throw new NotImplementedException();
        }
        public string Tipo{
            get => "Tierra/Volador";
            set => throw new NotImplementedException();
        }
        public double Altura{
            get => Convert.ToDouble(2.00);
            set => throw new NotImplementedException();
        }
        public double Peso{
            get => Convert.ToDouble(42.5);
            set => throw new NotImplementedException();
        }
        public string Evolucion{
            get => "No tiene evolución";
            set => throw new NotImplementedException();
        }
        public string Descripcion{
            get => "Este Pokémon se inspira en un murciélago por sus alas y orejas, y en un escorpión por su cola y pinzas. Gliscor tiene unas fuertes tenazas las cuales le sirven de defensa contra sus enemigos. Además tiene fuertes mandíbulas con las cuales puede comer grandes presas. Sus alas cuentan con la fuerza suficiente para crear vendavales. Puede parecer siniestro ya que tiene un color de piel oscuro y un aspecto aterrador, pero no es un Pokémon muy agresivo. Suele colgarse boca abajo de los árboles, y así espera a atacar presas.";
            set => throw new NotImplementedException();
        }

        public GliscorJCZ(){
            this.InitializeComponent();
            this.IsTabStop = true;
            sbEstadoBase = (Storyboard)this.Resources["sbEstadoBase"];
            sbEstadoBase.RepeatBehavior = RepeatBehavior.Forever;
            sbEstadoBase.Begin();
            pbSALUD.Value = 100;
            pbCOMBATE.Value = 100;
            this.KeyDown += Page_KeyDown;
        }

        private void Page_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            // Obtener la animación correspondiente según la tecla presionada
            Storyboard sbaux = null;
            switch (e.Key)
            {
                case Windows.System.VirtualKey.W: // Ataque Fuerte
                    sbaux = (Storyboard)this.Resources["sbAtaqueFuerte"];
                    sbaux.Begin();
                    sbaux.Completed += ResetAnimaciones;
                    break;
                case Windows.System.VirtualKey.Q: // Ataque Pinza
                    sbaux = (Storyboard)this.Resources["sbAtaquePinza"];
                    sbaux.Begin();
                    sbaux.Completed += ResetAnimaciones;
                    break;
                case Windows.System.VirtualKey.E: // Escudo
                    sbaux = (Storyboard)this.Resources["sbEscudo"];
                    sbaux.Begin();
                    break;
                case Windows.System.VirtualKey.R: // Meditación
                    sbaux = (Storyboard)this.Resources["sbMeditacion"];
                    sbaux.Begin();
                    sbaux.Completed += ResetAnimaciones;
                    break;
                case Windows.System.VirtualKey.T: // Herido
                    sbaux = (Storyboard)this.Resources["sbHerido"];
                    sbaux.Begin();
                    sbaux.Completed += ResetAnimaciones;
                    break;
                case Windows.System.VirtualKey.Y: // Cansado
                    sbaux = (Storyboard)this.Resources["sbCansado"];
                    sbaux.Begin();
                    sbaux.Completed += ResetAnimaciones;
                    break;
                case Windows.System.VirtualKey.U: // Derrotado
                    sbaux = (Storyboard)this.Resources["sbDerrotado"];
                    sbaux.Begin();
                    sbaux.Completed += ResetAnimaciones;
                    break;
                case Windows.System.VirtualKey.I: // EscudoAnimacion
                    sbaux = (Storyboard)this.Resources["sbEscudoAnimacion"];
                    sbaux.Begin();
                    sbaux.Completed += ResetAnimaciones;
                    break;
                case Windows.System.VirtualKey.V: // Volar
                    sbaux = (Storyboard)this.Resources["sbVolar"];
                    sbaux.Begin();
                    sbaux.Completed += ResetAnimaciones;
                    break;
            }

            // Si se ha seleccionado una animación
            if (sbaux != null)
            {
                sbaux.Begin();
            }
        }

        private void ResetAnimaciones(object sender, object e)
        {
            // Reiniciar todas las animaciones al estado base
            Storyboard sbEstadoBase = (Storyboard)this.Resources["sbEstadoBase"];
            sbEstadoBase.Begin();
        }

        private void aumentoSalud(object sender, PointerRoutedEventArgs e){
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(50);
            dtTime.Tick += controlincrementoVida;
            dtTime.Start();
            this.corazon.Opacity = 0.6;
        }

        private void controlincrementoVida(object sender, object e){
            this.pbSALUD.Value += 0.15;
            if (pbSALUD.Value >= 100){
                this.dtTime.Stop();
                this.corazon.Opacity = 1;
            }
        }

        private void PocionRoja_PointerReleased(object sender, PointerRoutedEventArgs e){
            Storyboard sbMeditacion = (Storyboard)this.Resources["sbMeditacion"];
            sbMeditacion.Begin();

            this.aumentoSalud(sender, e);
        }

        private void aumentarEnergia(object sender, PointerRoutedEventArgs e){
            dtTime2 = new DispatcherTimer();
            dtTime2.Interval = TimeSpan.FromMilliseconds(50);
            dtTime2.Tick += controlIncrementoEnergia;
            dtTime2.Start();
            this.rayo.Opacity = 0.5;
        }

        private void controlIncrementoEnergia(object sender, object e){
            this.pbCOMBATE.Value += 0.3;
            if (pbCOMBATE.Value >= 100){
                this.dtTime2.Stop();
                this.rayo.Opacity = 1;
            }
        }

        private void pocionAmarilla_PointerReleased(object sender, PointerRoutedEventArgs e){
            Storyboard sbMeditacion = (Storyboard)this.Resources["sbMeditacion"];
            sbMeditacion.Begin();

            this.aumentarEnergia(sender, e);

        }

        private void AtaqueBasico1_Click(object sender, RoutedEventArgs e)
        {
            Storyboard AtaqueBasico = (Storyboard)this.Resources["AtaqueBasico"];
            AtaqueBasico.Begin();

            this.pbCOMBATE.Value -= 20;

        }

        public void verFondo(bool verfondo){
            if (!verfondo) { this.fondo = null; }
            else
                throw new NotImplementedException();
        }

        public void verFilaVida(bool ver)
        {
            throw new NotImplementedException();
        }

        public void verFilaEnergia(bool ver)
        {
            throw new NotImplementedException();
        }

        public void verPocionVida(bool ver)
        {
            throw new NotImplementedException();
        }

        public void verPocionEnergia(bool ver)
        {
            throw new NotImplementedException();
        }

        public void verNombre(bool ver)
        {
            throw new NotImplementedException();
        }

        public void activarAniIdle(bool activar)
        {
            throw new NotImplementedException();
        }

        public void animacionAtaqueFlojo()
        {
            throw new NotImplementedException();
        }

        public void animacionAtaqueFuerte()
        {
            throw new NotImplementedException();
        }

        public void animacionDefensa()
        {
            throw new NotImplementedException();
        }

        public void animacionDescasar()
        {
            throw new NotImplementedException();
        }

        public void animacionCansado()
        {
            throw new NotImplementedException();
        }

        public void animacionNoCansado()
        {
            throw new NotImplementedException();
        }

        public void animacionHerido()
        {
            throw new NotImplementedException();
        }

        public void animacionNoHerido()
        {
            throw new NotImplementedException();
        }

        public void animacionDerrota()
        {
            throw new NotImplementedException();
        }
    }
}
