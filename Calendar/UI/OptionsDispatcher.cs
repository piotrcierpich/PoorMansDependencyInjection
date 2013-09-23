using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Calendar.UI
{
    class OptionsDispatcher
    {
        private readonly TextReader textReader;
        private readonly IEnumerable<IOption> options;

        public OptionsDispatcher(IEnumerable<IOption> options, TextReader textReader)
        {
            this.options = options;
            this.textReader = textReader;
        }

        public bool ChooseOptionAndRun()
        {
            IOption option = PrintAndChooseOption();
            return option.Run();
        }

        private IOption PrintAndChooseOption()
        {
            PrintAvailableOptions();
            return ChooseOption();
        }

        private IOption ChooseOption()
        {
            while (true)
            {
                string chosenOptionAsString = textReader.ReadLine();
                IOption chosenOption = options.FirstOrDefault(o => o.MatchesString(chosenOptionAsString));
                if (chosenOption != default(IOption))
                {
                    return chosenOption;
                }
                
                Console.WriteLine("Incorrect option, try again");
            }
        }

        private void PrintAvailableOptions()
        {
            Console.WriteLine("Pick option:");
            foreach (var option in options)
            {
                Console.WriteLine(option);
            }
        }
    }
}
