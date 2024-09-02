using System;

namespace BabakSoft.LangCoach.Model
{
    public abstract class BaseConjugation
    {
        protected Dictionary<VerbPerson, string> ConjugatePresent(Verb verb)
        {
            if (verb.EndForm == "er")
            {
                return ConjugatePresentGroup1(verb);
            }

            return null;
        }

        protected Dictionary<VerbPerson, string> ConjugatePresentGroup1(Verb verb)
        {
            var root = verb.Name.Substring(0, verb.Name.Length - verb.EndForm.Length);
            return new Dictionary<VerbPerson, string>()
            {
                { VerbPerson.FirstSingular, $"{root}e" },
                { VerbPerson.SecondSingular, $"{root}es" },
                { VerbPerson.ThirdSingular, $"{root}e" },
                { VerbPerson.FirstPlural, $"{root}ons" },
                { VerbPerson.SecondPlural, $"{root}ez" },
                { VerbPerson.ThirdPlural, $"{root}ent" }
            };
        }
    }
}
