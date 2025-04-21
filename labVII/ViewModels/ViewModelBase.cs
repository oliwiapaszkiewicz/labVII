using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;

namespace labVII.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        private string sekwencja;
        public string Sekwencja
        {
            get => sekwencja;
            set => this.RaiseAndSetIfChanged(ref sekwencja, value);
        }

        private string wynik;
        public string Wynik
        {
            get => wynik;
            set => this.RaiseAndSetIfChanged(ref wynik, value);
        }

        public ReactiveCommand<Unit, Unit> PrzetworzSekwencjeCommand { get; }
        public ViewModelBase()
        {
            PrzetworzSekwencjeCommand = ReactiveCommand.Create(AnalizujSekwencje);
        }

        private void AnalizujSekwencje()
        {
            var podzial = new Dictionary<string, int>();
            var sekw = Sekwencja.ToUpper();
            for (int i = 0; i <= sekw.Length - 4; i++)
            {
                var fragment = sekw.Substring(i, 4);
                if (fragment.All(c => "ACGT".Contains(c)))
                {
                    if (!podzial.ContainsKey(fragment))
                        podzial[fragment] = 0;

                    podzial[fragment]++;
                }
            }
            if (podzial.Count == 0)
            {
                Wynik = "BLAD.";
                return;
            }
            Wynik = string.Join(Environment.NewLine, podzial.Select(kvp => $"{kvp.Key}: {kvp.Value}"));
        }
    }
}