using UnityEngine;
using MyBox;
public enum TrashType
{
    None,
    Organik,
    Anorganik,
    Kertas,
    Residu,
    B3
}

public enum ActiveCondition
{
    TrueCategory,
    FalseCategory,
    BothCategory
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
        public int Buff; //ngurangin power lawan di kategori yang sama
        public string Description; //deskripsi ability
        public TrashType Kategori;
        public Sprite Art;
        public bool affectAllyArea; //ngurangin power di semua kategori ally
        [ConditionalField(nameof(affectAllyArea))] public int affectAllyAmount; //jumlah ngurangin powernya
        [ConditionalField(nameof(affectAllyArea))] public ActiveCondition affectAllyCondition; //aktif saat kondisi apa
        public bool affectEnemyArea; //ngurangin power di semua kategori musuh
        [ConditionalField(nameof(affectEnemyArea))] public int affectEnemyAmount; //jumlah ngurangin powernya
        [ConditionalField(nameof(affectEnemyArea))] public ActiveCondition affectEnemyCondition; //aktif saat kondisi apa
    }
}