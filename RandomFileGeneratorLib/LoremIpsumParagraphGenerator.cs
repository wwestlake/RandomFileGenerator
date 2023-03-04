using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RandomFileGeneratorLib
{
    public class LoremIpsumParagraphGenerator : ParagraphGenerator
    {
        private readonly Random _random = new Random((int)DateTime.Now.Ticks);

        private readonly string _ipsum = @"Sed ut perspiciatis unde omnis iste natus error 
            sit voluptatem accusantium doloremque laudantium  totam rem 
            aperiam eaque ipsa  quae ab illo inventore veritatis et quasi
            architecto beatae vitae dicta sunt  explicabo
            Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit 
            aut fugit  sed quia consequuntur magni dolores eos  qui ratione 
            voluptatem sequi nesciunt  neque porro quisquam est  qui dolorem 
            ipsum  quia dolor sit amet consectetur adipisci velit  sed quia 
            non numquam eius modi tempora incidunt  ut labore et dolore magnam 
            aliquam quaerat voluptatem
            Ut enim ad minima veniam  quis nostrum exercitationem ullam corporis 
            suscipit laboriosam  nisi ut aliquid ex ea commodi consequatur
            Quis autem vel eum iure reprehenderit qui in ea voluptate velit 
            esse  quam nihil molestiae consequatur vel illum qui dolorem eum 
            fugiat quo voluptas nulla pariatur
            At vero eos et accusamus et iusto odio dignissimos ducimus  qui blanditiis 
            praesentium voluptatum deleniti atque corrupti  quos dolores et quas molestias 
            excepturi sint  obcaecati cupiditate non provident  similique sunt in culpa  
            qui officia deserunt mollitia animi  id est laborum et dolorum fuga 
            Et harum quidem rerum facilis est et expedita distinctio.Nam libero 
            tempore  cum soluta nobis est eligendi optio  cumque nihil impedit  
            quo minus id  quod maxime placeat  facere possimus  omnis voluptas 
            assumenda est  omnis dolor repellendus
            Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus 
            saepe eveniet  ut et voluptates repudiandae sint et molestiae non recusandae 
            Itaque earum rerum hic tenetur a sapiente delectus  ut aut reiciendis 
            voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat";

        private readonly List<string> _words = new List<string>();
        private readonly List<string> _punc = new List<string>() { ".", ",", ";", ":", "?", "!" };
        private bool _endOfSentence = false;
        private bool _firstWord = true;

        public LoremIpsumParagraphGenerator()
        {
            _ipsum = _ipsum.Replace("\n", "");
            _ipsum = _ipsum.Replace("\r", "");
            _words.AddRange(_ipsum.Split(' ', StringSplitOptions.RemoveEmptyEntries));
        }

        protected override string FirstWord()
        {
            return "Lorem Ipsum ";
        }

        protected override string FinalWord()
        {
            return PickWord() + ".";
        }


        protected override string PickPunctuation()
        {
            var chance = _random.Next(0, 100);
            if (chance <= 20)
            {
                var punc = _punc[_random.Next(0, _punc.Count - 1)];
                if (".!?".Contains(punc)) _endOfSentence = true;
                return punc + " ";
            } else
            {
                return " ";
            }
        }

        protected override string PickWord()
        {
            var word = _words[_random.Next(0, _words.Count - 1)];
            if (_firstWord || _endOfSentence)
            {
                _firstWord = false;
                _endOfSentence = false;
                return $"{word[0].ToString().ToUpper()}{word.Substring(1)}";
            }

            return word;
        }
    }
}
