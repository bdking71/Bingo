using System;
using System.Speech.Synthesis;

public class BingoAnnouncer : IDisposable
{
    private SpeechSynthesizer synthesizer;

    /// <summary>
    /// Initializes a new instance of the <see cref="BingoAnnouncer"/> class.
    /// This constructor sets up the text-to-speech synthesizer with a default female adult voice.
    /// </summary>
    /// <remarks>
    /// The <see cref="BingoAnnouncer"/> class is used to announce Bingo calls using a text-to-speech engine.
    /// </remarks>
    /// <example>
    /// <code>
    /// BingoAnnouncer announcer = new BingoAnnouncer();
    /// announcer.Announce("Bingo!");
    /// </code>
    /// </example>
    /// <seealso cref="System.Speech.Synthesis.SpeechSynthesizer"/>
    public BingoAnnouncer()
    {
        synthesizer = new SpeechSynthesizer();
        // Set the default voice
        synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
    }

    /// <summary>
    /// Announces the Bingo call using text-to-speech.
    /// </summary>
    /// <param name="ballLetter">The letter part of the Bingo ball (e.g., "B", "I", "N", "G", "O").</param>
    /// <param name="ballNumber">The number part of the Bingo ball (e.g., 1 to 75).</param>
    /// <remarks>
    /// This method constructs the announcement string by combining the letter and number,
    /// then uses the <see cref="System.Speech.Synthesis.SpeechSynthesizer"/> to speak the announcement.
    /// </remarks>
    /// <example>
    /// <code>
    /// BingoAnnouncer announcer = new BingoAnnouncer();
    /// announcer.Announce("B", 12);
    /// // This will announce "B 12".
    /// </code>
    /// </example>
    /// <seealso cref="System.Speech.Synthesis.SpeechSynthesizer.Speak(string)"/>
    public void Announce(string ballLetter, int ballNumber)
    {
        string announcement = $"{ballLetter.ToUpperInvariant()} {ballNumber}";
        synthesizer.Speak(announcement);
    }

    /// <summary>
    /// Releases all resources used by the <see cref="BingoAnnouncer"/> class.
    /// </summary>
    /// <remarks>
    /// This method calls <see cref="Dispose(bool)"/> with <c>true</c> to free both managed and unmanaged resources, 
    /// and then calls <see cref="GC.SuppressFinalize(object)"/> to prevent the garbage collector from calling the finalizer.
    /// </remarks>
    /// <example>
    /// <code>
    /// using (BingoAnnouncer announcer = new BingoAnnouncer())
    /// {
    ///     announcer.Announce("G", 55);
    /// }
    /// // The Dispose method is called automatically at the end of the using block.
    /// </code>
    /// </example>
    /// <seealso cref="Dispose(bool)"/>
    /// <seealso cref="GC.SuppressFinalize(object)"/>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Releases the unmanaged resources used by the <see cref="BingoAnnouncer"/> and optionally releases the managed resources.
    /// </summary>
    /// <param name="disposing">
    /// A boolean value indicating whether to release both managed and unmanaged resources (true) or only unmanaged resources (false).
    /// </param>
    /// <remarks>
    /// This method disposes of the <see cref="System.Speech.Synthesis.SpeechSynthesizer"/> if <paramref name="disposing"/> is true.
    /// It is called by the public <see cref="Dispose()"/> method and the finalizer.
    /// When <paramref name="disposing"/> is true, the method has been called directly or indirectly by user code.
    /// Managed and unmanaged resources can be disposed.
    /// When <paramref name="disposing"/> is false, the method has been called by the runtime from inside the finalizer,
    /// and you should not reference other objects. Only unmanaged resources can be disposed.
    /// </remarks>
    /// <example>
    /// <code>
    /// protected override void Dispose(bool disposing)
    /// {
    ///     if (disposing)
    ///     {
    ///         // Dispose managed resources.
    ///     }
    ///     // Dispose unmanaged resources.
    ///     base.Dispose(disposing);
    /// }
    /// </code>
    /// </example>
    /// <seealso cref="Dispose()"/>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (synthesizer != null)
            {
                synthesizer.Dispose();
            }
        }
    }
}
