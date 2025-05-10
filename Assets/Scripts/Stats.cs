[System.Serializable]
public struct Stats
{
    public int Atk;
    public int Def;
    public int Res;
    public int Spd;
    public int Crt;
    public int Aim;
    public int Eva;

    public Stats(int atk, int def, int res, int spd, int crt, int aim, int eva)
    {
        this.Atk = atk;
        this.Def = def;
        this.Res = res;
        this.Spd = spd;
        this.Crt = crt;
        this.Aim = aim;
        this.Eva = eva;
    }

    public static Stats Sum(Stats a, Stats b)
    {
        return new Stats(
            a.Atk + b.Atk,
            a.Def + b.Def,
            a.Res + b.Res,
            a.Spd + b.Spd,
            a.Crt + b.Crt,
            a.Aim + b.Aim,
            a.Eva + b.Eva
            );

    }
    
}
