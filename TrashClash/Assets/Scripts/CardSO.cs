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
        public int Value; //power kalo bener kategori
        public int Penalty; //power kalo salah kategori
        public int None; //power kalo belom ada kategori
        public int Debuff; //ngurangin power lawan kalo bener kategori
        public TrashType Kategori;
        public Sprite Art;
    }
}