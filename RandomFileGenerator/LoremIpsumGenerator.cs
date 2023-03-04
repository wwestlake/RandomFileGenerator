﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RandomFileGenerator
{


    internal class LoremIpsumGenerator : IGenerator
    {
        string ipsum = @"Sed ut perspiciatis  unde omnis iste natus error sit voluptatem accusantium doloremque laudantium  totam rem aperiam eaque ipsa  quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt  explicabo.
            Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit  sed quia consequuntur magni dolores eos  qui ratione voluptatem sequi nesciunt  neque porro quisquam est  qui dolorem ipsum  quia dolor sit amet consectetur adipisci velit  sed quia non numquam eius modi tempora incidunt  ut labore et dolore magnam aliquam quaerat voluptatem.
            Ut enim ad minima veniam  quis nostrum exercitationem ullam corporis suscipit laboriosam  nisi ut aliquid ex ea commodi consequatur?
            Quis autem vel eum iure reprehenderit  qui in ea voluptate velit esse  quam nihil molestiae consequatur  vel illum  qui dolorem eum fugiat  quo voluptas nulla pariatur? 
            At vero eos et accusamus et iusto odio dignissimos ducimus  qui blanditiis praesentium voluptatum deleniti atque corrupti  quos dolores et quas molestias excepturi sint  obcaecati cupiditate non provident  similique sunt in culpa  qui officia deserunt mollitia animi  id est laborum et dolorum fuga. 
            Et harum quidem rerum facilis est et expedita distinctio.Nam libero tempore  cum soluta nobis est eligendi optio  cumque nihil impedit  quo minus id  quod maxime placeat  facere possimus  omnis voluptas assumenda est  omnis dolor repellendus.
            Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet  ut et voluptates repudiandae sint et molestiae non recusandae.Itaque earum rerum hic tenetur a sapiente delectus  ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.";


        List<string> words = new List<string>();
        Random random = new Random((int)DateTime.Now.Ticks);

        public LoremIpsumGenerator()
        {
            ipsum = ipsum.Replace("\n", "");
            ipsum = ipsum.Replace("\r", "");
            ipsum = ipsum.Replace(".", "");
            var ipsum_words = ipsum.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            words.AddRange(ipsum_words);
        }

        private string RandomWord()
        {
            int position = random.Next(words.Count);
            return words[position];
        }

        public void Generate(Stream sink, long numberOfBytes)
        {
            long bytesGenerated = 0;
            StreamWriter sw = new StreamWriter(sink);

            while (bytesGenerated < numberOfBytes)
            {
                var word = RandomWord() + " ";
                if (bytesGenerated + word.Length <= numberOfBytes)
                {
                    sw.Write(word);
                    bytesGenerated += word.Length;
                }
                else
                {
                    var remainder = numberOfBytes - bytesGenerated;
                    string finish = new string(' ', (int)remainder);
                    sw.Write(finish);
                    bytesGenerated += remainder;
                }
            }
            sw.Flush();
        }
    }
}