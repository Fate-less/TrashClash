using UnityEngine;
public enum TrashType
{
    None,
    Organik,
    Anorganik,
    Kertas,
    Residu,
    B3
}

namespace CardHouse
{
    [CreateAssetMenu(menuName = "CardHouse/Card Definition/Trash")]
    public class CardSO : CardDefinition
    {
        public int Cost;
        public int Value;
        public int Penalty;
        public TrashType Kategori;
        public Sprite Art;
    }
}