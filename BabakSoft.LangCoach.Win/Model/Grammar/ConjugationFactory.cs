using System;

namespace BabakSoft.LangCoach.Model
{
    public class ConjugationFactory
    {
        public static IConjugation Create(Verb verb, VerbTense tense)
        {
            if (tense == VerbTense.Present)
            {
                return new PresentConjugation(verb, tense);
            }

            return null;
        }
    }
}
