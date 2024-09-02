using System;

namespace BabakSoft.LangCoach.Model
{
    public interface IConjugation
    {
        Verb Verb { get; }

        VerbTense Tense { get; }

        Dictionary<VerbPerson, string> Conjugate();
    }
}
