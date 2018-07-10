using System;
using System.IO;
using BigramApi;
using BigramPresentation;

namespace BigramConsoleApplication {
    class Program {
        static int Main(string[] args) {
            var options = new CommandLineOptions(args);
            
            if (!options.IsValid) {
                options.DisplayUsage();
                return 1;
            }
            var histogram = new BigramHistogram();

            try {
                var characterStream = new NtfsFileCharacterStream(options.Filepath);
                var wordStream = new WordStream(characterStream);
                var bigramStream = new BigramStream(wordStream);

                foreach (var bigram in bigramStream.Next()) {
                    histogram.Add(bigram);
                }
            } catch (IOException exception) {
                Console.WriteLine(exception.Message);
                return 1;
            } catch (NotSupportedException exception) {
                Console.WriteLine(exception.Message);
                return 1;
            }

            var presenter = new BigramHistogramPresenter();
            var viewModel = presenter.Prepare(histogram);
            var output = new JsonOutput(viewModel);

            output.Write();

            return 0;
        }
    }
}
