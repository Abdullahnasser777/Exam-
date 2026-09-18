
    using System.Linq;

    namespace Exam_System_01
    {
        public abstract class Question : ICloneable, IComparable<Question>
        {
        #region Properties
        public string Header { get; set; }

        public string Body { get; set; }

        public decimal Mark { get; set; }

        public Answer RightAnswer { get; set; }

        public abstract string QuestionTypeLabel { get; }

        public Answer[] Answers { get; set; } = Array.Empty<Answer>();
        #endregion

        #region Constructor
        protected Question(string header, string body, decimal mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
        }
        #endregion

        #region ICloneable Implementation
        public virtual object Clone()
        {
            var Clone = (Question)this.MemberwiseClone();

            Clone.Answers = this.Answers
                .Select(a => new Answer(a.AnswerId, a.AnswerName))
                .ToArray();

            if (this.RightAnswer != null)
            {
                Clone.RightAnswer = new Answer(this.RightAnswer.AnswerId, this.RightAnswer.AnswerName);
            }

            return Clone;
        }
        #endregion

        #region IComparable Implementation
        public int CompareTo(Question? other)
        {
            if (other == null)
                return 1;

            return this.Mark.CompareTo(other.Mark);
        }
        #endregion

        #region ToString Override
        public override string ToString()
        {
            return $"[{Header}] {Body} (Mark: {Mark})";
        } 
        #endregion
    }

    }

