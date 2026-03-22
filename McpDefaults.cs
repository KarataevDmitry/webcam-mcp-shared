namespace WebcamMcp.Shared;

/// <summary>Общие константы для capture- и analysis-MCP (пути в workspace).</summary>
public static class McpDefaults
{
    public const string DefaultOutputSubdir = @".cascade-ide\webcam-captures";
    public const int DefaultWarmupFrames = 5;
    public const int DefaultJpegQuality = 92;
    public const int DefaultBurstDurationSec = 2;
    public const int DefaultBurstTargetFps = 24;
    public const int DefaultBurstVideoFps = 24;
    public const string DefaultScreenOutputSubdir = @".cascade-ide\screen-captures";
    public const string DefaultAudioOutputSubdir = @".cascade-ide\audio-captures";
    public const int DefaultAudioDurationSec = 10;
    public const int DefaultAudioSampleRate = 16000;
    public const int DefaultAudioChannels = 1;
    public const int DefaultAudioFrameMs = 50;
    public const double DefaultAudioSilenceDb = -45;
    public const string DefaultAvOutputSubdir = @".cascade-ide\av-captures";
    public const string DefaultPdfOutputSubdir = @".cascade-ide\pdf-captures";
    public const string EnvWhisperModelPath = "WHISPER_MODEL_PATH";
    public const string EnvTesseractPath = "TESSERACT_PATH";
}
