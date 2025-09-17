static class AssemblyLine
{
    public static double SuccessRate(int speed)
    {
       double success = 0; 
       switch (speed)
       {
        case 1:
        case 2:
        case 3:
        case 4:
            success = 1;
            break;
        case 5:
        case 6:
        case 7:
        case 8:
            success = 0.9;
            break;
        case 9:
            success = 0.8;
            break;
        case 10:
            success = 0.77;
            break;
        }
        return success;
    }
    
    public static double ProductionRatePerHour(int speed)
    {
        return speed * 221 * SuccessRate(speed);
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        return (int)((speed * 221 * SuccessRate(speed)) / 60);
    }
}
