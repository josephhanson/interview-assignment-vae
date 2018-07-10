using System;
using System.Text;

namespace BigramPresentation {
    public class JsonOutput {
        private readonly HistogramViewModel _view;
        private readonly StringBuilder _builder = new StringBuilder();

        public JsonOutput(HistogramViewModel view) {
            _view = view;
        }

        public void Write() {
            Console.Write(ToString());
            Console.WriteLine();
        }

        public override string ToString() {
            var count = 0;
            _builder.AppendLine("{");

            foreach (var entry in _view.Data) {
                count++;

                _builder.Append("\"" + entry.Bigram + "\" : \"" + entry.Count + "\"");

                if (IsLastEntry(count, _view)) {
                    _builder.Append(",");
                }

                _builder.AppendLine();
            }

            _builder.Append("}");

            return _builder.ToString();
        }

        private bool IsLastEntry(int count, HistogramViewModel viewModel) {
            return count < viewModel.Count;
        }
    }
}
