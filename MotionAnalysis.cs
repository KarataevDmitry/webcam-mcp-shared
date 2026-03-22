namespace WebcamMcp.Shared;

public static class MotionAnalysis
{
    public static string ClassifyMotion(double score)
    {
        if (score < 5)
        {
            return "still";
        }

        if (score < 15)
        {
            return "low";
        }

        if (score < 35)
        {
            return "medium";
        }

        return "high";
    }
}
