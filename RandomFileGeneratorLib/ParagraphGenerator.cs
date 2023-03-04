using System.Text;

namespace RandomFileGeneratorLib
{
    public abstract class ParagraphGenerator
    {
        public ParagraphGenerator()
        {
        }

        protected abstract string FirstWord();

        protected abstract string PickWord();

        protected abstract string PickPunctuation();

        protected abstract string FinalWord();

        public string CreateParagraph(int numberOfWords, bool userFirstWord = true)
        {
            StringBuilder result = new StringBuilder();
            if (userFirstWord)
            {
                result.Append(FirstWord());
            }
            for (int i = 0; i < numberOfWords - 2; i++)
            {
                result.Append(PickWord());
                result.Append(PickPunctuation());
            }
            result.Append(FinalWord());

            return result.ToString();
        }

        public string CreateMultipleParagraphs(int numberOfParagraphs, int minWords, int maxWords, bool useFirstWord = true)
        {
            StringBuilder result = new StringBuilder();
            Random random = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < numberOfParagraphs; i++)
            {
                var numberOfWords = random.Next(minWords, maxWords);
                result.Append(CreateParagraph(numberOfWords, useFirstWord));
                result.Append("\n\n");
            }
            return result.ToString();
        }

        public string SingleWord()
        {
            return PickWord();
        }

        public List<string> MultiplWords(int number)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < number; i++)
            {
                result.Add(SingleWord());
            }
            return result;
        }
    }

}
