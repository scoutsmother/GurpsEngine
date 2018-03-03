using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator.Models.Stats
{
  public class StatSet
  {
    // Innate stats
    public Stat STR { get; set; }
    public Stat DEX { get; set; }
    public Stat INT { get; set; }
    public Stat HT { get; set; }
    public Stat HP { get; set; }
    public Stat PER { get; set; }
    public Stat WILL { get; set; }
    public Stat FP { get; set; }
    public Stat DR { get; set; }

    public Stat BasicSpeed { get; set; }

    public Stat Dodge { get; set; }

    public (int NumDice, int Modifier) Thrust { get; set; }

    public static int GetStatFeatureVectorLength()
    {
      return new StatSet().GetStatsAsFeatureVector().Length;
    }

    public Double[] GetStatsAsFeatureVector()
    {
      return new Double[]
      {
        STR.Value,
        DEX.Value,
        INT.Value,
        HT.Value,
        HP.Value,
        PER.Value,
        WILL.Value,
        FP.Value,
        DR.Value,
        BasicSpeed.Value,
        Dodge.Value,
        Thrust.Modifier,
        Thrust.NumDice
      };
    }

    public static StatSet operator +(StatSet s1, StatSet s2)
    {
      return new StatSet()
      {
        STR = s1.STR + s2.STR,
        DEX = s1.DEX + s2.DEX,
        INT = s1.INT + s2.INT,
        HT = s1.HT + s2.HT,
        HP = s1.HP + s2.HP,
        PER = s1.PER + s2.PER,
        WILL = s1.WILL + s2.WILL,
        FP = s1.FP + s2.FP,
        DR = s1.DR + s2.DR,
        BasicSpeed = s1.BasicSpeed + s2.BasicSpeed,
        Dodge = s1.Dodge + s2.Dodge
      };

    }

    public StatSet(StatSet s)
    {
      STR = s.STR;
      DEX = s.DEX;
      INT = s.INT;
      HT = s.HT;
      HP = s.HP;
      PER = s.PER;
      WILL = s.WILL;
      FP = s.FP;
      DR = s.DR;
      BasicSpeed = s.BasicSpeed;
      Dodge = s.Dodge;
    }

    public StatSet()
    {
      STR = new Stat(0);
      DEX = new Stat(0);
      INT = new Stat(0);
      HT = new Stat(0);
      HP = new Stat(0);
      PER = new Stat(0);
      WILL = new Stat(0);
      FP = new Stat(0);
      DR = new Stat(0);
      BasicSpeed = new Stat(0);
      Dodge = new Stat(0);
    }
  }
}
