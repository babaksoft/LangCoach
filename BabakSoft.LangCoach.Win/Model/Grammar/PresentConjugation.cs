using System;

namespace BabakSoft.LangCoach.Model
{
    public class PresentConjugation : BaseConjugation, IConjugation
    {
        public PresentConjugation(Verb verb, VerbTense tense)
        {
            Verb = verb;
            Tense = tense;
        }

        public Verb Verb { get; }

        public VerbTense Tense { get; }

        public Dictionary<VerbPerson, string> Conjugate()
        {
            return ConjugatePresent(Verb);
        }
    }
}
