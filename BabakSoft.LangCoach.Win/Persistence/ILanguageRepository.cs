using BabakSoft.LangCoach.Model;

namespace BabakSoft.LangCoach.Persistence
{
    public interface ILanguageRepository
    {
        #region User Story #1

        /// <summary>
        /// Adds or edits a single word in progressive dictionary
        /// </summary>
        /// <param name="word">Word to add or edit</param>
        void SaveWord(Word word);

        /// <summary>
        /// Adds or edits a single phrase in progressive dictionary
        /// </summary>
        /// <param name="word">Phrase to add or edit</param>
        void SavePhrase(Phrase phrase);

        /// <summary>
        /// Deletes an existing word from progressive dictionary
        /// </summary>
        /// <param name="wordId">Unique identifier of the word to delete</param>
        void DeleteWord(int wordId);

        /// <summary>
        /// Deletes an existing phrase from progressive dictionary
        /// </summary>
        /// <param name="wordId">Unique identifier of the phrase to delete</param>
        void DeletePhrase(int phraseId);

        #endregion

        #region User Story #2

        /// <summary>
        /// Adds or edits a verb in progressive dictionary
        /// </summary>
        /// <param name="verb">Verb to add or edit</param>
        void SaveVerb(Verb verb);

        /// <summary>
        /// Deletes an existing verb from progressive dictionary
        /// </summary>
        /// <param name="verbId">Unique identifier of the verb to delete</param>
        void DeleteVerb(int verbId);

        #endregion

        #region User Story #3

        /// <summary>
        /// Reads and returns a collection of all existing topics
        /// </summary>
        /// <returns>Collection of all topics</returns>
        List<Topic> GetAllTopics();

        /// <summary>
        /// Reads all words related to given topic
        /// </summary>
        /// <param name="topicId">Unique identifier of the topic of interest</param>
        /// <returns>Collection of all words having at least one meaning with given topic</returns>
        List<Word> GetWordsByTopic(int topicId);

        /// <summary>
        /// Reads all phrases related to given topic
        /// </summary>
        /// <param name="topicId">Unique identifier of the topic of interest</param>
        /// <returns>Collection of all phrases having at least one meaning with given topic</returns>
        List<Phrase> GetPhrasesByTopic(int topicId);

        /// <summary>
        /// Reads all verbs related to given topic
        /// </summary>
        /// <param name="topicId">Unique identifier of the topic of interest</param>
        /// <returns>Collection of all verbs having at least one meaning with given topic</returns>
        List<Verb> GetVerbsByTopic(int topicId);

        #endregion

        #region User Story #4

        /// <summary>
        /// Reads all notes without applying any filter
        /// </summary>
        /// <returns>Collection of all notes</returns>
        List<Note> GetAllNotes();

        /// <summary>
        /// Adds or edits a learner note
        /// </summary>
        /// <param name="note">Note to add or edit</param>
        void SaveNote(Note note);

        /// <summary>
        /// Deletes an existing learner note
        /// </summary>
        /// <param name="noteId">Unique identifier of the note to delete</param>
        void DeleteNote(int noteId);

        #endregion

        #region User Story #6

        /// <summary>
        /// Saves several topics in progressive dictionary (bulk mode)
        /// </summary>
        /// <param name="topics">Collection of topics to save</param>
        void SaveTopics(IEnumerable<Topic> topics);

        /// <summary>
        /// Saves several words in progressive dictionary (bulk mode)
        /// </summary>
        /// <param name="words">Collection of words to save</param>
        void SaveWords(IEnumerable<Word> words);

        /// <summary>
        /// Saves several phrases in progressive dictionary (bulk mode)
        /// </summary>
        /// <param name="phrases">Collection of phrases to save</param>
        void SavePhrases(IEnumerable<Phrase> phrases);

        /// <summary>
        /// Saves several verbs in progressive dictionary (bulk mode)
        /// </summary>
        /// <param name="verbs">Collection of verbs to save</param>
        void SaveVerbs(IEnumerable<Verb> verbs);

        #endregion

        #region User Story #7

        /// <summary>
        /// Reads all existing verbs from progrerssive dictionary
        /// </summary>
        /// <returns>Collection of existing verbs</returns>
        List<Verb> GetAllVerbs();

        #endregion
    }
}
