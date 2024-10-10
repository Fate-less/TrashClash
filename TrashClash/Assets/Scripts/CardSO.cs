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
        public int Cost; //energy yang dibutuhin
        public int Value; //power kalo bener kategori
        public int Penalty; //power kalo salah kategori
        public int None; //power kalo belom ada kategori
        public int Debuff; //ngurangin power lawan di kategori yang sama
        public bool affectAllyArea; //ngurangin power di semua kategori ally
        public int affectAllyAmount; //jumlah ngurangin powernya
        public bool affectEnemyArea; //ngurangin power di semua kategori musuh
        public int affectEnemyAmount; //jumlah ngurangin powernya
        public string Description; //deskripsi ability
        public TrashType Kategori;
        public Sprite Art;
    }
}