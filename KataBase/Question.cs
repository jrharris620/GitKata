namespace KataBase
{
    public class Question
    {
        /// <summary>
        /// The desired text
        /// </summary>
        public string[] DesiredAnswers { get; set; }

        /// <summary>
        /// The question that prompts the user.
        /// </summary>
        public string Text { get; set; }
    }
}