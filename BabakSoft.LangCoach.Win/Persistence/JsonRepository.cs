using BabakSoft.LangCoach.Model;
using BabakSoft.Platform.Common;

namespace BabakSoft.LangCoach.Persistence
{
    public class JsonRepository : ILanguageRepository
    {
        #region User Story #1

        /// <inheritdoc/>
        public void SaveWord(Word word)
        {
            throw ExceptionBuilder.NewNotImplementedException();
        }

        /// <inheritdoc/>
        public void SavePhrase(Phrase phrase)
        {
            throw ExceptionBuilder.NewNotImplementedException();
        }

        /// <inheritdoc/>
        public void DeleteWord(int wordId)
        {
            throw ExceptionBuilder.NewNotImplementedException();
        }

        /// <inheritdoc/>
        public void DeletePhrase(int phraseId)
        {
            throw ExceptionBuilder.NewNotImplementedException();
        }

        #endregion

        #region User Story #2

        /// <inheritdoc/>
        public void SaveVerb(Verb verb)
        {
            throw ExceptionBuilder.NewNotImplementedException();
        }

        /// <inheritdoc/>
        public void DeleteVerb(int verbId)
        {
            throw ExceptionBuilder.NewNotImplementedException();
        }

        #endregion

        #region User Story #3

        /// <inheritdoc/>
        public List<Word> GetWordsByTopic(int topicId)
        {
            throw ExceptionBuilder.NewNotImplementedException();
        }

        /// <inheritdoc/>
        public List<Phrase> GetPhrasesByTopic(int topicId)
        {
            throw ExceptionBuilder.NewNotImplementedException();
        }

        /// <inheritdoc/>
        public List<Verb> GetVerbsByTopic(int topicId)
        {
            throw ExceptionBuilder.NewNotImplementedException();
        }

        #endregion

        #region User Story #4

        /// <inheritdoc/>
        public List<Note> GetAllNotes()
        {
            throw ExceptionBuilder.NewNotImplementedException();
        }

        /// <inheritdoc/>
        public void SaveNote(Note note)
        {
            throw ExceptionBuilder.NewNotImplementedException();
        }

        /// <inheritdoc/>
        public void DeleteNote(int noteId)
        {
            throw ExceptionBuilder.NewNotImplementedException();
        }

        #endregion

        #region User Story #6

        /// <inheritdoc/>
        public void SaveWords(IEnumerable<Word> words)
        {
            throw ExceptionBuilder.NewNotImplementedException();
        }

        /// <inheritdoc/>
        public void SavePhrases(IEnumerable<Phrase> phrases)
        {
            throw ExceptionBuilder.NewNotImplementedException();
        }

        #endregion

        #region User Story #7

        /// <inheritdoc/>
        public List<Verb> GetAllVerbs()
        {
            throw ExceptionBuilder.NewNotImplementedException();
        }

        #endregion

        private static void EnsureDataFilesExist()
        {
            var dataPath = Path.Combine("..", "..", "..", "Data");
            if (!Directory.Exists(dataPath))
            {
                Directory.CreateDirectory(dataPath);
            }

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
            note.Text = note.Text.Replace(Environment.NewLine, EncodedNewLine);
        }

        private static void DecodeNoteText(Note note)
        {
            note.Text = note.Text.Replace(EncodedNewLine, Environment.NewLine);
        }

        private const string EncodedNewLine = @"\r\n";
    }
}
