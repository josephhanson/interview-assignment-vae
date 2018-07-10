namespace BigramApi {
    public struct Bigram {
        public string LeftWord { get; set; }
        public string RightWord { get; set; }

        public bool IsValid() {
            return !string.IsNullOrEmpty(LeftWord) && !string.IsNullOrEmpty(RightWord);
        }
    }
}