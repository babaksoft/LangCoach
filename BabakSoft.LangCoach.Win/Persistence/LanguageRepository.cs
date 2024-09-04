using BabakSoft.LangCoach.Model;
using BabakSoft.Platform.Common;

namespace BabakSoft.LangCoach.Persistence
{
    public class LanguageRepository : ILanguageRepository
    {
        public LanguageRepository()
        {
            EnsureDataFilesExist();
            _topicRepo = new JsonRepositoryBase<Topic>(Topic.DataPath, false);
            _wordRepo = new JsonRepository<Word>(Word.DataPath, false);
            _phraseRepo = new JsonRepository<Phrase>(Phrase.DataPath, false);
            _verbRepo = new JsonRepository<Verb>(Verb.DataPath, false);
            _noteRepo = new JsonRepositoryBase<Note>(Note.DataPath, false);
        }

        #region User Story #1

        /// <inheritdoc/>
        public void SaveWord(Word word)
        {
            _wordRepo.SaveDataItem(word);
        }

        /// <inheritdoc/>
        public void SavePhrase(Phrase phrase)
        {
            _phraseRepo.SaveDataItem(phrase);
        }

        /// <inheritdoc/>
        public void DeleteWord(int wordId)
        {
            _wordRepo.DeleteDataItem(wordId);
        }

        /// <inheritdoc/>
        public void DeletePhrase(int phraseId)
        {
            _phraseRepo.DeleteDataItem(phraseId);
        }

        #endregion

        #region User Story #2

        /// <inheritdoc/>
        public void SaveVerb(Verb verb)
        {
            _verbRepo.SaveDataItem(verb);
        }

        /// <inheritdoc/>
        public void DeleteVerb(int verbId)
        {
            _verbRepo.DeleteDataItem(verbId);
        }

        #endregion

        #region User Story #3

        /// <inheritdoc/>
        public List<Topic> GetAllTopics()
        {
            return _topicRepo.GetAllItems();
        }

        /// <inheritdoc/>
        public List<Word> GetWordsByTopic(int topicId)
        {
            return _wordRepo.GetItemsByTopic(topicId);
        }

        /// <inheritdoc/>
        public List<Phrase> GetPhrasesByTopic(int topicId)
        {
            return _phraseRepo.GetItemsByTopic(topicId);
        }

        /// <inheritdoc/>
        public List<Verb> GetVerbsByTopic(int topicId)
        {
            return _verbRepo.GetItemsByTopic(topicId);
        }

        #endregion

        #region User Story #4

        /// <inheritdoc/>
        public List<Note> GetAllNotes()
        {
            var allNotes = _noteRepo.GetAllItems();
            Array.ForEach(allNotes.ToArray(), note => DecodeNoteText(note));
            return allNotes;
        }

        /// <inheritdoc/>
        public void SaveNote(Note note)
        {
            EncodeNoteText(note);
            note.RevisionCount++;
            _noteRepo.SaveDataItem(note);
        }

        /// <inheritdoc/>
        public void DeleteNote(int noteId)
        {
            _noteRepo.DeleteDataItem(noteId);
        }

        #endregion

        #region User Story #6

        /// <inheritdoc/>
        public void SaveTopics(IEnumerable<Topic> topics)
        {
            _topicRepo.SaveDataItems(topics);
        }

        /// <inheritdoc/>
        public void SaveWords(IEnumerable<Word> words)
        {
            _wordRepo.SaveDataItems(words);
        }

        /// <inheritdoc/>
        public void SavePhrases(IEnumerable<Phrase> phrases)
        {
            _phraseRepo.SaveDataItems(phrases);
        }

        /// <inheritdoc/>
        public void SaveVerbs(IEnumerable<Verb> verbs)
        {
            _verbRepo.SaveDataItems(verbs);
        }

        #endregion

        #region User Story #7

        /// <inheritdoc/>
        public List<Verb> GetAllVerbs()
        {
            return _verbRepo.GetAllItems();
        }

        #endregion

        private static void EnsureDataFilesExist()
        {
            var dataPath = Path.Combine("..", "..", "..", "Data");
            if (!Directory.Exists(dataPath))
            {
                Directory.CreateDirectory(dataPath);
            }

            EnsureDataFileExists(dataPath, "topics");
            EnsureDataFileExists(dataPath, "words");
            EnsureDataFileExists(dataPath, "phrases");
            EnsureDataFileExists(dataPath, "verbs");
            EnsureDataFileExists(dataPath, "notes");
        }

        private static void EnsureDataFileExists(string dataPath, string name)
        {
            var path = Path.Combine(dataPath, $"{name}.json");
            if (!File.Exists(path))
            {
                File.WriteAllText(path, "[]");
            }
        }

        private static void EncodeNoteText(Note note)
        {
            Verify.ArgumentNotNull(note, nameof(note));
            note.Text = note.Text.Replace(Environment.NewLine, EncodedNewLine);
        }

        private static void DecodeNoteText(Note note)
        {
            Verify.ArgumentNotNull(note, nameof(note));
            note.Text = note.Text.Replace(EncodedNewLine, Environment.NewLine);
        }

        private const string EncodedNewLine = @"\r\n";
        private readonly JsonRepositoryBase<Topic> _topicRepo;
        private readonly JsonRepository<Word> _wordRepo;
        private readonly JsonRepository<Phrase> _phraseRepo;
        private readonly JsonRepository<Verb> _verbRepo;
        private readonly JsonRepositoryBase<Note> _noteRepo;
    }
}
